using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using DTO;
using GPS地图.DTO;
using GPS地图.IBLL;
using GPS地图.IBLL.实现;
using GPS地图.IService;
using GPS地图.IView;
using Utility.通用;

namespace GPS地图.Presenter
{
    public class PGPS : IS显示GPS, IS数据交互
    {
        private static readonly IB地图路径配置 _IB地图路径 = H容器.取出<IB地图路径配置>();

        private IV地图 _IV地图;

        private Dictionary<string, M图标显示参数> _标识参数 = new Dictionary<string, M图标显示参数>();

        private Dictionary<string, ulong> _标识图标 = new Dictionary<string, ulong>();

        private BGPS状态检测 _状态检测 = new BGPS状态检测();

        public virtual void 处理视图(IV地图 视图)
        {
            _IV地图 = 视图;
            _IV地图.显示等待();
            _IV_加载数据();
            _IV_配置事件();
            _IV地图.隐藏等待();
        }

        void _IV_加载数据()
        {
            _IV地图.显示等待("加载地图");
            _IV地图.加载地图(_IB地图路径.查询());
            _IV地图.隐藏等待();
        }

        void _IV_配置事件()
        {
            _IV地图.已关闭 += _IV_已关闭;
            _IV地图.进入图标 += IF地图_进入点;
            _IV地图.离开图标 += IF地图_离开点;
            _IV地图.单击图标 += IF地图_单击点;
            _状态检测.开始();
            _状态检测.状态变化 += GPS状态变化;
        }

        protected virtual void _IV_已关闭()
        {
            _IV地图.已关闭 -= _IV_已关闭;
            _IV地图.进入图标 -= IF地图_进入点;
            _IV地图.离开图标 -= IF地图_离开点;
            _IV地图.单击图标 -= IF地图_单击点;
        }

        void 更新位置(string __号码, MGPS __GPS)
        {
            if (!_标识参数.ContainsKey(__号码))
            {
                return;
            }
            if (_标识图标.ContainsKey(__号码))
            {
                _IV地图.删除图标(new List<ulong> { _标识图标[__号码] });
            }
            if (_标识参数[__号码].图片 == null && 更新图片 != null)
            {
                var __状态 = _状态检测.查询状态(__号码);
                _标识参数[__号码].图片 = 更新图片(__号码, __状态);
                if (_标识参数[__号码].图片 == null)
                {
                    return;
                }
                return;
            }
            var __结果 = _IV地图.添加图标(new List<M图标> { new M图标 { 业务标识 = __号码, 位置 = __GPS, 显示参数 = _标识参数[__号码] } });
            _标识图标[__号码] = __结果[0];
        }

        void 更新状态(string __号码)
        {
            if (!_标识参数.ContainsKey(__号码))
            {
                return;
            }
            if (_标识图标.ContainsKey(__号码))
            {
                _IV地图.删除图标(new List<ulong> { _标识图标[__号码] });
            }
            var __状态 = _状态检测.查询状态(__号码);
            if (更新图片 != null)
            {
                _标识参数[__号码].图片 = 更新图片(__号码, __状态);
            }
            if (_标识参数[__号码].图片 == null)
            {
                return;
            }
            var __GPS = _状态检测.查询位置(__号码);
            var __结果 = _IV地图.添加图标(new List<M图标> { new M图标 { 业务标识 = __号码, 位置 = __GPS, 显示参数 = _标识参数[__号码] } });
            _标识图标[__号码] = __结果[0];
        }

        void GPS状态变化(string __号码, EGPS状态 __新状态)
        {
            _IV地图.UI线程执行(() =>
            {
                if (_标识参数.ContainsKey(__号码))
                {
                    更新状态(__号码);
                }
                var __temp = 状态更新;
                if (__temp != null)
                {
                    __temp(__号码, __新状态);
                }
            });
        }

        void IF地图_单击点(M图标 obj, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            var __绑定对象 = obj.业务标识 as string;
            if (__绑定对象 != null)
            {
                var temp = 单击标识;
                if (temp != null)
                {
                    temp(__绑定对象);
                }
            }
        }

