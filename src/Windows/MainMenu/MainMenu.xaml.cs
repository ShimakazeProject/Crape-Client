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
//using System.Windows.Shapes;
using L2DLib.Framework;
using L2DLib.Utility;

namespace Crape_Client.Windows.MainMenu
{
    /// <summary>
    /// MainMenu.xaml 的交互逻辑
    /// </summary>
    public partial class MainMenu : Page
    {
        #region 对象
        private Random rnd = new Random();
        #endregion
        public MainMenu()
        {
            InitializeComponent();
            Loaded += MainWindow_Activated;
        }
        private void MainWindow_Activated(object sender, EventArgs e)
        {
            //MainWindow = Window.GetWindow(this);
            // 初始化Live2DShow
            L2DS.window = MainWindow.mainWindow;
            LoadModelJson();
        }
        #region Live2DShow相关
        L2DModel model;
        private void ReleaseCheck()
        {
            if (model != null)
            {
                model.Dispose();
            }
        }
        private void UpdateConfig()
        {
            // 模型自动呼吸设置
            model.UseBreath = true;// true;
            // 模型自动眨眼设置
            model.UseEyeBlink = true;//true;
            // 在渲染器上设置目标模型
            L2DS.Model = model;
        }
        private void LoadModelJson()
        {
            // Live2D
            // 导入模型
            ReleaseCheck();
            try
            {
                model = L2DFunctions.LoadModel(Settings.MainWindow.L2DJsonPath);
            }
            catch (NoMotionException e)
            {
                MessageBox.Show(e.Message + "\n操作中断",
                    "Fatal Error",
                    MessageBoxButton.OK);
                return;
            }
            // 更新设置
            UpdateConfig();
        }
        private void L2DS_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Random ran = new Random();
            foreach (L2DMotion[] group in model.Motion.Values)
            {
                int n = ran.Next(group.Length);
                group[n].StartMotion();
                return;
            }
        }

        #endregion Live2DShow相关

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void Campaign_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.Content = new Campaign.Campaign();
        }
    }
}