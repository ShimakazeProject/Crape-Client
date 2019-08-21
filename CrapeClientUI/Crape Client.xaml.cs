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
using Crape_Client.CrapeClientCore.Config;

namespace Crape_Client.CrapeClientUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CrapeMain
    {
        public CrapeMain()
        {
            InitializeComponent();
            // 设置窗口
            this.Height = UIconfig.MainWindow.Height;
            this.Width = UIconfig.MainWindow.Width;
            this.Title = UIconfig.MainWindow.Title;
            this.Background = UIconfig.MainWindow.Background;
            // 设置菜单框
            Menu.Height = UIconfig.MainWindow.Menu.Height;
            Menu.Width = UIconfig.MainWindow.Menu.Width;
            Menu.Margin = UIconfig.MainWindow.Menu.Margin;
            Canvas.SetTop(Logo, UIconfig.MainWindow.Menu.Logo.Top);
            Canvas.SetLeft(Logo, UIconfig.MainWindow.Menu.Logo.Left);
            Logo.Height = UIconfig.MainWindow.Menu.Logo.Height;
            Logo.Width = UIconfig.MainWindow.Menu.Logo.Width;
            TlogoS.Text = UIconfig.MainWindow.Menu.Logo.Text;
            TlogoB.Text = UIconfig.MainWindow.Menu.Logo.Text;
            Tlogo.Text = UIconfig.MainWindow.Menu.Logo.Text;
            #region 按钮
            Canvas.SetTop(bCampaign, UIconfig.MainWindow.Menu.Campaign.Top);
            Canvas.SetLeft(bCampaign, UIconfig.MainWindow.Menu.Campaign.Left);
            bCampaign.Width = UIconfig.MainWindow.Menu.Campaign.Width;
            bCampaign.Height = UIconfig.MainWindow.Menu.Campaign.Height;
            bCampaign.Content = UIconfig.MainWindow.Menu.Campaign.Content;
            bCampaign.DataContext = UIconfig.MainWindow.Menu.Campaign.DataContext;
            Canvas.SetTop(bSkirmish, UIconfig.MainWindow.Menu.Skirmish.Top);
            Canvas.SetLeft(bSkirmish, UIconfig.MainWindow.Menu.Skirmish.Left);
            bSkirmish.Width = UIconfig.MainWindow.Menu.Skirmish.Width;
            bSkirmish.Height = UIconfig.MainWindow.Menu.Campaign.Height;
            bSkirmish.Content = UIconfig.MainWindow.Menu.Skirmish.Content;
            bSkirmish.DataContext = UIconfig.MainWindow.Menu.Skirmish.DataContext;
            Canvas.SetTop(bLoadings, UIconfig.MainWindow.Menu.Loadings.Top);
            Canvas.SetLeft(bLoadings, UIconfig.MainWindow.Menu.Loadings.Left);
            bLoadings.Width = UIconfig.MainWindow.Menu.Loadings.Width;
            bLoadings.Height = UIconfig.MainWindow.Menu.Loadings.Height;
            bLoadings.Content = UIconfig.MainWindow.Menu.Loadings.Content;
            bLoadings.DataContext = UIconfig.MainWindow.Menu.Loadings.DataContext;
            Canvas.SetTop(bSettings, UIconfig.MainWindow.Menu.Settings.Top);
            Canvas.SetLeft(bSettings, UIconfig.MainWindow.Menu.Settings.Left);
            bSettings.Width = UIconfig.MainWindow.Menu.Settings.Width;
            bSettings.Height = UIconfig.MainWindow.Menu.Settings.Height;
            bSettings.Content = UIconfig.MainWindow.Menu.Settings.Content;
            bSettings.DataContext = UIconfig.MainWindow.Menu.Settings.DataContext;
            Canvas.SetBottom(bExit, UIconfig.MainWindow.Menu.Exit.Bottom);
            Canvas.SetLeft(bExit, UIconfig.MainWindow.Menu.Exit.Left);
            bExit.Width = UIconfig.MainWindow.Menu.Exit.Width;
            bExit.Height = UIconfig.MainWindow.Menu.Exit.Height;
            bExit.Content = UIconfig.MainWindow.Menu.Exit.Content;
            bExit.DataContext = UIconfig.MainWindow.Menu.Exit.DataContext;
            #endregion
            Canvas.SetTop(ClientFrame, UIconfig.MainWindow.Show.Top);
            Canvas.SetLeft(ClientFrame, UIconfig.MainWindow.Show.Left);
            ClientFrame.Height = UIconfig.MainWindow.Show.Height;
            ClientFrame.Width = UIconfig.MainWindow.Show.Width;

        }



        private void Exit(object sender, RoutedEventArgs e) /* 退出 */ {
            App.application.Shutdown(0);
            //Environment.Exit(0);
            Close();
        }

        private void Combat(object sender, RoutedEventArgs e) /* 战役 */{
            ClientFrame.Source = new Uri("/CrapeClientUI/Mission.xaml", UriKind.Relative); }
        private void Skirmish(object sender, RoutedEventArgs e) /* 遭遇战 */{
            ClientFrame.Source = new Uri("/Crape Client;component/CrapeClientUI/Skirmish.xaml", UriKind.Relative); }
        private void Loadings(object sender, RoutedEventArgs e)/* 载入 LoadSaveGames */{
            ClientFrame.Source = new Uri("/Crape Client;component/CrapeClientUI/LoadSaveGames.xaml", UriKind.Relative); }
        private void Settings(object sender, RoutedEventArgs e)/* 设置 */{
            ClientFrame.Source = new Uri("/Crape Client;component/CrapeClientUI/Settings.xaml", UriKind.Relative); }
        private void Website(object sender, RoutedEventArgs e)/* 浏览器 */{
            ClientFrame.Source = new Uri("https://www.baidu.com/");
        }
    }
}
