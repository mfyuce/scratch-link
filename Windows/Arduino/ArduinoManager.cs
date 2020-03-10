using scratch_lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino
{
    public class ArduinoManager
    {
        public static String GetDevelopmentModeSketch(ArduinoData data)
        {
            if(data == null){
                data = new ArduinoData();
            }
            ControllerTemplate page = new ControllerTemplate(data);
            return page.TransformText();
        }
        public static String GetUploadModeSketch(ASTree tree)
        {
            RunModeControllerTemplate page = new RunModeControllerTemplate(tree);
            return page.TransformText();
        }
    }
}
