﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crape_Client
{
    public class MissionList//任务列表用
    {
        public byte[] Ico { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }


    }
    public class MapList//地图列表用
    {
        public string Ico { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }

    }

}
