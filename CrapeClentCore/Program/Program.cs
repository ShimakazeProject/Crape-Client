using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Program
{
    public class Program
    {
        public static string SummaryInit(string str)// 处理字符串
        {
            str = str.Replace(@"\[n]", "\r\n");// 换行符号
            str = str.Replace(@"\[t]", "\t");// 横向制表符号
            str = str.Replace(@"\[v]", "\v");// 纵向制表符号
            return str;
        }
        public static void RunSyringe()// 运行游戏
        {
            IniEdit Configs = new IniEdit(
                AppDomain.CurrentDomain.BaseDirectory + @"Resource\Configs\Config.conf");
            IniEdit ra2md = new IniEdit(AppDomain.CurrentDomain.BaseDirectory + @"ra2md.ini");
            bool Windowed = IniTools.BoolCheck(ra2md.IniReadValue("Video", "Windowed"));
            string gamemd = Configs.IniReadValue("GameSettings", "GameName");
            string command = Configs.IniReadValue("GameSettings", "Command");

            if (Windowed)// 是否窗口化
                Screen.ChangeRes();//设置色深为16
            try
            {
                System.Diagnostics.Process proc = System.Diagnostics.Process.Start(
                        AppDomain.CurrentDomain.BaseDirectory + gamemd + command);
                if (Windowed)// 还原
                    Screen.DisChangeRes();//还原色深
                if (proc != null)
                {

                }
            }
            catch(System.ComponentModel.Win32Exception)
            {
                Crape_Client.Nlog.logger.Fatal("Cannot Start Syringe :" + AppDomain.CurrentDomain.BaseDirectory + gamemd + command);
                System.IO.DirectoryInfo folder = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                Crape_Client.Nlog.logger.Info("---Search Executable Programs in RunDirectory---");
                try
                {
                    foreach (System.IO.FileInfo file in folder.GetFiles("*.exe"))
                    {
                        Crape_Client.Nlog.logger.Info("Find " + file.Name);
                    }
                    Crape_Client.Nlog.logger.Info("---End Search ---");
                }
                catch(ArgumentNullException)
                {
                    Crape_Client.Nlog.logger.Error("Cannot Finded Any Executable Programs ! \r\n\tGame Install is NOT TRUE!");
                }
                catch(System.Security.SecurityException)
                {
                    Crape_Client.Nlog.logger.Error("Permission needs to be improved ! ");
                }
            }
        }

    }
}
