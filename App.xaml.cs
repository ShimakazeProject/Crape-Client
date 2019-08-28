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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Crape_Client
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
        }

        [STAThread]
        static void Main()
        {

            App app = new App()
            {
                // 定义Application对象作为整个应用程序入口  
                Resources = new ResourceDictionary // 添加资源字典
                {
                    Source = new Uri("Style.xaml", UriKind.Relative)
                },
                ShutdownMode = ShutdownMode.OnExplicitShutdown,// 不自动退出程序
                //StartupUri = new Uri("/CrapeClientUI/Crape Client.xaml", UriKind.Relative)
            };

            //Application app = new Application

            //*/
            /*
            CrapeClientUI.L2d l2dw = new CrapeClientUI.L2d();
            l2dw.ShowDialog();
            app.Shutdown();
            //*/
            // 设定启动窗口URI
            
            CrapeClientUI.LoadingWindow loading = new CrapeClientUI.LoadingWindow();
            loading.ShowDialog();
            CrapeClientUI.CrapeClient CC = new CrapeClientUI.CrapeClient();
            CC.ShowDialog();
            app.Shutdown();
            //*/
            //application.Run();// 启动程序

        }
    }
}
