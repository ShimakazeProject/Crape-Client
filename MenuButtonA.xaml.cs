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

namespace Crape_Client.CrapeClientUI
{
    /// <summary>
    /// MenuButton.xaml 的交互逻辑
    /// </summary>
    public partial class MenuButtonA : UserControl
    {
        #region 属性
        public string ShadowText
        {
            set
            {
                tbShadow.Text = value;
            }
            get
            {
                return tbShadow.Text;
            }
        }
        public string SubShadowText
        {
            set
            {
                tbSubShadow.Text = value;
            }
            get
            {
                return tbSubShadow.Text;
            }
        }
        public string MainText
        {
            set
            {
                tbMain.Text = value;
            }
            get
            {
                return tbMain.Text;
            }
        }
        public string SubText
        {
            set
            {
                tbSub.Text = value;
            }
            get
            {
                return tbSub.Text;
            }
        }

        public Brush ShadowFore
        {
            set
            {
                tbSubShadow.Foreground = value;
                tbShadow.Foreground = value;
            }
            get
            {
                return tbShadow.Foreground;
            }
        }
        public Brush MainFore
        {
            set
            {
                tbMain.Foreground = value;
            }
            get
            {
                return tbMain.Foreground;
            }
        }
        public Brush SubFore
        {
            set
            {
                tbSub.Foreground = value;
            }
            get
            {
                return tbSub.Foreground;
            }
        }
        /// <summary>
        /// 色块颜色
        /// </summary>
        public Color BlockColor
        {
            set
            {
                gsColorBlock.Color = value;
            }
            get
            {
                return gsColorBlock.Color;
            }
        }
        /// <summary>
        /// 色块path
        /// </summary>
        public Path BlockPath
        {
            set
            {
                pColorBlock = value;
            }
            get
            {
                return pColorBlock;
            }
        }
        /// <summary>
        /// 背景path
        /// </summary>
        public Path BackPath
        {
            set
            {
                pBackPath = value;
            }
            get
            {
                return pBackPath;
            }
        }
        /// <summary>
        /// 阴影path
        /// </summary>
        public Path ShadowPath
        {
            set
            {
                pShadowPath = value;
            }
            get
            {
                return pShadowPath;
            }
        }
        /// <summary>
        /// 字影
        /// </summary>
        public TextBlock Shadow
        {
            set
            {
                tbShadow = value;
            }
            get
            {
                return tbShadow;
            }
        }
        /// <summary>
        /// 第二字影
        /// </summary>
        public TextBlock SubShadow
        {
            set
            {
                tbSubShadow = value;
            }
            get
            {
                return tbSubShadow;
            }
        }
        /// <summary>
        /// 字
        /// </summary>
        public TextBlock Main
        {
            set
            {
                tbMain = value;
            }
            get
            {
                return tbMain;
            }
        }
        /// <summary>
        /// 第二字
        /// </summary>
        public TextBlock Sub
        {
            set
            {
                tbSub = value;
            }
            get
            {
                return tbSub;
            }
        }
        #endregion
        public MenuButtonA()
        {
            InitializeComponent();
        }

    }
}
