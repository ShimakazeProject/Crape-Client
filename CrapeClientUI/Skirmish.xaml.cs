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
            ColorInit();



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


            // 阵营
            HostSide.ItemsSource = sidelist;
            O1s.ItemsSource = sidelist;
            O2s.ItemsSource = sidelist;
            O3s.ItemsSource = sidelist;
            O4s.ItemsSource = sidelist;
            O5s.ItemsSource = sidelist;
            O6s.ItemsSource = sidelist;
            O7s.ItemsSource = sidelist;

            /*
            HostColor.ItemsSource = colorlist;
            O1c.ItemsSource = colorlist;
            O2c.ItemsSource = colorlist;
            O3c.ItemsSource = colorlist;
            O4c.ItemsSource = colorlist;
            O5c.ItemsSource = colorlist;
            O6c.ItemsSource = colorlist;
            O7c.ItemsSource = colorlist;
            //*/
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

        void ColorInit()
        {
            //Global.Colors
            Initialization.Config.Color[] colors = Global.Colors.ToArray();
            for (int i=0;i< colors.Length; i++)
            {
                HostColor.Items.Add(new ComboBoxItem()
                {
                    Tag = colors[i].Id,
                    Content = colors[i].Name,
                    Foreground = colors[i].Value
                });
                O1c.Items.Add(new ComboBoxItem()
                {
                    Tag = colors[i].Id,
                    Content = colors[i].Name,
                    Foreground = colors[i].Value
                });
                O2c.Items.Add(new ComboBoxItem()
                {
                    Tag = colors[i].Id,
                    Content = colors[i].Name,
                    Foreground = colors[i].Value
                });
                O3c.Items.Add(new ComboBoxItem()
                {
                    Tag = colors[i].Id,
                    Content = colors[i].Name,
                    Foreground = colors[i].Value
                });
                O4c.Items.Add(new ComboBoxItem()
                {
                    Tag = colors[i].Id,
                    Content = colors[i].Name,
                    Foreground = colors[i].Value
                });
                O5c.Items.Add(new ComboBoxItem()
                {
                    Tag = colors[i].Id,
                    Content = colors[i].Name,
                    Foreground = colors[i].Value
                });
                O6c.Items.Add(new ComboBoxItem()
                {
                    Tag = colors[i].Id,
                    Content = colors[i].Name,
                    Foreground = colors[i].Value
                });
                O7c.Items.Add(new ComboBoxItem()
                {
                    Tag = colors[i].Id,
                    Content = colors[i].Name,
                    Foreground = colors[i].Value
                });
            }

            /*
        O1c.Items.Add(item);
        O2c.Items.Add(item);
        O3c.Items.Add(item);
        O4c.Items.Add(item);
        O5c.Items.Add(item);
        O6c.Items.Add(item);
        O7c.Items.Add(item);//*/
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

        private void Page_Initialized(object sender, EventArgs e)
        {
            O1n.SelectedIndex = 0;
            O2n.SelectedIndex = 0;
            O3n.SelectedIndex = 0;
            O4n.SelectedIndex = 0;
            O5n.SelectedIndex = 0;
            O6n.SelectedIndex = 0;
            O7n.SelectedIndex = 0;
            HostSide.SelectedIndex = 0;
            O1s.SelectedIndex = 0;
            O2s.SelectedIndex = 0;
            O3s.SelectedIndex = 0;
            O4s.SelectedIndex = 0;
            O5s.SelectedIndex = 0;
            O6s.SelectedIndex = 0;
            O7s.SelectedIndex = 0;
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
            ComboBoxItem Item = HostColor.SelectedItem as ComboBoxItem;
            MessageBox.Show(
                "Id：" + ((uint)Item.Tag).ToString() + "\n" +
                "Text：" + Item.Content + "\n" +
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
            spawn.Settings.Color = (byte)HostColor.Tag;
            spawn.Settings.Side = (byte)HostSide.Tag;
            spawn.SpawnLocations.Multi1= (byte)HostLoc.Tag;

            // 这是遭遇战全部AI的配置
            spawn.HouseColors.Multi2 = (byte)O1c.Tag;
            spawn.HouseHandicaps.Multi2 = (byte)O1n.Tag;
            spawn.HouseCountries.Multi2 = (byte)O1s.Tag;
            spawn.SpawnLocations.Multi2 = (byte)O1l.Tag;
            spawn.HouseColors.Multi3 = (byte)O2c.Tag;
            spawn.HouseHandicaps.Multi3 = (byte)O2n.Tag;
            spawn.HouseCountries.Multi3 = (byte)O2s.Tag;
            spawn.SpawnLocations.Multi3 = (byte)O2l.Tag;
            spawn.HouseColors.Multi4 = (byte)O3c.Tag;
            spawn.HouseHandicaps.Multi4 = (byte)O3n.Tag;
            spawn.HouseCountries.Multi4 = (byte)O3s.Tag;
            spawn.SpawnLocations.Multi4 = (byte)O3l.Tag;
            spawn.HouseColors.Multi5 = (byte)O4c.Tag;
            spawn.HouseHandicaps.Multi5 = (byte)O4n.Tag;
            spawn.HouseCountries.Multi5 = (byte)O4s.Tag;
            spawn.SpawnLocations.Multi5 = (byte)O4l.Tag;
            spawn.HouseColors.Multi6 = (byte)O5c.Tag;
            spawn.HouseHandicaps.Multi6 = (byte)O5n.Tag;
            spawn.HouseCountries.Multi6 = (byte)O5s.Tag;
            spawn.SpawnLocations.Multi6 = (byte)O5l.Tag;
            spawn.HouseColors.Multi7 = (byte)O6c.Tag;
            spawn.HouseHandicaps.Multi7 = (byte)O6n.Tag;
            spawn.HouseCountries.Multi7 = (byte)O6s.Tag;
            spawn.SpawnLocations.Multi7 = (byte)O6l.Tag;
            spawn.HouseColors.Multi8 = (byte)O7c.Tag;
            spawn.HouseHandicaps.Multi8 = (byte)O7n.Tag;
            spawn.HouseCountries.Multi8 = (byte)O7s.Tag;
            spawn.SpawnLocations.Multi8 = (byte)O7l.Tag;
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
