using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using System.Xml.Linq;

namespace TimedDeletion
{
   public class TimingCycle
    {
        private static Timer aTimer = new Timer();
        TraversalFile traver = new TraversalFile();
        public void init()
        {

           
            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimeDispTimer_Tick);
            aTimer.AutoReset = true;//每到指定时间Elapsed事件是到时间就触发
            aTimer.Enabled = true; //指示 Timer 是否应引发 Elapsed 事件。
            aTimer.Interval = 300000;//86400000
            aTimer.Start();
            ReadXML();
        }

        private void OnTimeDispTimer_Tick(object sender, ElapsedEventArgs e)
        {
            ReadXML();
        }
        /// <summary>
        /// 读取xml配置文件
        /// </summary>
        private void ReadXML()
        {
            string logPath = AppDomain.CurrentDomain.BaseDirectory;
            string configXml = logPath + "Config.xml";
            XDocument config = XDocument.Load(configXml);
            XElement rootNode = config.Element("settings");
            foreach (XElement node in rootNode.Elements("Log"))
            {
                string path = node.Element("path").Value.Trim();
                string day = node.Element("day").Value.Trim();
                traver.ErgodicLOG(path, day);
            }
            foreach (XElement node in rootNode.Elements("Pic"))
            {
                string path = node.Element("path").Value.Trim();
                string day = node.Element("day").Value.Trim();
                traver.ErgodicPic(path, day);
            }
        }
    }
}
