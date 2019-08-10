using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crape_Client.CrapeClientCore;

namespace Crape_Client
{
    class Global
    {
        public static MemIniFile MissionConfig = new MemIniFile();
        public static MemIniFile MainConfig = new MemIniFile();
        public static MemIniFile Ra2mdConf = new MemIniFile();


        public static List<Cls_SaveFiles> SaveFilesList = new List<Cls_SaveFiles>();

        public static string LocalPath { get { return AppDomain.CurrentDomain.BaseDirectory; } }

        // 这是变量表
        public static string NoSummary { get { return "这个任务没有简报"; } }
        public static string SavesDir { get { return @"Saved Games\"; } }

        // 这是常量表
        public static string ConfigsDir { get { return @"Resource\Configs\"; } }
        public static string ImagesDir { get { return @"Resource\Images\"; } }

    }


}
