using System.Net;
using System.Xml.Linq;
using GPS地图.DTO;
using Utility.存储;

namespace GPS地图.IBLL.实现
{
	class B服务器配置 : IB服务器配置
	{
		private M服务器 _连接配置;

        private const string _路径 = "GPS地图.xml";

        private XDocument _XML文档;

        private XElement _根节点;

		public B服务器配置()
        {
            var __绝对路径 = H路径.获取绝对路径(_路径);
            _XML文档 = XDocument.Load(__绝对路径);
            _根节点 = _XML文档.Root.Element("服务器");
		}

		public M服务器 查询()
		{
            if (_连接配置 == null)
		    {
                _连接配置 = new M服务器
                {
                    服务器IP = IPAddress.Parse(_根节点.Element("IP").Value),
                    服务器端口号 = int.Parse(_根节点.Element("端口号").Value),
                };

		    }
		    return _连接配置;
		}

		public void 保存(M服务器 配置)
		{
			_连接配置 = 配置;
            var __绝对路径 = H路径.获取绝对路径(_路径);
            _根节点.Element("IP").Value = 配置.服务器IP.ToString();
            _根节点.Element("端口号").Value = 配置.服务器端口号.ToString();
            _XML文档.Save(__绝对路径);
        }

	}
}
