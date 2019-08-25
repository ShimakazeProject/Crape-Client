using System;
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
//using System.Windows.Shapes;
using L2DLib.Framework;
using L2DLib.Utility;
using System.IO;

namespace Crape_Client.CrapeClientUI
{
    /// <summary>
    /// L2d.xaml 的交互逻辑
    /// </summary>
    public partial class L2d : Window
    {
        L2DModel model;

        ListView ListMotion = new ListView();
        ListView ListExpression = new ListView();
        public L2d()
        {
            InitializeComponent();
            LoadModel();
        }
        private void LoadModel()
        {
            const string moc = @"Live2D\shizuku\shizuku.moc";
            const string json = @"Live2D\shizuku\shizuku.model.json";
            if (model != null)
            {
                model.Dispose();
            }

            // 导入模型
            model = new L2DModel(moc);

            // 加载纹理
            string texruePath =
                string.Format("{0}\\{1}.1024",
                new FileInfo(moc).Directory.FullName,
                Path.GetFileNameWithoutExtension(moc));

            if (Directory.Exists(texruePath))
            {
                model.SetTexture(Directory.GetFiles(texruePath));
            }
            MessageBox.Show("1");
            // Live2D
            // 导入模型
            model = L2DFunctions.LoadModel(json);
            MessageBox.Show("2");
            // 更新设置
            UpdateConfig();

            // Application
            // 初始化列表
            ListMotion.Items.Clear();
            ListExpression.Items.Clear();

            // 更新动态列表
            if (model.Motion != null)
            {
                foreach (L2DMotion[] group in model.Motion.Values)
                {
                    foreach (L2DMotion motion in group)
                    {
                        ListMotion.Items.Add(Path.GetFileName(motion.Path));
                    }
                }
            }
            // 面部表情列表更新
            if (model.Expression != null)
            {
                for (int i = 0; i < model.Expression.Count; i++)
                {
                    ListExpression.Items.Add(model.Expression.Keys.ElementAt(i));
                }
            }
            MessageBox.Show("4");
        }
        private void UpdateConfig()
        {
            // 模型自动呼吸设置
            model.UseBreath = true;
            // 模型自动眨眼设置
            model.UseEyeBlink = true;
            // 在渲染器上设置目标模型
            L2DV.Model = model;
            MessageBox.Show("3");
        }

        private void L2D_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (L2DMotion[] group in model.Motion.Values)
            {
                Random ran = new Random();
                int n = ran.Next(group.Length);
                group[n].StartMotion();
                return;
            }
        }

        private void Window_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            
        }
    }
}
