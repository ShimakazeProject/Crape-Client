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

namespace Crape_Client.Windows
{
    /// <summary>
    /// Initialization.xaml 的交互逻辑
    /// </summary>
    public partial class InitializationWindow : Window
    {
        public InitializationWindow()
        {
            InitializeComponent();
            Activated += Init;
        }
        [STAThread]
        public void Init(object sender, EventArgs e)
        {
            /*
            #region 
            System.Threading.Thread.Sleep(1000);
            tbStatus.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = ".",
            });

            System.Threading.Thread.Sleep(1000);
            tbStatus.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = ".",
            });
            System.Threading.Thread.Sleep(1000);
            tbStatus.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = ".",
            });
            System.Threading.Thread.Sleep(1000);
            #endregion
            //tbStatus.Text = "初始化日志系统";
            tbStatus.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = "\nInitializing LOG System\t",
            });
            Globals.LogMGR = new CrapeClientCore.LogMGR();
            //tbStatus.Text = "初始化首选项";
            tbStatus.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = "Over\nInitializing Settings\t",
            });
            new Renderer();

            Globals.MissionConfig.LoadFromFile(Globals.ConfigsDir + "Missions.ini");
            Globals.MainConfig.LoadFromFile(Globals.ConfigsDir + "Config.conf");
            Globals.Ra2mdConf.LoadFromFile(Globals.LocalPath + "ra2md.ini");

            tbStatus.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = "Over\nInitializing GUI\t\t",
            });
            new GUIconfigs();
            tbStatus.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = "Over\nInitializing Saved List\t",
            });
            new SaveLoadList();
            new ColorInit();
            new SideInit();
            // tbStatus.Text = "初始化任务列表";
            tbStatus.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = "Over\nInitializing Mission List\t",
            });
            new Mission();// 初始化列表
            //tbStatus.Text = "初始化完成";
            tbStatus.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = "Over\nInitialization Is Over.",
            });
            System.Threading.Thread.Sleep(1000);
            //MessageBox.Show("在这停顿");
            System.Diagnostics.Debug.WriteLine("载入窗口关闭");
            //*/
            Close();
        }

    }
}
