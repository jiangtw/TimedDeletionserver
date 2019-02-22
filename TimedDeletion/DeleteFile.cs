using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimedDeletion
{
    public class DeleteFile
    {
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filepath">文件路径</param>
        private void Deletefile(string filepath)
        {
            LogManager logmanger = new LogManager();
            if (File.Exists(filepath))
            {

                try
                {
                    File.SetAttributes(filepath, FileAttributes.Normal);
                    File.Delete(filepath);
                    logmanger.writeLog(filepath, "0");
                }
                catch (Exception e)
                {
                    logmanger.writeLog(filepath, e.Message.ToString());
                }


            }
            else if (Directory.Exists(filepath))
            {
                try
                {
                    Directory.Delete(filepath, true);
                    logmanger.writeLog(filepath, "0");
                }
                catch (Exception e)
                {
                    logmanger.writeLog(filepath, e.Message.ToString());
                }
            }

        }


        /// <summary>
        /// 定时删除图片
        /// </summary>
        /// <param name="filepath">文件全名带路径</param>
        /// <param name="filename">文件名，方便删除操作</param>
        /// <param name="day">间隔时间</param>
        public void DeletePic(string filepath, string filename, double day)
        {
            LogManager logmanger = new LogManager();
            try
            {
                string name;
                if (filename.Length > 6)
                {
                    name = filename.Substring(0, 8);
                }
                else
                {
                    name = filename + "27";
                }

                DateTime dtold = DateTime.ParseExact(name, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                TimeSpan timespan = DateTime.Now - dtold;
                double dt = timespan.TotalDays;
                if (dt > day)
                {
                    Deletefile(filepath);
                }
            }
            catch (Exception e)
            {
                logmanger.writeLog(filepath, e.Message.ToString());
            }

        }
        /// <summary>
        /// 定时删除日志文件
        /// </summary>
        /// <param name="filepath">文件全名带路径</param>
        /// <param name="filename">文件名，方便删除操作</param>
        /// <param name="day">间隔时间</param>
        public void DeleteLog(string filepath, string filename, double day)
        {
            LogManager logmanger = new LogManager();
            try
            {
                string namelog = filename.Replace("-", "");
                string name = namelog.Substring(0, 8);
                DateTime dtold = DateTime.ParseExact(name, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                TimeSpan timespan = DateTime.Now - dtold;
                double dt = timespan.TotalDays;
                if (dt > day)
                {
                    Deletefile(filepath);
                }
            }
            catch (Exception e)
            {
                logmanger.writeLog(filepath, e.Message.ToString());
            }

        }
    }
}

