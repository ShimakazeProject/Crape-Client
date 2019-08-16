using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows;
using System.Drawing;
using Crape_Client.CrapeClientCore;
using Crape_Client.CrapeClientCore.Config;


namespace Crape_Client
{
    class Init
    {
        #region 存档
        public static void SavesListInit()
        {
            DirectoryInfo folder = new DirectoryInfo(Global.LocalPath + Global.SavesDir);
            try
            {
                foreach (FileInfo file in folder.GetFiles("*.sav"))
                {
                    //Console.WriteLine(file.FullName);
                    Global.SaveFilesList.Add(new Cls_SaveFiles
                    {
                        Name = GameSaveFile.LoadSaveName(File.ReadAllBytes(file.FullName)),
                        Date = file.LastWriteTime.ToString(),
                        FileN = file.Name
                    });// FullName?
                }
            }
            catch (DirectoryNotFoundException e)
            {
                Nlog.logger.Info(e.Message);
                Global.SaveFilesList.Add(new Cls_SaveFiles
                {
                    Name = "没有发现可用存档",
                    Date = "",
                    FileN = ""
                });
            }
        }
        #endregion
        #region 任务
        public class NameList
        {
            public static List<string> Side0 { get; } = new List<string>();
            public static List<string> Side1 { get; } = new List<string>();
            public static List<string> Side2 { get; } = new List<string>();
            public static List<string> Side3 { get; } = new List<string>();
            public static List<string> Side4 { get; } = new List<string>();
            public static List<string> Side5 { get; } = new List<string>();
            public static List<string> Side6 { get; } = new List<string>();
            public static List<string> Side7 { get; } = new List<string>();
            public static List<string> Side8 { get; } = new List<string>();
            public static List<string> Side9 { get; } = new List<string>();
            public static void Add(int Side, string Item)
            {
                switch (Side)
                {
                    case 0:
                        Side0.Add(Item);
                        break;
                    case 1:
                        Side1.Add(Item);
                        break;
                    case 2:
                        Side2.Add(Item);
                        break;
                    case 3:
                        Side3.Add(Item);
                        break;
                    case 4:
                        Side4.Add(Item);
                        break;
                    case 5:
                        Side5.Add(Item);
                        break;
                    case 6:
                        Side6.Add(Item);
                        break;
                    case 7:
                        Side7.Add(Item);
                        break;
                    case 8:
                        Side8.Add(Item);
                        break;
                    case 9:
                        Side9.Add(Item);
                        break;
                }
            }
        }
        public class SectionNameList
        {
            public static List<string> Side0 { get; } = new List<string>();
            public static List<string> Side1 { get; } = new List<string>();
            public static List<string> Side2 { get; } = new List<string>();
            public static List<string> Side3 { get; } = new List<string>();
            public static List<string> Side4 { get; } = new List<string>();
            public static List<string> Side5 { get; } = new List<string>();
            public static List<string> Side6 { get; } = new List<string>();
            public static List<string> Side7 { get; } = new List<string>();
            public static List<string> Side8 { get; } = new List<string>();
            public static List<string> Side9 { get; } = new List<string>();
            public static void Add(int Side, string Item)
            {
                switch (Side)
                {
                    case 0:
                        Side0.Add(Item);
                        break;
                    case 1:
                        Side1.Add(Item);
                        break;
                    case 2:
                        Side2.Add(Item);
                        break;
                    case 3:
                        Side3.Add(Item);
                        break;
                    case 4:
                        Side4.Add(Item);
                        break;
                    case 5:
                        Side5.Add(Item);
                        break;
                    case 6:
                        Side6.Add(Item);
                        break;
                    case 7:
                        Side7.Add(Item);
                        break;
                    case 8:
                        Side8.Add(Item);
                        break;
                    case 9:
                        Side9.Add(Item);
                        break;
                }
            }
        }
        public static void MissionConfigAnalyze()
        {
            IniSection[] SectionList = (IniSection[])Global.MissionConfig.SectionList.ToArray(typeof(IniSection));
            if (SectionList.Length < 1) return;
            for (uint i = 0; i < SectionList.Length; i++)
            {
                #region 消除中文乱码
                Global.MissionConfig.WriteValue(
                    SectionList[i].SectionName
                    , "Name"
                    , IniIO.ReadValue(
                        SectionList[i].SectionName
                        , "Name"
                        , Global.LocalPath + Global.ConfigsDir + "Missions.ini"
                        )
                    );
                Global.MissionConfig.WriteValue(
                    SectionList[i].SectionName
                    , "Summary"
                    , IniIO.ReadValue(
                        SectionList[i].SectionName
                        , "Summary"
                        , Global.LocalPath + Global.ConfigsDir + "Missions.ini"
                        )
                    );
                #endregion
                int side = Global.MissionConfig.ReadValue(SectionList[i].SectionName, "Side", 0);
                NameList.Add(side, Global.MissionConfig.ReadValue(SectionList[i].SectionName, "Name", null));
                SectionNameList.Add(side, SectionList[i].SectionName);
            }
        }
        #endregion
        #region 窗口
        public static void MainWindowInit()
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(Global.LocalPath + Global.ConfigsDir + "UI.xml");
            }
            catch(XmlException e)
            {
                Nlog.logger.Error("Message : " + e.Message);
                Nlog.logger.Error("Source : " + e.Source);
                Nlog.logger.Error("TargetSite : " + e.TargetSite);
                Nlog.ErrorBoxShow(e);
            }
            XmlNode root = xml.SelectSingleNode("UIconfig");
            // 获取节点列表
            XmlNodeList xnl = root.ChildNodes;
            #region 主菜单
            XmlElement mainwindow = (XmlElement)xml.SelectSingleNode("UIconfig/MainWindow");
            UIconfig.MainWindow.Height = Convert.ToDouble(mainwindow.GetAttribute("Height"));
            UIconfig.MainWindow.Width = Convert.ToDouble(mainwindow.GetAttribute("Width"));
            UIconfig.MainWindow.Title = mainwindow.GetAttribute("Title");
            UIconfig.MainWindow.Background = string2Brush(mainwindow.GetAttribute("Background"));
            XmlElement menu = (XmlElement)xml.SelectSingleNode("UIconfig/MainWindow/Menu");
            UIconfig.MainWindow.Menu.Height = Convert.ToDouble(menu.GetAttribute("Height"));
            UIconfig.MainWindow.Menu.Width = Convert.ToDouble(menu.GetAttribute("Width"));
            UIconfig.MainWindow.Menu.Margin = string2Thickness(menu.GetAttribute("Margin"));
            XmlElement logo = (XmlElement)xml.SelectSingleNode("UIconfig/MainWindow/Menu/Logo");
            UIconfig.MainWindow.Menu.Logo.Height = Convert.ToDouble(logo.GetAttribute("Height"));
            UIconfig.MainWindow.Menu.Logo.Width = Convert.ToDouble(logo.GetAttribute("Width"));
            UIconfig.MainWindow.Menu.Logo.Left = Convert.ToDouble(logo.GetAttribute("Left"));
            UIconfig.MainWindow.Menu.Logo.Top = Convert.ToDouble(logo.GetAttribute("Top"));
            UIconfig.MainWindow.Menu.Logo.Text = logo.GetAttribute("Text");
            #endregion
            #region 按钮
            XmlElement camp = (XmlElement)xml.SelectSingleNode("UIconfig/MainWindow/Menu/Campaign");
            UIconfig.MainWindow.Menu.Campaign.Top = Convert.ToDouble(camp.GetAttribute("Top"));
            UIconfig.MainWindow.Menu.Campaign.Left = Convert.ToDouble(camp.GetAttribute("Left"));
            UIconfig.MainWindow.Menu.Campaign.Width = Convert.ToDouble(camp.GetAttribute("Width"));
            UIconfig.MainWindow.Menu.Campaign.Height = Convert.ToDouble(camp.GetAttribute("Height"));
            UIconfig.MainWindow.Menu.Campaign.Content = camp.GetAttribute("Content");
            UIconfig.MainWindow.Menu.Campaign.DataContext = camp.GetAttribute("DataContext");
            XmlElement skir = (XmlElement)xml.SelectSingleNode("UIconfig/MainWindow/Menu/Skirmish");
            UIconfig.MainWindow.Menu.Skirmish.Top = Convert.ToDouble(skir.GetAttribute("Top"));
            UIconfig.MainWindow.Menu.Skirmish.Left = Convert.ToDouble(skir.GetAttribute("Left"));
            UIconfig.MainWindow.Menu.Skirmish.Width = Convert.ToDouble(skir.GetAttribute("Width"));
            UIconfig.MainWindow.Menu.Skirmish.Height = Convert.ToDouble(skir.GetAttribute("Height"));
            UIconfig.MainWindow.Menu.Skirmish.Content = skir.GetAttribute("Content");
            UIconfig.MainWindow.Menu.Skirmish.DataContext = skir.GetAttribute("DataContext");
            XmlElement load = (XmlElement)xml.SelectSingleNode("UIconfig/MainWindow/Menu/Loadings");
            UIconfig.MainWindow.Menu.Loadings.Top = Convert.ToDouble(load.GetAttribute("Top"));
            UIconfig.MainWindow.Menu.Loadings.Left = Convert.ToDouble(load.GetAttribute("Left"));
            UIconfig.MainWindow.Menu.Loadings.Width = Convert.ToDouble(load.GetAttribute("Width"));
            UIconfig.MainWindow.Menu.Loadings.Height = Convert.ToDouble(load.GetAttribute("Height"));
            UIconfig.MainWindow.Menu.Loadings.Content = load.GetAttribute("Content");
            UIconfig.MainWindow.Menu.Loadings.DataContext = load.GetAttribute("DataContext");
            XmlElement sett = (XmlElement)xml.SelectSingleNode("UIconfig/MainWindow/Menu/Settings");
            UIconfig.MainWindow.Menu.Settings.Top = Convert.ToDouble(sett.GetAttribute("Top"));
            UIconfig.MainWindow.Menu.Settings.Left = Convert.ToDouble(sett.GetAttribute("Left"));
            UIconfig.MainWindow.Menu.Settings.Width = Convert.ToDouble(sett.GetAttribute("Width"));
            UIconfig.MainWindow.Menu.Settings.Height = Convert.ToDouble(sett.GetAttribute("Height"));
            UIconfig.MainWindow.Menu.Settings.Content = sett.GetAttribute("Content");
            UIconfig.MainWindow.Menu.Settings.DataContext = sett.GetAttribute("DataContext");
            XmlElement exit = (XmlElement)xml.SelectSingleNode("UIconfig/MainWindow/Menu/Exit");
            UIconfig.MainWindow.Menu.Exit.Left = Convert.ToDouble(exit.GetAttribute("Left"));
            UIconfig.MainWindow.Menu.Exit.Width = Convert.ToDouble(exit.GetAttribute("Width"));
            UIconfig.MainWindow.Menu.Exit.Bottom = Convert.ToDouble(exit.GetAttribute("Bottom"));
            UIconfig.MainWindow.Menu.Exit.Height = Convert.ToDouble(exit.GetAttribute("Height"));
            UIconfig.MainWindow.Menu.Exit.Content = exit.GetAttribute("Content");
            UIconfig.MainWindow.Menu.Exit.DataContext = exit.GetAttribute("DataContext");
            #endregion
            XmlElement show = (XmlElement)xml.SelectSingleNode("UIconfig/MainWindow/Show");
            UIconfig.MainWindow.Show.Margin = string2Thickness(menu.GetAttribute("Margin"));
            /*
            foreach (XmlNode xn in xnl)
            {
                UIconfig sc = new UIconfig();
                XmlElement xe = (XmlElement)xn;
                sc.Id = xe.GetAttribute("Id");
                sc.Name = xe.GetAttribute("Name");
                sc.Summary = xe.GetAttribute("Summary");

            }//*/
        }
        #endregion
        static System.Windows.Media.Brush string2Brush(string color)
        {
            Color clr = ColorTranslator.FromHtml(color);
            return
                new System.Windows.Media.SolidColorBrush(
                    System.Windows.Media.Color.FromArgb(
                        clr.A,
                        clr.R,
                        clr.G,
                        clr.B
                        )
                    );
        }

        static Thickness string2Thickness(string margin)
        {
            string[] a = margin.Split(',');
            double[] b = new double[] { 0, 0, 0, 0 };
            for (int i = 0; i < a.Length; i++)
            {
                b[i] = Convert.ToDouble(a[i]);
            }
            return new Thickness(b[0], b[1], b[2], b[3]);
        }






        static void Skirmish()
        {
            MemIniFile skir = new MemIniFile();
            skir.LoadFromFile(@"Resource\Configs\Skirmish.ini");
            InitConf.TeamNum = skir.ReadValue("SKIRMISH", "TeamNum", 4);
            InitConf.ColorNum = skir.ReadValue("SKIRMISH", "Side", 8);
            InitConf.SideNum = skir.ReadValue("SKIRMISH", "Color", 12);
            SkirmishSide(skir);
            SkirmishColor(skir);

        }
        static void SkirmishSide(MemIniFile skir)
        {
            for (int i = 0; i <= InitConf.SideNum; i++) 
            {
                string Value = skir.ReadValue("SIDE", i.ToString(), "");
                if (RandomCheck(Value))
                {
                    string[] maxMin;
                    maxMin = Value.Split('-');
                    Format1 format = new Format1
                    {
                        Num = Convert.ToInt16(maxMin[0]),
                        Max = Convert.ToInt16(maxMin[1]),
                        Readom = true
                    };

                    SkirConf.Side.Add(format);
                }
                else
                {
                    Format1 format = new Format1
                    {
                        Num = Convert.ToInt16(Value),
                        Max = null,
                        Readom = false
                    };
                    SkirConf.Side.Add(format);
                }
            }
        }
        static void SkirmishColor(MemIniFile skir)
        {
            for (int i = 0; i <= InitConf.ColorNum; i++)
            {
                string Value = skir.ReadValue("COLOR", i.ToString(), "");
                if (RandomCheck(Value))
                {
                    string[] maxMin;
                    maxMin = Value.Split('-');
                    Format1 format = new Format1
                    {
                        Num = Convert.ToInt16(maxMin[0]),
                        Max = Convert.ToInt16(maxMin[1]),
                        Readom = true
                    };
                    SkirConf.Color.Add(format);
                }
                else
                {
                    Format1 format = new Format1
                    {
                        Num = Convert.ToInt16(Value),
                        Max = null,
                        Readom = false
                    };
                    SkirConf.Color.Add(format);
                }
            }
        }
        static bool RandomCheck(string Value)
        {
            if (Value.IndexOf("-") < 0)
                return false;
            else return true;
        }
    }
}
