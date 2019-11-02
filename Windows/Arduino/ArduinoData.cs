using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino
{
    public enum ArduinoPin
    {
        PIN_0=0,
        PIN_1,
        PIN_2,
        PIN_3,
        PIN_4,
        PIN_5,
        PIN_6,
        PIN_7,
        PIN_8,
        PIN_9,
        PIN_10,
        PIN_11,
        PIN_12,
        PIN_13
    }
    public enum ArduinoPinMode
    {
        INPUT=0,
        OUTPUT
    }
    public class ArduinoData
    {
        internal Dictionary<ArduinoPin, bool> PinState { get; set; } = new Dictionary<ArduinoPin, bool>();
        internal Dictionary<ArduinoPin, ArduinoPinMode> PinMode { get; set; } = new Dictionary<ArduinoPin, ArduinoPinMode>();
        private static ArduinoData _default = null;
        public static ArduinoData Default {
            get {
                if (_default == null)
                {
                    _default = CreateEmtptyArduinoState();
                }
                return _default;
            }
        }

        public static ArduinoData CreateEmtptyArduinoState()
        {
            var _default = new ArduinoData();
            System.Collections.IList list = Enum.GetValues(typeof(ArduinoPin));
            for (int i = 0; i < list.Count; i++)
            {
                ArduinoPin pin = (ArduinoPin)list[i];
                _default.PinMode.Add(pin, ArduinoPinMode.OUTPUT);
                _default.PinState.Add(pin, false);
            }
            return _default;
        }

        public ArduinoData()
        {
        }
    }
}
