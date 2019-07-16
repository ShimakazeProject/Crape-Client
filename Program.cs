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
        public static void RunSyringe()
        {
            IniEdit iniEdit = new IniEdit(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Configs\Config.conf");
            string gamemd = iniEdit.IniReadValue("GameSettings", "GameName");
            string command = iniEdit.IniReadValue("GameSettings", "Command");

            System.Diagnostics.Process proc = System.Diagnostics.Process.Start(
                    AppDomain.CurrentDomain.BaseDirectory + gamemd + command);
            if (proc != null)
            {

            }
        }


    }
}
