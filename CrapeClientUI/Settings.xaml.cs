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
    /// Settings.xaml 的交互逻辑
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
        }
        #region 设置
        #region BGM大小
        private void MusicSet0(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(0);
        }
        private void MusicSet1(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(0.1);
        }
        private void MusicSet2(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(0.2);
        }
        private void MusicSet3(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(0.3);
        }
        private void MusicSet4(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(0.4);
        }
        private void MusicSet5(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(0.5);
        }
        private void MusicSet6(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(0.6);
        }
        private void MusicSet7(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(0.7);
        }
        private void MusicSet8(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(0.8);
        }
        private void MusicSet9(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(0.9);
        }
        private void MusicSetX(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.SoundVolume(1);
        }
        #endregion
        #region 音效大小
        private void ScoreSet0(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(0);
        }
        private void ScoreSet1(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(0.1);
        }
        private void ScoreSet2(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(0.2);
        }
        private void ScoreSet3(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(0.3);
        }
        private void ScoreSet4(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(0.4);
        }
        private void ScoreSet5(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(0.5);
        }
        private void ScoreSet6(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(0.6);
        }
        private void ScoreSet7(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(0.7);
        }
        private void ScoreSet8(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(0.8);
        }
        private void ScoreSet9(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(0.9);
        }
        private void ScoreSetX(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.ScoreVolume(1);
        }
        #endregion
        #region 语音大小
        private void VoiceSet0(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(0);
        }
        private void VoiceSet1(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(0.1);
        }
        private void VoiceSet2(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(0.2);
        }
        private void VoiceSet3(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(0.3);
        }
        private void VoiceSet4(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(0.4);
        }
        private void VoiceSet5(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(0.5);
        }
        private void VoiceSet6(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(0.6);
        }
        private void VoiceSet7(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(0.7);
        }
        private void VoiceSet8(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(0.8);
        }
        private void VoiceSet9(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(0.9);
        }
        private void VoiceSetX(object sender, RoutedEventArgs e)
        {
            Ra2md.Audio.VoiceVolume(1);
        }
        #endregion


        private void SetScreen(object sender, EventArgs e)/* 分辨率设置 */
        {
            try
            {
                string[] scr = cbScreen.SelectedItem.ToString().Split(':');
                scr = scr[1].Split('x');
                Ra2md.Video.ScreenWidth(Convert.ToInt32(scr[0]));
                Ra2md.Video.ScreenHeight(Convert.ToInt32(scr[1]));
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        private void SeletDetailLevel(object sender, EventArgs e)// 画质等级
        {
            if (cbDetailLevel.SelectedIndex < 3 && cbDetailLevel.SelectedIndex >= 0)
                Ra2md.Options.DetailLevel(cbDetailLevel.SelectedIndex);
        }
        private void IsWindowed(object sender, RoutedEventArgs e)// 窗口化
        {
            if (cbWindowed.IsChecked == true)
            {
                Ra2md.Video.Windowed(true);
                cbNoFrame.IsEnabled = true;
            }
            else if (cbWindowed.IsChecked == false)
            {
                Ra2md.Video.Windowed(false);
                cbNoFrame.IsEnabled = false;
            }
            else return;
        }
        private void IsNoFrame(object sender, RoutedEventArgs e)// 无边框
        {
            if (cbNoFrame.IsChecked == true)
                Ra2md.Video.NoWindowFrame(true);
            else if (cbNoFrame.IsChecked == false)
                Ra2md.Video.NoWindowFrame(false);
            else return;
        }
        private void VideoBackBuffer(object sender, RoutedEventArgs e)// 视频内存缓存
        {
            if (cbVideoBackBuffer.IsChecked == true)
                Ra2md.Video.VideoBackBuffer(true);
            else if (cbVideoBackBuffer.IsChecked == false)
                Ra2md.Video.VideoBackBuffer(false);
            else return;
        }
        private void IsShuffle(object sender, RoutedEventArgs e)// 随机音乐
        {
            if (cbShuffleMusic.IsChecked == true)
                Ra2md.Audio.IsScoreShuffle(true);
            else if (cbShuffleMusic.IsChecked == false)
                Ra2md.Audio.IsScoreShuffle(false);
            else return;
        }
        private void UnitActionLines(object sender, RoutedEventArgs e)// 显示目标线
        {
            if (cbUnitActionLines.IsChecked == true)
                Ra2md.Options.UnitActionLines(true);
            else if (cbUnitActionLines.IsChecked == false)
                Ra2md.Options.UnitActionLines(false);
            else return;
        }
        private void ShowHidden(object sender, RoutedEventArgs e)
        {
            if (cbShowHidden.IsChecked == true)
                Ra2md.Options.ShowHidden(true);
            else if (cbShowHidden.IsChecked == false)
                Ra2md.Options.ShowHidden(false);
            else return;
        }
        private void ScrollMethod(object sender, RoutedEventArgs e)
        {
            if (cbScrollMethod.IsChecked == true)
                Ra2md.Options.ScrollMethod(true);
            else if (cbScrollMethod.IsChecked == false)
                Ra2md.Options.ScrollMethod(false);
            else return;
        }
        private void ToolTips(object sender, RoutedEventArgs e)
        {
            if (cbToolTips.IsChecked == true)
                Ra2md.Options.ToolTips(true);
            else if (cbToolTips.IsChecked == false)
                Ra2md.Options.ToolTips(false);
            else return;
        }
        private void Handle(object sender, TextChangedEventArgs e)
        {
            Ra2md.MultiPlayer.Handle(tbHandle.Text);
        }
        #endregion

    }
}
