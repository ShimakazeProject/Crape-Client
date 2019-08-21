using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Crape_Client.CrapeClientCore
{
    public class Program
    {
        public static string SummaryInit(string str)// 处理字符串
        {
            if (str != "")
            {
                try
                {
                    str = str.Replace(@"\[n]", "\r\n");// 换行符号
                    str = str.Replace(@"\[t]", "\t");// 横向制表符号
                    str = str.Replace(@"\[v]", "\v");// 纵向制表符号
                    return str;
                }
                catch (NullReferenceException e)
                {
                    Global.LogMGR.Error(e);
                    return Global.NoSummary;
                }
                catch (Exception e)
                {
                    Global.LogMGR.Error(e);
                    Global.LogMGR.ErrorBoxShow();
                    return null;
                }
            }
            else return Global.NoSummary;
        }
        public static void RunSyringe()// 运行游戏
        {

            bool Windowed = Global.Ra2mdConf.ReadValue("Video", "Windowed", false);
            string gamemd = Global.MainConfig.ReadValue("GameSettings", "GameName", "syringe.exe \"gamemd.exe\" ");
            string command = Global.MainConfig.ReadValue("GameSettings", "Command", "");

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
            catch(System.ComponentModel.Win32Exception E)
            {
                Global.LogMGR.Fatal(E);
                Global.LogMGR.NoTimeMsg("Cannot Start Syringe :" + Global.LocalPath + gamemd + command);
                System.IO.DirectoryInfo folder = new System.IO.DirectoryInfo(Global.LocalPath);
                Global.LogMGR.NoTimeMsg("---Search Executable Programs in RunDirectory---");
                try
                {
                    foreach (System.IO.FileInfo file in folder.GetFiles("*.exe"))
                    {
                        Global.LogMGR.NoTimeMsg("Find " + file.Name);
                    }
                    Global.LogMGR.NoTimeMsg("---End Search ---");
                }
                catch(ArgumentNullException e)
                {
                    Global.LogMGR.Error(e);
                    Global.LogMGR.NoTimeMsg("Cannot Finded Any Executable Programs ! \r\n\tGame Install is NOT TRUE!");
                }
                catch(System.Security.SecurityException e)
                {
                    Global.LogMGR.Error(e);
                    Global.LogMGR.NoTimeMsg("Permission needs to be improved ! ");

                }
            }
            catch (Exception e)
            {
                Global.LogMGR.Error(e.ToString());
                return;
            }
        }

    }
}
