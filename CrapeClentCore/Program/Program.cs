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
            IniEdit Configs = new IniEdit(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Configs\Config.conf");
            IniEdit ra2md = new IniEdit(AppDomain.CurrentDomain.BaseDirectory + @"ra2md.ini");
            bool Windowed = IsWindowed(ra2md.IniReadValue("Video", "Windowed"));
            if (Windowed) 
                Screen.ChangeRes();


            string gamemd = Configs.IniReadValue("GameSettings", "GameName");
            string command = Configs.IniReadValue("GameSettings", "Command");

            System.Diagnostics.Process proc = System.Diagnostics.Process.Start(
                    AppDomain.CurrentDomain.BaseDirectory + gamemd + command);
            if (Windowed)
                Screen.DisChangeRes();
            if (proc != null)
            {
                
            }
        }
        static bool IsWindowed(string Value)
        {
            string str = StringTools.SubString(Value,1);
            if (str == "1")
                return true;
            else if (str.ToUpper() == "T")
                return true;
            else if (str.ToUpper() == "Y")
                return true;
            else return false;
        }
    }
}
