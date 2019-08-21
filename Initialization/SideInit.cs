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
        public SideInit() {
            // 读入XML文档
            XmlDocument Side = new XmlDocument();
            try
            {
                Side.Load(Global.ConfigsDir + "Side.xml");// 读入XML文档
            }
            catch (XmlException e)// 异常处理
            {
                Global.LogMGR.Error(e);
                Global.LogMGR.ErrorBoxShow();
            }
            // 主
            XmlNodeList List = Side.SelectSingleNode("Sides/Master").ChildNodes;
            foreach (XmlNode Node in List)
            {
                Config.SideList sm = new Config.SideList();
                // 节点转化为元素，便于得到节点的属性值
                XmlElement sn = (XmlElement)Node;
                sm.Id = Convert.ToUInt16(sn.GetAttribute("Id"));
                sm.Name = sn.GetAttribute("Name");
                sm.Icon = sn.GetAttribute("Icon");
                sm.From = Convert.ToUInt16(sn.GetAttribute("From"));
                sm.To = Convert.ToUInt32(sn.GetAttribute("To"));
                sm.Color = Tools.String2Brush(sn.GetAttribute("Color"));
                // 
                Global.SidesPlus.Add(sm);
            }//*/
            // 分支
            XmlNodeList SideNodeList = Side.SelectSingleNode("Sides/Branch").ChildNodes;
            foreach (XmlNode SideNode in SideNodeList)
            {
                Config.Side sm = new Config.Side();
                // 节点转化为元素，便于得到节点的属性值
                XmlElement sn = (XmlElement)SideNode;
                sm.Id = Convert.ToUInt16(sn.GetAttribute("Id"));
                sm.Sides = Convert.ToUInt32(sn.GetAttribute("Side"));
                sm.Name = sn.GetAttribute("Name");
                sm.Icon = sn.GetAttribute("Icon");
                sm.Summary = sn.GetAttribute("Summary");
                // 
                Global.Sides.Add(sm);
            }//*/
        }

    }
}
