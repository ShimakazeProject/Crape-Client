using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Crape_Client.Global;
using Crape_Client.CrapeClientCore;

namespace Crape_Client.CrapeClientUI
{
    class SettingMgr: UserControl
    {
        // 临时用常量
        const string NoneName = "None";

        Grid Grid = new Grid();//根
        ScrollViewer SV;
        // SP
        TextBlock title;// 页面标题
        StackPanel SP;

        // 窗体控件
        Canvas GB1C = new Canvas() { Height = 150 };
        ComboBox GB1CB1;
        ComboBox GB1CB2;
        ComboBox GB1CB3;
        CheckBox GB1cb1;
        CheckBox GB1cb2;
        CheckBox GB1cb3;
        Canvas GB2C = new Canvas() { Height = 150 };
        Slider GB2S1;
        Slider GB2S2;
        Slider GB2S3;
        CheckBox GB2cb1;
        Canvas GB3C = new Canvas() { Height = 150 };
        CheckBox GB3cb1;
        CheckBox GB3cb2;
        CheckBox GB3cb3;
        CheckBox GB3cb4;
        TextBox GB3TB;
        Slider GB3S1;
        public SettingMgr()
        {
            Content = Grid;
            title = new TextBlock()
            {
                Text = "设置",
                FontSize = GUIconfigs.Global.Title.FontSize,
                Foreground = GUIconfigs.Global.Title.Foreground,
                Height = GUIconfigs.Global.Title.Height,
                Margin = GUIconfigs.Global.Title.Margin,
                VerticalAlignment = VerticalAlignment.Top
            };
            Grid.Children.Add(title);
            SP = new StackPanel();
            SV = new ScrollViewer()
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
                Padding = new Thickness(10),
                Style = (Style)FindResource("ScrollViewer"),
                Margin = new Thickness(0, title.Height, 0, 0),
                Content = SP
            };
            Grid.Children.Add(SV);
            #region GB1
            GroupBox GB1 = new GroupBox()
            {
                Margin = new Thickness(20, 5, 20, 0),
                Header = "显示设置",
                Style = (Style)FindResource("TitleBox_GroupBox"),
                Content = GB1C,
                Foreground = Tools.String2Brush("#FFF")
            };
            SP.Children.Add(GB1);
            Label GB1lab1 = new Label() {
                Content = "分辨率",
                Foreground = Tools.String2Brush("#FFF")
            };
            Canvas.SetLeft(GB1lab1, 15);
            Canvas.SetTop(GB1lab1, 10);
            GB1C.Children.Add(GB1lab1);
            Label GB1lab2 = new Label()
            {
                Content = "画面质量",
                Foreground = Tools.String2Brush("#FFF")
    };
            Canvas.SetLeft(GB1lab2, 15);
            Canvas.SetTop(GB1lab2, 40);
            GB1C.Children.Add(GB1lab2);
            Label GB1lab3 = new Label()
            {
                Content = "渲染器",
                Foreground = Tools.String2Brush("#FFF")
            };
            Canvas.SetLeft(GB1lab3, 15);
            Canvas.SetTop(GB1lab3, 70);
            GB1C.Children.Add(GB1lab3);
            GB1CB1 = new ComboBox()
            {
                Width = 100,
                Height = 24,
                Style = (Style)FindResource("ComboBox")
            };
            Canvas.SetTop(GB1CB1, 10);
            Canvas.SetLeft(GB1CB1, 80);
            GB1CB1.DropDownClosed += SetScreen;
            #region Items
            GB1CB1.Items.Add(new ComboBoxItem()
            {
                Content = "800x600",
                DataContext = new c_ScreenWH(800,600)
            });
            GB1CB1.Items.Add(new ComboBoxItem()
            {
                Content = "1024x768",
                DataContext = new c_ScreenWH(1024, 768)
            });
            GB1CB1.Items.Add(new ComboBoxItem()
            {
                Content = "1152x864",
                DataContext = new c_ScreenWH(1152, 864)
            });
            GB1CB1.Items.Add(new ComboBoxItem()
            {
                Content = "1280x720",
                DataContext = new c_ScreenWH(1280, 720)
            });
            GB1CB1.Items.Add(new ComboBoxItem()
            {
                Content = "1280x768",
                DataContext = new c_ScreenWH(1280, 768)
            });
            GB1CB1.Items.Add(new ComboBoxItem()
            {
                Content = "1280x800",
                DataContext = new c_ScreenWH(1280, 800)
            });
            GB1CB1.Items.Add(new ComboBoxItem()
            {
                Content = "1280x960",
                DataContext = new c_ScreenWH(1280, 960)
            });
            GB1CB1.Items.Add(new ComboBoxItem()
            {
                Content = "1280x1024",
                DataContext = new c_ScreenWH(1280, 1024)
            });
            GB1CB1.Items.Add(new ComboBoxItem()
            {
                Content = "1360x768",
                DataContext = new c_ScreenWH(1360, 768)
            });
            GB1CB1.Items.Add(new ComboBoxItem()
            {
                Content = "1360x1024",
                DataContext = new c_ScreenWH(1360, 1024)
            });
            GB1CB1.Items.Add(new ComboBoxItem()
            {
                Content = "1440x900",
                DataContext = new c_ScreenWH(1440, 900)
            });
            GB1CB1.Items.Add(new ComboBoxItem()
            {
                Content = "1680x1050",
                DataContext = new c_ScreenWH(1680, 1050)
            });
            GB1CB1.Items.Add(new ComboBoxItem()
            {
                Content = "1776x1000",
                DataContext = new c_ScreenWH(1776, 1000)
            });
            GB1CB1.Items.Add(new ComboBoxItem()
            {
                Content = "1920x1080",
                DataContext = new c_ScreenWH(1920, 1080)
            });
            #endregion
            Screen();
            GB1C.Children.Add(GB1CB1);
            GB1CB2 = new ComboBox()
            {
                Width = 100,
                Height = 24,
                Style = (Style)FindResource("ComboBox")
            };
            Canvas.SetTop(GB1CB2, 37);
            Canvas.SetLeft(GB1CB2, 80);
            GB1CB2.DropDownClosed += SeletDetailLevel;
            #region Items
            GB1CB2.Items.Add(new ComboBoxItem()
            {
                Content = "高",
                DataContext = 2
            });
            GB1CB2.Items.Add(new ComboBoxItem()
            {
                Content = "中",
                DataContext = 1
            });
            GB1CB2.Items.Add(new ComboBoxItem()
            {
                Content = "低",
                DataContext = 0
            });
            #endregion
            GB1C.Children.Add(GB1CB2);
            GB1CB3 = new ComboBox()
            {
                Width = 100,
                Height = 24,
                IsReadOnly = true,
                Style = (Style)FindResource("ComboBox")
            };
            Canvas.SetTop(GB1CB3, 64);
            Canvas.SetLeft(GB1CB3, 80);
            GB1CB3.DropDownClosed += SeletRenderer;
            Renderer();
            GB1C.Children.Add(GB1CB3);
            GB1cb1 = new CheckBox()
            {
                Content = "窗口化",
                Style = (Style)FindResource("CheckBox")
            };
            Canvas.SetTop(GB1cb1, 95);
            Canvas.SetLeft(GB1cb1, 25);
            GB1cb1.Checked += IsWindowed;
            GB1cb1.Unchecked += IsWindowed;
            GB1cb2 = new CheckBox()
            {
                Content = "无边框",
                Style = (Style)FindResource("CheckBox"),
                IsEnabled = false
            };
            Canvas.SetTop(GB1cb2, 116);
            Canvas.SetLeft(GB1cb2, 40);
            GB1cb2.Checked += IsNoFrame;
            GB1cb2.Unchecked += IsNoFrame;
            GB1cb3 = new CheckBox()
            {
                Content = "视频内存缓存",
                Style = (Style)FindResource("CheckBox")
            };
            Canvas.SetTop(GB1cb3, 137);
            Canvas.SetLeft(GB1cb3, 25);
            GB1cb3.Checked += VideoBackBuffer;
            GB1cb3.Unchecked += VideoBackBuffer;
            GB1C.Children.Add(GB1cb1);
            GB1C.Children.Add(GB1cb2);
            GB1C.Children.Add(GB1cb3);
            #endregion
            #region GB2
            GroupBox GB2 = new GroupBox()
            {
                Margin = new Thickness(20, 5, 20, 0),
                Header = "声音设置",
                Style = (Style)FindResource("TitleBox_GroupBox"),
                Content = GB2C,
                Foreground = Tools.String2Brush("#FFF")
            };
            SP.Children.Add(GB2);
            Label GB2lab1 = new Label() {
                Content="游戏音量",
                Foreground = Tools.String2Brush("#FFF")
            };
            Canvas.SetTop(GB2lab1, 16);
            Canvas.SetLeft(GB2lab1, 10);
            Label GB2lab2 = new Label()
            {
                Content = "音效音量",
                Foreground = Tools.String2Brush("#FFF")
            };
            Canvas.SetTop(GB2lab2, 49);
            Canvas.SetLeft(GB2lab2, 10);
            Label GB2lab3 = new Label()
            {
                Content = "语音音量",
                Foreground = Tools.String2Brush("#FFF")
            };
            Canvas.SetTop(GB2lab3, 82);
            Canvas.SetLeft(GB2lab3, 10);
            GB2C.Children.Add(GB2lab1);
            GB2C.Children.Add(GB2lab2);
            GB2C.Children.Add(GB2lab3);
            GB2S1 = new Slider()
            {
                Style = (Style)FindResource("Slider_CustomStyle"),
                Width = 200,
                Maximum = 1,
                LargeChange = 0.3,
            };
            Canvas.SetTop(GB2S1, 14);
            Canvas.SetLeft(GB2S1, 90);
            GB2S1.ValueChanged += VolumeSet;
            GB2S2 = new Slider()
            {
                Style = (Style)FindResource("Slider_CustomStyle"),
                Width = 200,
                Maximum = 1,
                LargeChange = 0.3,
            };
            Canvas.SetTop(GB2S2, 47);
            Canvas.SetLeft(GB2S2, 90);
            GB2S2.ValueChanged += VolumeSet;
            GB2S3 = new Slider()
            {
                Style = (Style)FindResource("Slider_CustomStyle"),
                Width = 200,
                Maximum = 1,
                LargeChange = 0.3,
            };
            Canvas.SetTop(GB2S3, 80);
            Canvas.SetLeft(GB2S3, 90);
            GB2S3.ValueChanged += VolumeSet;
            GB2cb1 = new CheckBox()
            {
                Content = "随机播放游戏音乐",
                Style = (Style)FindResource("CheckBox"),
            };
            Canvas.SetTop(GB2cb1, 115);
            GB2cb1.Checked += IsShuffle;
            GB2cb1.Unchecked += IsShuffle;
            GB2C.Children.Add(GB2S1);
            GB2C.Children.Add(GB2S2);
            GB2C.Children.Add(GB2S3);
            GB2C.Children.Add(GB2cb1);
            #endregion
            #region GB3
            GroupBox GB3 = new GroupBox()
            {
                Margin = new Thickness(20, 5, 20, 0),
                Header = "游戏设置",
                Style = (Style)FindResource("TitleBox_GroupBox"),
                Content = GB3C,
                Foreground = Tools.String2Brush("#FFF")
            };
            SP.Children.Add(GB3);
            Label GB3lab1 = new Label()
            {
                Content = "卷动速率",
                Foreground = Tools.String2Brush("#FFF")
            };
            Canvas.SetTop(GB3lab1, 14);
            Canvas.SetLeft(GB3lab1, 15);
            Label GB3lab2 = new Label()
            {
                Content = "游戏者名",
                Foreground = Tools.String2Brush("#FFF")
            };
            Canvas.SetTop(GB3lab2, 104);
            Canvas.SetLeft(GB3lab2, 15);
            GB3C.Children.Add(GB3lab1);
            GB3C.Children.Add(GB3lab2);
            GB3S1 = new Slider()
            {
                Style = (Style)FindResource("Slider_CustomStyle"),
                Width = 210,
                Maximum = 6,
                LargeChange = 3,
            };
            Canvas.SetTop(GB3S1, 14);
            Canvas.SetLeft(GB3S1, 95);
            GB3S1.ValueChanged += ScrollRate;
            GB3cb1 = new CheckBox()
            {
                Content = "惯性滚动",
                Style = (Style)FindResource("CheckBox"),
            };
            Canvas.SetTop(GB3cb1, 58);
            Canvas.SetLeft(GB3cb1, 25);
            GB3cb1.Checked += ScrollMethod;
            GB3cb1.Unchecked += ScrollMethod;
            GB3cb2 = new CheckBox()
            {
                Content = "显示目标线",
                Style = (Style)FindResource("CheckBox"),
            };
            Canvas.SetTop(GB3cb2, 79);
            Canvas.SetLeft(GB3cb2, 25);
            GB3cb2.Checked += UnitActionLines;
            GB3cb2.Unchecked += UnitActionLines;
            GB3cb3 = new CheckBox()
            {
                Content = "提示隐藏对象",
                Style = (Style)FindResource("CheckBox"),
            };
            Canvas.SetTop(GB3cb3, 58);
            Canvas.SetLeft(GB3cb3, 190);
            GB3cb3.Checked += ShowHidden;
            GB3cb3.Unchecked += ShowHidden;
            GB3cb4 = new CheckBox()
            {
                Content = "工具提示",
                Style = (Style)FindResource("CheckBox"),
            };
            Canvas.SetTop(GB3cb4, 79);
            Canvas.SetLeft(GB3cb4, 190);
            GB3cb4.Checked += ToolTips;
            GB3cb4.Unchecked += ToolTips;
            GB3TB = new TextBox()
            {
                Height = 23,
                Width = 260
            };
            Canvas.SetTop(GB3TB, 107);
            Canvas.SetLeft(GB3TB, 95);
            GB3TB.TextChanged += Handle;
            GB3C.Children.Add(GB3S1);
            GB3C.Children.Add(GB3cb1);
            GB3C.Children.Add(GB3cb2);
            GB3C.Children.Add(GB3cb3);
            GB3C.Children.Add(GB3cb4);
            GB3C.Children.Add(GB3TB);
            #endregion
            GB2S1.Value = Ra2md.Audio.SoundVolume;
            //MessageBox.Show(Ra2md.Audio.ScoreVolume.ToString()+"\n"+ Ra2md.Audio.VoiceVolume.ToString());
            GB2S2.Value = Ra2md.Audio.ScoreVolume;
            GB2S3.Value = Ra2md.Audio.VoiceVolume;
            GB1CB2.SelectedIndex = Ra2md.Options.DetailLevel;
            GB1cb1.IsChecked = Ra2md.Video.Windowed;
            GB1cb2.IsChecked = Ra2md.Video.NoWindowFrame;
            GB1cb3.IsChecked = Ra2md.Video.VideoBackBuffer;
            GB2cb1.IsChecked = Ra2md.Audio.IsScoreShuffle;
            GB3cb2.IsChecked = Ra2md.Options.UnitActionLines;
            GB3cb3.IsChecked = Ra2md.Options.ShowHidden;
            GB3cb1.IsChecked = Ra2md.Options.ScrollMethod;
            GB3cb4.IsChecked = Ra2md.Options.ToolTips;
            GB3TB.Text = Ra2md.MultiPlayer.Handle;
            GB3S1.Value = 6 - Ra2md.Options.ScrollRate;
        }
        private void Screen()
        {
            GB1CB1.Text = Ra2md.Video.ScreenWidth.ToString() + 'x' + Ra2md.Video.ScreenHeight.ToString();

        }
        private void Renderer()
        {
            string renderer = Ra2md.Video.Renderer;
            GB1CB3.Items.Add(NoneName);
            GB1CB3.SelectedIndex = 0;
            Initialization.Config.Renderer[] renderers = Globals.RendererList.ToArray();
            int a = renderers.Length;
            for (int i = 0; i < a; i++)
            {
                GB1CB3.Items.Add(renderers[i].Name);
                if (renderer == renderers[i].Name) GB1CB3.SelectedIndex = i + 1;
            }
        }

