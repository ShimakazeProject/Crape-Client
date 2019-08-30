using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
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
    public partial class MainWindow : NavigationWindow //Window
    {
        public static NavigationWindow mainWindow;
        //public static Frame uiFrame;
        public MainWindow()
        {
            InitializationWindow IW = new InitializationWindow();
            IW.ShowDialog();
            InitializeComponent();
            Activated += MainWindow_Activated;
            //Content = ContentShow.MainMenu;
            Content = new MainMenu.MainMenu();
            mainWindow = this;
            //uiFrame = UIFrame; 
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
        }


    }
}
