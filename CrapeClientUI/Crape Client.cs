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

namespace Crape_Client.CrapeClientUI
{

    class CrapeClient: Window
    {

        private Frame Frame;
        public CrapeClient()
        {
            // 固定不可变
            this.ResizeMode = ResizeMode.NoResize;
            this.Style = (Style)this.FindResource("WindowStyle");
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            // 可变项
            this.Title = GUIconfigs.MainWindowConfig.Title;
            this.Height = GUIconfigs.MainWindowConfig.Height;
            this.Width = GUIconfigs.MainWindowConfig.Width;
            this.Foreground = GUIconfigs.MainWindowConfig.Foreground;


            #region Grid
            Grid Grid = new Grid();
            #region Path背景
            Path Path = new Path();
            LinearGradientBrush pathFillBrush = new LinearGradientBrush
            {
                StartPoint = GUIconfigs.MainWindowConfig.Background.StartPoint,
                EndPoint = GUIconfigs.MainWindowConfig.Background.EndPoint
            };
            GradientStop[] gradient = GUIconfigs.MainWindowConfig.Background.GradientStop.ToArray();
            for(int i=0;i< gradient.Length; i++)
            {
                pathFillBrush.GradientStops.Add(gradient[i]);
            }
            Path.Fill = pathFillBrush;
            Path.Data = new RectangleGeometry(new Rect(0, 0, Width, Height));
            Grid.Children.Add(Path);
            #endregion Path背景
            Canvas Menu = new Canvas();
            #region Menu(Canvas)
            #region Logo
            Grid Logo = new Grid();
            Canvas.SetTop(Logo, GUIconfigs.MainWindowConfig.Logo.Top);
            Canvas.SetLeft(Logo, GUIconfigs.MainWindowConfig.Logo.Left);
            Logo.Width = GUIconfigs.MainWindowConfig.Logo.Width;
            Logo.Height = GUIconfigs.MainWindowConfig.Logo.Height;
            #region Reflection
            TextBlock Logo3 = new TextBlock// 倒影
            {
                Text = GUIconfigs.MainWindowConfig.Logo.Text,
                FontWeight = FontWeights.Bold,
                FontSize = GUIconfigs.MainWindowConfig.Logo.FontSize,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Height = 38,
                Margin = GUIconfigs.MainWindowConfig.Logo.Reflection.Margin,
                RenderTransformOrigin = GUIconfigs.MainWindowConfig.Logo.Reflection.RenderTransformOrigin,
                FontStyle = FontStyles.Italic,
            };
            LinearGradientBrush Logo3FG = new LinearGradientBrush
            {
                StartPoint = GUIconfigs.MainWindowConfig.Logo.Reflection.LinearGradientBrush.StartPoint,
                EndPoint = GUIconfigs.MainWindowConfig.Logo.Reflection.LinearGradientBrush.EndPoint
            };
            gradient = GUIconfigs.MainWindowConfig.Logo.Reflection.LinearGradientBrush.GradientStop.ToArray();
            for (int i = 0; i < gradient.Length; i++)
            {
                Logo3FG.GradientStops.Add(gradient[i]);
            }
            Logo3.Foreground = Logo3FG;
            TransformGroup Logo3TG = new TransformGroup();
            Logo3TG.Children.Add(new ScaleTransform(0, GUIconfigs.MainWindowConfig.Logo.Reflection.ScaleTransformY));
            Logo3.RenderTransform = Logo3TG;
            #endregion
            TextBlock Logo2 = new TextBlock// 背影
            {
                Text = GUIconfigs.MainWindowConfig.Logo.Text,
                FontWeight = FontWeights.Bold,
                FontSize = GUIconfigs.MainWindowConfig.Logo.FontSize,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = GUIconfigs.MainWindowConfig.Logo.Projection.Margin,
                Foreground = GUIconfigs.MainWindowConfig.Logo.Projection.Foreground
            };
            TextBlock Logo1 = new TextBlock// Main
            {
                Text = GUIconfigs.MainWindowConfig.Logo.Text,
                FontSize = GUIconfigs.MainWindowConfig.Logo.FontSize,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = GUIconfigs.MainWindowConfig.Logo.Foreground
            };
            Logo.Children.Add(Logo3);
            Logo.Children.Add(Logo2);
            Logo.Children.Add(Logo1);
            Menu.Children.Add(Logo);
            #endregion
            #region 按钮
            RadioButton Campaign = new RadioButton()
            {
                Style = (Style)FindResource("MainMenuBattleButton"),
                GroupName = "Menu",
                IsChecked = false,
                Width = GUIconfigs.MainWindowConfig.MenuButton.Width,
                Height = GUIconfigs.MainWindowConfig.MenuButton.Height,
                Content = GUIconfigs.MainWindowConfig.MenuButton.Campaign.Content,
                DataContext = GUIconfigs.MainWindowConfig.MenuButton.Campaign.DataContext
            };
            Campaign.Checked += Combat;
            Canvas.SetLeft(Campaign,GUIconfigs.MainWindowConfig.MenuButton.Left);
            Canvas.SetTop(Campaign, GUIconfigs.MainWindowConfig.MenuButton.Campaign.Top);
            RadioButton Skirmish = new RadioButton()
            {
                Style = (Style)FindResource("MainMenuSkirmishButton"),
                GroupName = "Menu",
                IsChecked = false,
                Width = GUIconfigs.MainWindowConfig.MenuButton.Width,
                Height = GUIconfigs.MainWindowConfig.MenuButton.Height,
                Content = GUIconfigs.MainWindowConfig.MenuButton.Skirmish.Content,
                DataContext = GUIconfigs.MainWindowConfig.MenuButton.Skirmish.DataContext
            };
            Skirmish.Checked += this.Skirmish;
            Canvas.SetLeft(Skirmish, GUIconfigs.MainWindowConfig.MenuButton.Left);
            Canvas.SetTop(Skirmish, GUIconfigs.MainWindowConfig.MenuButton.Skirmish.Top);
            RadioButton Loadings = new RadioButton()
            {
                Style = (Style)FindResource("MainMenuLoadButton"),
                GroupName = "Menu",
                IsChecked = false,
                Width = GUIconfigs.MainWindowConfig.MenuButton.Width,
                Height = GUIconfigs.MainWindowConfig.MenuButton.Height,
                Content = GUIconfigs.MainWindowConfig.MenuButton.Loadings.Content,
                DataContext = GUIconfigs.MainWindowConfig.MenuButton.Loadings.DataContext
            };
            Loadings.Checked += this.Loadings;
            Canvas.SetLeft(Loadings, GUIconfigs.MainWindowConfig.MenuButton.Left);
            Canvas.SetTop(Loadings, GUIconfigs.MainWindowConfig.MenuButton.Loadings.Top);
            RadioButton Settings = new RadioButton()
            {
                Style = (Style)FindResource("MainMenuSettingsButton"),
                GroupName = "Menu",
                IsChecked = false,
                Width = GUIconfigs.MainWindowConfig.MenuButton.Width,
                Height = GUIconfigs.MainWindowConfig.MenuButton.Height,
                Content = GUIconfigs.MainWindowConfig.MenuButton.Settings.Content,
                DataContext = GUIconfigs.MainWindowConfig.MenuButton.Settings.DataContext
            };
            Settings.Checked += this.Settings;
            Canvas.SetLeft(Settings, GUIconfigs.MainWindowConfig.MenuButton.Left);
            Canvas.SetTop(Settings, GUIconfigs.MainWindowConfig.MenuButton.Settings.Top);
            RadioButton Exit = new RadioButton()
            {
                Style = (Style)FindResource("MainMenuExitButton"),
                GroupName = "Menu",
                IsChecked = false,
                Width = GUIconfigs.MainWindowConfig.Exit.Width,
                Height = GUIconfigs.MainWindowConfig.Exit.Height,
                Content = GUIconfigs.MainWindowConfig.Exit.Content,
                DataContext = GUIconfigs.MainWindowConfig.Exit.DataContext
            };
            Exit.Checked += this.Exit;
            Canvas.SetLeft(Exit, GUIconfigs.MainWindowConfig.Exit.Left);
            Canvas.SetBottom(Exit, GUIconfigs.MainWindowConfig.Exit.Bottom);

            Menu.Children.Add(Campaign);
            Menu.Children.Add(Skirmish);
            Menu.Children.Add(Loadings);
            Menu.Children.Add(Settings);
            Menu.Children.Add(Exit);
            #endregion 按钮
            Grid.Children.Add(Menu);
            #endregion Menu(Canvas)
            Frame = new Frame()// Frame初始化
            {
                NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden,
                Source = new Uri("/Crape Client;component/CrapeClientUI/Welcome.xaml", UriKind.Relative)
            };
            Frame.Margin = GUIconfigs.MainWindowConfig.Frame.Margin;
            Grid.Children.Add(Frame);
            #endregion
            Content = Grid;
        }
        private void Combat(object sender, RoutedEventArgs e) /* 战役 */{
            Frame.Source = new Uri("/CrapeClientUI/Mission.xaml", UriKind.Relative); }
        private void Skirmish(object sender, RoutedEventArgs e) /* 遭遇战 */{
            Frame.Source = new Uri("/Crape Client;component/CrapeClientUI/Skirmish.xaml", UriKind.Relative); }
        private void Loadings(object sender, RoutedEventArgs e)/* 载入 LoadSaveGames */{
            Frame.Source = new Uri("/Crape Client;component/CrapeClientUI/LoadSaveGames.xaml", UriKind.Relative); }
        private void Settings(object sender, RoutedEventArgs e)/* 设置 */{
            Frame.Source = new Uri("/Crape Client;component/CrapeClientUI/Settings.xaml", UriKind.Relative); }
        private void Exit(object sender, RoutedEventArgs e) /* 退出 */{
            //Environment.Exit(0);
            Close();
        }

    }
}
