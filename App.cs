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
        [STAThread]

        static void Main()

        {

            // 定义Application对象作为整个应用程序入口  
            Application app = new Application();

            app.Resources = new ResourceDictionary
            {
                Source = new Uri("Style.xaml", UriKind.Relative)
            };
            // 通过Url的方式启动
            //app.StartupUri = new Uri("WindowGrid.xaml", UriKind.Relative);
            //app.Run();
            Initialization.LoadingWindow loadingWindow = new Initialization.LoadingWindow();
            

            loadingWindow.LoadWindowInit();

        }
    }
}
