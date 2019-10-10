using Fleck;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Management;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;

namespace scratch_link
{
    internal class ArduinoSession : Session
    {
        private Dictionary<string, dynamic> listOfDevices =
                                new Dictionary<string, dynamic>();
        private Dictionary<string, SerialPort> serialPorts =
                                new Dictionary<string, SerialPort>();
        public ArduinoSession(IWebSocketConnection webSocket, int bufferSize = 4096, int maxMessageSize = 1048576) : base(webSocket, bufferSize, maxMessageSize)
        {
        }
        private async void GetListOfDevices()
        {
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
                        var peripheralData = new JObject
                        {
                            new JProperty("name", new JValue(captionObj)),
                            new JProperty("rssi", null),
                            new JProperty("peripheralId", new JValue(deviceID))
                        };
                        SendRemoteRequest("didDiscoverPeripheral", peripheralData);
                    }
                }
            });
        }
        private void Write(string pin, string value)
        {
            SerialPort _serialPort = null;
            var port = listOfDevices.Keys.First();
            if (!serialPorts.ContainsKey(port))
            {
                _serialPort = serialPorts[port] = new SerialPort();
                _serialPort.PortName = port;
                _serialPort.BaudRate = 115200;
                _serialPort.WriteBufferSize = 2;
                _serialPort.WriteTimeout = 2000;
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
                        Thread.Sleep(1000);
                    }
                    catch
                    {
                        _serialPort.Close();
                        _serialPort.Open();
                    }
                }
                _serialPort.Write(value);
                Thread.Sleep(2000);
                _serialPort.BaseStream.Flush();
                Thread.Sleep(2000);
                Console.WriteLine(value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        string codeToCompile = @"
const int led = {0};
 int state=0;  
void setup()   
{{   
    Serial.begin(115200); //Starts the serial connection with 115200 Buad Rate   
    pinMode(led, OUTPUT); //Sets led pin as an output
}}

void loop()
{{
    String data = Serial.readString();//Read the serial buffer as a string

    if (data==""0"")//checks if it is ""ON""
    {{
        digitalWrite(led, HIGH); // Sets the led ON   
        state = 0;// Sets the state value to 0
    }}
    else if (data==""1"")//checks if it is ""OFF""
    {{
        digitalWrite(led, LOW); //Sets the led OFF   
        state = 0;// Sets the state value to 1
    }}
    else if (data.indexOf(""STATE"") != -1)//checks if it is ""STATE""
    {{
        Serial.write(""state="");//Sends the state
        Serial.println(state);
    }}
}}
";

        protected override async Task DidReceiveCall(string method, JObject parameters, Func<JToken, JsonRpcException, Task> completion)
        {
            switch (method)
            {
                case "discover": 
                    GetListOfDevices();
                    await completion(null, null);
                    break;
                case "connect":
                    await completion(null, null);
                    break;
                case "write":
                    var msg = parameters["message"];
                    Write(msg["pin"].ToString(), msg["value"].ToString());
                    await completion(null, null);
                    break;
                case "read":
                    await completion(new JValue("test"), null);
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

    internal class Win32_PnPEntity
    {
        UInt16 Availability;
        string Caption;
        string ClassGuid;
        string[] CompatibleID;
        UInt32 ConfigManagerErrorCode;
        bool ConfigManagerUserConfig;
        string CreationClassName;
        string Description;
        string DeviceID;
        bool ErrorCleared;
        string ErrorDescription;
        string[] HardwareID;
        DateTime InstallDate;
        UInt32 LastErrorCode;
        string Manufacturer;
        string Name;
        string PNPClass;
        string PNPDeviceID;
        UInt16[] PowerManagementCapabilities;
        bool PowerManagementSupported;
        bool Present;
        string Service;
        string Status;
        UInt16 StatusInfo;
        string SystemCreationClassName;
        string SystemName;
    }
}
