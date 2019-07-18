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


        private void Exit(object sender, RoutedEventArgs e) /* 退出 */ { Environment.Exit(0); }

        private void Combat(object sender, RoutedEventArgs e) /* 战役 */{
            ClientFrame.Source = new Uri("/CrapeClientUI/Mission.xaml", UriKind.Relative); }
        private void Skirmish(object sender, RoutedEventArgs e) /* 遭遇战 */{
            ClientFrame.Source = new Uri("/Crape Client;component/CrapeClientUI/Skirmish.xaml", UriKind.Relative); }
        private void Loadings(object sender, RoutedEventArgs e)/* 载入 LoadSaveGames */{
            ClientFrame.Source = new Uri("/Crape Client;component/CrapeClientUI/LoadSaveGames.xaml", UriKind.Relative); }
        private void Settings_check(object sender, RoutedEventArgs e)/* 设置 */{
            ClientFrame.Source = new Uri("/Crape Client;component/CrapeClientUI/Settings.xaml", UriKind.Relative); }
    }
}
