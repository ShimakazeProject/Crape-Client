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

namespace Crape_Client.Controls
{
    /// <summary>
    /// MenuButton.xaml 的交互逻辑
    /// </summary>
    public partial class MenuButton : UserControl
    {

        public string MainText
        {
            get { return (string)GetValue(MainTextProperty); }
            set { SetValue(MainTextProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MainText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainTextProperty =
            DependencyProperty.Register("MainText", typeof(string), typeof(MenuButton), new PropertyMetadata("按钮"));

        public string SubText
        {
            get { return (string)GetValue(SubTextProperty); }
            set { SetValue(SubTextProperty, value); }
        }
        // Using a DependencyProperty as the backing store for SubText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SubTextProperty =
            DependencyProperty.Register("SubText", typeof(string), typeof(MenuButton), new PropertyMetadata("Button"));

        public double MainSize
        {
            get { return (double)GetValue(MainSizeProperty); }
            set { SetValue(MainSizeProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MainSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainSizeProperty =
            DependencyProperty.Register("MainSize", typeof(double), typeof(MenuButton), new PropertyMetadata((double)18));


        public double SubSize
        {
            get { return (double)GetValue(SubSizeProperty); }
            set { SetValue(SubSizeProperty, value); }
        }
        // Using a DependencyProperty as the backing store for SubSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SubSizeProperty =
            DependencyProperty.Register("SubSize", typeof(double), typeof(MenuButton), new PropertyMetadata((double)12));



        public Brush BlockColor
        {
            get { return (Brush)GetValue(BlockColorProperty); }
            set { SetValue(BlockColorProperty, value); }
        }
        // Using a DependencyProperty as the backing store for BlockColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BlockColorProperty =
            DependencyProperty.Register("BlockColor", typeof(Brush), typeof(MenuButton), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0xFF, 0, 0, 255))));






        public MenuButton()
        {
            InitializeComponent();
        }

    }
}
