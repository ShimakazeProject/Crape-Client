using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Crape_Client.CrapeClientUI
{
    class Welcome:UserControl
    {
        public Welcome()
        {
            Image Image = new Image()
            {
                Source = new System.Windows.Media.Imaging.BitmapImage(
                new Uri(Global.Globals.ImagesDir + "Welcome.png",
                UriKind.RelativeOrAbsolute))
            };
            Content = Image;
        }
    }
}
