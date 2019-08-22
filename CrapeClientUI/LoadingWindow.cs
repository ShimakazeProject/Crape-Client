using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using Crape_Client.Global;
using Crape_Client.Initialization;

namespace Crape_Client.CrapeClientUI
{
    class LoadingWindow: Window
    {
        readonly Canvas Canvas = new Canvas();
        private TextBlock Status;
        const string LogoStr = "Crape Client";
        const double ALeft = 200;
        const double LogoFontSize = 28;
        public LoadingWindow()
        {
            // 主窗口创建
            Title = "Crape Client 初始化";
            Width = 600;
            Height = 400;
            Foreground = Tools.String2Brush("#FFF");
            ResizeMode = ResizeMode.NoResize;
            Style = (Style)FindResource("WindowStyle");
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
            image.Width = Width - ALeft;
            image.Height = Height;
            Canvas.SetLeft(image, ALeft);
            image.Source = new System.Windows.Media.Imaging.BitmapImage(
                new Uri(Globals.ImagesDir + "Welcome.png",
                UriKind.RelativeOrAbsolute));
            #endregion
            Grid Logo = new Grid();
            Canvas.SetTop(Logo, 0);
            Logo.Width = ALeft;
            Logo.Height = 60;
            TextBlock Logo3 = new TextBlock// 倒影
            {
                Text = LogoStr,
                FontWeight = FontWeights.Bold,
                FontSize = LogoFontSize,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(20, 20, 20, -25),
                Height = 38,
                RenderTransformOrigin = new Point(0.5, 0.5),
                FontStyle = FontStyles.Italic,
            };
            LinearGradientBrush Logo3FG = new LinearGradientBrush
            {
                StartPoint = new Point(0.5, 0),
                EndPoint = new Point(0.5, 1)
            };
            Logo3FG.GradientStops.Add(new GradientStop(Colors.Transparent, 0.5));
            Logo3FG.GradientStops.Add(new GradientStop(Tools.String2Color("#50000000"), 1));
            Logo3.Foreground = Logo3FG;
            TransformGroup Logo3TG = new TransformGroup();
            Logo3TG.Children.Add(new ScaleTransform() { ScaleY = -1 });
            Logo3.RenderTransform = Logo3TG;
            TextBlock Logo2 = new TextBlock
            {
                Text = LogoStr,
                FontWeight = FontWeights.Bold,
                FontSize = LogoFontSize,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(17, 14, 10, 10),
                Foreground = Tools.String2Brush("#50EAEAEA")
            };
            TextBlock Logo1 = new TextBlock
            {
                Text = LogoStr,
                FontWeight = FontWeights.Bold,
                FontSize = LogoFontSize,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = Tools.String2Brush("#FFEAEAEA")
            };
            Logo.Children.Add(Logo3);
            Logo.Children.Add(Logo2);
            Logo.Children.Add(Logo1);
            // 著作权信息
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
                Text = "Copyright © 2019 Crape Studio,\n",
                FontSize = 9
            });
            Copyright.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = "\tAll Rights Reserved.\n",
                FontSize = 9
            });
            // 状态信息文字块
            Status = new TextBlock
            {
                Width = Width - 60
            };
            Canvas.SetLeft(Status, 20);
            Canvas.SetTop(Status, 70);
            Status.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = "Initialization.",//正在初始化...\n
            });

            // ----
            Canvas.Children.Add(path);
            Canvas.Children.Add(image);
            Canvas.Children.Add(Logo);
            Canvas.Children.Add(Copyright);
            Canvas.Children.Add(Status);
            Content = Canvas;// 用户区设置
            Activated += Init;
            //Activated += Inita;


        }
        //public void Inita(object sender, EventArgs e) { }
        public void Init(object sender, EventArgs e)
        {
            #region 
            System.Threading.Thread.Sleep(1000);
            Status.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = ".",
            });

            System.Threading.Thread.Sleep(1000);
            Status.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = ".",
            });
            System.Threading.Thread.Sleep(1000);
            Status.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = ".",
            });
            System.Threading.Thread.Sleep(1000);
            #endregion
            //Status.Text = "初始化日志系统";
            Status.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = "\nInitializing LOG System\t",
            });
            Globals.LogMGR = new CrapeClientCore.LogMGR();
            //Status.Text = "初始化首选项";
            Status.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = "Over\nInitializing Settings\t",
            });
            new Renderer();

            Globals.MissionConfig.LoadFromFile(Globals.ConfigsDir + "Missions.ini");
            Globals.MainConfig.LoadFromFile(Globals.ConfigsDir + "Config.conf");
            Globals.Ra2mdConf.LoadFromFile(Globals.LocalPath + "ra2md.ini");
            //Status.Text = "初始化存档列表";
            Status.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = "Over\nInitializing Saved List\t",
            });
            new SavedList();
            new ColorInit();
            new SideInit();
            // Status.Text = "初始化任务列表";
            Status.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = "Over\nInitializing Mission List\t",
            });
            new Mission();// 初始化列表
            //Status.Text = "初始化GUI";
            Status.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = "Over\nInitializing GUI\t\t",
            });
            new GUIconfigs();
            //Status.Text = "初始化完成";
            Status.Inlines.Add(new System.Windows.Documents.Run
            {
                Text = "Over\nInitialization Is Over.",
            });
            System.Threading.Thread.Sleep(1000);
            MessageBox.Show("");
            System.Diagnostics.Debug.WriteLine("载入窗口关闭");
            Close();
        }
    }

}
