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
using Crape_Client.CrapeClientCore;

namespace Crape_Client.CrapeClientUI
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Skirmish : Page
    {

        static Spawn spawn = new Spawn();




        // int MaxPlayerNum = 7;

        public Skirmish()
        {
            InitializeComponent();
            HostName.Text = Ra2md.MultiPlayer.Handle;




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
            List<string> teamlist = new List<string>{
                "-"
                ,"A"
                ,"B"
                ,"C"
                ,"D"
            };
            List<string> locallist = new List<string>{
                "?"
                ,"1"
                ,"2"
                ,"3"
                ,"4"
                ,"5"
                ,"6"
                ,"7"
                ,"8"
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

            HostLoc.ItemsSource = locallist;
            O1l.ItemsSource = locallist;
            O2l.ItemsSource = locallist;
            O3l.ItemsSource = locallist;
            O4l.ItemsSource = locallist;
            O5l.ItemsSource = locallist;
            O6l.ItemsSource = locallist;
            O7l.ItemsSource = locallist;

            HostTeam.ItemsSource = teamlist;
            O1t.ItemsSource = teamlist;
            O2t.ItemsSource = teamlist;
            O3t.ItemsSource = teamlist;
            O4t.ItemsSource = teamlist;
            O5t.ItemsSource = teamlist;
            O6t.ItemsSource = teamlist;
            O7t.ItemsSource = teamlist;
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
            public string Ico { get; set; }
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
        private void HostColorss(object sender, EventArgs e)
        {
            Color color = HostColor.SelectedItem as Color;
            MessageBox.Show(
                "Id：" + color.Id + "\n" +
                "Text：" + color.Text + "\n" +
                "Color：" + color.Clr + "\n" +
                "SelectedIndex: " + HostColor.SelectedIndex.ToString());
        }
        private void RunGame(object sender, RoutedEventArgs e)
        {
            
            spawn.Settings.Scenario = lMapName.DataContext.ToString();
            spawn.Settings.Credits = Convert.ToUInt32(Credits.Text);
            spawn.Settings.TechLevel = Convert.ToByte(TechLevel.Text);
            spawn.Settings.UnitCount = Convert.ToByte(UnitCount.Text);
            spawn.Settings.GameSpeed = Convert.ToByte(GameSpeed.Tag);
            spawn.Settings.ShortGame = ShortGame.IsChecked;
            spawn.Settings.MCVRedeploy = MCVRedeploy.IsChecked;
            spawn.Settings.BuildOffAlly = BuildOffAlly.IsChecked;
            spawn.Settings.Superweapons = Superweapons.IsChecked;
            spawn.Settings.AlliesAllowed = AlliesAllowed.IsChecked;
            spawn.Settings.MultiEngineer = MultiEngineer.IsChecked;
            spawn.Settings.FogOfWar = FogOfWar.IsChecked;
            spawn.Settings.BridgeDestroy = BridgeDestroy.IsChecked;
            spawn.Settings.SkipScoreScreen = SkipScoreScreen.IsChecked;
            spawn.Settings.AttackNeutralUnits = AttackNeutralUnits.IsChecked;




            spawn.Settings.Name = HostName.Text;
            spawn.Settings.Color = Convert.ToByte(HostColor.Tag.ToString());
            spawn.Settings.Side = Convert.ToByte(HostSide.Tag.ToString());
            spawn.SpawnLocations.Multi1= Convert.ToByte(HostLoc.Tag.ToString());

            // 这是遭遇战全部AI的配置
            spawn.HouseColors.Multi2 = Convert.ToByte(O1c.Tag.ToString());
            spawn.HouseHandicaps.Multi2 = Convert.ToByte(O1n.Tag.ToString());
            spawn.HouseCountries.Multi2 = Convert.ToByte(O1s.Tag.ToString());
            spawn.SpawnLocations.Multi2 = Convert.ToByte(O1l.Tag.ToString());
            spawn.HouseColors.Multi3 = Convert.ToByte(O2c.Tag.ToString());
            spawn.HouseHandicaps.Multi3 = Convert.ToByte(O2n.Tag.ToString());
            spawn.HouseCountries.Multi3 = Convert.ToByte(O2s.Tag.ToString());
            spawn.SpawnLocations.Multi3 = Convert.ToByte(O2l.Tag.ToString());
            spawn.HouseColors.Multi4 = Convert.ToByte(O3c.Tag.ToString());
            spawn.HouseHandicaps.Multi4 = Convert.ToByte(O3n.Tag.ToString());
            spawn.HouseCountries.Multi4 = Convert.ToByte(O3s.Tag.ToString());
            spawn.SpawnLocations.Multi4 = Convert.ToByte(O3l.Tag.ToString());
            spawn.HouseColors.Multi5 = Convert.ToByte(O4c.Tag.ToString());
            spawn.HouseHandicaps.Multi5 = Convert.ToByte(O4n.Tag.ToString());
            spawn.HouseCountries.Multi5 = Convert.ToByte(O4s.Tag.ToString());
            spawn.SpawnLocations.Multi5 = Convert.ToByte(O4l.Tag.ToString());
            spawn.HouseColors.Multi6 = Convert.ToByte(O5c.Tag.ToString());
            spawn.HouseHandicaps.Multi6 = Convert.ToByte(O5n.Tag.ToString());
            spawn.HouseCountries.Multi6 = Convert.ToByte(O5s.Tag.ToString());
            spawn.SpawnLocations.Multi6 = Convert.ToByte(O5l.Tag.ToString());
            spawn.HouseColors.Multi7 = Convert.ToByte(O6c.Tag.ToString());
            spawn.HouseHandicaps.Multi7 = Convert.ToByte(O6n.Tag.ToString());
            spawn.HouseCountries.Multi7 = Convert.ToByte(O6s.Tag.ToString());
            spawn.SpawnLocations.Multi7 = Convert.ToByte(O6l.Tag.ToString());
            spawn.HouseColors.Multi8 = Convert.ToByte(O7c.Tag.ToString());
            spawn.HouseHandicaps.Multi8 = Convert.ToByte(O7n.Tag.ToString());
            spawn.HouseCountries.Multi8 = Convert.ToByte(O7s.Tag.ToString());
            spawn.SpawnLocations.Multi8 = Convert.ToByte(O7l.Tag.ToString());
            TeamSet(HostTeam, 1);
            TeamSet(O1t, 2);
            TeamSet(O2t, 3);
            TeamSet(O3t, 4);
            TeamSet(O4t, 5);
            TeamSet(O5t, 6);
            TeamSet(O6t, 7);
            TeamSet(O7t, 8);
            spawn.Write();
        }
        void TeamSet(ComboBox comboBox,int Player)
        {
            string value = comboBox.Text;
            switch (value)
            {
                case "A":
                    AllyA.Add(Player);
                    break;
                case "B":
                    AllyB.Add(Player);
                    break;
                case "C":
                    AllyC.Add(Player);
                    break;
                case "D":
                    AllyD.Add(Player);
                    break;
                default:
                    return;
            }
        }
        void Team(List<int> Ally)
        {
            int[] a = Ally.ToArray();
            for (int i = 0; i < a.Length; i++)
            {
                byte p = (byte)a[i];
                Spawn.Alliances alliances = new Spawn.Alliances();
                for (int i2 = 0; i2 < a.Length; i2++)
                {
                    if (p != a[i2])
                    {
                        CheckTeam(alliances, p);
                    }
                    switch (p)
                    {
                        case 0:
                            spawn.Multi1_Alliances = alliances;
                            break;
                        case 1:
                            spawn.Multi2_Alliances = alliances;
                            break;
                        case 2:
                            spawn.Multi3_Alliances = alliances;
                            break;
                        case 3:
                            spawn.Multi4_Alliances = alliances;
                            break;
                        case 4:
                            spawn.Multi5_Alliances = alliances;
                            break;
                        case 5:
                            spawn.Multi6_Alliances = alliances;
                            break;
                        case 6:
                            spawn.Multi7_Alliances = alliances;
                            break;
                        case 7:
                            spawn.Multi8_Alliances = alliances;
                            break;
                    }
                }
            }
        }
        void CheckTeam(Spawn.Alliances alliances, byte p)
        {
            if (alliances.HouseAllyOne == null)
                alliances.HouseAllyOne = p;
            else if (alliances.HouseAllyTwe == null)
                alliances.HouseAllyTwe = p;
            else if (alliances.HouseAllyThree == null)
                alliances.HouseAllyThree = p;
            else if (alliances.HouseAllyFour == null)
                alliances.HouseAllyFour = p;
            else if (alliances.HouseAllyFive == null)
                alliances.HouseAllyFive = p;
            else if (alliances.HouseAllySix == null)
                alliances.HouseAllySix = p;
            else if (alliances.HouseAllySeven == null)
                alliances.HouseAllySeven = p;
        }
        static List<int> AllyA = new List<int>();
        static List<int> AllyB = new List<int>();
        static List<int> AllyC = new List<int>();
        static List<int> AllyD = new List<int>();


    }

}
