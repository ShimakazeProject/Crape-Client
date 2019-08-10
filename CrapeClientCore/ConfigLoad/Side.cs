using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Crape_Client.CrapeClientCore.ConfigLoad
{
    class Side
    {
        public Side()
        {
            // 创建实例
            XmlDocument xml = new XmlDocument();
            // 读取文件
            xml.Load(Global.LocalPath + Global.ConfigsDir + "SideConfig.xml");
            // 设定根节点
            XmlNode root = xml.SelectSingleNode("Sides");
            // 获取节点列表
            XmlNodeList xnl = root.ChildNodes;

            foreach(XmlNode xn in xnl)
            {
                SideClass sc = new SideClass();
                XmlElement xe = (XmlElement)xn;
                sc.Id = xe.GetAttribute("Id");
                sc.Name = xe.GetAttribute("Name");
                sc.Summary = xe.GetAttribute("Summary");

            }
        }

        class SideClass// Root
        {
            public string Id { set; get; }
            public string Name { set; get; }
            public string Summary { set; get; }
        }
    }
}
