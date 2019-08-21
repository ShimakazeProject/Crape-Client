using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Crape_Client
{
    class App: Application
    {
        public static Application application = new Application();
        
        [STAThread] static void Main()
        {
            // 定义Application对象作为整个应用程序入口  
            application.Resources = new ResourceDictionary // 添加资源字典
            {
                Source = new Uri("Style.xaml", UriKind.Relative)
            };
            application.ShutdownMode = ShutdownMode.OnExplicitShutdown;// 不自动退出程序
            application.StartupUri = new Uri("/CrapeClientUI/Crape Client.xaml", UriKind.Relative);// 设定启动窗口URI
            CrapeClientUI.LoadingWindow loadingWindow = new CrapeClientUI.LoadingWindow();// 实例化初始化窗口
            loadingWindow.LoadWindowInit();// 激活初始化窗口实例
            application.Run();// 启动程序

        }
    }
}