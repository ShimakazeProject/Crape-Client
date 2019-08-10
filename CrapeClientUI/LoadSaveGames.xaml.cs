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
using System.IO;
using Crape_Client.CrapeClientCore;

namespace Crape_Client.CrapeClientUI
{
    /// <summary>
    /// LoadSaveGames.xaml 的交互逻辑
    /// </summary>
    public partial class LoadSaveGames : Page
    {
        public LoadSaveGames()
        {
            InitializeComponent();
            try {
                Cls_SaveFiles[] List = Global.SaveFilesList.ToArray();
                for (int i = 0; i < List.Length; i++)
                {
                    dgLoadList.Items.Add(List[i]);
                }
            }catch(Exception e)
            {
                Nlog.logger.Fatal("Unknow Error:");
                Nlog.logger.Debug("Message : " + e.Message);
                Nlog.logger.Debug("Source : " + e.Source);
                Nlog.logger.Debug("TargetSite : " + e.TargetSite);
                Nlog.ErrorBoxShow(e);
            }

            
        }
        #region 存档列表

        private void LoadSave(object sender, MouseButtonEventArgs e)// 双击列表项
        {
            Spawn spawn = new Spawn();
            if (dgLoadList.SelectedItem is Cls_SaveFiles LoadSaveName && LoadSaveName is Cls_SaveFiles)
            {
                //*
                spawn.Settings.LoadSaveGame = true;
                spawn.Settings.SaveGameName = LoadSaveName.FileN;
                spawn.Settings.GameSpeed = 1;
                spawn.Settings.Firestorm = false;
                spawn.Settings.SidebarHack = false;
                spawn.Write();
                Program.RunSyringe();

                //*/
            }

        }
        #endregion
    }
}
