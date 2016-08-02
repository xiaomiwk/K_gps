using System.Xml.Linq;
using GPS地图.DTO;
using Utility.存储;

namespace GPS地图.IBLL.实现
{
    class BGPS状态配置 : IBGPS状态配置
    {
        private const string _路径 = "GPS地图.xml";

        private XDocument _XML文档;

        private XElement _根节点;
        public BGPS状态配置()
        {
            var __绝对路径 = H路径.获取绝对路径(_路径);
            _XML文档 = XDocument.Load(__绝对路径);
            _根节点 = _XML文档.Root.Element("GPS状态配置");
        }

        public void 保存(MGPS状态配置 参数)
        {
            var __绝对路径 = H路径.获取绝对路径(_路径);
            _根节点.Element("短期未更新间隔").Value = 参数.短期未更新间隔.ToString();
            _根节点.Element("很久未更新间隔").Value = 参数.很久未更新间隔.ToString();
            _根节点.Element("停止显示间隔").Value = 参数.停止显示间隔.ToString();
            _XML文档.Save(__绝对路径);
        }

        public MGPS状态配置 查询()
        {
            var __很久未更新间隔 = int.Parse(_根节点.Element("很久未更新间隔").Value.Trim());
            var __短期未更新间隔 = int.Parse(_根节点.Element("短期未更新间隔").Value.Trim());
            var __停止显示间隔 = int.Parse(_根节点.Element("停止显示间隔").Value.Trim());
            return new MGPS状态配置 { 很久未更新间隔 = __很久未更新间隔, 短期未更新间隔 = __短期未更新间隔, 停止显示间隔 = __停止显示间隔 };
        }

    }
}
