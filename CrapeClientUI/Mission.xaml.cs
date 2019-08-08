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
using Crape_Client.CrapeClientCore;
using Crape_Client;

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
            sDifficulty.Value = Ra2md.Options.Difficulty();
            DataGridInit(Initialization.NameList.Side0.ToArray(), Initialization.SectionNameList.Side0.ToArray(), 0);
            DataGridInit(Initialization.NameList.Side1.ToArray(), Initialization.SectionNameList.Side1.ToArray(), 1);
            DataGridInit(Initialization.NameList.Side2.ToArray(), Initialization.SectionNameList.Side2.ToArray(), 2);
            DataGridInit(Initialization.NameList.Side3.ToArray(), Initialization.SectionNameList.Side3.ToArray(), 3);
            DataGridInit(Initialization.NameList.Side4.ToArray(), Initialization.SectionNameList.Side4.ToArray(), 4);
            DataGridInit(Initialization.NameList.Side5.ToArray(), Initialization.SectionNameList.Side5.ToArray(), 5);
            DataGridInit(Initialization.NameList.Side6.ToArray(), Initialization.SectionNameList.Side6.ToArray(), 6);
            DataGridInit(Initialization.NameList.Side7.ToArray(), Initialization.SectionNameList.Side7.ToArray(), 7);
            DataGridInit(Initialization.NameList.Side8.ToArray(), Initialization.SectionNameList.Side8.ToArray(), 8);
            DataGridInit(Initialization.NameList.Side9.ToArray(), Initialization.SectionNameList.Side9.ToArray(), 9);

        }
        #region 任务列表
        void DataGridInit(string[] MissionName, string[] IdName,int Side)// 加载任务列表
        {
            for (uint i = 0; i < MissionName.Length; i++)
            {
                try
                {
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = File.ReadAllBytes(Global.LocalPath + Global.ImagesDir + "Side" + Side.ToString() + ".png"),
                        Name = MissionName[i],
                        OriginalName = IdName[i],
                    });
                }
                catch (FileNotFoundException e)
                {
                    Nlog.logger.Info(e.ToString() +"\r\n\tCannot Found Side"+Side.ToString()+".png");
                    dgMissionSeleted.Items.Add(new MissionList
                    {
                        Ico = null,
                        Name = MissionName[i],
                        OriginalName = IdName[i]
                    });
                }
                catch(Exception e)
                {
                    Nlog.logger.Error(e.ToString());
                }
            }
        }
        private void MissionSeleted(object sender, SelectionChangedEventArgs e)
        {
            // MessageBox.Show(dgMissionSeleted.SelectedItem.ToString());
            MissionList mission = dgMissionSeleted.SelectedItem as MissionList;
            if (mission != null && mission is MissionList)
            {
                string Summary = Global.MissionConfig.ReadValue(mission.OriginalName, "Summary", null);
                MissionSummary.Text = Program.SummaryInit(Summary);
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
                spawn.Settings.Side = Convert.ToByte(Global.MissionConfig.ReadValue(mission.OriginalName, "Side", 0));
                spawn.Settings.Firestorm = Global.MissionConfig.ReadValue(mission.OriginalName, "Firestorm", false);
                spawn.Settings.SidebarHack = Global.MissionConfig.ReadValue(mission.OriginalName, "SidebarHack", false);
                spawn.Settings.BuildOffAlly = Global.MissionConfig.ReadValue(mission.OriginalName, "BuildOffAlly", false);
                // 反正我是留了..能不能用就不知道了
                spawn.Settings.MultiEngineer = Global.MissionConfig.ReadValue(mission.OriginalName, "MultiEngineer", false);
                spawn.Settings.MCVRedeploy = Global.MissionConfig.ReadValue(mission.OriginalName, "MCVRedeploy", false);
                spawn.Settings.FogOfWar = Global.MissionConfig.ReadValue(mission.OriginalName, "FogOfWar", false);
                spawn.Settings.BridgeDestroy = Global.MissionConfig.ReadValue(mission.OriginalName, "BridgeDestroy", false);
                spawn.Settings.SkipScoreScreen = Global.MissionConfig.ReadValue(mission.OriginalName, "SkipScoreScreen", false);
                spawn.Settings.AttackNeutralUnits = Global.MissionConfig.ReadValue(mission.OriginalName, "AttackNeutralUnits", false);

                spawn.Settings.DifficultyModeHuman = 0;
                spawn.Settings.DifficultyModeComputer = 2;
                spawn.Write();
                Program.RunSyringe();
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
