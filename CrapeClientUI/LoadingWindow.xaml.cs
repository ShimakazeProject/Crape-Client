using System;
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
using System.Windows.Shapes;
using Crape_Client.CrapeClientCore;
using System.IO;


namespace Crape_Client.CrapeClientUI
{
    /// <summary>
    /// LoadingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            InitializeComponent();
        }

        private void LoadingWindowInit(object sender, EventArgs e)
        {
        }

        void InitWindows()
        {
            System.Threading.Thread.Sleep(1000);
            tbStatus.Text = "正在准备初始化";
            System.Threading.Thread.Sleep(1000);
            tbStatus.Text = "初始化日志系统";
            Nlog.NLogInit();
            tbStatus.Text = "初始化设置";
            Global.MissionConfig.LoadFromFile(Global.LocalPath + Global.ConfigsDir + "Missions.ini");
            Global.MainConfig.LoadFromFile(Global.LocalPath + Global.ConfigsDir + "Config.conf");
            Global.Ra2mdConf.LoadFromFile(Global.LocalPath + "ra2md.ini");
            tbStatus.Text = "初始化存档列表";
            Initialization.SavesListInit();
            tbStatus.Text = "初始化任务列表";
            Initialization.MissionConfigAnalyze();// 初始化列表
            tbStatus.Text = "初始化GUI";
            Initialization.MainWindowInit();
            tbStatus.Text = "初始化完成";
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
        private void LoadingWindowInit(object sender, RoutedEventArgs e)
        {
            InitWindows();
        }
    }
}
