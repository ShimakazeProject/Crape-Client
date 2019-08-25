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
using L2DLib.Framework;
using L2DLib.Utility;

namespace Crape_Client.CrapeClientUI
{
    class Live2DView: L2DView
    {
        public Live2DView()
        {
            //PreviewMouseMove += Live2DView_MouseMove;
            CaptureMouse();
        }



        private void Live2DView_MouseMove(object sender, MouseEventArgs e)
        {
            CaptureMouse();
            //ReleaseMouseCapture();
            //throw new NotImplementedException();
        }

        public override void Rendering()
        {
            //if (IsMouseCaptured && Mouse.LeftButton == MouseButtonState.Pressed)
            //{
            double angleX;
            double angleY;
            if (Mouse.GetPosition(this)==new Point(0, 0))
            {
                angleX = 0;
                angleY = ActualWidth / 2;
            }
            else {
                angleX = (ActualWidth / 2 + Mouse.GetPosition(this).X) - ActualWidth;
                angleY = ActualWidth / 2 - Mouse.GetPosition(this).Y;
            }


            Model.SetParamFloat("PARAM_ANGLE_X", (float)(angleX / (ActualWidth / 2) * 30));
            Model.SetParamFloat("PARAM_ANGLE_Y", (float)(angleY / (ActualHeight / 2) * 30));
            Model.SetParamFloat("PARAM_EYE_BALL_X", (float)(angleX / (ActualWidth / 2)));
            Model.SetParamFloat("PARAM_EYE_BALL_Y", (float)(angleY / (ActualHeight / 2)));
            Model.SetParamFloat("PARAM_BODY_ANGLE_X", (float)(angleX / (ActualWidth / 2) * 10));
            //}
        }
    }
}
