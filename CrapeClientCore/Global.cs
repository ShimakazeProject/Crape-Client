using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crape_Client.CrapeClientCore;
using Crape_Client.Initialization;

namespace Crape_Client
{
    class Global// 全局属性
    {
        public static MemIniFile MissionConfig { set; get; }
        public static MemIniFile MainConfig { set; get; }
        public static MemIniFile Ra2mdConf { set; get; }
        #region 初始化配置信息
        public static List<SideInit.SideModel> Sides { set; get; }// 阵营信息初始化
        public static List<Initialization.Config.Color> Colors { set; get; }// 颜色信息初始化
        public static List<Cls_SaveFiles> SaveFilesList { set; get; }// 存档列表读取
        public static List<Initialization.Config.Renderer> RendererList { set; get; }// 存档列表读取
        #endregion

        public static LogMGR LogMGR { set; get; }

        public static string NoSummary { get { return "这个任务没有简报"; } }

        // 这是只读属性
        public static string LocalPath { get { return AppDomain.CurrentDomain.BaseDirectory; } }
        public static string SavesDir { get { return LocalPath + @"Saved Games\"; } }// 游戏存档文件夹
        public static string ResourceDir { get { return LocalPath + @"Resource\"; } }// 资源文件夹
        public static string ConfigsDir { get { return ResourceDir + @"Configs\"; } }// 配置文件位置
        public static string ImagesDir { get { return ResourceDir + @"Images\"; } } // 图像资源位置
        public static string DdrawDir { get { return ResourceDir + @"Renderer\"; } }

        public static string LogPath { get { return LocalPath + @"Debug\Crape Client.log"; } }
        static Global()
        {
            MissionConfig = new MemIniFile();
            MainConfig = new MemIniFile();
            Ra2mdConf = new MemIniFile();

            RendererList = new List<Initialization.Config.Renderer>();
            SaveFilesList = new List<Cls_SaveFiles>();
            Sides = new List<SideInit.SideModel>();
            Colors= new List<Initialization.Config.Color>();
        }
    }


}
