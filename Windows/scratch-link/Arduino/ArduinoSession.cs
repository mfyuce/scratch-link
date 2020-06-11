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
using scratch_lang;
using System.Reflection;
using CSharp_Arduino_CLI;

namespace scratch_link
{
    internal class ArduinoSession : Session
    {
        #region constants
        #endregion
        #region fields
        private string connectedPort = null;
        protected Dictionary<string, string> listOfDeviceIdsAndPorts = new Dictionary<string, string>();
        private Dictionary<string, dynamic> listOfDevices = new Dictionary<string, dynamic>();
        private Dictionary<string, SerialPort> serialPorts = new Dictionary<string, SerialPort>();
        #endregion
        public ArduinoSession(IWebSocketConnection webSocket, int bufferSize = 4096, int maxMessageSize = 1048576 ) : base(webSocket, bufferSize, maxMessageSize)
        { 
        }
        protected virtual async void GetListOfDevices()
        {
            listOfDeviceIdsAndPorts.Clear();
            await Task.Run(() =>
            { 
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
                        //Console.WriteLine(obj["Availability'"]);
                        Console.WriteLine(obj["Caption"]);
                        Console.WriteLine(obj["ClassGuid"]);
                        Console.WriteLine(obj["CompatibleID"]);
                        Console.WriteLine(obj["ConfigManagerErrorCode"]);
                        Console.WriteLine(obj["ConfigManagerUserConfig"]);
                        Console.WriteLine(obj["CreationClassName"]);
                        Console.WriteLine(obj["Description"]);
                        String deviceID = (String)obj["DeviceID"];
                        Console.WriteLine(deviceID);
                        Console.WriteLine(obj["ErrorCleared"]);
                        Console.WriteLine(obj["ErrorDescription"]);
                        Console.WriteLine(obj["HardwareID"]);
                        Console.WriteLine(obj["InstallDate"]);
                        Console.WriteLine(obj["LastErrorCode"]);
                        Console.WriteLine(obj["Manufacturer"]);
                        Console.WriteLine(obj["Name"]);
                        Console.WriteLine(obj["PNPClass"]);
                        Console.WriteLine(obj["PNPDeviceID"]);
                        //uint16 PowerManagementCapabilities[]"]);
                        //boolean PowerManagementSupported"]);
                        Console.WriteLine(obj["Present"]);
                        Console.WriteLine(obj["Service"]);
                        Console.WriteLine(obj["Status"]);
                        Console.WriteLine(obj["StatusInfo"]);
                        Console.WriteLine(obj["SystemCreationClassName"]);
                        Console.WriteLine(obj["SystemName"]);
                        object captionObj = obj["Caption"]; //This will get you the friendly name.
                        this.listOfDevices.Add(portName, obj);
                        var peripheralData = new JObject
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
            string ret = null;
            if (!serialPorts.ContainsKey(connectedPort))
            {
                _serialPort = serialPorts[connectedPort] = new SerialPort();
                _serialPort.PortName = connectedPort;
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
                _serialPort = serialPorts[connectedPort];
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
        protected virtual void Write(string pin, string value)
        {
            string text = pin + (String.IsNullOrWhiteSpace(value) ? "" : ":" + value);

            PortOp((port) =>
            {
                port.Write(text);
                return "";
            });
        }

        protected virtual String Read(string pin)
        {
            return PortOp((port) =>
            {
                byte[] toRead = new Byte[100];
                int numRead = port.Read(toRead, 0, 100);
                if (numRead > 0)
                {

                    return System.Text.Encoding.ASCII.GetString(toRead).TrimEnd("\0\r\n".ToCharArray());
                }
                return null;
            });
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
                            var ret = ArduinoManager.UploadDevModeSketch(connectedPort);
                            await completion(new JValue(ret), null);
                        }
                        else
                        {
                            if (command == "upload_run_mode")
                            {
                                var data = msg["data"];
                                JEnumerable<JToken> blockList = data["blocks"].Children();
                                var startingBlockName = (string)data["startingBlock"];
                                var ret = ArduinoManager.UploadRunModeSketch(connectedPort, startingBlockName, blockList);
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
