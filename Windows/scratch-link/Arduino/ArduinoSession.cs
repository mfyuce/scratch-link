using Fleck;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Management;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using Arduino;
using Arduino.Simulator;
using NppArduino.Domain;

namespace scratch_link
{
    internal class ArduinoSession : Session
    {
        public static string DEFAULT_ARDUINO_FQBN = "arduino:avr:uno";
        public static string SKETCH_FOLDER =ArduinoCLI_API.ARDUINO_CLI_PATH + "sketches/";
        public static string DEV_MODE_SKETCH_FOLDER = SKETCH_FOLDER + "dev_mode/";
        bool connectedToSimulator = false;
        string connectedPort = null;
        private Dictionary<string, string> listOfDeviceIdsAndPorts = new Dictionary<string, string>();
        static ArduinoSession()
        {
            sim = new ArduinoPortSimulator();
            sim.Start();
        }
        static ArduinoPortSimulator sim = null;
        private Dictionary<string, dynamic> listOfDevices =
                                new Dictionary<string, dynamic>();
        private Dictionary<string, SerialPort> serialPorts =
                                new Dictionary<string, SerialPort>();

        public ArduinoSession(IWebSocketConnection webSocket, int bufferSize = 4096, int maxMessageSize = 1048576) : base(webSocket, bufferSize, maxMessageSize)
        {
        }
        private async void GetListOfDevices()
        {
            listOfDeviceIdsAndPorts.Clear();
            await Task.Run(() =>
            {
                var peripheralData = new JObject
                        {
                            new JProperty("name", new JValue("Pinoo Simulator")),
                            new JProperty("rssi", null),
                            new JProperty("peripheralId", new JValue("0"))
                        };
                listOfDeviceIdsAndPorts["0"] = "Pinoo Simulator";
                SendRemoteRequest("didDiscoverPeripheral", peripheralData);

                string[] portNames = SerialPort.GetPortNames();// Get real serial ports
                foreach (string portName in portNames)
                {

                    List<string> otherSerial = new List<string>();
                    List<ManagementObject> listObj = new List<ManagementObject>();//using System.Management;
                    try
                    {
                        // get only devices that are working properly."
                        // TODO: osquery?
                        string query = "SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0 AND NAME LIKE '%(" + portName + "%'";// get only devices that are working properly."
                        ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                        listObj = searcher.Get().Cast<ManagementObject>().ToList();
                        searcher.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        otherSerial = new List<string>(); // clear the list because there are errors
                                                          // addcode here to handle the error.....
                    }
                    foreach (ManagementObject obj in listObj)
                    {
                        //System.Console.WriteLine(obj["Availability'"]);
                        System.Console.WriteLine(obj["Caption"]);
                        System.Console.WriteLine(obj["ClassGuid"]);
                        System.Console.WriteLine(obj["CompatibleID"]);
                        System.Console.WriteLine(obj["ConfigManagerErrorCode"]);
                        System.Console.WriteLine(obj["ConfigManagerUserConfig"]);
                        System.Console.WriteLine(obj["CreationClassName"]);
                        System.Console.WriteLine(obj["Description"]);
                        String deviceID = (String)obj["DeviceID"];
                        System.Console.WriteLine(deviceID);
                        System.Console.WriteLine(obj["ErrorCleared"]);
                        System.Console.WriteLine(obj["ErrorDescription"]);
                        System.Console.WriteLine(obj["HardwareID"]);
                        System.Console.WriteLine(obj["InstallDate"]);
                        System.Console.WriteLine(obj["LastErrorCode"]);
                        System.Console.WriteLine(obj["Manufacturer"]);
                        System.Console.WriteLine(obj["Name"]);
                        System.Console.WriteLine(obj["PNPClass"]);
                        System.Console.WriteLine(obj["PNPDeviceID"]);
                        //uint16 PowerManagementCapabilities[]"]);
                        //boolean PowerManagementSupported"]);
                        System.Console.WriteLine(obj["Present"]);
                        System.Console.WriteLine(obj["Service"]);
                        System.Console.WriteLine(obj["Status"]);
                        System.Console.WriteLine(obj["StatusInfo"]);
                        System.Console.WriteLine(obj["SystemCreationClassName"]);
                        System.Console.WriteLine(obj["SystemName"]);
                        object captionObj = obj["Caption"]; //This will get you the friendly name.
                        this.listOfDevices.Add(portName, obj);
                        peripheralData = new JObject
                        {
                            new JProperty("name", new JValue(captionObj)),
                            new JProperty("rssi", null),
                            new JProperty("peripheralId", new JValue(deviceID))
                        };
                        listOfDeviceIdsAndPorts[deviceID] = portName;
                        SendRemoteRequest("didDiscoverPeripheral", peripheralData);
                    }
                }
            });
        }

