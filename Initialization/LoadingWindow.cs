using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
//using System.Drawing;


namespace Crape_Client.Initialization
{
    class LoadingWindow
    {
        readonly Window Window = new Window();
        readonly Canvas Canvas = new Canvas();
        readonly TextBlock Status = new TextBlock
        {
            Name = "tbStatus"
        };

        static readonly string LogoStr = "Crape Client";
        static readonly double Width = 600;
        static readonly double Height = 400;
        static readonly double Left = 200;
        static readonly double FontSize = 28;
        public void LoadWindowInit()
        {
            // 主窗口创建
            Window.Title = "Crape Client 初始化";
            Window.Width = Width;
            Window.Height = Height;
            Window.Foreground = Tools.String2Brush("#FFF");
            Window.ResizeMode = ResizeMode.NoResize;
            Window.Style = (Style)Window.FindResource("WindowStyle");
            Window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Window.Name = "LoadWindow";
            // 窗口组件创建
            // 创建Path
            Path path = new Path();
            #region path
            LinearGradientBrush pathFillBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 0)
            };
            pathFillBrush.GradientStops.Add(new GradientStop(
                Color.FromArgb(0xCC, 0x15, 0x07, 0x38), 0));
            pathFillBrush.GradientStops.Add(new GradientStop(
                Color.FromArgb(0xCC, 0x15, 0x07, 0x38), 0.3));
            pathFillBrush.GradientStops.Add(new GradientStop(
                Color.FromArgb(0x99, 0x29, 0x22, 0x3A), 0.5));
            pathFillBrush.GradientStops.Add(new GradientStop(
                Color.FromArgb(0x44, 0x2B, 0x28, 0x33), 1));
            path.Fill = pathFillBrush;
            path.Data = new RectangleGeometry(new Rect(0,0, Width, Height));
            #endregion
            // Image
            Image image = new Image();
            #region image
            image.Width = Width - Left;
            image.Height = Height;
            Canvas.SetLeft(image, Left);
            image.Source = new System.Windows.Media.Imaging.BitmapImage(
                new Uri(Global.ImagesDir + "Welcome.png",
                UriKind.RelativeOrAbsolute));
            #endregion
            Grid Logo = new Grid();
            Canvas.SetTop(Logo, 0);
            Logo.Width = Left;
            Logo.Height = 60;
            TextBlock text2 = new TextBlock();
            text2.Text = LogoStr;
            text2.FontWeight = FontWeights.Bold;
            text2.FontSize = FontSize;
            text2.HorizontalAlignment = HorizontalAlignment.Center;
            text2.VerticalAlignment = VerticalAlignment.Center;
            text2.Margin = new Thickness(17, 14, 10, 10);
            text2.Foreground = Tools.String2Brush("#50EAEAEA");
            TextBlock text1 = new TextBlock();
            text1.Text = LogoStr;
            text1.FontWeight = FontWeights.Bold;
            text1.FontSize = FontSize;
            text1.HorizontalAlignment = HorizontalAlignment.Center;
            text1.VerticalAlignment = VerticalAlignment.Center;
            text1.Foreground = Tools.String2Brush("#FFEAEAEA");
            Logo.Children.Add(text2);
            Logo.Children.Add(text1);

            TextBlock Copyright = new TextBlock();
            Canvas.SetLeft(Copyright, 20);
            Canvas.SetBottom(Copyright, 10);
            Copyright.Width = Width - 40;
            Copyright.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = "Crape Client\n",
                FontSize = 12
            });
            Copyright.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = "Created By 清廉正洁的射命丸文\n",
                FontSize = 10
            });
            Copyright.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = "Copyright © 2019 Crape STAFF,\n",
                FontSize = 9
            });
            Copyright.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = "\t\tAll Rights Reserved.\n",
                FontSize = 9
            });
            // 状态信息文字块
            Canvas.SetLeft(Status, 30);
            Canvas.SetTop(Status, 70);
            Status.Width = Width - 60;

            // ----
            Canvas.Children.Add(path);
            Canvas.Children.Add(image);
            Canvas.Children.Add(Logo);
            Canvas.Children.Add(Copyright);
            Canvas.Children.Add(Status);
            Window.Content = Canvas;// 用户区设置
            Window.Show();// 显示窗口
            // --------
            System.Threading.Thread.Sleep(1000);
            Status.Text = "正在准备初始化";
            System.Threading.Thread.Sleep(1000);
            Status.Text = "初始化日志系统";
            Nlog.NLogInit();
            Status.Text = "初始化设置";
            Global.MissionConfig.LoadFromFile(Global.LocalPath + Global.ConfigsDir + "Missions.ini");
            Global.MainConfig.LoadFromFile(Global.LocalPath + Global.ConfigsDir + "Config.conf");
            Global.Ra2mdConf.LoadFromFile(Global.LocalPath + "ra2md.ini");
            Status.Text = "初始化存档列表";
            Init.SavesListInit();
            Status.Text = "初始化任务列表";
            Init.MissionConfigAnalyze();// 初始化列表
            Status.Text = "初始化GUI";
            Init.MainWindowInit();
            Status.Text = "初始化完成";
            System.Threading.Thread.Sleep(1000);
            MainWindow window = new MainWindow();
            window.Show();
            Window.Close();
        }

    }
    public class Tools {
        public static Brush String2Brush(string color)
        {
            System.Drawing.Color clr = System.Drawing.ColorTranslator.FromHtml(color);
            return
                new SolidColorBrush(
                    Color.FromArgb(
                        clr.A,
                        clr.R,
                        clr.G,
                        clr.B
                        )
                    );
        }
    }
}
