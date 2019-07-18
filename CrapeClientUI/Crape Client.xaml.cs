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

namespace Crape_Client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            Nlog.NLogInit();
            InitializeComponent();

        }
        #region 任务列表
        void LoadMissions()// 加载任务列表
        {
            IniAnalyze.MissionAnalyze();
            #region 生成列表
            try
            {
                string[] side0 = IniAnalyze.MissionSideAnalyze.side0.ToArray();
                string[] name = IniAnalyze.MissionSideName.side0.ToArray();
                for (uint i = 0; i < side0.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new Mission {
                        Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side0.png"),
                        Name = side0[i],
                        OriginalName = name[i],
                         });
                }
            }
            catch(FileNotFoundException)
            {
                string[] side0 = IniAnalyze.MissionSideAnalyze.side0.ToArray();
                string[] name = IniAnalyze.MissionSideName.side0.ToArray();
                for (uint i = 0; i < side0.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new Mission
                    {
                        Ico = null,
                        Name = side0[i],
                        OriginalName = name[i]
                   , });
                }
            }
            try
            {
                string[] side1 = IniAnalyze.MissionSideAnalyze.side1.ToArray();
                string[] name = IniAnalyze.MissionSideName.side1.ToArray();
                for (uint i = 0; i < side1.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new Mission {
                        Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side1.png"),
                        Name = side1[i],
                        OriginalName = name[i], });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side1 = IniAnalyze.MissionSideAnalyze.side1.ToArray();
                string[] name = IniAnalyze.MissionSideName.side1.ToArray();
                for (uint i = 0; i < side1.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new Mission
                    {
                        Ico = null,
                        Name = side1[i],
                        OriginalName = name[i]
                   , });
                }
            }
            try
            {
                string[] side1 = IniAnalyze.MissionSideAnalyze.side2.ToArray();
                string[] name = IniAnalyze.MissionSideName.side2.ToArray();
                for (uint i = 0; i < side1.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new Mission {
                        Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side2.png"),
                        Name = side1[i],
                        OriginalName = name[i], });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side1 = IniAnalyze.MissionSideAnalyze.side2.ToArray();
                string[] name = IniAnalyze.MissionSideName.side2.ToArray();
                for (uint i = 0; i < side1.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new Mission
                    {
                        Ico = null,
                        Name = side1[i],
                        OriginalName = name[i]
                   , });
                }
            }
            try
            {
                string[] side1 = IniAnalyze.MissionSideAnalyze.side3.ToArray();
                string[] name = IniAnalyze.MissionSideName.side3.ToArray();
                for (uint i = 0; i < side1.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new Mission {
                        Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side3.png"),
                        Name = side1[i],
                        OriginalName = name[i], });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side1 = IniAnalyze.MissionSideAnalyze.side3.ToArray();
                string[] name = IniAnalyze.MissionSideName.side3.ToArray();
                for (uint i = 0; i < side1.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new Mission
                    {
                        Ico = null,
                        Name = side1[i],
                        OriginalName = name[i]
                   , });
                }
            }
            try
            {
                string[] side1 = IniAnalyze.MissionSideAnalyze.side4.ToArray();
                string[] name = IniAnalyze.MissionSideName.side4.ToArray();
                for (uint i = 0; i < side1.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new Mission { Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side4.png"), Name = side1[i], OriginalName = name[i], });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side1 = IniAnalyze.MissionSideAnalyze.side4.ToArray();
                string[] name = IniAnalyze.MissionSideName.side4.ToArray();
                for (uint i = 0; i < side1.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new Mission {
                        Ico = null,
                        Name = side1[i], OriginalName = name[i], });
                }
            }
            try
            {
                string[] side5 = IniAnalyze.MissionSideAnalyze.side5.ToArray();
                string[] name = IniAnalyze.MissionSideName.side5.ToArray();
                for (uint i = 0; i < side5.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new Mission {
                        Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side5.png"),
                        Name = side5[i], OriginalName = name[i], });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side5 = IniAnalyze.MissionSideAnalyze.side5.ToArray();
                string[] name = IniAnalyze.MissionSideName.side5.ToArray();
                for (uint i = 0; i < side5.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new Mission {
                        Ico = null,
                        Name = side5[i], OriginalName = name[i], });
                }
            }
            try
            {
                string[] side6 = IniAnalyze.MissionSideAnalyze.side6.ToArray();
                string[] name = IniAnalyze.MissionSideName.side6.ToArray();
                for (uint i = 0; i < side6.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new Mission {
                        Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side6.png"),
                        Name = side6[i], OriginalName = name[i], });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side6 = IniAnalyze.MissionSideAnalyze.side6.ToArray();
                string[] name = IniAnalyze.MissionSideName.side6.ToArray();
                for (uint i = 0; i < side6.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new Mission {
                        Ico = null,
                        Name = side6[i], OriginalName = name[i], });
                }
            }
            try
            {
                string[] side7 = IniAnalyze.MissionSideAnalyze.side7.ToArray();
                string[] name = IniAnalyze.MissionSideName.side7.ToArray();
                for (uint i = 0; i < side7.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new Mission {
                        Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side7.png"),
                        Name = side7[i], OriginalName = name[i], });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side7 = IniAnalyze.MissionSideAnalyze.side7.ToArray();
                string[] name = IniAnalyze.MissionSideName.side7.ToArray();
                for (uint i = 0; i < side7.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new Mission {
                        Ico = null,
                        Name = side7[i], OriginalName = name[i], });
                }
            }
            try
            {
                string[] side8 = IniAnalyze.MissionSideAnalyze.side8.ToArray();
                string[] name = IniAnalyze.MissionSideName.side8.ToArray();
                for (uint i = 0; i < side8.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new Mission { Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side8.png"), Name = side8[i], OriginalName = name[i], });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side8 = IniAnalyze.MissionSideAnalyze.side8.ToArray();
                string[] name = IniAnalyze.MissionSideName.side8.ToArray();
                for (uint i = 0; i < side8.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new Mission {
                        Ico = null,
                        Name = side8[i], OriginalName = name[i], });
                }
            }
            try
            {
                string[] side9 = IniAnalyze.MissionSideAnalyze.side9.ToArray();
                string[] name = IniAnalyze.MissionSideName.side9.ToArray();
                for (uint i = 0; i < side9.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new Mission {
                        Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side9.png"),
                        Name = side9[i], OriginalName = name[i], });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side9 = IniAnalyze.MissionSideAnalyze.side9.ToArray();
                string[] name = IniAnalyze.MissionSideName.side9.ToArray();
                for (uint i = 0; i < side9.Length; i++)
                {
                    dgMissionSeleted.Items.Add(new Mission {
                        Ico = null,
                        Name = side9[i], OriginalName = name[i], });
                }
            }
            #endregion
        }
        IniEdit Missions = new IniEdit(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Configs\Missions.ini");
        private void MissionSeleted(object sender, SelectionChangedEventArgs e)
        {
            // MessageBox.Show(dgMissionSeleted.SelectedItem.ToString());
            Mission mission = dgMissionSeleted.SelectedItem as Mission;
            if (Mission != null && mission is Mission)
            {
                string Summary = Missions.IniReadValue(mission.OriginalName, "Summary");
                MissionSummary.Text = Program.Program.SummaryInit(Summary);
            }
        }
        private void MissionRun(object sender, RoutedEventArgs e)
        {
            Mission mission = dgMissionSeleted.SelectedItem as Mission;
            if (mission != null && mission is Mission)
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
        #region 存档列表
        void LoadSave()// 加载存档列表
        {
            // AppDomain.CurrentDomain.BaseDirectory
            DirectoryInfo folder = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Saved Games");
            try
            {
                foreach (FileInfo file in folder.GetFiles("*.sav"))
                {
                    //Console.WriteLine(file.FullName);
                    dgLoadList.Items.Add(new Cls_SaveFiles
                    {
                        Name = GameSaveFile.LoadSaveName(File.ReadAllBytes(file.FullName)),
                        Date = file.LastWriteTime.ToString(),
                        FileN = file.Name
                    });// FullName?
                }
            }
            catch (DirectoryNotFoundException)
            {
                dgLoadList.Items.Add(new
                {
                    Name = "没有发现可用存档",
                    Data = "Null",
                    FileN = ""
                });
            }
        }
        private void LoadSave(object sender, MouseButtonEventArgs e)// 双击列表项
        {
            Spawn spawn = new Spawn();
            Cls_SaveFiles LoadSaveName = dgLoadList.SelectedItem as Cls_SaveFiles;
            if (LoadSaveName != null && LoadSaveName is Cls_SaveFiles)
            {
                //*
                spawn.Settings.LoadSaveGame = true;
                spawn.Settings.SaveGameName = LoadSaveName.FileN;
                spawn.Settings.GameSpeed = 1;
                spawn.Settings.Firestorm = false;
                spawn.Settings.SidebarHack = false;
                spawn.Write();
                Program.Program.RunSyringe();

                //*/
            }

        }
        #endregion


        #region 方法们
        void LoadMaps()// 加载地图列表
        {
            dgMapList.Items.Add(new MapList { Ico = null, Name = "Hello" });
            dgMapList.Items.Add(new MapList { Ico = null, Name = "guten Tag" });
            dgMapList.Items.Add(new MapList { Ico = null, Name = "Bonjour" });
            dgMapList.Items.Add(new MapList { Ico = null, Name = "こんにちわ" });
        }

        #endregion

        private void DMSkinWindow_Loaded(object sender, RoutedEventArgs e){
        }
        private void Exit(object sender, RoutedEventArgs e) /* 退出 */ { Environment.Exit(0); }
        private void Combat_check(object sender, RoutedEventArgs e) // 战役
        {
            if (rbmCombat.IsChecked == true)
            {
                LoadMissions();
                this.Mission.Visibility = Visibility.Visible;
            }
            else
            {
                this.Mission.Visibility = Visibility.Hidden;
                IniAnalyze.MissionSideAnalyze.Clear();
                IniAnalyze.MissionSideName.Clear();
                dgMissionSeleted.Items.Clear();
            }
        }
        private void Encounter_check(object sender, RoutedEventArgs e)//遭遇战
        {
            if (rbmEncounter.IsChecked == true)
            {
                LoadMaps();
                this.遭遇战.Visibility = Visibility.Visible;
            }
            else
            {
                this.遭遇战.Visibility = Visibility.Hidden;
                dgMapList.Items.Clear();
            }
        }
        private void Loadings_check(object sender, RoutedEventArgs e)// 载入
        {
            if (rbmLoadSaves.IsChecked == true)
            {
                LoadSave();
                this.LoadSaveGame.Visibility = Visibility.Visible;
            }
            else
            {
                this.LoadSaveGame.Visibility = Visibility.Hidden;
                dgLoadList.Items.Clear();
            }
        }
        private void Settings_check(object sender, RoutedEventArgs e)// 设置
        {
            if (rbmSettings.IsChecked == true)
            {
                this.Settings.Visibility = Visibility.Visible;
            }
            else
            {
                this.Settings.Visibility = Visibility.Hidden;
            }
        }
        private void Normal_check(object sender, RoutedEventArgs e)// 欢迎界面
        {
            try
            {
                if (rbmNormal.IsChecked == true)
                {
                    this.Normal.Visibility = Visibility.Visible;
                }
                else
                {
                    this.Normal.Visibility = Visibility.Hidden;
                }
            }
            catch
            {
                return;
            }
        }
        private void WindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                if (Window.Width < 1175)
                {
                    gbSoundSettings.SetValue(Canvas.TopProperty, 472);
                    gbSoundSettings.SetValue(Canvas.LeftProperty, 10);
                }
                else
                {
                    gbSoundSettings.SetValue(Canvas.TopProperty, 10);
                    gbSoundSettings.SetValue(Canvas.LeftProperty, 485);
                }
            }
            catch { return; }
        }
        #region 设置
        #region BGM大小
        private void MusicSet0(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(0);
        }
        private void MusicSet1(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(0.1);
        }
        private void MusicSet2(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(0.2);
        }
        private void MusicSet3(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(0.3);
        }
        private void MusicSet4(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(0.4);
        }
        private void MusicSet5(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(0.5);
        }
        private void MusicSet6(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(0.6);
        }
        private void MusicSet7(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(0.7);
        }
        private void MusicSet8(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(0.8);
        }
        private void MusicSet9(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(0.9);
        }
        private void MusicSetX(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(1);
        }
        #endregion
        #region 音效大小
        private void ScoreSet0(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(0);
        }
        private void ScoreSet1(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(0.1);
        }
        private void ScoreSet2(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(0.2);
        }
        private void ScoreSet3(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(0.3);
        }
        private void ScoreSet4(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(0.4);
        }
        private void ScoreSet5(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(0.5);
        }
        private void ScoreSet6(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(0.6);
        }
        private void ScoreSet7(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(0.7);
        }
        private void ScoreSet8(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(0.8);
        }
        private void ScoreSet9(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(0.9);
        }
        private void ScoreSetX(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(1);
        }
        #endregion
        #region 语音大小
        private void VoiceSet0(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(0);
        }
        private void VoiceSet1(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(0.1);
        }
        private void VoiceSet2(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(0.2);
        }
        private void VoiceSet3(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(0.3);
        }
        private void VoiceSet4(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(0.4);
        }
        private void VoiceSet5(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(0.5);
        }
        private void VoiceSet6(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(0.6);
        }
        private void VoiceSet7(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(0.7);
        }
        private void VoiceSet8(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(0.8);
        }
        private void VoiceSet9(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(0.9);
        }
        private void VoiceSetX(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(1);
        }
        #endregion

        private void SetScreen(object sender, EventArgs e)/* 分辨率设置 */{
            try
            {
                string[] scr = cbScreen.SelectedItem.ToString().Split(':');
                scr = scr[1].Split('x');
                Ra2md.Video.ScreenWidth(Convert.ToInt32(scr[0]));
                Ra2md.Video.ScreenHeight(Convert.ToInt32(scr[1]));
            }
            catch(NullReferenceException)
            {
                return;
            }
        }

        private void SeletDetailLevel(object sender, EventArgs e)// 画质等级
        {
            if (cbDetailLevel.SelectedIndex < 3 && cbDetailLevel.SelectedIndex >= 0)
                Ra2md.Options.DetailLevel(cbDetailLevel.SelectedIndex);
        }
        private void IsWindowed(object sender, RoutedEventArgs e)// 窗口化
        {
            if (cbWindowed.IsChecked == true)
            {
                Ra2md.Video.Windowed(true);
                cbNoFrame.IsEnabled = true;
            }
            else if (cbWindowed.IsChecked == false)
            {
                Ra2md.Video.Windowed(false);
                cbNoFrame.IsEnabled = false;
            }
            else return;
        }
        private void IsNoFrame(object sender, RoutedEventArgs e)// 无边框
        {
            if (cbNoFrame.IsChecked == true)
                Ra2md.Video.NoWindowFrame(true);
            else if (cbNoFrame.IsChecked == false)
                Ra2md.Video.NoWindowFrame(false);
            else return;
        }
        private void VideoBackBuffer(object sender, RoutedEventArgs e)// 视频内存缓存
        {
            if (cbVideoBackBuffer.IsChecked == true)
                Ra2md.Video.VideoBackBuffer(true);
            else if (cbVideoBackBuffer.IsChecked == false)
                Ra2md.Video.VideoBackBuffer(false);
            else return;
        }
        private void IsShuffle(object sender, RoutedEventArgs e)// 随机音乐
        {
            if (cbShuffleMusic.IsChecked == true)
                Ra2md.Audio.IsScoreShuffle(true);
            else if (cbShuffleMusic.IsChecked == false)
                Ra2md.Audio.IsScoreShuffle(false);
            else return;
        }
        private void UnitActionLines(object sender, RoutedEventArgs e)// 显示目标线
        {
            if (cbUnitActionLines.IsChecked == true)
                Ra2md.Options.UnitActionLines(true);
            else if (cbUnitActionLines.IsChecked == false)
                Ra2md.Options.UnitActionLines(false);
            else return;
        }
        private void ShowHidden(object sender, RoutedEventArgs e)
        {
            if (cbShowHidden.IsChecked == true)
                Ra2md.Options.ShowHidden(true);
            else if (cbShowHidden.IsChecked == false)
                Ra2md.Options.ShowHidden(false);
            else return;
        }
        private void ScrollMethod(object sender, RoutedEventArgs e)
        {
            if (cbScrollMethod.IsChecked == true)
                Ra2md.Options.ScrollMethod(true);
            else if (cbScrollMethod.IsChecked == false)
                Ra2md.Options.ScrollMethod(false);
            else return;
        }
        private void ToolTips(object sender, RoutedEventArgs e)
        {
            if (cbToolTips.IsChecked == true)
                Ra2md.Options.ToolTips(true);
            else if (cbToolTips.IsChecked == false)
                Ra2md.Options.ToolTips(false);
            else return;
        }

        private void Handle(object sender, TextChangedEventArgs e)
        {
            Ra2md.MultiPlayer.Handle(tbHandle.Text);
        }
    }


}
#endregion