        private String PortOp(Func<SerialPort, String> cmd)
        {
            SerialPort _serialPort = null;
            var port = listOfDevices.Keys.First();
            string ret = null;
            if (!serialPorts.ContainsKey(port))
            {
                _serialPort = serialPorts[port] = new SerialPort();
                _serialPort.PortName = port;
                _serialPort.BaudRate = 115200;
                _serialPort.WriteBufferSize = 2000;
                _serialPort.WriteTimeout = 2000;
                _serialPort.ReadTimeout = 2000;
                _serialPort.Handshake = Handshake.None;
                _serialPort.DtrEnable = true;
                _serialPort.RtsEnable = true;
                _serialPort.Open();
            }
            else
            {
                _serialPort = serialPorts[port];
            }
            try
            {
                if (!_serialPort.IsOpen)
                {
                    try
                    {
                        _serialPort.Open();
                        Thread.Sleep(100);
                    }
                    catch
                    {
                        _serialPort.Close();
                        _serialPort.Open();
                    }
                }

                ret = cmd(_serialPort);
                Thread.Sleep(100);

                _serialPort.BaseStream.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ret;
        }
        private void Write(string pin, string value)
        {
            string text = pin + (String.IsNullOrWhiteSpace(value)?"":":" + value);
            if (connectedToSimulator)
            {
                Serial.printlnFromOtherSide(text);
            }
            else
            {
                PortOp((port) =>
                {
                    port.Write(text);
                    return "";
                });
            }
        }

        private String Read(string pin)
        {
            if (connectedToSimulator)
            {
                return Serial.readStringFromOtherSide();
            }
            else
            {
                return PortOp((port) =>
                {
                    byte[] toRead = new Byte[100];
                    int numRead =  port.Read(toRead,0,100);
                    if (numRead > 0)
                    {

                        return System.Text.Encoding.ASCII.GetString(toRead).TrimEnd("\0\r\n".ToCharArray());
                    }
                    return null;
                });
            }
        }

        
        protected override async Task DidReceiveCall(string method, JObject parameters, Func<JToken, JsonRpcException, Task> completion)
        {
            parameters.TryGetValue("message", out JToken msg);

            switch (method)
            {
                case "discover": 
                    GetListOfDevices();
                    await completion(null, null);
                    break;
                case "connect":
                    //connectedToSimulator = true;
                    connectedPort = listOfDeviceIdsAndPorts[parameters["peripheralId"].ToString()];
                    await completion(null, null);
                    break;
                case "write":
                    JToken value = msg["value"];
                    JToken jcommand = msg["command"];

                    if (jcommand != null)
                    {
                        String command = jcommand.ToString();
                        if (command == "upload_dev_mode")
                        {
                            //var data = msg["data"];
                            //var blockList = data["blocks"].Children();
                            //var startingBlockName = (string)data["startingBlock"];
                            //dynamic startingBlock = findBlock(blockList, startingBlockName);

                            var ret = ArduinoCLI_API.CompileSketch(DEFAULT_ARDUINO_FQBN, DEV_MODE_SKETCH_FOLDER, null);
                            ret += "\r\n\r\n" + ArduinoCLI_API.UploadSketch(connectedPort, DEFAULT_ARDUINO_FQBN, DEV_MODE_SKETCH_FOLDER, null);
                            await completion(new JValue(ret), null);
                        }
                        else
                        {
                            Write(msg["pin"].ToString(), value?.ToString());
                            if (!String.IsNullOrWhiteSpace(command))
                            {
                                if (command == "digital_read")
                                {
                                    await completion(new JValue(Read(msg["pin"].ToString())), null);
                                }
                                else
                                {
                                    if (command == "set_pin_mode")
                                    {
                                        await completion(new JValue(Read(msg["pin"].ToString())), null);
                                    }
                                    else
                                    {
                                        await completion(null, null);
                                    }
                                }
                            }
                            else
                            {
                                await completion(null, null);
                            }
                        }
                    }
                    else
                    {
                        await completion(null, null);
                    }
                    break;
                case "read":
                    await completion(new JValue(Read(msg["pin"].ToString())), null);
                    break;
                case "startNotifications":
                    await completion(null, null);
                    break;
                case "stopNotifications":
                    await completion(null, null);
                    break;
                case "upload":
                    await completion(null, null);
                    break;
                case "compile":
                    await completion(null, null);
                    break;
                case "getServices":
                    await completion(JToken.FromObject(null), null);
                    break;
                default:
                    // unrecognized method: pass to base class
                    await base.DidReceiveCall(method, parameters, completion);
                    break;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override JObject GetVersion()
        {
            return base.GetVersion();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
    
}
