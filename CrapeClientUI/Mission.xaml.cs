using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Program;
using RA2.Ini;

namespace Crape_Client.CrapeClientUI
{
    /// <summary>
    /// Mission.xaml 的交互逻辑
    /// </summary>
    public partial class Mission : Page
    {
        public Mission()
        {
            InitializeComponent();
            Initialization();
        }
        #region 任务列表
        void Initialization()// 加载任务列表
        {
            IniAnalyze.MissionAnalyze();
            #region 生成列表
            try
            {
                string[] side0 = IniAnalyze.MissionSideAnalyze.side0.ToArray();
                string[] name = IniAnalyze.MissionSideName.side0.ToArray();
                for (uint i = 0; i < side0.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side0.png"),
                        Name = side0[i],
                        OriginalName = name[i],
                    });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side0 = IniAnalyze.MissionSideAnalyze.side0.ToArray();
                string[] name = IniAnalyze.MissionSideName.side0.ToArray();
                for (uint i = 0; i < side0.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = null,
                        Name = side0[i],
                        OriginalName = name[i]
                   ,
                    });
                }
            }
            try
            {
                string[] side1 = IniAnalyze.MissionSideAnalyze.side1.ToArray();
                string[] name = IniAnalyze.MissionSideName.side1.ToArray();
                for (uint i = 0; i < side1.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side1.png"),
                        Name = side1[i],
                        OriginalName = name[i],
                    });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side1 = IniAnalyze.MissionSideAnalyze.side1.ToArray();
                string[] name = IniAnalyze.MissionSideName.side1.ToArray();
                for (uint i = 0; i < side1.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = null,
                        Name = side1[i],
                        OriginalName = name[i]
                   ,
                    });
                }
            }
            try
            {
                string[] side1 = IniAnalyze.MissionSideAnalyze.side2.ToArray();
                string[] name = IniAnalyze.MissionSideName.side2.ToArray();
                for (uint i = 0; i < side1.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side2.png"),
                        Name = side1[i],
                        OriginalName = name[i],
                    });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side1 = IniAnalyze.MissionSideAnalyze.side2.ToArray();
                string[] name = IniAnalyze.MissionSideName.side2.ToArray();
                for (uint i = 0; i < side1.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = null,
                        Name = side1[i],
                        OriginalName = name[i]
                   ,
                    });
                }
            }
            try
            {
                string[] side1 = IniAnalyze.MissionSideAnalyze.side3.ToArray();
                string[] name = IniAnalyze.MissionSideName.side3.ToArray();
                for (uint i = 0; i < side1.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side3.png"),
                        Name = side1[i],
                        OriginalName = name[i],
                    });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side1 = IniAnalyze.MissionSideAnalyze.side3.ToArray();
                string[] name = IniAnalyze.MissionSideName.side3.ToArray();
                for (uint i = 0; i < side1.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = null,
                        Name = side1[i],
                        OriginalName = name[i]
                   ,
                    });
                }
            }
            try
            {
                string[] side1 = IniAnalyze.MissionSideAnalyze.side4.ToArray();
                string[] name = IniAnalyze.MissionSideName.side4.ToArray();
                for (uint i = 0; i < side1.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new MissionList { Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side4.png"), Name = side1[i], OriginalName = name[i], });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side1 = IniAnalyze.MissionSideAnalyze.side4.ToArray();
                string[] name = IniAnalyze.MissionSideName.side4.ToArray();
                for (uint i = 0; i < side1.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = null,
                        Name = side1[i],
                        OriginalName = name[i],
                    });
                }
            }
            try
            {
                string[] side5 = IniAnalyze.MissionSideAnalyze.side5.ToArray();
                string[] name = IniAnalyze.MissionSideName.side5.ToArray();
                for (uint i = 0; i < side5.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side5.png"),
                        Name = side5[i],
                        OriginalName = name[i],
                    });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side5 = IniAnalyze.MissionSideAnalyze.side5.ToArray();
                string[] name = IniAnalyze.MissionSideName.side5.ToArray();
                for (uint i = 0; i < side5.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = null,
                        Name = side5[i],
                        OriginalName = name[i],
                    });
                }
            }
            try
            {
                string[] side6 = IniAnalyze.MissionSideAnalyze.side6.ToArray();
                string[] name = IniAnalyze.MissionSideName.side6.ToArray();
                for (uint i = 0; i < side6.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side6.png"),
                        Name = side6[i],
                        OriginalName = name[i],
                    });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side6 = IniAnalyze.MissionSideAnalyze.side6.ToArray();
                string[] name = IniAnalyze.MissionSideName.side6.ToArray();
                for (uint i = 0; i < side6.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = null,
                        Name = side6[i],
                        OriginalName = name[i],
                    });
                }
            }
            try
            {
                string[] side7 = IniAnalyze.MissionSideAnalyze.side7.ToArray();
                string[] name = IniAnalyze.MissionSideName.side7.ToArray();
                for (uint i = 0; i < side7.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side7.png"),
                        Name = side7[i],
                        OriginalName = name[i],
                    });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side7 = IniAnalyze.MissionSideAnalyze.side7.ToArray();
                string[] name = IniAnalyze.MissionSideName.side7.ToArray();
                for (uint i = 0; i < side7.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = null,
                        Name = side7[i],
                        OriginalName = name[i],
                    });
                }
            }
            try
            {
                string[] side8 = IniAnalyze.MissionSideAnalyze.side8.ToArray();
                string[] name = IniAnalyze.MissionSideName.side8.ToArray();
                for (uint i = 0; i < side8.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new MissionList { Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side8.png"), Name = side8[i], OriginalName = name[i], });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side8 = IniAnalyze.MissionSideAnalyze.side8.ToArray();
                string[] name = IniAnalyze.MissionSideName.side8.ToArray();
                for (uint i = 0; i < side8.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = null,
                        Name = side8[i],
                        OriginalName = name[i],
                    });
                }
            }
            try
            {
                string[] side9 = IniAnalyze.MissionSideAnalyze.side9.ToArray();
                string[] name = IniAnalyze.MissionSideName.side9.ToArray();
                for (uint i = 0; i < side9.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side9.png"),
                        Name = side9[i],
                        OriginalName = name[i],
                    });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side9 = IniAnalyze.MissionSideAnalyze.side9.ToArray();
                string[] name = IniAnalyze.MissionSideName.side9.ToArray();
                for (uint i = 0; i < side9.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = null,
                        Name = side9[i],
                        OriginalName = name[i],
                    });
                }
            }
            #endregion
        }
        IniEdit Missions = new IniEdit(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Configs\Missions.ini");
        private void MissionSeleted(object sender, SelectionChangedEventArgs e)
        {
            // MessageBox.Show(dgMissionSeleted.SelectedItem.ToString());
            MissionList mission = dgMissionSeleted.SelectedItem as MissionList;
            if (mission != null && mission is MissionList)
            {
                string Summary = Missions.IniReadValue(mission.OriginalName, "Summary");
                MissionSummary.Text = Program.Program.SummaryInit(Summary);
            }
        }
        private void MissionRun(object sender, RoutedEventArgs e)
        {
            MissionList mission = dgMissionSeleted.SelectedItem as MissionList;
            if (mission != null && mission is MissionList)
            {
                Spawn spawn = new Spawn();
                spawn.Settings.Scenario = mission.Name;
                spawn.Settings.GameSpeed = 6;
                spawn.Settings.Firestorm = false;
                spawn.Settings.IsSinglePlayer = true;
                spawn.Settings.SidebarHack = false;
                spawn.Settings.Side = Convert.ToByte(Missions.IniReadValue(mission.OriginalName, "Side"));
                spawn.Settings.BuildOffAlly = true;
                spawn.Settings.DifficultyModeHuman = 0;
                spawn.Settings.DifficultyModeComputer = 2;
                spawn.Write();
                Program.Program.RunSyringe();
            }
        }
        #endregion
    }
}
