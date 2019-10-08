using Fleck;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Rfcomm;
using Windows.Devices.Enumeration;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace scratch_link
{
    internal class ArduinoSession : Session
    {
        public ArduinoSession(IWebSocketConnection webSocket, int bufferSize = 4096, int maxMessageSize = 1048576) : base(webSocket, bufferSize, maxMessageSize)
        {
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

        protected override async Task DidReceiveCall(string method, JObject parameters, Func<JToken, JsonRpcException, Task> completion)
        {
            switch (method)
            {
                case "discover":
                    var peripheralData = new JObject
                    {
                        new JProperty("name", new JValue("deneme")),
                        new JProperty("rssi", new JValue("127")),
                        new JProperty("peripheralId", new JValue("123"))
                    };
                    SendRemoteRequest("didDiscoverPeripheral", peripheralData);
                    //await completion("didDiscoverPeripheral", peripheralData);
                    break;
                case "connect":
                    await completion(null, null);
                    break;
                case "write":
                    await completion(null, null);
                    break;
                case "read":
                    await completion("test", null);
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
    }
}
