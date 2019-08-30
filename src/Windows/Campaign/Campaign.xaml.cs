﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Crape_Client.Windows.Campaign
{
    /// <summary>
    /// Campaign.xaml 的交互逻辑
    /// </summary>
    public partial class Campaign : Page
    {
        private bool _Difficult;
        public Campaign()
        {
            InitializeComponent();
            _Difficult = true;
            ccSummary.Content = new Summary();
        }

        private void Difficult_Click(object sender, RoutedEventArgs e)
        {
            if (_Difficult)
            {
                _Difficult = !_Difficult;
                ccSummary.Content = new Difficult();
            }
            else
            {
                _Difficult = !_Difficult;
                ccSummary.Content = new Summary();
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow.uiFrame.Content = new MainMenu.MainMenu();
            MainWindow.mainWindow.GoBack();
        }
    }
}
