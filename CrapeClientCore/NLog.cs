using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Targets;
using NLog.Config;

namespace Crape_Client
{
    class Nlog
    {
        public static Logger logger = LogManager.GetLogger("NLog");
        public static void NLogInit() // 初始化日誌管理
        {
            try
            {
                System.IO.File.WriteAllText(
                    Global.LocalPath + @"\Debug\Crape Client.log",
                    "*   -----" + DateTime.Now.ToLongTimeString() + "-----CC is Worked.-----\n");
            }
            catch (UnauthorizedAccessException ex)// path 指定了一个只读文件。 - 或 - 当前平台不支持此操作。 - 或 - path 指定了一个目录。 - 或 - 调用方没有所要求的权限。
            {
                System.Windows.MessageBox.Show("Cannot Created LogFile.\nPlease check if you have permission.\n" + ex.Message, "Fatal");
            }
            catch (System.Security.SecurityException ex)//     调用方没有所要求的权限。
            {
                System.Windows.MessageBox.Show("Cannot Created LogFile.\nPlease check if you have permission.\n" + ex.Message, "Fatal");
            }
            var config = new LoggingConfiguration();

            var fInfoTarget = new FileTarget("InfoTarget")// Info级消息格式
            {
                FileName = "${basedir}/Debug/Crape Client.log",
                Layout = @"    ${level} |" + DateTime.Now.ToShortTimeString() + " : ${message}"
            };
            config.AddTarget(fInfoTarget);
            config.AddRuleForOneLevel(LogLevel.Info, fInfoTarget);

            var fWarnTarget = new FileTarget("WarnTarget")// Warn级消息处理
            {
                FileName = "${basedir}/Debug/Crape Client.log",
                Layout = @" *  ${level} |" + DateTime.Now.ToShortTimeString() + " : ${message} |" +
                " ${onexception:${exception:format=tostring} ${stacktrace} ${newline}"
            };
            config.AddTarget(fWarnTarget);
            config.AddRuleForOneLevel(LogLevel.Warn, fWarnTarget);

            var fErrorTarget = new FileTarget("ErrorTarget"){
                FileName = "${basedir}/Debug/Crape Client.log",
                Layout = @" * ${level} |" + DateTime.Now.ToShortTimeString() + " : ${message} |" +
                " ${onexception:${exception:format=tostring} ${stacktrace} ${newline}"
            };
            config.AddTarget(fErrorTarget);
            config.AddRuleForOneLevel(LogLevel.Fatal, fErrorTarget);
            config.AddRuleForOneLevel(LogLevel.Error, fErrorTarget);
            //config.AddRuleForOneLevel(LogLevel.Debug, fErrorTarget);
            config.AddRuleForOneLevel(LogLevel.Trace, fErrorTarget);

            var fDebugTarget = new FileTarget("DebugTarget")
            {
                FileName = "${basedir}/Debug/Crape Client.log",
                Layout = @"         |" + DateTime.Now.ToShortTimeString() + " : ${message}"
            };
            config.AddTarget(fDebugTarget);
            config.AddRuleForOneLevel(LogLevel.Debug, fDebugTarget);

            LogManager.Configuration = config;
        }
        public static void ErrorBoxShow(Exception e)
        {
            System.Windows.MessageBox.Show(
                "The Program has a Fatal Error:\n" +
                "Please Mail \".\\Debug\\Crape Client.log\" To frg2089@foxmail.com\n" +
                "Or Visit https://github.com/frg2089/Crape-Client" +
                "\nMessage\t: " + e.Message +
                "\nSource\t: " + e.Source +
                "\nTargetSite\t: " + e.TargetSite
                , "Fatal  Error!");
            Environment.Exit(0);
        }
    }
}
