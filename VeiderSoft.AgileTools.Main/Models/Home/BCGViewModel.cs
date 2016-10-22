using CODE.Framework.Wpf.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VeiderSoft.AgileTools.Main.Models.Home
{
    public class BCGViewModel : ViewModel
    {
        public ViewAction TestCommand { get; private set; }

        public BCGViewModel()
        {
            TestCommand = new ViewAction("Test", execute: (a, o) => Test(), canExecute: (a, o) => true, brushResourceKey: "CODE.Framework-Icon-Collapsed");

            Actions.Add(TestCommand);
            Actions.Add(new CloseCurrentViewAction(this, beginGroup: true));
        }

        private void Test()
        {
            new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "BlockCodeGen.exe",
                    //Arguments = "prop"
                }
            }.Start();


            //ExecuteCommand("prop int test t'");



            //var proc = new ProcessPiper();
            //var fi = new FileInfo("BlockCodeGen.exe");
            //proc.Start(fi, "prop", (o) => { Console.WriteLine(o.StdOut); });



            //string originalTitle = Console.Title;
            //string uniqueTitle = Guid.NewGuid().ToString();
            //Console.Title = uniqueTitle;
            //System.Threading.Thread.Sleep(50);
            //IntPtr handle = FindWindowByCaption(IntPtr.Zero, "bcg");

            //if (handle == IntPtr.Zero)
            //{
            //    Console.WriteLine("Oops, cant find main window.");
            //    return;
            //}
            ////Console.Title = originalTitle;

            //while (true)
            //{
            //    System.Threading.Thread.Sleep(3000);
            //    Console.WriteLine(SetForegroundWindow(handle));
            //}
        }

        //[DllImport("user32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool SetForegroundWindow(IntPtr hWnd);

        //[DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        //static extern IntPtr FindWindowByCaption(IntPtr zeroOnly, string lpWindowName);

        public static void ExecuteCommand(string command)
        {
            Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "BlockCodeGen.exe";
            proc.StartInfo.Arguments = command;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();

            while (!proc.StandardOutput.EndOfStream)
            {
                Console.WriteLine(proc.StandardOutput.ReadLine());
            }
        }
    }
        
    public class ProcessPiper
    {
        public string StdOut { get; private set; }
        public string StdErr { get; private set; }
        public string ExMessage { get; set; }
        public void Start(FileInfo exe, string args, Action<ProcessPiper> onComplete)
        {
            ProcessStartInfo psi = new ProcessStartInfo(exe.FullName, args);
            psi.RedirectStandardError = true;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.WorkingDirectory = Path.GetDirectoryName(exe.FullName);
            Task.Factory.StartNew(() =>
            {
                try
                {
                    ExMessage = string.Empty;
                    Process process = new Process();
                    process.StartInfo = psi;
                    process.Start();
                    process.WaitForExit();
                    StdOut = process.StandardOutput.ReadToEnd();
                    StdErr = process.StandardError.ReadToEnd();
                    onComplete(this);
                }
                catch (Exception ex)
                {
                    ExMessage = ex.Message;
                }
            });
        }
    }
}
