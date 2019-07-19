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

        int MaxPlayerNum = 7;

        public Skirmish()
        {
            InitializeComponent();
            Initialization();
        }
        void Initialization()
        {
            #region 玩家框初始化
            InitNameCB(O1n);
            InitNameCB(O2n);
            InitNameCB(O3n);
            InitNameCB(O4n);
            InitNameCB(O5n);
            InitNameCB(O6n);
            InitNameCB(O7n);

            InitSideCB(HostSide);
            InitSideCB(O1s);
            InitSideCB(O2s);
            InitSideCB(O3s);
            InitSideCB(O4s);
            InitSideCB(O5s);
            InitSideCB(O6s);
            InitSideCB(O7s);

            InitColCB(HostColor);
            InitColCB(O1c);
            InitColCB(O2c);
            InitColCB(O3c);
            InitColCB(O4c);
            InitColCB(O5c);
            InitColCB(O6c);
            InitColCB(O7c);

            InitLocCB(HostLoc);
            InitLocCB(O1l);
            InitLocCB(O2l);
            InitLocCB(O3l);
            InitLocCB(O4l);
            InitLocCB(O5l);
            InitLocCB(O6l);
            InitLocCB(O7l);

            InitTeamCB(HostTeam);
            InitTeamCB(O1t);
            InitTeamCB(O2t);
            InitTeamCB(O3t);
            InitTeamCB(O4t);
            InitTeamCB(O5t);
            InitTeamCB(O6t);
            InitTeamCB(O7t);
            #endregion
            Credits.SelectedIndex = 0;
            TechLevel.SelectedIndex = 0;
            UnitCount.SelectedIndex = 0;
            GameSpeed.SelectedIndex = 0;
        }
        void InitNameCB(ComboBox comboBox)
        {
            comboBox.Items.Add("---");
            comboBox.Items.Add("困难AI");
            comboBox.Items.Add("中等AI");
            comboBox.Items.Add("简单AI");
            comboBox.SelectedIndex = 0;
        }
        void InitSideCB(ComboBox comboBox)
        {
            comboBox.Items.Add("---");
            comboBox.Items.Add("Side0");
            comboBox.Items.Add("Side1");
            comboBox.Items.Add("Side2");
            comboBox.SelectedIndex = 0;
        }
        void InitColCB(ComboBox comboBox)
        {
            comboBox.Items.Add("---");
            comboBox.Items.Add("Color1");
            comboBox.Items.Add("Color2");
            comboBox.SelectedIndex = 0;
        }
        void InitLocCB(ComboBox comboBox)
        {
            comboBox.Items.Add("-");
            comboBox.Items.Add("1");
            comboBox.Items.Add("2");
            comboBox.Items.Add("3");
            comboBox.Items.Add("4");
            comboBox.Items.Add("5");
            comboBox.Items.Add("6");
            comboBox.Items.Add("7");
            comboBox.Items.Add("8");
            comboBox.SelectedIndex = 0;
        }
        void InitTeamCB(ComboBox comboBox)
        {
            comboBox.Items.Add("-");
            comboBox.Items.Add("A");
            comboBox.Items.Add("B");
            comboBox.Items.Add("C");
            comboBox.Items.Add("D");
            comboBox.SelectedIndex = 0;
        }














        private void RunGame(object sender, RoutedEventArgs e)
        {

            spawn.Settings.Credits = Convert.ToUInt32(this.Credits.SelectionBoxItemStringFormat);
            spawn.Settings.TechLevel = Convert.ToByte(this.TechLevel.SelectionBoxItemStringFormat);
            spawn.Settings.UnitCount = Convert.ToByte(this.GameSpeed.SelectionBoxItemStringFormat);
            spawn.Settings.GameSpeed = Convert.ToByte(this.GameSpeed.SelectionBoxItemStringFormat);
            spawn.Settings.ShortGame = ShortGame.IsChecked;
            spawn.Settings.MCVRedeploy = MCVRedeploy.IsChecked;
            spawn.Settings.BuildOffAlly = BuildOffAlly.IsChecked;
            spawn.Settings.Superweapons = Superweapons.IsChecked;
            spawn.Settings.AlliesAllowed = ShortGame.IsChecked;
            spawn.Settings.Creates = Creates.IsChecked;
            spawn.Settings.Name = this.HostName.Text;
            spawn.Settings.Side = ComboBoxSelectedIndex2Byte(HostSide);
            spawn.Settings.Color= ComboBoxSelectedIndex2Byte(HostColor);
            AIplayerset();
            SpawnUnifiedSet();

            spawn.Write();
            Program.Program.RunSyringe();
        }
        void AIplayerset()
        {
            spawn.HouseCountries.Multi2 = ComboBoxSelectedIndex2Byte(O1s, O1n);
            spawn.HouseCountries.Multi3 = ComboBoxSelectedIndex2Byte(O2s, O1n);
            spawn.HouseCountries.Multi4 = ComboBoxSelectedIndex2Byte(O3s, O1n);
            spawn.HouseCountries.Multi5 = ComboBoxSelectedIndex2Byte(O4s, O1n);
            spawn.HouseCountries.Multi6 = ComboBoxSelectedIndex2Byte(O5s, O1n);
            spawn.HouseCountries.Multi7 = ComboBoxSelectedIndex2Byte(O6s, O1n);
            spawn.HouseCountries.Multi8 = ComboBoxSelectedIndex2Byte(O7s, O1n);

            spawn.HouseHandicaps.Multi2 = AIPlayerComboBoxSelectedIndex2Byte(O1n);
            spawn.HouseHandicaps.Multi3 = AIPlayerComboBoxSelectedIndex2Byte(O2n);
            spawn.HouseHandicaps.Multi4 = AIPlayerComboBoxSelectedIndex2Byte(O3n);
            spawn.HouseHandicaps.Multi5 = AIPlayerComboBoxSelectedIndex2Byte(O4n);
            spawn.HouseHandicaps.Multi6 = AIPlayerComboBoxSelectedIndex2Byte(O5n);
            spawn.HouseHandicaps.Multi7 = AIPlayerComboBoxSelectedIndex2Byte(O6n);
            spawn.HouseHandicaps.Multi8 = AIPlayerComboBoxSelectedIndex2Byte(O7n);

            spawn.HouseColors.Multi2 = ComboBoxSelectedIndex2Byte(O1c, O1n);
            spawn.HouseColors.Multi3 = ComboBoxSelectedIndex2Byte(O2c, O1n);
            spawn.HouseColors.Multi4 = ComboBoxSelectedIndex2Byte(O3c, O1n);
            spawn.HouseColors.Multi5 = ComboBoxSelectedIndex2Byte(O4c, O1n);
            spawn.HouseColors.Multi6 = ComboBoxSelectedIndex2Byte(O5c, O1n);
            spawn.HouseColors.Multi7 = ComboBoxSelectedIndex2Byte(O6c, O1n);
            spawn.HouseColors.Multi8 = ComboBoxSelectedIndex2Byte(O7c, O1n);
        }
        void SpawnUnifiedSet()
        {
            spawn.SpawnLocations.Multi1 = ComboBox2byte(HostLoc);
            spawn.SpawnLocations.Multi2 = ComboBox2byte(O1l, O1n);
            spawn.SpawnLocations.Multi3 = ComboBox2byte(O2l, O1n);
            spawn.SpawnLocations.Multi4 = ComboBox2byte(O3l, O1n);
            spawn.SpawnLocations.Multi5 = ComboBox2byte(O4l, O1n);
            spawn.SpawnLocations.Multi6 = ComboBox2byte(O5l, O1n);
            spawn.SpawnLocations.Multi7 = ComboBox2byte(O6l, O1n);
            spawn.SpawnLocations.Multi8 = ComboBox2byte(O7l, O1n);
        }

        byte? ComboBoxSelectedIndex2Byte(ComboBox comboBox, ComboBox Master)
        {
            if (Master.SelectedIndex == 0) return null;
            if (comboBox.SelectedIndex == -1) return null;
            else return (byte)comboBox.SelectedIndex;
        }
        byte? ComboBoxSelectedIndex2Byte(ComboBox comboBox)
        {
            if (comboBox.SelectedIndex == -1) return null;
            else return (byte)comboBox.SelectedIndex;
        }

        byte? AIPlayerComboBoxSelectedIndex2Byte(ComboBox comboBox)
        {
            if (comboBox.SelectedIndex == -1) return null;
            else if (comboBox.SelectedIndex == 0) return null;
            else return Convert.ToByte(comboBox.SelectedIndex - 1);
        }
        byte? ComboBox2byte(ComboBox comboBox, ComboBox Master)
        {
            if (Master.SelectedIndex == 0) return null;
            Random rd = new Random();
            if (comboBox.SelectedItem == null) return null;
            if (comboBox.SelectedIndex==0) return (byte)rd.Next(0, MaxPlayerNum);
            else
            {
                int a = Convert.ToInt32(comboBox.SelectedItem.ToString());
                return Convert.ToByte(a - 1);
            }
        }
        byte? ComboBox2byte(ComboBox comboBox)
        {
            Random rd = new Random();
            if (comboBox.SelectedItem == null) return null;
            if (comboBox.SelectedIndex == 0) return (byte)rd.Next(0, MaxPlayerNum);
            else
            {
                int a = Convert.ToInt32(comboBox.SelectedItem.ToString());
                return Convert.ToByte(a - 1);
            }
        }


    }
}
