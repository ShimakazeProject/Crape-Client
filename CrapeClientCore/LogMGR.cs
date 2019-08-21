using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Crape_Client.CrapeClientCore
{
    
    class LogMGR
    {
        private readonly TextWriter tw;
        const string ErrorMessage =
            "        Crape Client has encountered an Internal Error\n" +
            "             and is unable to continue normally.\n\n" +
            "Please Visit our website at https://github.com/frg2089/Crape-Client" + "\n" +
            "               Or Mail To frg2089@foxmail.com\n" +
            "             for the latest updates and technical.";
        public LogMGR(string LogPath)// 构造函数
        {
            tw = new StreamWriter(LogPath, true); //true在文件末尾添加数据
        }
        public LogMGR()// 构造函数
        {
            File.WriteAllText(Global.LocalPath + @"\Debug\Crape Client.log",
                "*   -----"+ DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString() + "-----CC is Worked.-----\n");
            tw = new StreamWriter(Global.LogPath, true); //true在文件末尾添加数据
        }
        public void Fatal(string Msg){// 致命
            tw.WriteLine("---------+-------------------------------------------");
            tw.WriteLine(" * Fatal | " + DateTime.Now.ToLongTimeString() + " | " + Msg);
        }
        public void Fatal(Exception e){
            tw.WriteLine("---------+-------------------------------------------");
            tw.WriteLine(" * Fatal | " + DateTime.Now.ToLongTimeString() + " : ");
            tw.WriteLine("         | " + e.Message);
            tw.WriteLine("         | " + e.Source);
            tw.WriteLine("         | " + e.TargetSite);
            tw.WriteLine("         | " + e.StackTrace);
            tw.WriteLine("         | " + e.InnerException);
            tw.WriteLine("         | " + e.Data);
            FatalBoxShow(e);
        }
        public void Fatal(Exception e,string Msg){
            tw.WriteLine("---------+-------------------------------------------");
            tw.WriteLine(" * Fatal | " + DateTime.Now.ToLongTimeString() + " : " );
            tw.WriteLine("         | " + Msg);
            tw.WriteLine("         | " + e.Message);
            tw.WriteLine("         | " + e.Source);
            tw.WriteLine("         | " + e.TargetSite);
            tw.WriteLine("         | " + e.StackTrace);
            tw.WriteLine("         | " + e.InnerException);
            tw.WriteLine("         | " + e.Data);
            FatalBoxShow(e);
        }
        public void FatalBoxShow(Exception e)
        {
            System.Windows.MessageBox.Show(
                ErrorMessage +
                "\nTargetSite\t: " + e.TargetSite +
                "\nMessage\t: " + e.Message +
                "\nSource\t: " + e.Source 
                , "Fatal Error!");
            Environment.Exit(0);
        }
        public void Error(string Msg){// 错误
            tw.WriteLine("---------+-------------------------------------------");
            tw.WriteLine(" * Error | " + DateTime.Now.ToLongTimeString() + " | " + Msg);
        }
        public void Error(Exception e){
            tw.WriteLine("---------+-------------------------------------------");
            tw.WriteLine(" * Error | " + DateTime.Now.ToLongTimeString() + " : ");
            tw.WriteLine("         | " + e.Message);
            tw.WriteLine("         | " + e.Source);
            tw.WriteLine("         | " + e.TargetSite);
            tw.WriteLine("         | " + e.StackTrace);
            tw.WriteLine("         | " + e.InnerException);
            tw.WriteLine("         | " + e.Data);
            ErrorBoxShow();
        }
        public void ErrorBoxShow()
        {
            System.Windows.MessageBox.Show(ErrorMessage, "Internal Error!");
            App.application.Shutdown();
        }

        public void Warn(string Msg){// 警告
            tw.WriteLine("---------+-------------------------------------------");
            tw.WriteLine(" *  Warn | " + DateTime.Now.ToLongTimeString() + " | " + Msg);
        }

        public void Debug(string Msg){// 调试
            tw.WriteLine("---------+-------------------------------------------");
            tw.WriteLine("   Debug | " + DateTime.Now.ToLongTimeString() + " | " + Msg);
        }
        public void Info(string Msg){// 信息
            tw.WriteLine("---------+-------------------------------------------");
            tw.WriteLine("    Info | " + DateTime.Now.ToLongTimeString() + " | " + Msg);
        }
        public void Trace(string Msg){// 跟踪
            tw.WriteLine("---------+-------------------------------------------");
            tw.WriteLine("   Trace | " + DateTime.Now.ToLongTimeString() + " | " + Msg);
        }
        public void Message(string Msg)
        {
            tw.WriteLine("         | " + DateTime.Now.ToLongTimeString() + " | " + Msg);
        }
        public void NoTimeMsg(string Msg)
        {
            tw.WriteLine("         | " +  Msg);
        }


    }
}
