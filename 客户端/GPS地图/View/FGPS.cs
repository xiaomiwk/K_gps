using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DTO;
using GPS地图.DTO;
using GPS地图.IService;
using GPS地图.IView;
using GPS地图.Presenter;
using GPS地图.Properties;
using Utility.通用;
using 显示地图;

namespace GPS地图.View
{
    public partial class FGPS : F控件, IV地图
    {
        private PGPS _PGPS;

        public IS显示GPS 显示GPS { get { return _PGPS; } }

        public IS数据交互 数据交互 { get { return _PGPS; } }

        public F地图 地图 { get; private set; }

        private Dictionary<ulong, Tuple<M图标, ulong?>> _图标缓存 = new Dictionary<ulong, Tuple<M图标, ulong?>>();

        private const int _轨迹点数上限 = 8 * 60 * 4; //小时, 分钟, 每分钟数量

        private string _轨迹图层名称 = "静态轨迹";

        private string _图标层名称 = "图标层";

        public FGPS()
        {
            H接口注册.设置();
            InitializeComponent();
            this.地图 = new F地图 { Dock = DockStyle.Fill };
            this._PGPS = H容器.虚方法拦截<PGPS>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!DesignMode)
            {
                地图.添加图层(_轨迹图层名称);
                地图.添加图层(_图标层名称);
                this.地图.单击点 += (m, n) => On单击图标((M图标)m, n);
                this.地图.进入点 += m => On进入图标((M图标)m);
                this.地图.离开点 += m => On离开图标((M图标)m);
                this.Controls.Add(地图);

                _PGPS.处理视图(this);
            }
        }

        #region IV地图

        public void 加载地图(Dictionary<string, bool> __地图路径列表)
        {
            if (__地图路径列表.Count == 0)
            {
                显示失败("请拷贝地图文件到程序目录的\"离线地图\"目录!");
            }
            else if (!__地图路径列表.Values.ToList().Contains(true))
            {
                显示失败("请配置地图路径!");
            }
            else
            {
                try
                {
                    var __列表 = new List<string>();
                    foreach (var kv in __地图路径列表)
                    {
                        if (kv.Value)
                        {
                            __列表.Add(kv.Key);
                        }
                    }
                    if (__列表.Count > 1)
                    {
                        var __切换 = new FDemo切换
                        {
                            Anchor = AnchorStyles.Top | AnchorStyles.Right,
                            Left = this.Width - 40,
                            Top = 5
                        };
                        this.Controls.Add(__切换);
                        __切换.BringToFront();
                        __切换.初始化(地图, __列表, 0);
                    }
                    地图.加载地图(__列表[0]);
                }
                catch (Exception ex)
                {
                    显示失败(ex.Message);
                }
            }
        }

        public List<ulong> 添加图标(List<M图标> __图标集)
        {
            var __结果 = new List<ulong>();
            __图标集.ForEach(__图标 =>
            {
                var __经纬度 = __图标.位置.转M经纬度();
                var __点标识 = 地图.添加点(__图标.位置.转M经纬度(), __图标.显示参数.图片, __图标.显示参数.名称, __图标, _图标层名称, __图标.显示参数.名称一直显示 ? E标题显示方式.Always : E标题显示方式.OnMouseOver);
                UInt64? __线标识 = null;
                if (__图标.显示参数.显示轨迹数 > 0 && __图标.轨迹 != null && __图标.轨迹.Count > 0)
                {
                    var __轨迹缓存 = __图标.轨迹.Select(q => new M经纬度(q.经度, q.纬度)).ToList();
                    if (__图标.轨迹.Count >= 2)
                    {
                        var __点数量 = Math.Min(__轨迹缓存.Count, __图标.显示参数.显示轨迹数);
                        __轨迹缓存.Insert(0, __经纬度);
                        __线标识 = 地图.添加线(__轨迹缓存.GetRange(__轨迹缓存.Count - __点数量, __点数量), 2, Color.Yellow, null, _图标层名称);
                    }
                }
                _图标缓存[__点标识] = new Tuple<M图标, UInt64?>(__图标, __线标识);
                __结果.Add(__点标识);
            });
            return __结果;
        }

