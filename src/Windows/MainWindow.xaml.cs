using System;
using System.Collections.Generic;
using System.IO;
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
//using System.Windows.Shapes;
using L2DLib.Framework;
using L2DLib.Utility;

namespace Crape_Client.Windows
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Activated += MainWindow_Activated;
            Content = ContentShow.MainMenu;
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
        }


    }
    public class ContentShow
    {
        public static MainMenu.MainMenu MainMenu { get; private set; }
        public static Campaign.Campaign Campaign { get; private set; }
        static ContentShow()
        {
            MainMenu = new MainMenu.MainMenu();
            Campaign = new Campaign.Campaign();
        }
    }
}
