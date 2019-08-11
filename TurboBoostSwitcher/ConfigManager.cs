using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace TurboBoostSwitcher
{
    class ConfigManager
    {
        public bool minimizedOnLoad;
        public bool runOnStart;
        private readonly string configPath;
        public ConfigManager()
        {
            configPath = AppDomain.CurrentDomain.BaseDirectory + "config.xml";
            if (!File.Exists(configPath))
            {
                InitCfg();                                
            }
            else
            {
                XDocument doc = XDocument.Load(configPath);
                minimizedOnLoad = Convert.ToBoolean(doc.Root.Element("MinimizedOnLoad").Value);
                runOnStart = Convert.ToBoolean(doc.Root.Element("RunOnStart").Value);
            }
        }

        public void InitCfg()
        {
            minimizedOnLoad = false;
            runOnStart = false;
            XDocument doc = new XDocument();
            doc.Add(new XElement("Config",
                        new XElement("MinimizedOnLoad", false),
                        new XElement("RunOnStart", false)));
            doc.Save(configPath);
        }

        public void SaveCfg()
        {
            XDocument doc = XDocument.Load(configPath);
            doc.Root.SetElementValue("MinimizedOnLoad", minimizedOnLoad);
            doc.Root.SetElementValue("RunOnStart", runOnStart);
            doc.Save(configPath);
        }
    }
}
