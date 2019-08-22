using System;
using System.Collections.Generic;
using System.Xml;// 使用System.Xml命名空间
using Crape_Client.Global;

namespace Crape_Client.Initialization// 命名空间定义
{
    class Renderer// 类定义
    {
        public Renderer()// 构造函数
        {
            XmlDocument RendererXml = new XmlDocument();// 实例化 XmlDocument 类
            try
            {
                RendererXml.Load(Globals.ConfigsDir + "Renderer.xml");// 读入XML文档
            }
            catch (XmlException e)// 异常处理
            {
                Globals.LogMGR.Error(e);
                Globals.LogMGR.ErrorBoxShow();
            }
            XmlNode Root = RendererXml.SelectSingleNode("Renderers");// 获取 Root 节点
            XmlNodeList NodeList = Root.ChildNodes;// 获取节点列表
            foreach (XmlNode Node in NodeList)// 遍历 NodeList 循环
            {
                Config.Renderer rm = new Config.Renderer();// 实例化类
                XmlElement ne = (XmlElement)Node;// 节点转化为元素，便于得到节点的属性值
                rm.Name = ne.GetAttribute("Name");// 获取Name属性
                rm.Dll = ne.GetAttribute("Dll");// 获取Dll属性
                XmlNodeList FileList = Node.ChildNodes;// 获取File元素列表
                if (FileList.Count != 0)// 检查是否有File元素
                {
                    foreach (XmlNode File in FileList)// 遍历FileList循环
                    {
                        XmlElement fe = (XmlElement)File;// 节点转化为元素，便于得到节点的属性值
                        rm.Files.Add(fe.InnerText.Trim());// 添加File元素内容
                    }
                }
                Globals.RendererList.Add(rm);// 添加类到全局渲染器储存
            }
        }
    }
}
