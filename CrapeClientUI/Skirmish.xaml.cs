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
    public partial class Skirmish : UserControl
    {

        private Spawn spawn = new Spawn();

        // Team ComboBox列表
        private List<ComboBox> TeamCBs = new List<ComboBox>();
        // 玩家结盟列表
        private List<int> TeamA = new List<int>();
        private List<int> TeamB = new List<int>();
        private List<int> TeamC = new List<int>();
        private List<int> TeamD = new List<int>();



        // int MaxPlayerNum = 7;
        public Skirmish()
        {
            InitializeComponent();
            HostName.Text = Ra2md.MultiPlayer.Handle;
            SideInit();
            ColorInit();
            TeamInit();

            TeamCBs = new List<ComboBox>(){
                // 初始化Team ComboBox列表(应该放到构造函数里)
                HostTeam,
                O1t,
                O2t,
                O3t,
                O4t,
                O5t,
                O6t,
                O7t,
            };

            List<AIplayer> namelist = new List<AIplayer>{
                new AIplayer{ Id=-1, Text = "无"}
                ,new AIplayer{ Id=2, Text = "简单"}
                ,new AIplayer{ Id=1, Text = "中等"}
                ,new AIplayer{ Id=0, Text = "困难"}
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

            HostLoc.ItemsSource = locallist;
            O1l.ItemsSource = locallist;
            O2l.ItemsSource = locallist;
            O3l.ItemsSource = locallist;
            O4l.ItemsSource = locallist;
            O5l.ItemsSource = locallist;
            O6l.ItemsSource = locallist;
            O7l.ItemsSource = locallist;
        }

        void ColorInit()
        {
            //Global.Globals.Colors
            Initialization.Config.Color[] colors = Global.Globals.Colors.ToArray();
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
        }
        void SideInit()
        {
            List<Brush> Colors = new List<Brush>();

            Initialization.Config.Side[] sides = Global.Globals.Sides.ToArray();
            Initialization.Config.SideList[] list = Global.Globals.SidesPlus.ToArray();
            HostSide.Items.Add(new ComboBoxItem()
            {
                Tag = -1,
                Content = "随机"
            });
            O1s.Items.Add(new ComboBoxItem()
            {
                Tag =-1,
                Content = "随机"
            });
            O2s.Items.Add(new ComboBoxItem()
            {
                Tag =-1,
                Content = "随机"
            });
            O3s.Items.Add(new ComboBoxItem()
            {
                Tag =-1,
                Content = "随机"
            });
            O4s.Items.Add(new ComboBoxItem()
            {
                Tag =-1,
                Content = "随机"
            });
            O5s.Items.Add(new ComboBoxItem()
            {
                Tag =-1,
                Content = "随机"
            });
            O6s.Items.Add(new ComboBoxItem()
            {
                Tag =-1,
                Content = "随机"
            });
            O7s.Items.Add(new ComboBoxItem()
            {
                Tag =-1,
                Content = "随机"
            });
            for (int i = 0; i < list.Length; i++)
            {
                Colors.Add(list[i].Color);
                HostSide.Items.Add(new ComboBoxItem()
                {
                    Tag = -2 - list[i].Id,
                    Content = list[i].Name,
                    Foreground = list[i].Color
                });
                O1s.Items.Add(new ComboBoxItem()
                {
                    Tag = -2 - list[i].Id,
                    Content = list[i].Name,
                    Foreground = list[i].Color
                });
                O2s.Items.Add(new ComboBoxItem()
                {
                    Tag = -2 - list[i].Id,
                    Content = list[i].Name,
                    Foreground = list[i].Color
                });
                O3s.Items.Add(new ComboBoxItem()
                {
                    Tag = -2 - list[i].Id,
                    Content = list[i].Name,
                    Foreground = list[i].Color
                });
                O4s.Items.Add(new ComboBoxItem()
                {
                    Tag = -2 - list[i].Id,
                    Content = list[i].Name,
                    Foreground = list[i].Color
                });
                O5s.Items.Add(new ComboBoxItem()
                {
                    Tag = -2 - list[i].Id,
                    Content = list[i].Name,
                    Foreground = list[i].Color
                });
                O6s.Items.Add(new ComboBoxItem()
                {
                    Tag = -2 - list[i].Id,
                    Content = list[i].Name,
                    Foreground = list[i].Color
                });
                O7s.Items.Add(new ComboBoxItem()
                {
                    Tag = -2 - list[i].Id,
                    Content = list[i].Name,
                    Foreground = list[i].Color
                });
            }
            Brush[] Color = Colors.ToArray();
            for (int i = 0; i < sides.Length; i++)
            {
                HostSide.Items.Add(new ComboBoxItem()
                {
                    Tag = sides[i].Id,
                    Content = sides[i].Name,
                    Foreground= Color[sides[i].Sides]
                });
                O1s.Items.Add(new ComboBoxItem()
                {
                    Tag = sides[i].Id,
                    Content = sides[i].Name,
                    Foreground = Color[sides[i].Sides]
                });
                O2s.Items.Add(new ComboBoxItem()
                {
                    Tag = sides[i].Id,
                    Content = sides[i].Name,
                    Foreground = Color[sides[i].Sides]
                });
                O3s.Items.Add(new ComboBoxItem()
                {
                    Tag = sides[i].Id,
                    Content = sides[i].Name,
                    Foreground = Color[sides[i].Sides]
                });
                O4s.Items.Add(new ComboBoxItem()
                {
                    Tag = sides[i].Id,
                    Content = sides[i].Name,
                    Foreground = Color[sides[i].Sides]
                });
                O5s.Items.Add(new ComboBoxItem()
                {
                    Tag = sides[i].Id,
                    Content = sides[i].Name,
                    Foreground = Color[sides[i].Sides]
                });
                O6s.Items.Add(new ComboBoxItem()
                {
                    Tag = sides[i].Id,
                    Content = sides[i].Name,
                    Foreground = Color[sides[i].Sides]
                });
                O7s.Items.Add(new ComboBoxItem()
                {
                    Tag = sides[i].Id,
                    Content = sides[i].Name,
                    Foreground = Color[sides[i].Sides]
                });
            }
        }
        void TeamInit()
        {
            ComboBox cb = new ComboBox();
            int i = 0;
            while (true)
            {
                if (i >= 8) return;
                else switch (i)
                    {
                        case 0:
                            cb = HostTeam;
                            break;
                        case 1:
                            cb = O1t;
                            break;
                        case 2:
                            cb = O2t;
                            break;
                        case 3:
                            cb = O3t;
                            break;
                        case 4:
                            cb = O4t;
                            break;
                        case 5:
                            cb = O5t;
                            break;
                        case 6:
                            cb = O6t;
                            break;
                        case 7:
                            cb = O7t;
                            break;
                    }
                cb.Items.Add(new ComboBoxItem() { Content = "-", DataContext = "-" });
                cb.Items.Add(new ComboBoxItem() { Content = "A", DataContext = "A" });
                cb.Items.Add(new ComboBoxItem() { Content = "B", DataContext = "B" });
                cb.Items.Add(new ComboBoxItem() { Content = "C", DataContext = "C" });
                cb.Items.Add(new ComboBoxItem() { Content = "D", DataContext = "D" });
                i++;
            }
        }
        class AIplayer
        {
            public int Id { get; set; }
            public string Text { get; set; }
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
            /*
            spawn.Settings.Scenario = lMapName.DataContext.ToString();
            spawn.Settings.Credits = Convert.ToUInt32(Credits.Text);
            spawn.Settings.TechLevel = Convert.ToByte(TechLevel.Text);
            spawn.Settings.UnitCount = Convert.ToByte(UnitCount.Text);
            spawn.Settings.GameSpeed = (byte)GameSpeed.Tag;
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
            //*/
            //SpawnTeam();

            spawn.Make();
        }


        private void SpawnTeam()// 添加玩家结盟列表
        {
            // 遍历TeamCBs
            {
                int i = 0;
                foreach (ComboBox cb in TeamCBs)
                {
                    string value = (string)((ComboBoxItem)cb.SelectedItem).DataContext;
                    switch (value)
                    {
                        case "A":
                            TeamA.Add(i);
                            break;
                        case "B":
                            TeamB.Add(i);
                            break;
                        case "C":
                            TeamC.Add(i);
                            break;
                        case "D":
                            TeamD.Add(i);
                            break;
                    }
                    i++;
                }
            }

            // 创建临时变量
            List<int> Team = new List<int>();

            foreach (int player in Team)
            {
                switch (player)
                {
                    case 1:
                        spawn.Multi1_Alliances.Add(player);
                        break;
                    case 2:
                        spawn.Multi2_Alliances.Add(player);
                        break;
                    case 3:
                        spawn.Multi3_Alliances.Add(player);
                        break;
                    case 4:
                        spawn.Multi4_Alliances.Add(player);
                        break;
                    case 5:
                        spawn.Multi5_Alliances.Add(player);
                        break;
                    case 6:
                        spawn.Multi6_Alliances.Add(player);
                        break;
                    case 7:
                        spawn.Multi7_Alliances.Add(player);
                        break;
                    case 8:
                        spawn.Multi8_Alliances.Add(player);
                        break;
                }

            }
            for (int i_ = 0; i_ < 4; i_++)
            {
                switch (i_)
                {
                    case 0:
                        Team = TeamA;
                        break;
                    case 1:
                        Team = TeamB;
                        break;
                    case 2:
                        Team = TeamC;
                        break;
                    case 3:
                        Team = TeamD;
                        break;
                }
                for (int i = 0; i < Team.Count; i++)
                {
                    switch (Team[i])
                    {
                        case 1:
                            foreach (int player in Team)
                                if (player != 1) spawn.Multi1_Alliances.Add(player);
                            break;
                        case 2:
                            foreach (int player in Team)
                                if (player != 2) spawn.Multi2_Alliances.Add(player);
                            break;
                        case 3:
                            foreach (int player in Team)
                                if (player != 3) spawn.Multi3_Alliances.Add(player);
                            break;
                        case 4:
                            foreach (int player in Team)
                                if (player != 4) spawn.Multi4_Alliances.Add(player);
                            break;
                        case 5:
                            foreach (int player in Team)
                                if (player != 5) spawn.Multi5_Alliances.Add(player);
                            break;
                        case 6:
                            foreach (int player in Team)
                                if (player != 6) spawn.Multi6_Alliances.Add(player);
                            break;
                        case 7:
                            foreach (int player in Team)
                                if (player != 7) spawn.Multi7_Alliances.Add(player);
                            break;
                        case 8:
                            foreach (int player in Team)
                                if (player != 8) spawn.Multi8_Alliances.Add(player);
                            break;
                    }
                }
            }
        }
    }

}
