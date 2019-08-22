using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Crape_Client.Initialization
{
    class ColorInit
    {
        public ColorInit()// 构造函数
        {
            XmlDocument ColorXml = new XmlDocument();// 实例化 XmlDocument 类
            try
            {
                ColorXml.Load(Global.Globals.ConfigsDir + "Color.xml");// 读入XML文档
            }
            catch (XmlException e)// 异常处理
            {
                Global.Globals.LogMGR.Error(e);
                Global.Globals.LogMGR.ErrorBoxShow();
            }
            XmlNode Root = ColorXml.SelectSingleNode("Colors");// 获取 Root 节点
            XmlNodeList NodeList = Root.ChildNodes;// 获取节点列表
            foreach (XmlNode Node in NodeList)// 遍历 NodeList 循环
            {
                Config.Color color = new Config.Color();// 实例化类
                XmlElement ne = (XmlElement)Node;// 节点转化为元素，便于得到节点的属性值
                color.Id = Convert.ToUInt32(ne.GetAttribute("Id"));
                color.Name = ne.GetAttribute("Name");// 获取Name属性
                color.Value = Tools.String2Brush(ne.GetAttribute("Value"));
                Global.Globals.Colors.Add(color);// 添加类到全局渲染器储存
            }
        }
    }
}
