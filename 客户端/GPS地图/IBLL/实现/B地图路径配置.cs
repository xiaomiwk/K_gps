using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Utility.存储;
using Utility.扩展;

namespace GPS地图.IBLL.实现
{
    class B地图路径配置 : IB地图路径配置
    {
        private const string _路径 = "GPS地图.xml";

        private XDocument _XML文档;

        private XElement _根节点;


        public B地图路径配置()
        {
            var __绝对路径 = H路径.获取绝对路径(_路径);
            _XML文档 = XDocument.Load(__绝对路径);
            _根节点 = _XML文档.Root.Element("地图路径");
        }

        public Dictionary<string, bool> 查询()
        {
            var __结果 = new Dictionary<string, bool>();
            var __地图目录 = H路径.获取绝对路径("离线地图");
            if (!H路径.验证目录是否存在(__地图目录))
            {
                return __结果;
            }
            var __地图文件列表 = Directory.GetFiles(__地图目录, "*.gmdb");
            if (__地图文件列表.Length == 0)
            {
                return __结果;
            }
            foreach (var __文件路径 in __地图文件列表)
            {
                __结果[__文件路径] = false;
            }

            var __复制对象 = __结果.DeepClone();
            foreach (var xElement in _根节点.Elements("已选择路径"))
            {
                var __已选择文件 = xElement.Value;
                foreach (var kv in __复制对象)
                {
                    var __文件路径 = kv.Key;
                    var __文件名 = Path.GetFileNameWithoutExtension(__文件路径);
                    if (__文件名 == __已选择文件)
                    {
                        __结果[__文件路径] = true;
                    }
                }
            }
            return __结果;
        }

        public void 保存(List<string> 已选择的路径)
        {
            var __绝对路径 = H路径.获取绝对路径(_路径);
            _根节点.RemoveAll();
            已选择的路径.ForEach(q => _根节点.Add(new XElement("已选择路径", Path.GetFileNameWithoutExtension(q))));
            _XML文档.Save(__绝对路径);
        }

    }
}
