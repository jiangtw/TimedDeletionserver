using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace TimedDeletion
{
  public  class LogManager
    {
        private static string logPath = string.Empty;
        public static string LogPath
        {
            get
            {
                if (logPath == string.Empty)
                {
                  
                    logPath = AppDomain.CurrentDomain.BaseDirectory + "\\log\\";
                    if (!Directory.Exists(logPath))
                    {
                        Directory.CreateDirectory(logPath);
                    }

                }
                return logPath;
            }
            set { logPath = value; }
        }
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="filepath">被删除的文件名</param>
        /// <param name="err">错误编码，数字是没有错误，汉字是具体错误内容</param>
        public void writeLog(string filepath,string err)
        {
            try
            {
                System.IO.StreamWriter sw = System.IO.File.AppendText(
                    LogPath  + "deletefile" +
                    DateTime.Now.ToString("yyyyMMdd") + ".Log"
                    );
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss: ") + filepath+" || "+err);
                sw.Dispose();

                sw.Close();
            }
            catch
            { }
        }
    }
}
