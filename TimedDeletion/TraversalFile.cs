using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimedDeletion
{
    public class TraversalFile
    {
        /// <summary>
        /// 遍历文件夹下的文件，并进行删除
        /// </summary>
        /// <param name="filepath">文件夹路径</param>
        /// <param name="day">保存时间</param>
        /// <param name="type">类型1是log，2是图片</param>
        public void ErgodicLOG(string filepath, string day)
        {

            DirectoryInfo root = new DirectoryInfo(filepath);
            DeleteFile detelefile = new DeleteFile();
            foreach (FileInfo f in root.GetFiles())
            {
                string name = f.Name;
                string fullName = f.FullName;

                detelefile.DeleteLog(fullName, name, double.Parse(day));


            }

        }

        public void ErgodicPic(string filepath, string day)
        {
            DirectoryInfo root = new DirectoryInfo(filepath);
            DeleteFile detelefile = new DeleteFile();
            foreach (DirectoryInfo f in root.GetDirectories())
            {
                string name = f.FullName;//年子文件夹 2018
                DirectoryInfo rootyear = new DirectoryInfo(name);
                foreach (DirectoryInfo fyear in rootyear.GetDirectories())
                {
                    string namemouth = fyear.Name;//月子文件 201806
                    string fullnamemouth = fyear.FullName + @"\";
                    detelefile.DeletePic(fullnamemouth, namemouth, double.Parse(day));
                    if (Directory.Exists(fullnamemouth))
                    {
                        DirectoryInfo rootmouth = new DirectoryInfo(fullnamemouth);
                        foreach (DirectoryInfo fmouth in rootmouth.GetDirectories())
                        {
                            string nameday = fmouth.Name;//201802822
                            string fullnameday = fmouth.FullName + @"\";
                            detelefile.DeletePic(fullnameday, nameday, double.Parse(day));
                        }
                    }


                }
            }
        }
    }
}
