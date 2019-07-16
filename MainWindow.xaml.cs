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
            InitializeComponent();
        }
        #region 任务列表
        void LoadMissions()// 加载任务列表
        {
            IniAnalyze.MessionAnalyze();
            #region 生成列表
            try
            {
                string[] side0 = IniAnalyze.MissionSideAnalyze.side0.ToArray();
                string[] name = IniAnalyze.MissionSideName.side0.ToArray();
                for (uint i = 0; i < side0.Length; i++)
                {
                    dgMessionSeleted.Items.Add(new Mession {
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
                    dgMessionSeleted.Items.Add(new Mession
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
                    dgMessionSeleted.Items.Add(new Mession {
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
                    dgMessionSeleted.Items.Add(new Mession
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
                    dgMessionSeleted.Items.Add(new Mession {
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
                    dgMessionSeleted.Items.Add(new Mession
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
                    dgMessionSeleted.Items.Add(new Mession {
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
                    dgMessionSeleted.Items.Add(new Mession
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
                    dgMessionSeleted.Items.Add(new Mession { Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side4.png"), Name = side1[i], OriginalName = name[i], });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side1 = IniAnalyze.MissionSideAnalyze.side4.ToArray();
                string[] name = IniAnalyze.MissionSideName.side4.ToArray();
                for (uint i = 0; i < side1.Length; i++)
                {
                    dgMessionSeleted.Items.Add(new Mession {
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
                    dgMessionSeleted.Items.Add(new Mession {
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
                    dgMessionSeleted.Items.Add(new Mession {
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
                    dgMessionSeleted.Items.Add(new Mession {
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
                    dgMessionSeleted.Items.Add(new Mession {
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
                    dgMessionSeleted.Items.Add(new Mession {
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
                    dgMessionSeleted.Items.Add(new Mession {
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
                    dgMessionSeleted.Items.Add(new Mession { Ico = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Images\Side8.png"), Name = side8[i], OriginalName = name[i], });
                }
            }
            catch (FileNotFoundException)
            {
                string[] side8 = IniAnalyze.MissionSideAnalyze.side8.ToArray();
                string[] name = IniAnalyze.MissionSideName.side8.ToArray();
                for (uint i = 0; i < side8.Length; i++)
                {
                    dgMessionSeleted.Items.Add(new Mession {
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
                    dgMessionSeleted.Items.Add(new Mession {
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
                    dgMessionSeleted.Items.Add(new Mession {
                        Ico = null,
                        Name = side9[i], OriginalName = name[i], });
                }
            }
            #endregion
        }

        private void MessionSeleted(object sender, SelectionChangedEventArgs e)
        {
            IniEdit iniEdit = new IniEdit(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Configs\Missions.ini");
            // MessageBox.Show(dgMessionSeleted.SelectedItem.ToString());
            Mession Mession = dgMessionSeleted.SelectedItem as Mession;
            if (Mession != null && Mession is Mession)
            {
                string Summary = iniEdit.IniReadValue(Mession.OriginalName, "Summary");
                MissionSummary.Text = Program.Program.SummaryInit(Summary);

                //iniEdit.IniReadValue(Mession.Name);
                /*
                MessageBox.Show("存档名：" + Mession.Name +
                    "\n\n" + "日期：" + Mession.Data + "\n\n" +
                    "文件名：" + Mession.FileN);//*/


            }
        }
        private void MissionRun(object sender, RoutedEventArgs e)
        {
            Mession Mession = dgMessionSeleted.SelectedItem as Mession;
            if (Mession != null && Mession is Mession)
            {

                MessageBox.Show(
                    "任务: \"" + Mession.Name +
                    "\"\n任务文件名: " + Mession.OriginalName,
                    "信息", MessageBoxButton.OK
                    );
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
        void LoadSave()// 加载存档列表
        {
            // AppDomain.CurrentDomain.BaseDirectory
            DirectoryInfo folder = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Saved Games");
            try
            {
                foreach (FileInfo file in folder.GetFiles("*.sav"))
                {
                    //Console.WriteLine(file.FullName);
                    dgLoadList.Items.Add(new Cls_SaveFiles {
                        Name = GameSaveFile.LoadSaveName(File.ReadAllBytes(file.FullName)),
                        Date = file.LastWriteTime.ToString(),
                        FileN = file.Name
                    });// FullName?
                }
            }
            catch (DirectoryNotFoundException)
            {
                dgLoadList.Items.Add(new {
                    Name = "没有发现可用存档", Data = "Null", FileN = "" });
            }
        }
        private void LoadSave(object sender, MouseButtonEventArgs e)
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
                //*/
            }

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
                dgMessionSeleted.Items.Clear();
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


    }


}
