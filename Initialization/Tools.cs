using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
namespace Crape_Client.Initialization
{
    class Tools
    {
        public static Brush String2Brush(string color)
        {
            System.Drawing.Color clr = System.Drawing.ColorTranslator.FromHtml(color);
            return
                new SolidColorBrush(
                    Color.FromArgb(
                        clr.A,
                        clr.R,
                        clr.G,
                        clr.B
                        )
                    );
        }
        public static Thickness String2Thickness(string margin)
        {
            string[] a = margin.Split(',');
            double[] b = new double[] { 0, 0, 0, 0 };
            for (int i = 0; i < a.Length; i++)
            {
                b[i] = Convert.ToDouble(a[i]);
            }
            return new Thickness(b[0], b[1], b[2], b[3]);
        }
    }
}
