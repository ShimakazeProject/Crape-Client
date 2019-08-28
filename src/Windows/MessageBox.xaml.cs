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
using System.Windows.Shapes;

namespace Crape_Client.Windows
{
    /// <summary>
    /// MessageBox.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBox : Window
    {
        /// <summary>
        /// 返回值
        /// </summary>
        private MessageBoxResult result;

        public MessageBox()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 显示一个消息框具有一条消息，并且它返回的结果。
        /// </summary>
        /// <param name="messageBoxText">一个 System.String ，它指定要显示的文本。</param>
        /// <returns>一个 Crape_Client.Windows.MessageBoxResult 值，该值指定在用户单击哪个消息框按钮。</returns>
        public static MessageBoxResult Show(string messageBoxText)
            => show(messageBoxText, "", MessageBoxButton.OK, MessageBoxImage.None);
        /// <summary>
        ///   显示具有消息和标题栏标题; 一个消息框它返回的结果。
        /// </summary>
        /// <param name="messageBoxText">一个 System.String ，它指定要显示的文本。</param>
        /// <param name="caption">一个 System.String ，它指定要显示的标题栏标题。</param>
        /// <returns>一个 Crape_Client.Windows.MessageBoxResult 值，该值指定在用户单击哪个消息框按钮。</returns>
        public static MessageBoxResult Show(string messageBoxText, string caption)
            => show(messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.None);
        /// <summary>
        /// 显示具有消息、 标题栏标题和按钮，则一个消息框它返回的结果。
        /// </summary>
        /// <param name="messageBoxText">一个 System.String ，它指定要显示的文本。</param>
        /// <param name="caption">一个 System.String ，它指定要显示的标题栏标题。</param>
        /// <param name="button">一个 Crape_Client.Windows.MessageBoxButton 值，该值指定哪个按钮或要显示的按钮。</param>
        /// <returns>一个 Crape_Client.Windows.MessageBoxResult 值，该值指定在用户单击哪个消息框按钮。</returns>
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button)
            => show(messageBoxText, caption, button, MessageBoxImage.None);
        /// <summary>
        /// 显示具有消息、 标题栏标题和按钮，则一个消息框它返回的结果。
        /// </summary>
        /// <param name="messageBoxText">一个 System.String ，它指定要显示的文本。</param>
        /// <param name="caption">一个 System.String ，它指定要显示的标题栏标题。</param>
        /// <param name="button">一个 Crape_Client.Windows.MessageBoxButton 值，该值指定哪个按钮或要显示的按钮。</param>
        /// <param name="icon">敬请期待</param>
        /// <returns>一个 Crape_Client.Windows.MessageBoxResult 值，该值指定在用户单击哪个消息框按钮。</returns>
        public static MessageBoxResult show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            MessageBox mb = new MessageBox();
            mb.MessageBlock.Text = messageBoxText;
            mb._Title.Text = mb.Title = caption;
            mb.MakeButton(button);
            mb.ShowDialog();
            return mb.result;
        }
        #region 按钮
        private static MenuItem OK = new MenuItem()
        {
            Header = "确定",
            FontWeight = FontWeights.Normal,
        };
        private static MenuItem Cancel = new MenuItem()
        {
            Header = "取消",
            FontWeight = FontWeights.Normal,
        };
        private static MenuItem Yes = new MenuItem()
        {
            Header = "是",
            FontWeight = FontWeights.Normal,
        };
        private static MenuItem No = new MenuItem()
        {
            Header = "否",
            FontWeight = FontWeights.Normal,
        };
        private void MakeButton(MessageBoxButton button)
        {
            switch (button)
            {
                case MessageBoxButton.OK:
                    menu.Items.Add(OK);
                    OK.Click += OK_Click;
                    break;
                case MessageBoxButton.OKCancel:
                    menu.Items.Add(OK);
                    OK.Click += OK_Click;
                    menu.Items.Add(Cancel);
                    Cancel.Click += Cancel_Click;
                    break;
                case MessageBoxButton.YesNoCancel:
                    menu.Items.Add(Yes);
                    Yes.Click += Yes_Click;
                    menu.Items.Add(No);
                    No.Click += No_Click;
                    menu.Items.Add(Cancel);
                    Cancel.Click += Cancel_Click;
                    break;
                case MessageBoxButton.YesNo:
                    menu.Items.Add(Yes);
                    Yes.Click += Yes_Click;
                    menu.Items.Add(No);
                    No.Click += No_Click;
                    break;
            }
        }
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            result = MessageBoxResult.OK;
            Close();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            result = MessageBoxResult.Cancel;
            Close();
        }
        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            result = MessageBoxResult.Yes;
            Close();
        }
        private void No_Click(object sender, RoutedEventArgs e)
        {
            result = MessageBoxResult.No;
            Close();
        }
        #endregion

    }
    public enum MessageBoxButton
    {
        OK = 0,
        OKCancel = 1,
        YesNoCancel = 3,
        YesNo = 4
    }
    public enum MessageBoxResult
    {
        None = 0,
        OK = 1,
        Cancel = 2,
        Yes = 6,
        No = 7
    }
    public enum MessageBoxImage
    {
        None = 0,
        Hand = 16,
        Stop = 16,
        Error = 16,
        Question = 32,
        Exclamation = 48,
        Warning = 48,
        Asterisk = 64,
        Information = 64
    }
}
