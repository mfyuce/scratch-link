using Arduino.Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arduino
{
    public class ArduinoPortSimulator
    {
        int state0 = 0;
        const int pin0 = 0;
        int state1 = 0;
        const int pin1 = 1;
        int state2 = 0;
        const int pin2 = 2;
        int state3 = 0;
        const int pin3 = 3;
        int state4 = 0;
        const int pin4 = 4;
        int state5 = 0;
        const int pin5 = 5;
        int state6 = 0;
        const int pin6 = 6;
        int state7 = 0;
        const int pin7 = 7;
        int state8 = 0;
        const int pin8 = 8;
        int state9 = 0;
        const int pin9 = 9;
        int state10 = 0;
        const int pin10 = 10;
        int state11 = 0;
        const int pin11 = 11;
        int state12 = 0;
        const int pin12 = 12;
        int state13 = 0;
#pragma warning disable IDE0044 // Add readonly modifier
        private int OUTPUT = 0;
#pragma warning restore IDE0044 // Add readonly modifier
#pragma warning disable IDE0044 // Add readonly modifier
        private int INPUT = 1;
#pragma warning restore IDE0044 // Add readonly modifier
        const int pin13 = 13;

        public bool LOW = false;
        public bool HIGH = true;
        readonly ArduinoData state = ArduinoData.CreateEmtptyArduinoState();
#pragma warning disable IDE1006 // Naming Styles
        void setup()
#pragma warning restore IDE1006 // Naming Styles
        {
            Serial.begin(115200); //Starts the serial connection with 115200 Buad Rate
            pinMode(pin0, OUTPUT);
            pinMode(pin1, OUTPUT);
            pinMode(pin2, OUTPUT);
            pinMode(pin3, OUTPUT);
            pinMode(pin4, OUTPUT);
            pinMode(pin5, OUTPUT);
            pinMode(pin6, OUTPUT);
            pinMode(pin7, OUTPUT);
            pinMode(pin8, OUTPUT);
            pinMode(pin9, OUTPUT);
            pinMode(pin10, OUTPUT);
            pinMode(pin11, OUTPUT);
            pinMode(pin12, OUTPUT);
            pinMode(pin13, OUTPUT);

        }

#pragma warning disable IDE1006 // Naming Styles
        private void pinMode(int pin0, int mod)
#pragma warning restore IDE1006 // Naming Styles
        {
            state.PinMode[(ArduinoPin)pin0] = (ArduinoPinMode)mod;
        }
        public void Start()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    loop();
                    Thread.Sleep(100);
                }
            });
        }
#pragma warning disable IDE1006 // Naming Styles
        void loop()
#pragma warning restore IDE1006 // Naming Styles
        {
           
            String data = Serial.readString();//Read the serial buffer as a string
            if (data == "0:0")//set pin "OFF"
            {
                digitalWrite(pin0, LOW);
                state0 = 0;
            }
            else if (data == "0:1")////set pin "ON"
            {
                digitalWrite(pin0, HIGH);
                state0 = 1;
            }
            else if (data == "0")
            {
                Serial.println(state0 );
            }
            if (data == "1:0")//set pin "OFF"
            {
                digitalWrite(pin1, LOW);
                state1 = 0;
            }
            else if (data == "1:1")////set pin "ON"
            {
                digitalWrite(pin1, HIGH);
                state1 = 1;
            }
            else if (data == "1")
            {
                Serial.println(state1);
            }
            if (data == "2:0")//set pin "OFF"
            {
                digitalWrite(pin2, LOW);
                state2 = 0;
            }
            else if (data == "2:1")////set pin "ON"
            {
                digitalWrite(pin2, HIGH);
                state2 = 1;
            }
            else if (data == "2")
            {
                Serial.println(state2);
            }
            if (data == "3:0")//set pin "OFF"
            {
                digitalWrite(pin3, LOW);
                state3 = 0;
            }
            else if (data == "3:1")////set pin "ON"
            {
                digitalWrite(pin3, HIGH);
                state3 = 1;
            }
            else if (data == "3")
            {
                Serial.println(state3);
            }
            if (data == "4:0")//set pin "OFF"
            {
                digitalWrite(pin4, LOW);
                state4 = 0;
            }
            else if (data == "4:1")////set pin "ON"
            {
                digitalWrite(pin4, HIGH);
                state4 = 1;
            }
            else if (data == "4")
            {
                Serial.println(state4);
            }
            if (data == "5:0")//set pin "OFF"
            {
                digitalWrite(pin5, LOW);
                state5 = 0;
            }
            else if (data == "5:1")////set pin "ON"
            {
                digitalWrite(pin5, HIGH);
                state5 = 1;
            }
            else if (data == "5")
            {
                Serial.println(state5);
            }
            if (data == "6:0")//set pin "OFF"
            {
                digitalWrite(pin6, LOW);
                state6 = 0;
            }
            else if (data == "6:1")////set pin "ON"
            {
                digitalWrite(pin6, HIGH);
                state6 = 1;
            }
            else if (data == "6")
            {
                Serial.println(state6);
            }
            if (data == "7:0")//set pin "OFF"
            {
                digitalWrite(pin7, LOW);
                state7 = 0;
            }
            else if (data == "7:1")////set pin "ON"
            {
                digitalWrite(pin7, HIGH);
                state7 = 1;
            }
            else if (data == "7")
            {
                Serial.println(state7);
            }
            if (data == "8:0")//set pin "OFF"
            {
                digitalWrite(pin8, LOW);
                state8 = 0;
            }
            else if (data == "8:1")////set pin "ON"
            {
                digitalWrite(pin8, HIGH);
                state8 = 1;
            }
            else if (data == "8")
            {
                Serial.println(state8);
            }
            if (data == "9:0")//set pin "OFF"
            {
                digitalWrite(pin9, LOW);
                state9 = 0;
            }
            else if (data == "9:1")////set pin "ON"
            {
                digitalWrite(pin9, HIGH);
                state9 = 1;
            }
            else if (data == "9")
            {
                Serial.println(state9);
            }
            if (data == "10:0")//set pin "OFF"
            {
                digitalWrite(pin10, LOW);
                state10 = 0;
            }
            else if (data == "10:1")////set pin "ON"
            {
                digitalWrite(pin10, HIGH);
                state10 = 1;
            }
            else if (data == "10")
            {
                Serial.println(state10);
            }
            if (data == "11:0")//set pin "OFF"
            {
                digitalWrite(pin11, LOW);
                state11 = 0;
            }
            else if (data == "11:1")////set pin "ON"
            {
                digitalWrite(pin11, HIGH);
                state11 = 1;
            }
            else if (data == "11")
            {
                Serial.println(state11);
            }
            if (data == "12:0")//set pin "OFF"
            {
                digitalWrite(pin12, LOW);
                state12 = 0;
            }
            else if (data == "12:1")////set pin "ON"
            {
                digitalWrite(pin12, HIGH);
                state12 = 1;
            }
            else if (data == "12")
            {
                Serial.println(state12);
            }
            if (data == "13:0")//set pin "OFF"
            {
                digitalWrite(pin13, LOW);
                state13 = 0;
            }
            else if (data == "13:1")////set pin "ON"
            {
                digitalWrite(pin13, HIGH);
                state13 = 1;
            }
            else if (data == "13")
            {
                Serial.println(state13);
            }
        }

#pragma warning disable IDE1006 // Naming Styles
        private void digitalWrite(int pin0, bool _state)
#pragma warning restore IDE1006 // Naming Styles
        {
            state.PinState[(ArduinoPin)pin0] = _state;
            Console.WriteLine(pin0 + ":" + _state);
        }
    }
}
