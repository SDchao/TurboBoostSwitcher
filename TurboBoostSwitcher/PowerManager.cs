using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using TurboBoostSwitcher;

namespace TurboBoostSwitcher
{
    class PowerManager
    {
        private readonly string scheme_GUID;
        private readonly string sub_GUID;
        private readonly string setting_GUID;
        public int maxValue;
        public int minValue;

        public PowerManager()
        {

            //写出查询结果日志
            if (!File.Exists("runtime.log"))
                File.Create("runtime.log").Close();
            else
            {
                //若文件超过100k则清空
                FileInfo fileInfo = new FileInfo("runtime.log");
                if(fileInfo.Length > 100 * 1024)
                {
                    File.Create("runtime.log").Close();
                }
            }

            CmdResult schemeListResult = CmdRunner.CmdRun("powercfg /l");
            Log("\n计划列表\n" + schemeListResult.result);
            CmdResult queryResult = CmdRunner.CmdRun("powercfg /q");
            Log("\n计划查询\n" + queryResult.result);
            //查找当前电源方案的GUID
            Regex rScheme = new Regex(@"电源方案 GUID: ([a-z0-9\-]+)  \(.*\) \*");
            if (rScheme.IsMatch(schemeListResult.result))
                scheme_GUID = rScheme.Match(schemeListResult.result).Groups[1].ToString();
            else
                throw new Exception("CmdError:" + schemeListResult.error 
                    + "&CmdResult:" + schemeListResult.result);
            //查找子组GUID
            Regex rSub = new Regex(@"子组 GUID: ([a-z0-9\-]+)  \(处理器电源管理\)");
            if(rSub.IsMatch(queryResult.result))
                sub_GUID = rSub.Match(queryResult.result).Groups[1].ToString();
            else
                throw new Exception("CmdError:" + queryResult.error
                    + "&CmdResult:" + queryResult.result);
            //查找设置GUID
            Regex rSet = new Regex(@"电源设置 GUID: ([a-z0-9\-]+)  \(最大处理器状态\)");
            if (rSet.IsMatch(queryResult.result))
                setting_GUID = rSet.Match(queryResult.result).Groups[1].ToString();
            else
                throw new Exception("CmdError:" + queryResult.error
                    + "&CmdResult:" + queryResult.result);

            //查找当前CPU设置
            //查找最大处理器状态
            int startIndex = queryResult.result.IndexOf("最大处理器状态");
            Regex rValue = new Regex(@"交流电源设置索引: 0x([0-9]+)");
            maxValue = Convert.ToInt32(rValue.Match(queryResult.result,startIndex).Groups[1].ToString(),16);

            //查找最小处理器状态
            startIndex = queryResult.result.IndexOf("最小处理器状态");
            minValue = Convert.ToInt32(rValue.Match(queryResult.result, startIndex).Groups[1].ToString(), 16);

            Log("\n已查找GUID：" + 
                "\n电源方案 " + scheme_GUID +
                "\n子类 " + sub_GUID +
                "\n最大状态 " + setting_GUID + " " + maxValue
                + "\n最小状态 " + minValue);
            //若最小处理器状态过大
            if (minValue == 100)
            {
                //查找最小处理器状态GUID
                rSet = new Regex(@"电源设置 GUID: ([a-z0-9\-]+)  \(最小处理器状态\)");
                string minSettingGUID = rSet.Match(queryResult.result).Groups[1].ToString();

                //设置最小CPU为99
                string command1 = "powercfg /setacvalueindex " +
                scheme_GUID + " " + sub_GUID + " " + minSettingGUID + " 99";
                string command2 = "powercfg /setdcvalueindex " +
                    scheme_GUID + " " + sub_GUID + " " + minSettingGUID + " 99";
                CmdRunner.CmdRun(command1 + "&" + command2);
            }
        }

        public bool SetMaxCpu(int num)
        {
            if (num > 100)
                num = 100;
            if (num < 0)
                num = 0;
            string command1 = "powercfg /setacvalueindex " + 
                scheme_GUID + " " + sub_GUID + " " + setting_GUID + " " + num.ToString();
            string command2 = "powercfg /setdcvalueindex " +
                scheme_GUID + " " + sub_GUID + " " + setting_GUID + " " + num.ToString();
            string command3 = "powercfg /s " + scheme_GUID;
            CmdResult result = CmdRunner.CmdRun(command1 + "&" + command2 + "&" + command3);

            Log("\n设置状态\n" + command1 + "&" + command2 + "&" + command3);

            if (result.error == string.Empty)
                return true;
            else
                return false;      
        }

        public void Log(string Message)
        {
            StreamWriter debugWriter = new StreamWriter(File.Open("runtime.log", FileMode.Append));
            debugWriter.WriteLine("[" + DateTime.Now + "]" + Message);
            debugWriter.Close();
        }
    }
}
