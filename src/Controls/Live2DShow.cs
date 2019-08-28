using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L2DLib.Framework;
using System.Windows;
using System.Runtime.InteropServices;

namespace Crape_Client.Controls
{
    class Live2DShow : L2DView
    {
        // 获取窗口的属性
        public Window window { set; get; }

        /// <summary>
        /// 控件捕捉鼠标位置
        /// </summary>
        public bool Mouse
        {   
            get { return (bool)GetValue(MouseProperty); }
            set { SetValue(MouseProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mouse.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MouseProperty =
            DependencyProperty.Register("Mouse", typeof(bool), typeof(Live2DShow), new PropertyMetadata(true));
        /// <summary>
        /// 控件水平中心偏移量
        /// </summary>
        public double OffsetX
        {
            get { return (double)GetValue(OffsetXProperty); }
            set { SetValue(OffsetXProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OffsetX.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OffsetXProperty =
            DependencyProperty.Register("OffsetX", typeof(double), typeof(Live2DShow), new PropertyMetadata((double)0));
        /// <summary>
        /// 控件垂直中心偏移量
        /// </summary>
        public double OffsetY
        {
            get { return (double)GetValue(OffsetYProperty); }
            set { SetValue(OffsetYProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OffsetY.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OffsetYProperty =
            DependencyProperty.Register("OffsetY", typeof(double), typeof(Live2DShow), new PropertyMetadata((double)0));


        /// <summary>
        /// 构造函数
        /// </summary>
        public Live2DShow()
        {
            CaptureMouse();
        }
        /// <summary>
        /// 渲染
        /// </summary>
        public override void Rendering()
        {
            //if (IsMouseCaptured && Mouse.LeftButton == MouseButtonState.Pressed)
            if (Mouse)
            {
                Win32.POINT p = new Win32.POINT(0, 0);
                Win32.GetCursorPos(out p);
                double X = p.X - window.Left - Margin.Left - OffsetX;
                double Y = p.Y - window.Top - Margin.Top - OffsetY;
                double angleX = (ActualWidth / 2 + X) - ActualWidth;
                double angleY = ActualWidth / 2 - Y;
                Model.SetParamFloat("PARAM_ANGLE_X", (float)(angleX / (ActualWidth / 2) * 30));
                Model.SetParamFloat("PARAM_ANGLE_Y", (float)(angleY / (ActualHeight / 2) * 30));
                Model.SetParamFloat("PARAM_EYE_BALL_X", (float)(angleX / (ActualWidth / 2)));
                Model.SetParamFloat("PARAM_EYE_BALL_Y", (float)(angleY / (ActualHeight / 2)));
                Model.SetParamFloat("PARAM_BODY_ANGLE_X", (float)(angleX / (ActualWidth / 2) * 10));
            }
        }
        public class Win32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct POINT
            {
                public int X;
                public int Y;
                public POINT(int x, int y)
                {
                    this.X = x;
                    this.Y = y;
                }
            }
            [DllImport("user32.dll")]
            public static extern bool GetCursorPos(out POINT lpPoint);
        }
    }
}
