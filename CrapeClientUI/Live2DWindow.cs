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
using System.Windows.Navigation;
// using System.Windows.Shapes;
using L2DLib.Framework;
using L2DLib.Utility;
using System.IO;

namespace Crape_Client.CrapeClientUI
{
    class Live2DWindow: Window
    {
        L2DModel model;
        Live2DView L2DV;
        ListView ListMotion = new ListView();
        ListView ListExpression = new ListView();

        public Live2DWindow()
        {
            Title = "Live2D";
            Height = 600;
            Width = 400;
            //Style = (Style)FindResource("WindowStyle"),
            //Content = L2DV;
            L2DV = new Live2DView()
            {
                Background = null,
            };
            LoadModel();
            MessageBox.Show("88");
            //L2DV.MouseLeftButtonDown += L2DV_MouseLeftButtonDown;
            MessageBox.Show("89");
            this.Content = L2DV;
            MessageBox.Show("0");
        }

        private void L2DV_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (L2DMotion[] group in model.Motion.Values)
            {
                Random ran = new Random();
                int n = ran.Next(group.Length);
                group[n].StartMotion();
            }

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
    }
}
