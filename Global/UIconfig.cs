using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml;
using Crape_Client.Initialization;

namespace Crape_Client.Global
{
    public class GUIconfigs
    {
        public class LinearGradientBrush
        {
            public Point StartPoint { set; get; }
            public Point EndPoint { set; get; }
            public List<GradientStop> GradientStop { set; get; }
        }

        public struct MainWindowConfig
        {
            public static double Height { set; get; }
            public static double Width { set; get; }
            public static string Title { set; get; }
            public static Brush Foreground { set; get; }
            public static LinearGradientBrush Background { set; get; }
            public struct Logo
            {
                public static double Left { set; get; }
                public static double Top { set; get; }
                public static double Width { set; get; }
                public static double Height { set; get; }
                public static string Text { set; get; }
                public static double FontSize { set; get; }
                public static Brush Foreground { set; get; }
                public struct Projection
                {
                    public static Brush Foreground { set; get; }
                    public static Thickness Margin { set; get; }
                }
                public struct Reflection
                {
                    public static Thickness Margin { set; get; }
                    public static Point RenderTransformOrigin { set; get; }
                    public static double ScaleTransformY { set; get; }
                    public static LinearGradientBrush LinearGradientBrush { set; get; }
                }
            }
            public struct MenuButton
            {
                public static double Left { set; get; }
                public static double Width { set; get; }
                public static double Height { set; get; }
                public static Button Campaign { set; get; }
                public static Button Skirmish { set; get; }
                public static Button Loadings { set; get; }
                public static Button Settings { set; get; }
                public struct Button
                {
                    public double Top { set; get; }
                    public string Content { set; get; }
                    public string DataContext { set; get; }
                }
            }
            public struct Exit
            {
                public static double Left { set; get; }
                public static double Bottom { set; get; }
                public static double Width { set; get; }
                public static double Height { set; get; }
                public static string Content { set; get; }
                public static string DataContext { set; get; }
            }
            public struct Frame
            {
                public static Thickness Margin { set; get; }
            }
        }
        public GUIconfigs()
        {
            XmlDocument Xml = new XmlDocument();// 实例化 XmlDocument 类
            try
            {
                Xml.Load(Globals.ConfigsDir + "CrapeClientUIconfig.xml");// 读入XML文档
            }
            catch (XmlException e)// 异常处理
            {
                Globals.LogMGR.Error(e);
                Globals.LogMGR.ErrorBoxShow();
            }
            XmlElement XE;
            #region MainWindowConfig

            XE = (XmlElement)Xml.SelectSingleNode("GUIconfigs/MainWindowConfig");
            MainWindowConfig.Width = Convert.ToDouble(XE.GetAttribute("Width"));
            MainWindowConfig.Height = Convert.ToDouble(XE.GetAttribute("Height"));
            MainWindowConfig.Foreground = Tools.String2Brush(XE.GetAttribute("Foreground"));
            MainWindowConfig.Title = XE.GetAttribute("Title");
            #region Background
            XE = (XmlElement)Xml.SelectSingleNode("GUIconfigs/MainWindowConfig/Background");
            MainWindowConfig.Background = new LinearGradientBrush()
            {
                StartPoint = Tools.String2Point(XE.GetAttribute("StartPoint")),
                EndPoint = Tools.String2Point(XE.GetAttribute("EndPoint")),
                GradientStop = new List<GradientStop>()
            };
            foreach (XmlNode Node in 
                Xml.SelectSingleNode("GUIconfigs/MainWindowConfig/Background").ChildNodes)
            {
                XE = (XmlElement)Node;
                MainWindowConfig.Background.GradientStop.Add(
                    new GradientStop(
                        Tools.String2Color(XE.GetAttribute("Color")),
                        Convert.ToDouble(XE.GetAttribute("Offset"))
                    )
                );
            }
            #endregion Background
            #region Logo
            XE = (XmlElement)Xml.SelectSingleNode("GUIconfigs/MainWindowConfig/Logo");
            MainWindowConfig.Logo.Left = Convert.ToDouble(XE.GetAttribute("Left"));
            MainWindowConfig.Logo.Top = Convert.ToDouble(XE.GetAttribute("Top"));
            MainWindowConfig.Logo.Width = Convert.ToDouble(XE.GetAttribute("Width"));
            MainWindowConfig.Logo.Height = Convert.ToDouble(XE.GetAttribute("Height"));
            MainWindowConfig.Logo.Text = XE.GetAttribute("Text");
            MainWindowConfig.Logo.FontSize = Convert.ToDouble(XE.GetAttribute("FontSize"));
            MainWindowConfig.Logo.Foreground = Tools.String2Brush(XE.GetAttribute("Foreground"));
            XE = (XmlElement)Xml.SelectSingleNode("GUIconfigs/MainWindowConfig/Logo/Projection");
            MainWindowConfig.Logo.Projection.Foreground = Tools.String2Brush(XE.GetAttribute("Foreground"));
            MainWindowConfig.Logo.Projection.Margin = Tools.String2Thickness(XE.GetAttribute("Margin"));
            XE = (XmlElement)Xml.SelectSingleNode("GUIconfigs/MainWindowConfig/Logo/Reflection");
            MainWindowConfig.Logo.Reflection.Margin = Tools.String2Thickness(XE.GetAttribute("Margin"));
            MainWindowConfig.Logo.Reflection.RenderTransformOrigin =
                Tools.String2Point(XE.GetAttribute("RenderTransformOrigin"));
            MainWindowConfig.Logo.Reflection.ScaleTransformY= Convert.ToDouble(XE.GetAttribute("ScaleTransformY"));
            XE = (XmlElement)Xml.SelectSingleNode("GUIconfigs/MainWindowConfig/Logo/Reflection/LinearGradientBrush");
            MainWindowConfig.Logo.Reflection.LinearGradientBrush = new LinearGradientBrush()
            {
                StartPoint = Tools.String2Point(XE.GetAttribute("StartPoint")),
                EndPoint = Tools.String2Point(XE.GetAttribute("EndPoint")),
                GradientStop = new List<GradientStop>()
            };
            foreach (XmlNode Node in 
                Xml.SelectSingleNode("GUIconfigs/MainWindowConfig/Logo/Reflection/LinearGradientBrush").ChildNodes)
            {
                XE = (XmlElement)Node;
                MainWindowConfig.Logo.Reflection.LinearGradientBrush.GradientStop.Add(
                    new GradientStop(
                        Tools.String2Color(XE.GetAttribute("Color")),
                        Convert.ToDouble(XE.GetAttribute("Offset"))
                    )
                );
            }
            #endregion Logo
            #region MenuButton
            XE = (XmlElement)Xml.SelectSingleNode("GUIconfigs/MainWindowConfig/MenuButton");
            MainWindowConfig.MenuButton.Left = Convert.ToDouble(XE.GetAttribute("Left"));
            MainWindowConfig.MenuButton.Width = Convert.ToDouble(XE.GetAttribute("Width"));
            MainWindowConfig.MenuButton.Height = Convert.ToDouble(XE.GetAttribute("Height"));
            XE = (XmlElement)Xml.SelectSingleNode("GUIconfigs/MainWindowConfig/MenuButton/Campaign");
            MainWindowConfig.MenuButton.Campaign = new MainWindowConfig.MenuButton.Button()
            {
                Top = Convert.ToDouble(XE.GetAttribute("Top")),
                Content = XE.GetAttribute("Content"),
                DataContext = XE.GetAttribute("DataContext")
            };
            XE = (XmlElement)Xml.SelectSingleNode("GUIconfigs/MainWindowConfig/MenuButton/Skirmish");
            MainWindowConfig.MenuButton.Skirmish = new MainWindowConfig.MenuButton.Button()
            {
                Top = Convert.ToDouble(XE.GetAttribute("Top")),
                Content = XE.GetAttribute("Content"),
                DataContext = XE.GetAttribute("DataContext")
            };
            XE = (XmlElement)Xml.SelectSingleNode("GUIconfigs/MainWindowConfig/MenuButton/Loadings");
            MainWindowConfig.MenuButton.Loadings = new MainWindowConfig.MenuButton.Button()
            {
                Top = Convert.ToDouble(XE.GetAttribute("Top")),
                Content = XE.GetAttribute("Content"),
                DataContext = XE.GetAttribute("DataContext")
            };
            XE = (XmlElement)Xml.SelectSingleNode("GUIconfigs/MainWindowConfig/MenuButton/Settings");
            MainWindowConfig.MenuButton.Settings = new MainWindowConfig.MenuButton.Button()
            {
                Top = Convert.ToDouble(XE.GetAttribute("Top")),
                Content = XE.GetAttribute("Content"),
                DataContext = XE.GetAttribute("DataContext")
            };
            #endregion MenuButton
            XE = (XmlElement)Xml.SelectSingleNode("GUIconfigs/MainWindowConfig/Exit");
            MainWindowConfig.Exit.Left = Convert.ToDouble(XE.GetAttribute("Left"));
            MainWindowConfig.Exit.Bottom = Convert.ToDouble(XE.GetAttribute("Bottom"));
            MainWindowConfig.Exit.Width = Convert.ToDouble(XE.GetAttribute("Width"));
            MainWindowConfig.Exit.Height = Convert.ToDouble(XE.GetAttribute("Height"));
            MainWindowConfig.Exit.Content = XE.GetAttribute("Content");
            MainWindowConfig.Exit.DataContext = XE.GetAttribute("DataContext");
            XE = (XmlElement)Xml.SelectSingleNode("GUIconfigs/MainWindowConfig/Frame");
            MainWindowConfig.Frame.Margin = Tools.String2Thickness(XE.GetAttribute("Margin"));
            #endregion MainWindowConfig


        }
    }
}
