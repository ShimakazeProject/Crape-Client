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
                    Nlog.logger.Error("Message : " + e.Message);
                    Nlog.logger.Error("Source : " + e.Source);
                    Nlog.logger.Error("TargetSite : " + e.TargetSite);
                    return Global.NoSummary;
                }
                catch (Exception e)
                {
                    Nlog.logger.Error("Message : " + e.Message);
                    Nlog.logger.Error("Source : " + e.Source);
                    Nlog.logger.Error("TargetSite : " + e.TargetSite);
                    Nlog.ErrorBoxShow(e);
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
                Nlog.logger.Fatal(E.ToString());
                Nlog.logger.Fatal("Cannot Start Syringe :" + Global.LocalPath + gamemd + command);
                System.IO.DirectoryInfo folder = new System.IO.DirectoryInfo(Global.LocalPath);
                Nlog.logger.Info("---Search Executable Programs in RunDirectory---");
                try
                {
                    foreach (System.IO.FileInfo file in folder.GetFiles("*.exe"))
                    {
                        Nlog.logger.Info("Find " + file.Name);
                    }
                    Nlog.logger.Info("---End Search ---");
                }
                catch(ArgumentNullException e)
                {
                    Nlog.logger.Error("Cannot Finded Any Executable Programs ! \r\n\tGame Install is NOT TRUE!");
                    Nlog.logger.Error(e.ToString());
                }
                catch(System.Security.SecurityException e)
                {
                    Nlog.logger.Error("Permission needs to be improved ! ");
                    Nlog.logger.Error(e.ToString());
                }
            }
            catch (Exception e)
            {
                Nlog.logger.Error(e.ToString());
                return;
            }
        }

    }
}
