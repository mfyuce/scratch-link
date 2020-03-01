using Kbg.NppPluginNET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace NppArduino.Domain
{
    public static class ArduinoCLI_API
    {
        public static string ARDUINO_CLI_PATH= System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/tools/arduino-cli/";

        public static string[] GetPorts()
        {
            return SerialPort.GetPortNames();
        }

        public static string CompileSketch(string boardFqbn, string skechtFolder, CompileOption[] options = null)
        {
            UpdateIndex();
            var cliCommand = $"compile --fqbn {boardFqbn}{(options == null ? "" : $":{string.Join<CompileOption>(",", options)}")} {skechtFolder}";
            return RunCliCommand(cliCommand);
        }
        public static string UpdateIndex()
        {
            var cliCommand = $"core update-index";
            return RunCliCommand(cliCommand);
        }

        public static string UploadSketch(string port, string boardFqbn, string skechtFolder, CompileOption[] options = null)
        { 
            string cliCommand = $"upload -p {port} --fqbn {boardFqbn}{(options == null ? "" : $":{string.Join<CompileOption>(",", options)}")} {skechtFolder}";
            return RunCliCommand(cliCommand);
        }

        public static Board[] GetInstalledBoards()
        {

            string cliCommand = "board listall";
            string json = RunCliCommand(cliCommand);
            var boards = ParseBoards(json);

            return boards;
        }

        public static string GetConnectedBoards()
        {
            string cliCommand = "board list";
            string json = RunCliCommand(cliCommand);

            return json;
        }

        public static BoardDetail GetBoardDetails(string boardFqbn)
        {
            string cliCommand = $"board details {boardFqbn}";
            var json = RunCliCommand(cliCommand);

            var boardDetails = ParseDetails(json);
            return boardDetails;
        }


        internal static Task<string> RunCliCommandAsync(string arguments)
        {
            var tcs = new TaskCompletionSource<string>();

            var process = new System.Diagnostics.Process
            {
                StartInfo = {
                    FileName = ARDUINO_CLI_PATH + "arduino-cli",
                    Arguments = arguments + " --format json --config-file " + ARDUINO_CLI_PATH + "arduino-cli.yaml",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    WorkingDirectory = ARDUINO_CLI_PATH
                 },
                EnableRaisingEvents = true
            };

            var output = "";
            var errors = "";
            process.OutputDataReceived += (s, e) => { output += e.Data; };
            process.ErrorDataReceived += (s, e) => { errors += e.Data; };

            process.Exited += (s, e) =>
            {
                tcs.SetResult(output);
                process.Dispose();
            };

            bool started = process.Start();
            if (!started)
            {
                throw new InvalidOperationException("Could not start process: " + process);
            }

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            Debug.WriteLine("run");
            return tcs.Task;
        }

        internal static string RunCliCommand(string arguments)
        {

            var process = new System.Diagnostics.Process
            {
                StartInfo = {
                    FileName = ARDUINO_CLI_PATH + "arduino-cli",
                    Arguments = arguments + " --format json --config-file " + ARDUINO_CLI_PATH + "arduino-cli.yaml",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    WorkingDirectory = ARDUINO_CLI_PATH
                 },
            };

            process.Start();
            string strOutput = process.StandardOutput.ReadToEnd() + "\r\n\r\n" + process.StandardError.ReadToEnd();
            process.WaitForExit();

            return strOutput;
        }

        private static Board[] ParseBoards(string json)
        {
            var rst = new List<Board>();

            var newBoard = new Board();
            string[] lines = json.Replace("\"", "").Split('\n');
            foreach (string line in lines)
            {
                var cleanLine = line.Trim();
                if (cleanLine.StartsWith("name: "))
                {
                    newBoard.Name = cleanLine.Replace("name: ", "").Replace(",", "");
                }
                else if (cleanLine.StartsWith("FQBN: "))
                {
                    newBoard.Fqbn = cleanLine.Replace("FQBN: ", "").Replace(",", "");
                    rst.Add(newBoard);
                    newBoard = new Board();
                }
            }

            return rst.ToArray();
        }

        private static BoardDetail ParseDetails(string json)
        {
            var boardDetail = new BoardDetail();

            string[] lines = json.Replace("\"", "").Split('\n');

            BoardOption boardOption = null;
            BoardOptionValue boardOptionValue = null;
            foreach (string line in lines)
            {
                var cleanLine = line.Trim();

                if (cleanLine.StartsWith("option: "))
                {
                    boardOption = new BoardOption();
                    boardOption.Option = cleanLine.Replace("option: ", "").Replace(",", "").Replace(",", "");
                }
                else if (cleanLine.StartsWith("option_label: "))
                {
                    if (boardOption != null) boardOption.Option_Label = cleanLine.Replace("option_label: ", "").Replace(",", "");
                }
                else if (cleanLine.StartsWith("value: "))
                {
                    boardOptionValue = new BoardOptionValue();
                    boardOptionValue.Value = cleanLine.Replace("value: ", "").Replace(",", "").Replace(",", "");
                }
                else if (cleanLine.StartsWith("value_label: "))
                {
                    if (boardOptionValue != null) boardOptionValue.Value_Label = cleanLine.Replace("value_label: ", "").Replace(",", "");
                }
                else if (cleanLine.StartsWith("selected: "))
                {
                    if (boardOptionValue != null) boardOptionValue.Selected = true;
                }
                else if (cleanLine.StartsWith("}"))
                {
                    if (boardOptionValue != null)
                    {
                        boardOption?.Values.Add(boardOptionValue);
                        boardOptionValue = null;
                    }
                    else if (boardOption != null)
                    {
                        boardDetail.Options.Add(boardOption);
                        boardOption = null;
                    }
                }
            }

            return boardDetail;
        }
    }
}