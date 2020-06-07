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

namespace scratch_link
{
    internal class ArduinoSimulatorSession : ArduinoSession
    {
        #region fields
        static ArduinoPortSimulator sim = null;
        #endregion
        public ArduinoSimulatorSession(IWebSocketConnection webSocket, int bufferSize = 4096, int maxMessageSize = 1048576) : base(webSocket, bufferSize, maxMessageSize)
        {
            sim = new ArduinoPortSimulator();
            sim.Start();
        }
        protected override async void GetListOfDevices()
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
            });
        }

        protected override void Write(string pin, string value)
        {
            string text = pin + (String.IsNullOrWhiteSpace(value)?"":":" + value);
            Serial.printlnFromOtherSide(text);
        }

        protected override String Read(string pin)
        {
            return Serial.readStringFromOtherSide();
        }
    }

}
