using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arduino.Simulator
{
    public static class Serial
    {
        private const int WAIT_TIME = 100;
        static List<String> lstInput = new List<string>();
        static List<String> lstOutput = new List<string>();
        static object objLock = new object();
        internal static void begin(int v)
        {
            
        }

        public static string readString()
        {
            return _readString(lstInput);
        }

        public static string readStringFromOtherSide()
        {
            return _readString(lstOutput);
        }
        public static void printlnFromOtherSide(String data)
        {
            lstInput.Add(data);
        }
        public static string _readString(List<String> lst)
        {
            string ret;
            int totalTimeWaited = 0;
            lock (objLock)
            {
                do
                {
                    ret = lst.LastOrDefault();
                    if (ret == null)
                    {
                        Thread.Sleep(WAIT_TIME);
                        totalTimeWaited += WAIT_TIME;
                    }
                } while (ret == null && totalTimeWaited < 1000);
                if (ret != null)
                {
                    lst.RemoveAt(lst.Count - 1);
                }
            }
            return ret;
        }
        public static void println(string data)
        {
            lstOutput.Add(data);
        }
        public static void println(int data)
        {
            lstOutput.Add(data + "");
        }
    }
}
