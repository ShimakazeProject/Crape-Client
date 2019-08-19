using System;
using System.Collections.Generic;


namespace Crape_Client.Initialization.Config// 定义命名空间
{
    class Renderer// 定义类
    {
        public string Name { set; get; }// Name属性
        public string Dll { set; get; }// Dll属性
        public List<string> Files { set; get; }// Files属性
        public Renderer()// 构造函数
        {
            Files = new List<string>();// 初始化Files属性
        }
    }
}
