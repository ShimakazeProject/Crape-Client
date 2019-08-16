using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Crape_Client.Initialization
{
    public class SideInit
    {
        public static void Side() {
            // 读入XML文档
            XmlDocument Side = new XmlDocument();
            // 获取 Root 节点
            XmlNode SideRoot = Side.SelectSingleNode("Sides");
            // 获取节点列表
            XmlNodeList SideNodeList = SideRoot.ChildNodes;

            foreach (XmlNode SideNode in SideNodeList)
            {
                SideModel sm = new SideModel();
                // 节点转化为元素，便于得到节点的属性值
                XmlElement sn = (XmlElement)SideNode;
                sm.Id = Convert.ToUInt16(sn.GetAttribute("Id"));
                sm.Name = sn.GetAttribute("Name");
                sm.Icon = sn.GetAttribute("Icon");
                sm.Summary = sn.GetAttribute("Summary");
                // 
                Global.Sides.Add(sm);
            }//*/
        }


        public class SideModel
        {
            public ushort Id { set; get; }
            public string Name { set; get; }
            public string Icon { set; get; }
            public string Summary { set; get; }
        }
    }
}
