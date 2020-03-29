using CSharp_Arduino_CLI;
using Newtonsoft.Json.Linq;
using scratch_lang;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Arduino
{
    public class ArduinoManager
    {
        public static string ARDUINO_CLI_PATH = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + Path.DirectorySeparatorChar + "tools"+ Path.DirectorySeparatorChar  + "arduino-cli" + Path.DirectorySeparatorChar;
        public static string DEFAULT_ARDUINO_FQBN = "arduino:avr:uno";
        public static string SKETCH_FOLDER = ARDUINO_CLI_PATH + "sketches" + Path.DirectorySeparatorChar;
        public static string DEV_MODE_SKETCH_NAME = "dev_mode";
        public static string DEV_MODE_SKETCH_FOLDER = SKETCH_FOLDER + DEV_MODE_SKETCH_NAME + Path.DirectorySeparatorChar;
         
        public static string ToValidFileName(string fileName) => Path.GetInvalidFileNameChars().Aggregate(fileName, (f, c) => f.Replace(c, '_'));

        public static string UploadDevModeSketch(string connectedPort)
        { 
            ControllerTemplate page = new ControllerTemplate(ArduinoData.Default);
            return UploadSketch(connectedPort, DEV_MODE_SKETCH_NAME, page.TransformText());
        }
        public static string UploadRunModeSketch(string connectedPort, string startingBlockName, JEnumerable<JToken> blockList)
        {
            var tree = ASTree.Traverse(blockList, startingBlockName);
            RunModeControllerTemplate page = new RunModeControllerTemplate(tree);
            string sketchName = ToValidFileName(startingBlockName);

            return UploadSketch(  connectedPort,   sketchName, page.TransformText());
        }
        public static string UploadSketch(string connectedPort,string sketchName, string code)
        {
            ArduinoCLI_API.SetArduinoCliPath(ARDUINO_CLI_PATH);
            String sketchFolder = SKETCH_FOLDER + sketchName + Path.DirectorySeparatorChar;
            if (!Directory.Exists(sketchFolder))
            {
                Directory.CreateDirectory(sketchFolder);
            }
            String sketchFile = sketchFolder + sketchName + ".ino";
            File.WriteAllText(sketchFile, code);
            var ret = ArduinoCLI_API.CompileSketch(DEFAULT_ARDUINO_FQBN, sketchFile, null);
            ret += "\r\n\r\n" + ArduinoCLI_API.UploadSketch(connectedPort, DEFAULT_ARDUINO_FQBN, sketchFolder, null);
            return ret;
        }
    }
}