        private class c_ScreenWH
        {
            public uint Width { set; get; }
            public uint Height { set; get; }
            public c_ScreenWH(){
            }
            public c_ScreenWH(uint Width,uint Height)
            {
                this.Width = Width;
                this.Height = Height;
            }
        }
        // 控件事件方法
        private void SetScreen(object sender, EventArgs e)/* 分辨率设置 */
        {
            if(GB1CB1.SelectedItem is ComboBoxItem cbi)
            {
                if(cbi.DataContext is c_ScreenWH wh)
                {
                    Ra2md.Video.ScreenWidth = (int)wh.Width;
                    Ra2md.Video.ScreenHeight = (int)wh.Height;
                }
            }
        }
        private void SeletDetailLevel(object sender, EventArgs e)// 画质
        {
            if (GB1CB1.SelectedItem is ComboBoxItem cbi)
            {
                Ra2md.Options.DetailLevel = (int)cbi.DataContext;
            }
        }
        private void SeletRenderer(object sender, EventArgs e)// 选择渲染器
        {
            string Selet = (string)GB1CB3.SelectionBoxItem;
            Ra2md.Video.Renderer = Selet;
            if (Selet == NoneName)
            {
                CrapeClientCore.Renderer.Clear();
                return;
            }

            Initialization.Config.Renderer[] renderers = Globals.RendererList.ToArray();
            int a = renderers.Length;
            for (int i = 0; i < a; i++)
            {
                if (Selet == renderers[i].Name)
                {
                    CrapeClientCore.Renderer.RendererSet(renderers[i]);
                }
            }

        }
        private void IsWindowed(object sender, RoutedEventArgs e)// 窗口化
        {
            if (GB1cb1.IsChecked == true)
            {
                Ra2md.Video.Windowed = true;
                GB1cb2.IsEnabled = true;
            }
            else if (GB1cb1.IsChecked == false)
            {
                Ra2md.Video.Windowed = false;
                GB1cb2.IsEnabled = false;
                GB1cb2.IsChecked = false;
            }
            else return;
        }
        private void IsNoFrame(object sender, RoutedEventArgs e)// 无边框
        {
            if (GB1cb1.IsChecked == true)
                Ra2md.Video.NoWindowFrame = true;
            else if (GB1cb1.IsChecked == false)
                Ra2md.Video.NoWindowFrame = false;
            else return;
        }
        private void VideoBackBuffer(object sender, RoutedEventArgs e)// 视频内存缓存
        {
            if (GB1cb3.IsChecked == true)
                Ra2md.Video.VideoBackBuffer = true;
            else if (GB1cb3.IsChecked == false)
                Ra2md.Video.VideoBackBuffer = false;
            else return;
        }
        private void VolumeSet(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double Value;
            Value = Convert.ToDouble(GB2S1.Value.ToString("#0.0"));
            Ra2md.Audio.SoundVolume = Value;
            GB2S1.Value = Value;
            Value = Convert.ToDouble(GB2S2.Value.ToString("#0.0"));
            Ra2md.Audio.ScoreVolume = Value;
            GB2S2.Value = Value;
            Value = Convert.ToDouble(GB2S3.Value.ToString("#0.0"));
            Ra2md.Audio.VoiceVolume = Value;
            GB2S3.Value = Value;
            //MessageBox.Show(Ra2md.Audio.ScoreVolume.ToString() + "\n" + Ra2md.Audio.VoiceVolume.ToString());
        }
        private void IsShuffle(object sender, RoutedEventArgs e)// 随机音乐
        {
            if (GB2cb1.IsChecked == true)
                Ra2md.Audio.IsScoreShuffle = true;
            else if (GB2cb1.IsChecked == false)
                Ra2md.Audio.IsScoreShuffle = false;
            else return;
        }
        private void ScrollRate(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int Value = 6 - (int)GB3S1.Value;
            Ra2md.Options.ScrollRate = Value;
            GB3S1.Value = 6 - Value;
        }
        private void UnitActionLines(object sender, RoutedEventArgs e)// 显示目标线
        {
            if (GB3cb2.IsChecked == true)
                Ra2md.Options.UnitActionLines = true;
            else if (GB3cb2.IsChecked == false)
                Ra2md.Options.UnitActionLines = false;
            else return;
        }
        private void ShowHidden(object sender, RoutedEventArgs e)// 提示隐藏对象
        {
            if (GB3cb3.IsChecked == true)
                Ra2md.Options.ShowHidden = true;
            else if (GB3cb3.IsChecked == false)
                Ra2md.Options.ShowHidden = false;
            else return;
        }
        private void ScrollMethod(object sender, RoutedEventArgs e)// 惯性滚动
        {
            if (GB3cb1.IsChecked == true)
                Ra2md.Options.ScrollMethod = true;
            else if (GB3cb1.IsChecked == false)
                Ra2md.Options.ScrollMethod = false;
            else return;
        }
        private void ToolTips(object sender, RoutedEventArgs e)// 工具提示
        {
            if (GB3cb4.IsChecked == true)
                Ra2md.Options.ToolTips = true;
            else if (GB3cb4.IsChecked == false)
                Ra2md.Options.ToolTips = false;
            else return;
        }
        private void Handle(object sender, TextChangedEventArgs e)// 游戏者名
        {
            Ra2md.MultiPlayer.Handle = GB3TB.Text;
        }
    }
}
