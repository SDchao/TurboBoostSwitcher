﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TurboBoostSwitcher;

namespace TurboBoostSwitcher
{
    class PowerManager
    {
        private string scheme_GUID;
        private string sub_GUID;
        private string setting_GUID;

        public PowerManager()
        {
            CmdResult schemeListResult = CmdRunner.CmdRun("powercfg /l");
            CmdResult queryResult = CmdRunner.CmdRun("powercfg /q");
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

            Console.WriteLine(scheme_GUID + "\n" + sub_GUID + "\n" + setting_GUID);
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
            string command3 = "powercfg /s " + sub_GUID;
            CmdResult result = CmdRunner.CmdRun(command1 + "&" + command2 + "&" + command3);
            if (result.error == string.Empty)
                return true;
            else
                return false;
        }
    }
}
