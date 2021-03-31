using System;
using System.Diagnostics;
using System.IO;

namespace gitfilelist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            System.Console.WriteLine(System.Environment.CurrentDirectory);
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = "cmd.exe";
            processStartInfo.Arguments = " /c git ";
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardOutput = true;             
            Process process = System.Diagnostics.Process.Start(processStartInfo);
            StreamReader stream = process.StandardOutput;
            string str= stream.ReadToEnd();
            process.WaitForExit();
           
            Console.WriteLine(str);
            Console.ReadLine();

            //git log -1 --name-only --author fengguoqiang --pretty="%s"  -5



        }
    }
}
