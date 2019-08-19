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
    /// Settings.xaml 的交互逻辑
    /// </summary>
    public partial class Settings : Page
    {

        string NoneName = "None";

        public Settings()
        {
            InitializeComponent();

            cbScreen.Text = Ra2md.Video.ScreenWidth().ToString() + 'x' + Ra2md.Video.ScreenHeight().ToString();
            sSoundSetting.Value = Ra2md.Audio.SoundVolume();
            sScoreSetting.Value = Ra2md.Audio.ScoreVolume();
            sVoiceSetting.Value = Ra2md.Audio.VoiceVolume();
            cbDetailLevel.SelectedIndex = Ra2md.Options.DetailLevel();
            cbWindowed.IsChecked = Ra2md.Video.Windowed();
            cbNoFrame.IsChecked = Ra2md.Video.NoWindowFrame();
            cbVideoBackBuffer.IsChecked = Ra2md.Video.VideoBackBuffer();
            cbShuffleMusic.IsChecked = Ra2md.Audio.IsScoreShuffle();
            cbUnitActionLines.IsChecked = Ra2md.Options.UnitActionLines();
            cbShowHidden.IsChecked = Ra2md.Options.ShowHidden();
            cbScrollMethod.IsChecked = Ra2md.Options.ScrollMethod();
            cbToolTips.IsChecked = Ra2md.Options.ToolTips();
            tbHandle.Text = Ra2md.MultiPlayer.Handle();
            sScrollRate.Value = 6 - Ra2md.Options.ScrollRate();
            Renderer();
        }

        void Renderer()
        {
            cbRenderer.Items.Add(NoneName);
            Initialization.Config.Renderer[] renderers = Global.RendererList.ToArray();
            int a = renderers.Length;
            for (int i = 0; i < a; i++)
            {
                cbRenderer.Items.Add(renderers[i].Name);
            }
        }


        #region 设置
        private void MusicSet(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double Value = Convert.ToDouble(sSoundSetting.Value.ToString("#0.0"));
            Ra2md.Audio.SoundVolume(Value);
            sSoundSetting.Value = Value;
        }
        private void ScoreSet(object sender, RoutedEventArgs e)
        {
            double Value = Convert.ToDouble(sScoreSetting.Value.ToString("#0.0"));
            Ra2md.Audio.ScoreVolume(Value);
            sScoreSetting.Value = Value;
        }
        private void VoiceSet(object sender, RoutedEventArgs e)
        {
            double Value = Convert.ToDouble(sVoiceSetting.Value.ToString("#0.0"));
            Ra2md.Audio.VoiceVolume(Value);
            sVoiceSetting.Value = Value;
        }
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
                cbNoFrame.IsChecked = false;
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
        private void ShowHidden(object sender, RoutedEventArgs e)// 提示隐藏对象
        {
            if (cbShowHidden.IsChecked == true)
                Ra2md.Options.ShowHidden(true);
            else if (cbShowHidden.IsChecked == false)
                Ra2md.Options.ShowHidden(false);
            else return;
        }
        private void ScrollMethod(object sender, RoutedEventArgs e)// 惯性滚动
        {
            if (cbScrollMethod.IsChecked == true)
                Ra2md.Options.ScrollMethod(true);
            else if (cbScrollMethod.IsChecked == false)
                Ra2md.Options.ScrollMethod(false);
            else return;
        }
        private void ToolTips(object sender, RoutedEventArgs e)// 工具提示
        {
            if (cbToolTips.IsChecked == true)
                Ra2md.Options.ToolTips(true);
            else if (cbToolTips.IsChecked == false)
                Ra2md.Options.ToolTips(false);
            else return;
        }
        private void Handle(object sender, TextChangedEventArgs e)// 游戏者名
        {
            Ra2md.MultiPlayer.Handle(tbHandle.Text);
        }

        #endregion

        private void ScrollRate(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int Value = 6 - (int)sScrollRate.Value;
            Ra2md.Options.ScrollRate(Value);
            sScrollRate.Value = 6 - Value;
        }

        private void CbRenderer_DropDownClosed(object sender, EventArgs e)
        {
            if((string)cbRenderer.SelectionBoxItem == NoneName)
            {
                CrapeClientCore.Renderer.Clear();
                return;
            }

            Initialization.Config.Renderer[] renderers = Global.RendererList.ToArray();
            int a = renderers.Length;
            for (int i = 0; i < a; i++)
            {
                if ((string)cbRenderer.SelectionBoxItem == renderers[i].Name)
                {
                    CrapeClientCore.Renderer.RendererSet(renderers[i]);
                }
            }

        }
    }
}
