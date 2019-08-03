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
using System.Windows.Shapes;
using RA2.Ini;

namespace Crape_Client.CrapeClientUI
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Skirmish : Page
    {

        Spawn spawn = new Spawn();




        // int MaxPlayerNum = 7;

        public Skirmish()
        {
            InitializeComponent();


            

            List<AIplayer> namelist = new List<AIplayer>{
                new AIplayer{ Id=-1, Text = "无"}
                ,new AIplayer{ Id=2, Text = "简单"}
                ,new AIplayer{ Id=1, Text = "中等"}
                ,new AIplayer{ Id=0, Text = "困难"}
            };
            List<Side> sidelist = new List<Side>{
                new Side{ Id=-1, Text = "随机" },
                new Side{ Id=-2, Text = "随机萌军" },
                new Side{ Id=-3, Text = "随机酥联" },
                new Side{ Id=0, Text = "美国" },
                new Side{ Id=1, Text = "韩国" },
                new Side{ Id=2, Text = "法国" },
                new Side{ Id=3, Text = "德国" },
                new Side{ Id=4, Text = "英国" },
                new Side{ Id=5, Text = "伊拉克" },
                new Side{ Id=6, Text = "利比亚" },
                new Side{ Id=7, Text = "古巴" },
                new Side{ Id=8, Text = "俄罗斯" },
                new Side{ Id=9, Text = "尤理" }
            };
            List<Color> colorlist = new List<Color>{
                new Color { Id = 0, Text = "黄色", Clr="#FFFF00" },
                new Color { Id = 1, Text = "红色", Clr="#ff0000" },
                new Color { Id = 2, Text = "蓝色", Clr="#0000ff" },
                new Color { Id = 3, Text = "绿色", Clr="#00ff00" },
                new Color { Id = 4, Text = "橙色", Clr="#ff9900" },
                new Color { Id = 5, Text = "青色", Clr="#00ffff" },
                new Color { Id = 6, Text = "紫色", Clr="#9900ff" },
                new Color { Id = 7, Text = "粉色", Clr="#ff00ff" }
            };

            // AI玩家
            O1n.ItemsSource = namelist;
            O2n.ItemsSource = namelist;
            O3n.ItemsSource = namelist;
            O4n.ItemsSource = namelist;
            O5n.ItemsSource = namelist;
            O6n.ItemsSource = namelist;
            O7n.ItemsSource = namelist;
            O1n.SelectedIndex = 0;
            O2n.SelectedIndex = 0;
            O3n.SelectedIndex = 0;
            O4n.SelectedIndex = 0;
            O5n.SelectedIndex = 0;
            O6n.SelectedIndex = 0;
            O7n.SelectedIndex = 0;

            // 阵营
            HostSide.ItemsSource = sidelist;
            O1s.ItemsSource = sidelist;
            O2s.ItemsSource = sidelist;
            O3s.ItemsSource = sidelist;
            O4s.ItemsSource = sidelist;
            O5s.ItemsSource = sidelist;
            O6s.ItemsSource = sidelist;
            O7s.ItemsSource = sidelist;
            HostSide.SelectedIndex = 0;
            O1s.SelectedIndex = 0;
            O2s.SelectedIndex = 0;
            O3s.SelectedIndex = 0;
            O4s.SelectedIndex = 0;
            O5s.SelectedIndex = 0;
            O6s.SelectedIndex = 0;
            O7s.SelectedIndex = 0;



            HostColor.ItemsSource = colorlist;
            O1c.ItemsSource = colorlist;
            O2c.ItemsSource = colorlist;
            O3c.ItemsSource = colorlist;
            O4c.ItemsSource = colorlist;
            O5c.ItemsSource = colorlist;
            O6c.ItemsSource = colorlist;
            O7c.ItemsSource = colorlist;




        }
        class AIplayer
        {
            public int Id { get; set; }
            public string Text { get; set; }
        }
        class Side
        {
            public int Id { get; set; }
            public string Text { get; set; }
        }
        class Color
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public string Clr { get; set; }
        }







        private void O1n_DropDownClosed(object sender, EventArgs e)
        {
            AIplayer aIplayer = O1n.SelectedItem as AIplayer;
            MessageBox.Show(
                "Id：" + aIplayer.Id + "\n\n" +
                "Text：" + aIplayer.Text + "\n\n" +
                "SelectedIndex: " + O1n.SelectedIndex.ToString());
        }
    }

}