        public void 删除图标(List<ulong> __图标集)
        {
            __图标集.ForEach(q =>
            {
                if (_图标缓存.ContainsKey(q))
                {
                    地图.删除点(q, _图标层名称);
                    if (_图标缓存[q].Item2.HasValue)
                    {
                        地图.删除线(_图标缓存[q].Item2.Value, _图标层名称);
                    }
                    _图标缓存.Remove(q);
                }
            });
        }

        public void 删除所有图标()
        {
            foreach (var __kv in _图标缓存)
            {
                地图.删除点(__kv.Key, _图标层名称);
                if (_图标缓存[__kv.Key].Item2.HasValue)
                {
                    地图.删除线(_图标缓存[__kv.Key].Item2.Value, _图标层名称);
                }
            }
            _图标缓存.Clear();
        }

        public List<M图标> 查询所有图标()
        {
            return _图标缓存.Select(q => q.Value.Item1).ToList();
        }

        public void 添加静态轨迹(List<M静态轨迹> __轨迹集)
        {
            //抽稀
            long __轨迹点数总数 = 0;
            foreach (var __kv in __轨迹集)
            {
                __轨迹点数总数 += __kv.GPS.Count;
            }
            if (__轨迹点数总数 > _轨迹点数上限)
            {
                var __比例 = (int)(__轨迹点数总数 / _轨迹点数上限 + 1);
                foreach (var __kv in __轨迹集)
                {
                    for (int i = __kv.GPS.Count - 2; i > 0; i--)
                    {
                        if (i % __比例 != 0)
                        {
                            __kv.GPS.RemoveAt(i);
                        }
                    }
                }
            }

            Image __开始图标 = Resources.开始;
            Image __结束图标 = Resources.结束;
            Image __轨迹点图标 = Resources.轨迹点;

            __轨迹集.ForEach(k =>
            {
                k.GPS.ForEach(__图标 =>
                {
                    var __名称 = string.Format("名称: {0}{5}时间: {1}{5}误差: {2}米{5}经度: {3}{5}纬度: {4}{5}", k.名称, __图标.时间, __图标.精度, __图标.经度, __图标.纬度, Environment.NewLine);
                    地图.添加点(__图标.转M经纬度(), __轨迹点图标, __名称, null, _轨迹图层名称);

                });
                var __开始点 = k.GPS.First();
                var __结束点 = k.GPS.Last();
                地图.添加点(new M经纬度(__开始点.经度, __开始点.纬度), __开始图标, k.名称, null, _轨迹图层名称, __轨迹集.Count > 1 ? E标题显示方式.Always : E标题显示方式.OnMouseOver);
                地图.添加点(new M经纬度(__结束点.经度, __结束点.纬度), __结束图标, k.名称, null, _轨迹图层名称, __轨迹集.Count > 1 ? E标题显示方式.Always : E标题显示方式.OnMouseOver);
                地图.添加线(k.GPS.Select(q => new M经纬度(q.经度, q.纬度)).ToList(), 2, k.显示颜色, null, _轨迹图层名称);
            });
        }

        public void 显隐静态轨迹()
        {
            //if (!地图.存在图层(_轨迹图层名称))
            //{
            //    return;
            //}
            if (地图.查询显隐(_轨迹图层名称))
            {
                地图.隐藏图层(_轨迹图层名称);
            }
            else
            {
                地图.显示图层(_轨迹图层名称);
            }
        }

        public void 定位(List<ulong> __图标集)
        {
            var __经纬度列表 = new List<M经纬度>();
            __图标集.ForEach(q =>
            {
                if (_图标缓存.ContainsKey(q))
                {
                    __经纬度列表.Add(_图标缓存[q].Item1.位置.转M经纬度());
                }
            });
            地图.定位(__经纬度列表);
        }

        public event Action<M图标, MouseEventArgs> 单击图标;

        public event Action<M图标> 进入图标;

        public event Action<M图标> 离开图标;

        #endregion

        protected virtual void On单击图标(M图标 arg1, MouseEventArgs arg2)
        {
            var handler = 单击图标;
            if (handler != null) handler(arg1, arg2);
        }

        protected virtual void On进入图标(M图标 obj)
        {
            var handler = 进入图标;
            if (handler != null) handler(obj);
        }

        protected virtual void On离开图标(M图标 obj)
        {
            var handler = 离开图标;
            if (handler != null) handler(obj);
        }

    }

}
