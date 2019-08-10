using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TurboBoostSwitcher
{

    public class CmdResult
    {
        public string result;
        public string error;

        public CmdResult(string r, string e)
        {
            result = r;
            error = e;
        }

        public void Set(string r, string e)
        {
            result = r.Substring(0, r.Length - 1);
            error = e;
        }
    }

    class CmdRunner
    {
        public static CmdResult CmdRun(string command)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            // p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = "/c " + command;
            p.Start();

            string result = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();

            p.WaitForExit();
            p.Close();
            CmdResult cmdResult = new CmdResult(result, error);
            return cmdResult;
        }

        public static CmdResult Run(string fileName, string args)
        {
            Process p = new Process();
            p.StartInfo.FileName = fileName;
            p.StartInfo.Arguments = args;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;

            CmdResult cmdResult = new CmdResult("", "");
            try
            {
                p.Start();
                p.WaitForExit();
                cmdResult.Set(p.StandardOutput.ReadToEnd(), p.StandardError.ReadToEnd());
            }
            catch (Exception e)
            {
                Console.WriteLine("运行 " + fileName + " 出现错误\n" + e.StackTrace);
            }

            return cmdResult;
        }
    }
}
