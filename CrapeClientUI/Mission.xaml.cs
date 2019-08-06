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
            IniAnalyze.MissionAnalyze();// 初始化列表
            InitializeComponent();
            sDifficulty.Value = Ra2md.Options.Difficulty();
            #region 列表
            string[] side;
            string[] name;
            side = IniAnalyze.MissionSideAnalyze.side0.ToArray();
            name = IniAnalyze.MissionSideName.side0.ToArray();
            Initialization(side, name,0);
            side = IniAnalyze.MissionSideAnalyze.side1.ToArray();
            name = IniAnalyze.MissionSideName.side1.ToArray();
            Initialization(side, name, 1);
            side = IniAnalyze.MissionSideAnalyze.side2.ToArray();
            name = IniAnalyze.MissionSideName.side2.ToArray();
            Initialization(side, name, 2);
            side = IniAnalyze.MissionSideAnalyze.side3.ToArray();
            name = IniAnalyze.MissionSideName.side3.ToArray();
            Initialization(side, name, 3);
            side = IniAnalyze.MissionSideAnalyze.side4.ToArray();
            name = IniAnalyze.MissionSideName.side4.ToArray();
            Initialization(side, name, 4);
            side = IniAnalyze.MissionSideAnalyze.side5.ToArray();
            name = IniAnalyze.MissionSideName.side5.ToArray();
            Initialization(side, name, 5);
            side = IniAnalyze.MissionSideAnalyze.side6.ToArray();
            name = IniAnalyze.MissionSideName.side6.ToArray();
            Initialization(side, name, 6);
            side = IniAnalyze.MissionSideAnalyze.side7.ToArray();
            name = IniAnalyze.MissionSideName.side7.ToArray();
            Initialization(side, name, 7);
            side = IniAnalyze.MissionSideAnalyze.side8.ToArray();
            name = IniAnalyze.MissionSideName.side8.ToArray();
            Initialization(side, name, 8);
            side = IniAnalyze.MissionSideAnalyze.side9.ToArray();
            name = IniAnalyze.MissionSideName.side9.ToArray();
            Initialization(side, name, 9);
            #endregion

        }
        #region 任务列表
        void Initialization(string[] side, string[] name,int sidenum)// 加载任务列表
        {
            for (uint i = 0; i < side.Length; i++)
            {
                try
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side"+sidenum.ToString()+".png"),
                        Name = side[i],
                        OriginalName = name[i],
                    });
                }
                catch (FileNotFoundException)
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = null,
                        Name = side[i],
                        OriginalName = name[i]
                    });
                }
            }
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
                spawn.Settings.GameSpeed = 2; // 任务速度恒等于4
                spawn.Settings.IsSinglePlayer = true; // 这不废话嘛
                spawn.Settings.Side = Convert.ToByte(Missions.IniReadValue(mission.OriginalName, "Side"));
                spawn.Settings.Firestorm = IniTools.BoolCheck(Missions.IniReadValue(mission.OriginalName, "Firestorm"));
                spawn.Settings.SidebarHack = IniTools.BoolCheck(Missions.IniReadValue(mission.OriginalName, "SidebarHack"));
                spawn.Settings.BuildOffAlly = IniTools.BoolCheck(Missions.IniReadValue(mission.OriginalName, "BuildOffAlly"));
                // 反正我是留了..能不能用就不知道了
                spawn.Settings.MultiEngineer = IniTools.BoolCheck(Missions.IniReadValue(mission.OriginalName, "MultiEngineer"));
                spawn.Settings.MCVRedeploy = IniTools.BoolCheck(Missions.IniReadValue(mission.OriginalName, "MCVRedeploy"));
                spawn.Settings.FogOfWar = IniTools.BoolCheck(Missions.IniReadValue(mission.OriginalName, "FogOfWar"));
                spawn.Settings.BridgeDestroy = IniTools.BoolCheck(Missions.IniReadValue(mission.OriginalName, "BridgeDestroy"));
                spawn.Settings.SkipScoreScreen = IniTools.BoolCheck(Missions.IniReadValue(mission.OriginalName, "SkipScoreScreen"));
                spawn.Settings.AttackNeutralUnits = IniTools.BoolCheck(Missions.IniReadValue(mission.OriginalName, "AttackNeutralUnits"));

                spawn.Settings.DifficultyModeHuman = 0;
                spawn.Settings.DifficultyModeComputer = 2;
                spawn.Write();
                Program.Program.RunSyringe();
            }
        }
        #endregion

        private void Difficulty(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int Value = (int)sDifficulty.Value;
            Ra2md.Options.Difficulty(Value);
            sDifficulty.Value = Value;
        }
    }
}
