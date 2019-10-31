using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino
{
    public class ArduinoManager
    {
        public static String GetDevelopmentModeSketch()
        {
            ControllerTemplate page = new ControllerTemplate(new ArduinoData());
            return page.TransformText();
        }
    }
}
