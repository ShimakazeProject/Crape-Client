using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Crape_Client.CrapeClientCore
{
    class InitConf
    {


        // Skirmish Config
        public static int TeamNum { set; get; }
        public static int ColorNum { set; get; }
        public static int SideNum { set; get; }
        //public static int TeamNum { set; get; }


    }
    class SkirConf
    {
        public static List<Format1> Side;
        public static List<Format1> Color;

    }
    class Format1
    {
        public short Num { set; get; }
        public short? Max { set; get; }
        public bool Readom { set; get; }
    }
}
