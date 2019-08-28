using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crape_Client.Settings
{
    static class MainWindow
    {
        public static string L2DJsonPath { get; private set; }
        static MainWindow()
        {
            L2DJsonPath = @"Resource\Live2D\shizuku\shizuku.model.json";
        }
    }
}
