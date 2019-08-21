using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crape_Client.Initialization.Config
{
    class Side
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Icon { set; get; }
        public string Summary { set; get; }
        public uint Sides { set; get; }
    }
    class SideList
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Icon { set; get; }
        public uint From { set; get; }
        public uint To { set; get; }
        public System.Windows.Media.Brush Color { set; get; }

    }
}
