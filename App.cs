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
        [STAThread] static void Main()
        {
            Application app = new Application
            {
                // 定义Application对象作为整个应用程序入口  
                Resources = new ResourceDictionary // 添加资源字典
                {
                    Source = new Uri("Style.xaml", UriKind.Relative)
                },
                ShutdownMode = ShutdownMode.OnExplicitShutdown// 不自动退出程序
            };
            //app.StartupUri = new Uri("/CrapeClientUI/Crape Client.xaml", UriKind.Relative);
            // 设定启动窗口URI
            CrapeClientUI.LoadingWindow loading = new CrapeClientUI.LoadingWindow();
            loading.ShowDialog();
            //loading.Init();// 激活初始化窗口实例
            CrapeClientUI.CrapeClient CC = new CrapeClientUI.CrapeClient();
            CC.ShowDialog();
            app.Shutdown();
            //application.Run();// 启动程序

        }
    }
}