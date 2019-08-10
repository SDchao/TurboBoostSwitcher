using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }
    }
}
