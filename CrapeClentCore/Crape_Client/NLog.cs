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
            var config = new LoggingConfiguration();

            var fInfoTarget = new FileTarget("InfoTarget"){
                FileName = "${basedir}/debug/Crape Client.log",
                Layout = @"   ${level} | ${shotrdata} : ${message}"
            };
            config.AddTarget(fInfoTarget);
            config.AddRuleForOneLevel(LogLevel.Info, fInfoTarget);

            var fWarnTarget = new FileTarget("WarnTarget"){
                FileName = "${basedir}/debug/Crape Client.log",
                Layout = @" * ${level} | ${longdata} : ${message} | ${onexception:${exception:format=tostring} ${stacktrace} ${newline}"
            };
            config.AddTarget(fWarnTarget);
            config.AddRuleForOneLevel(LogLevel.Fatal, fWarnTarget);
            config.AddRuleForOneLevel(LogLevel.Error, fWarnTarget);
            config.AddRuleForOneLevel(LogLevel.Warn, fWarnTarget);
            config.AddRuleForOneLevel(LogLevel.Debug, fInfoTarget);
            config.AddRuleForOneLevel(LogLevel.Trace, fInfoTarget);

            LogManager.Configuration = config;
        }
    }
}
