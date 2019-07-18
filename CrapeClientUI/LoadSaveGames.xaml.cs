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
using Program;
using RA2.Ini;

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
            initialization();
        }
        #region 存档列表
        void initialization()// 加载存档列表
        {
            // AppDomain.CurrentDomain.BaseDirectory
            DirectoryInfo folder = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Saved Games");
            try
            {
                foreach (FileInfo file in folder.GetFiles("*.sav"))
                {
                    //Console.WriteLine(file.FullName);
                    dgLoadList.Items.Add(new Cls_SaveFiles
                    {
                        Name = GameSaveFile.LoadSaveName(File.ReadAllBytes(file.FullName)),
                        Date = file.LastWriteTime.ToString(),
                        FileN = file.Name
                    });// FullName?
                }
            }
            catch (DirectoryNotFoundException)
            {
                dgLoadList.Items.Add(new
                {
                    Name = "没有发现可用存档",
                    Data = "Null",
                    FileN = ""
                });
            }
        }
        private void LoadSave(object sender, MouseButtonEventArgs e)// 双击列表项
        {
            Spawn spawn = new Spawn();
            Cls_SaveFiles LoadSaveName = dgLoadList.SelectedItem as Cls_SaveFiles;
            if (LoadSaveName != null && LoadSaveName is Cls_SaveFiles)
            {
                //*
                spawn.Settings.LoadSaveGame = true;
                spawn.Settings.SaveGameName = LoadSaveName.FileN;
                spawn.Settings.GameSpeed = 1;
                spawn.Settings.Firestorm = false;
                spawn.Settings.SidebarHack = false;
                spawn.Write();
                Program.Program.RunSyringe();

                //*/
            }

        }
        #endregion
    }
}
