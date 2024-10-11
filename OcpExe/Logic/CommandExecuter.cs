using OcpExe.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OcpExe.Logic
{
    [Register<CommandExecuter>]
    internal class CommandExecuter
    {
        public CommandExecuter()
        {
          
        }

        public string Execute(string command)
        {
            Process process = new Process();
            process.StartInfo.FileName = "dir";
            process.StartInfo.Arguments = command;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;


            return "";
            // Start the process
            //process.Start();

            // Read the standard output and error
            //string output = process.StandardOutput.ReadToEnd();
            //string error = process.StandardError.ReadToEnd();

            // Wait for the process to finish
            //process.WaitForExit();

            // Display the output
            //if (!string.IsNullOrEmpty(output))
            //{
            //    Console.WriteLine("Command Output:");
            //    Console.WriteLine(output);
            //}

            // Display any errors
            //if (!string.IsNullOrEmpty(error))
            //{
            //    Console.WriteLine("Error:");
            //    Console.WriteLine(error);
            //}
            //return output ?? "error";
        }
    }
}
