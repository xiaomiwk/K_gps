using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO;
using GPS地图.DTO;
using GPS地图.View;
using GPS;
using Utility.存储;

namespace GPS地图.示例
{
    public class F实时显示 : F显示模板
    {
        private IB订阅 _IB订阅 = B入口.订阅;

        public FGPS _FGPS;

        private List<string> _订阅缓存;

        public F实时显示()
        {
            _FGPS = new FGPS() { Dock = DockStyle.Fill };
            this.控件 = _FGPS;
            this.显示GPS = _FGPS.显示GPS;
            this.数据交互 = _FGPS.数据交互;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _IB订阅.位置更新 += (__号码, __位置) =>
            {
                _FGPS.数据交互.增加(__号码.ToString(), __位置);
            };
            B入口.已连接 += BGPS应用_已连接;

        }

        void BGPS应用_已连接()
        {
            if (_订阅缓存 != null && _订阅缓存.Count > 0)
            {
                _IB订阅.增加(_订阅缓存);
            }
        }

        public void 设置号码(List<M个号> __列表, List<M组号> __组号列表 = null)
        {
            if (_订阅缓存 != null && _订阅缓存.Count > 0)
            {
                _IB订阅.删除(_订阅缓存);
            }

            var __参数 = new Dictionary<M个号, M图标显示参数>();
            __列表.ForEach(q => __参数[q] = new M图标显示参数 { 名称 = q.ToString(), 名称一直显示 = true });
            base.设置号码(__参数, __组号列表);

            _订阅缓存 = __列表.Select(q => q.号码.ToString()).ToList();
            if (_订阅缓存.Count > 0)
            {
                _IB订阅.增加(_订阅缓存);
            }
        }

    }
}
