using CODE.Framework.Wpf.Controls;
using CODE.Framework.Wpf.Mvvm;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using Microsoft.Build.Framework;
using Microsoft.Build.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace VeiderSoft.AgileTools.Main.Models.Home
{
    public class BuildViewModel : ViewModel
    {
        public ViewAction BuildCommand { get; private set; }
        public ViewAction DropedElementDetectedCommand { get; private set; }

        public BuildViewModel()
        {
            //this.BuildCommand = new ViewAction("Build Solution", execute: (a, o) => { Build(); }, canExecute: (a, o) => { return true; }, brushResourceKey: "CODE.Framework-Icon-Collapsed");
            this.DropedElementDetectedCommand = new ViewAction(execute: (a, o) => { DropedElementDetected(o); });

            //Actions.Add(BuildCommand);
            Actions.Add(new CloseCurrentViewAction(this, beginGroup: true));
        }

        private void DropedElementDetected(object o)
        {
            var isCorrect = true;
            var ecp = o as EventCommandParameters;
            var e = ecp.EventArgs as DragEventArgs;
            FileInfo info = null;
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true) == true)
            {
                string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop, true);
                foreach (string filename in filenames)
                {
                    if (File.Exists(filename) == false)
                    {
                        isCorrect = false;
                        break;
                    }
                    info = new FileInfo(filename);
                    if (info.Extension != ".sln")
                    {
                        isCorrect = false;
                        break;
                    }
                }

                if (isCorrect == true)
                    e.Effects = DragDropEffects.All;
                else
                    e.Effects = DragDropEffects.None;
                e.Handled = true;
            }

            if (isCorrect)
                Task.Run(() => Build(info));
            else
                Controller.Status("El archivo debe tener la extensión .sln");
        }
        private void Build(FileInfo file)
        {
            BuildSolution(file.FullName);
        }

        private void BuildSolution(string slnPath)
        {
            ProjectCollection pc = new ProjectCollection();
            List<ILogger> loggers = new List<ILogger>();
            loggers.Add(new FileLogger());

            Dictionary<string, string> GlobalProperty = new Dictionary<string, string>();
            GlobalProperty.Add("Configuration", "Debug");
            GlobalProperty.Add("Platform", "x86");

            BuildRequestData BuildRequest = new BuildRequestData(slnPath, GlobalProperty, "4.0", new string[] { "Build" }, null);
            BuildParameters bp = new BuildParameters(pc);
            bp.Loggers = loggers;

            BuildResult buildResult = BuildManager.DefaultBuildManager.Build(bp, BuildRequest);

            StartProcess("ReadFileConsoleApp.exe", "msbuild.log");
        }

        public void StartProcess(string fileName, string arguments)
        {
            Process process = new Process();
            // Configure the process using the StartInfo properties.
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

            process.Start();
            process.WaitForExit();// Waits here for the process to exit.
        }
    }
}
