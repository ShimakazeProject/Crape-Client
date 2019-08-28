using Crape_Client.CrapeClientCore;
using Crape_Client.Global;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Crape_Client.CrapeClientUI
{
    class SaveLoader:UserControl
    {
        DataGrid DG;
        public SaveLoader()
        {
            Width = GUIconfigs.MainWindowConfig.Width -
                GUIconfigs.MainWindowConfig.Logo.Width - 10;
            Height = GUIconfigs.MainWindowConfig.Height - 10;
            Grid Grid = new Grid();
            Content = Grid;
            TextBlock title = new TextBlock()
            {
                Text = GUIconfigs.SaveLoader.Title,
                FontSize = GUIconfigs.Global.Title.FontSize,
                Foreground = GUIconfigs.Global.Title.Foreground,
                Height = GUIconfigs.Global.Title.Height,
                Margin = GUIconfigs.Global.Title.Margin,
                VerticalAlignment = VerticalAlignment.Top
            };
            Grid.Children.Add(title);
            ScrollViewer SV = new ScrollViewer()
            {
                Style = (Style)FindResource("ScrollViewer"),
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                Padding = new Thickness(10),
                Margin = new Thickness(0, title.Height, 0, 0)
            };
            DG = new DataGrid()
            {
                Width = Width,
                Margin = new Thickness(0),
                Style = (Style)FindResource("DataGrid"),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Background = null,
            };
            DG.MouseDoubleClick += GameLoading;
            DataGridTextColumn DGTC1 = new DataGridTextColumn()
            {
                Header = GUIconfigs.SaveLoader.DGTC1.Header,
                Width = GUIconfigs.SaveLoader.DGTC1.Width,
                Binding = new Binding("Name")
            };

            DataGridTextColumn DGTC2 = new DataGridTextColumn()
            {
                Header = GUIconfigs.SaveLoader.DGTC2.Header,
                Binding = new Binding("Date")
            };
            DataGridTextColumn DGTC3 = new DataGridTextColumn()
            {
                Visibility = Visibility.Collapsed,
                Binding = new Binding("File")
            };
            DG.Columns.Add(DGTC1);
            DG.Columns.Add(DGTC2);
            DG.Columns.Add(DGTC3);
            try
            {
                Cls_SaveFiles[] List = Globals.SaveFilesList.ToArray();
                for (int i = 0; i < List.Length; i++)
                {
                    DG.Items.Add(List[i]);
                }
            }
            catch (Exception e)
            {
                Globals.LogMGR.Error(e);
                Globals.LogMGR.ErrorBoxShow();
            }
            SV.Content = DG;
            Grid.Children.Add(SV);
        }

        private void GameLoading(object sender, MouseButtonEventArgs e)
        {
            Spawn spawn = new Spawn();
            if (DG.SelectedItem is Cls_SaveFiles LoadSaveName)
            {
                /*
                MessageBox.Show(
                    "Name:\t" + LoadSaveName.Name + 
                    "\nData:\t" + LoadSaveName.Date + 
                    "\nFile:\t" + LoadSaveName.FileN);//*/
                //*
                spawn.Settings.LoadSaveGame = true;
                spawn.Settings.SaveGameName = LoadSaveName.File;
                spawn.Settings.GameSpeed = 1;
                spawn.Settings.Firestorm = false;
                spawn.Settings.SidebarHack = false;
                spawn.Make();
                Program.RunSyringe();

                //*/
            }
            // throw new NotImplementedException();
        }
    }
}
