using CODE.Framework.Wpf.Mvvm;
using System;
using System.Diagnostics;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace Project.Client.SHAGenerator.Models.Home
{
    public class StartViewModel : ViewModel
    {
        private string module = "VeiderSoft.AgileTools.PowerShell.dll";
        public static StartViewModel Current { get; set; }

        public StartViewModel()
        {
            Current = this;
        }

        public void LoadActions()
        {
            Actions.Clear();

            // TODO: The following list of actions is used to populate the application's main navigation area (such as a menu or a home screen)

            Actions.Add(new ViewAction("Menu Item #1", execute: (a, o) => Controller.Message("Menu Item #1 clicked!")) { Significance = ViewActionSignificance.AboveNormal });
            Actions.Add(new ViewAction("Menu Item #2", execute: (a, o) => Controller.Message("Menu Item #2 clicked!")));
            Actions.Add(new ViewAction("Menu Item #3", execute: (a, o) => Controller.Message("Menu Item #3 clicked!")));

            Actions.Add(new ViewAction("SHA-1 Gen", category: "Tools", execute: (a, o) => Controller.Action("Home", "Shagen"), brushResourceKey: "CODE.Framework-Icon-Comment"));
            Actions.Add(new ViewAction("Password Gen", category: "Tools", execute: (a, o) => Controller.Action("Home", "Passgen"), brushResourceKey: "CODE.Framework-Icon-Login"));
            Actions.Add(new ViewAction("Build Sln", category: "Tools", execute: (a, o) => Controller.Action("Home", "Build"), brushResourceKey: "CODE.Framework-Icon-Bold"));
            Actions.Add(new ViewAction("Resources Visualizer", category: "Tools", execute: (a, o) => Controller.Action("Home", "ResourceVisualizer"), brushResourceKey: "CODE.Framework-Icon-View"));
            Actions.Add(new ViewAction("BCG", category: "Tools", execute: (a, o) => Controller.Action("Home", "BlockCodeGenerator"), brushResourceKey: "CODE.Framework-Icon-Keyboard"));
            Actions.Add(new ViewAction("PowerShell", category: "Tools", execute: (a, o) => ExecutePowerShell(), brushResourceKey: "CODE.Framework-Icon-Remote"));

            Controller.Action("Home", "Bing");
        }

        private void ExecutePowerShell()
        {
            Runspace runSpace = RunspaceFactory.CreateRunspace();
            runSpace.Open();

            Pipeline pipeline = runSpace.CreatePipeline();

            //Command import = new Command("Import-Module");
            //import.Parameters.Add("Assembly", module);
            //import.Parameters.Add("Name", module);
            //pipeline.Commands.Add(import);

            //Command get = new Command("Get-Command");
            //get.Parameters.Add("Module", module);
            //pipeline.Commands.Add(get);

            pipeline.Commands.Add("Import-Module");
            var command = pipeline.Commands[0];
            command.Parameters.Add("Assembly", module);

            var output = pipeline.Invoke();
            foreach (PSObject psObject in output)
            {
                Process process = (Process)psObject.BaseObject;
                Console.WriteLine("Process name: " + process.ProcessName);
            }
        }
    }
}
