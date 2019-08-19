using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows;
using System.Drawing;
using Crape_Client.CrapeClientCore;
using Crape_Client.CrapeClientCore.Config;

namespace Crape_Client.Initialization
{
    class MainWindow
    {
        public MainWindow()
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(Global.ConfigsDir + "UI.xml");
            }
            catch (XmlException e)
            {
                Nlog.logger.Error("Message : " + e.Message);
                Nlog.logger.Error("Source : " + e.Source);
                Nlog.logger.Error("TargetSite : " + e.TargetSite);
                Nlog.ErrorBoxShow(e);
            }
            #region 主菜单
            XmlElement mainwindow = (XmlElement)xml.SelectSingleNode("UIconfig/MainWindow");
            UIconfig.MainWindow.Height = Convert.ToDouble(mainwindow.GetAttribute("Height"));
            UIconfig.MainWindow.Width = Convert.ToDouble(mainwindow.GetAttribute("Width"));
            UIconfig.MainWindow.Title = mainwindow.GetAttribute("Title");
            UIconfig.MainWindow.Background = Tools.String2Brush(mainwindow.GetAttribute("Background"));
            XmlElement menu = (XmlElement)xml.SelectSingleNode("UIconfig/MainWindow/Menu");
            UIconfig.MainWindow.Menu.Height = Convert.ToDouble(menu.GetAttribute("Height"));
            UIconfig.MainWindow.Menu.Width = Convert.ToDouble(menu.GetAttribute("Width"));
            UIconfig.MainWindow.Menu.Margin = Tools.String2Thickness(menu.GetAttribute("Margin"));
            XmlElement logo = (XmlElement)xml.SelectSingleNode("UIconfig/MainWindow/Menu/Logo");
            UIconfig.MainWindow.Menu.Logo.Height = Convert.ToDouble(logo.GetAttribute("Height"));
            UIconfig.MainWindow.Menu.Logo.Width = Convert.ToDouble(logo.GetAttribute("Width"));
            UIconfig.MainWindow.Menu.Logo.Left = Convert.ToDouble(logo.GetAttribute("Left"));
            UIconfig.MainWindow.Menu.Logo.Top = Convert.ToDouble(logo.GetAttribute("Top"));
            UIconfig.MainWindow.Menu.Logo.Text = logo.GetAttribute("Text");
            #endregion
            #region 按钮
            XmlElement camp = (XmlElement)xml.SelectSingleNode("UIconfig/MainWindow/Menu/Campaign");
            UIconfig.MainWindow.Menu.Campaign.Top = Convert.ToDouble(camp.GetAttribute("Top"));
            UIconfig.MainWindow.Menu.Campaign.Left = Convert.ToDouble(camp.GetAttribute("Left"));
            UIconfig.MainWindow.Menu.Campaign.Width = Convert.ToDouble(camp.GetAttribute("Width"));
            UIconfig.MainWindow.Menu.Campaign.Height = Convert.ToDouble(camp.GetAttribute("Height"));
            UIconfig.MainWindow.Menu.Campaign.Content = camp.GetAttribute("Content");
            UIconfig.MainWindow.Menu.Campaign.DataContext = camp.GetAttribute("DataContext");
            XmlElement skir = (XmlElement)xml.SelectSingleNode("UIconfig/MainWindow/Menu/Skirmish");
            UIconfig.MainWindow.Menu.Skirmish.Top = Convert.ToDouble(skir.GetAttribute("Top"));
            UIconfig.MainWindow.Menu.Skirmish.Left = Convert.ToDouble(skir.GetAttribute("Left"));
            UIconfig.MainWindow.Menu.Skirmish.Width = Convert.ToDouble(skir.GetAttribute("Width"));
            UIconfig.MainWindow.Menu.Skirmish.Height = Convert.ToDouble(skir.GetAttribute("Height"));
            UIconfig.MainWindow.Menu.Skirmish.Content = skir.GetAttribute("Content");
            UIconfig.MainWindow.Menu.Skirmish.DataContext = skir.GetAttribute("DataContext");
            XmlElement load = (XmlElement)xml.SelectSingleNode("UIconfig/MainWindow/Menu/Loadings");
            UIconfig.MainWindow.Menu.Loadings.Top = Convert.ToDouble(load.GetAttribute("Top"));
            UIconfig.MainWindow.Menu.Loadings.Left = Convert.ToDouble(load.GetAttribute("Left"));
            UIconfig.MainWindow.Menu.Loadings.Width = Convert.ToDouble(load.GetAttribute("Width"));
            UIconfig.MainWindow.Menu.Loadings.Height = Convert.ToDouble(load.GetAttribute("Height"));
            UIconfig.MainWindow.Menu.Loadings.Content = load.GetAttribute("Content");
            UIconfig.MainWindow.Menu.Loadings.DataContext = load.GetAttribute("DataContext");
            XmlElement sett = (XmlElement)xml.SelectSingleNode("UIconfig/MainWindow/Menu/Settings");
            UIconfig.MainWindow.Menu.Settings.Top = Convert.ToDouble(sett.GetAttribute("Top"));
            UIconfig.MainWindow.Menu.Settings.Left = Convert.ToDouble(sett.GetAttribute("Left"));
            UIconfig.MainWindow.Menu.Settings.Width = Convert.ToDouble(sett.GetAttribute("Width"));
            UIconfig.MainWindow.Menu.Settings.Height = Convert.ToDouble(sett.GetAttribute("Height"));
            UIconfig.MainWindow.Menu.Settings.Content = sett.GetAttribute("Content");
            UIconfig.MainWindow.Menu.Settings.DataContext = sett.GetAttribute("DataContext");
            XmlElement exit = (XmlElement)xml.SelectSingleNode("UIconfig/MainWindow/Menu/Exit");
            UIconfig.MainWindow.Menu.Exit.Left = Convert.ToDouble(exit.GetAttribute("Left"));
            UIconfig.MainWindow.Menu.Exit.Width = Convert.ToDouble(exit.GetAttribute("Width"));
            UIconfig.MainWindow.Menu.Exit.Bottom = Convert.ToDouble(exit.GetAttribute("Bottom"));
            UIconfig.MainWindow.Menu.Exit.Height = Convert.ToDouble(exit.GetAttribute("Height"));
            UIconfig.MainWindow.Menu.Exit.Content = exit.GetAttribute("Content");
            UIconfig.MainWindow.Menu.Exit.DataContext = exit.GetAttribute("DataContext");
            #endregion
            XmlElement show = (XmlElement)xml.SelectSingleNode("UIconfig/MainWindow/Show");
            UIconfig.MainWindow.Show.Left = Convert.ToDouble(show.GetAttribute("Left"));
            UIconfig.MainWindow.Show.Top = Convert.ToDouble(show.GetAttribute("Top"));
            UIconfig.MainWindow.Show.Width = Convert.ToDouble(show.GetAttribute("Width"));
            UIconfig.MainWindow.Show.Height = Convert.ToDouble(show.GetAttribute("Height"));

        }

    }
}
