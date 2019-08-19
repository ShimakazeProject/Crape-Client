using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crape_Client.CrapeClientCore;
using Crape_Client.Initialization;

namespace Crape_Client
{
    class Global
    {
        public static MemIniFile MissionConfig = new MemIniFile();
        public static MemIniFile MainConfig = new MemIniFile();
        public static MemIniFile Ra2mdConf = new MemIniFile();
        #region 初始化配置信息
        public static List<SideInit.SideModel> Sides = new List<SideInit.SideModel>();// 阵营信息初始化
        public static List<Cls_SaveFiles> SaveFilesList = new List<Cls_SaveFiles>();// 存档列表读取
        public static List<Initialization.Config.Renderer> RendererList =
            new List<Initialization.Config.Renderer>();// 存档列表读取
        #endregion

        public static string LocalPath { get { return AppDomain.CurrentDomain.BaseDirectory; } }

        // 这是变量表
        public static string NoSummary { get { return "这个任务没有简报"; } }

        // 这是常量表
        public const string SavesDir = @"Saved Games\"; // 游戏存档文件夹

        public const string ResourceDir = @"Resource\";// 资源文件夹
        public const string ConfigsDir = ResourceDir + @"Configs\";// 配置文件位置
        public const string ImagesDir = ResourceDir + @"Images\"; // 图像资源位置
        public const string DdrawDir = ResourceDir + @"Renderer\";

    }


}
