using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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
using L2DLib.Framework;
using L2DLib.Utility;

namespace Crape_Client.Live2DCore
{
    class Live2DView : L2DView
    {
        public Window window { set; get; }
        public double LeftOffset { set; get; }
        public double TopOffset { set; get; }

        public Live2DView()
        {
            CaptureMouse();
            TopOffset = 0;
            LeftOffset = 0;
        }
        public override void Rendering()
        {
            double X;
            double Y;
            Win32.POINT p = new Win32.POINT(0, 0);
            Win32.GetCursorPos(out p);
            X = p.X - window.Left - Margin.Left - LeftOffset;
            Y = p.Y - window.Top - Margin.Top - TopOffset;
            double centerX = ActualWidth / 2;
            double centerY = ActualHeight / 2;
            double angleX;
            double angleY;
            angleX = (centerX + X) - ActualWidth;
            angleY = centerY - Y;
            Model.SetParamFloat("PARAM_ANGLE_X", (float)(angleX / centerX * 30));
            Model.SetParamFloat("PARAM_ANGLE_Y", (float)(angleY / centerY * 30));
            Model.SetParamFloat("PARAM_EYE_BALL_X", (float)(angleX / centerX));
            Model.SetParamFloat("PARAM_EYE_BALL_Y", (float)(angleY / centerY));
            Model.SetParamFloat("PARAM_BODY_ANGLE_X", (float)(angleX / centerX * 10));
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

            //刷新桌面
            [DllImport("user32.dll")]
            public static extern bool GetCursorPos(out POINT lpPoint);

        }
    }
}
