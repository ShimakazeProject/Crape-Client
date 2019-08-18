using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Crape_Client.CrapeClientCore.Config
{
    public static class UIconfig
    {
        public class MainWindow
        {
            public static double Height { set; get; }
            public static double Width { set; get; }
            public static string Title { set; get; }
            public static Brush Background { set; get; }
            public class Menu
            {
                public static double Height { set; get; }
                public static double Width { set; get; }
                public static Thickness Margin { set; get; }

                public static MenuButton Campaign = new MenuButton();
                public static MenuButton Skirmish = new MenuButton();
                public static MenuButton Loadings = new MenuButton();
                public static MenuButton Settings = new MenuButton();
                public static class Logo
                {
                    public static double Left { set; get; }
                    public static double Top { set; get; }
                    public static double Height { set; get; }
                    public static double Width { set; get; }
                    public static string Text { set; get; }
                }
                public class MenuButton
                {
                    public double Left { set; get; }
                    public double Top { set; get; }
                    public double Width { set; get; }
                    public double Height { set; get; }
                    public string Content { set; get; }
                    public string DataContext { set; get; }
                }
                public class Exit
                {
                    public static double Left { set; get; }
                    public static double Bottom { set; get; }
                    public static double Width { set; get; }
                    public static double Height { set; get; }
                    public static string Content { set; get; }
                    public static string DataContext { set; get; }
                }
            }
            public class Show {
                public static double Left { set; get; }
                public static double Top { set; get; }
                public static double Width { set; get; }
                public static double Height { set; get; }
            }
        }
    }
}