        void IF地图_离开点(M图标 obj)
        {
            var __绑定对象 = obj.业务标识 as string;
            if (__绑定对象 != null)
            {
                var temp = 鼠标离开标识;
                if (temp != null)
                {
                    temp(__绑定对象);
                }
            }
        }

        void IF地图_进入点(M图标 obj)
        {
            var __绑定对象 = obj.业务标识 as string;
            if (__绑定对象 != null)
            {
                var temp = 鼠标进入标识;
                if (temp != null)
                {
                    temp(__绑定对象);
                }
            }
        }

        #region IS显示GPS

        public void 显示(Dictionary<string, M图标显示参数> 标识集)
        {
            var __新增图标 = new List<Tuple<string, M图标>>();
            var __删除图标 = new List<ulong>();
            foreach (var __kv in 标识集)
            {
                var __标识 = __kv.Key;
                _标识参数[__标识] = __kv.Value;
                if (_标识图标.ContainsKey(__标识))
                {
                    __删除图标.Add(_标识图标[__标识]);
                    _标识图标.Remove(__标识);
                }

                EGPS状态 __状态;
                var __GPS = _状态检测.查询位置(__标识, out __状态);
                if (__GPS != null)
                {
                    if (__kv.Value.图片 == null)
                    {
                        __kv.Value.图片 = 更新图片(__标识, __状态);
                    }
                    if (__kv.Value.图片 == null)
                    {
                        continue;
                    }
                    __新增图标.Add(new Tuple<string, M图标>(__标识, new M图标 { 业务标识 = __标识, 位置 = __GPS, 显示参数 = __kv.Value }));
                }
            }
            _IV地图.删除图标(__删除图标);
            var __结果 = _IV地图.添加图标(__新增图标.Select(q => q.Item2).ToList());
            for (int i = 0; i < __新增图标.Count; i++)
            {
                var __标识 = __新增图标[i].Item1;
                _标识图标[__标识] = __结果[i];
            }
        }

        public void 隐藏(List<string> 标识集)
        {
            var __图标集 = new List<ulong>();
            标识集.ForEach(__标识 =>
            {
                if (_标识图标.ContainsKey(__标识))
                {
                    var __号码属性 = _标识图标[__标识];
                    __图标集.Add(__号码属性);
                    _标识图标.Remove(__标识);
                }
                if (_标识参数.ContainsKey(__标识))
                {
                    _标识参数.Remove(__标识);
                }
            });
            if (__图标集.Count > 0)
            {
                _IV地图.删除图标(__图标集);
            }
        }

        public void 定位(List<string> __标识集)
        {
            var __图标集 = new List<ulong>();
            __标识集.ForEach(__号码 =>
            {
                if (_标识图标.ContainsKey(__号码))
                {
                    var __图标 = _标识图标[__号码];
                    __图标集.Add(__图标);
                }
            });
            if (__图标集.Count > 0)
            {
                _IV地图.定位(__图标集);
            }
        }

        public event Action<string> 单击标识;

        public event Action<string> 鼠标进入标识;

        public event Action<string> 鼠标离开标识;
        #endregion

        #region IS接收GPS

        public Func<DateTime> 参照时间
        {
            get { return _状态检测.时间偏移; }
            set { _状态检测.时间偏移 = value; }
        }

        public void 增加(string 标识, MGPS GPS)
        {
            var __状态变更 = _状态检测.接收GPS数据(标识, GPS);
            if (!__状态变更)
            {
                _IV地图.UI线程执行(() => 更新位置(标识, GPS));
            }
        }

        public void 删除(string 标识)
        {
            _状态检测.删除GPS数据(标识);
        }

        public EGPS状态 查询(string 标识)
        {
            return _状态检测.查询状态(标识);
        }

        public event Action<string, EGPS状态> 状态更新;
        #endregion

        public Func<string, EGPS状态, Image> 更新图片 { get; set; }
    }
}
