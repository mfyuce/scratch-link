using Fleck;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Management;
using System.Threading.Tasks;
using System.Linq;

namespace scratch_link
{
    internal class ArduinoSession : Session
    {
        private Dictionary<string, dynamic> listOfDevices =
                                new Dictionary<string, dynamic>();
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
