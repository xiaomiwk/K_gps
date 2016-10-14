using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using DTO;
using GPS地图.DTO;
using GPS地图.IBLL;
using Utility.通用;

namespace GPS.IBLL.实现
{
    class B回放_按频率 : IB回放_按频率
    {
        private int _播放索引;

        private DateTime _当前播放时间;

        private E播放状态 _当前播放状态;

        private Timer _播放定时器;

        private int _定时器间隔;

        private int _回放标识;

        List<MGPS> _GPS数据列表 = new List<MGPS>();

        int _刻度 = 100;

        public void 初始化(List<MGPS> __GPS数据)
        {
            _当前播放状态 = E播放状态.初始化;
            On播放状态变化(_当前播放状态);

            //查询GPS数据
            实际开始时间 = __GPS数据.First().时间;
            实际结束时间 = __GPS数据.Last().时间;
            _GPS数据列表 = new List<MGPS>(__GPS数据);
        }

        public DateTime 实际开始时间 { get; set; }

        public DateTime 实际结束时间 { get; set; }

        public DateTime 当前时间
        {
            get { return _当前播放时间; }
        }

        public void 播放(int __频率)
        {
            _定时器间隔 = 1000 / __频率;
            if (_当前播放状态 == E播放状态.初始化 || _当前播放状态 == E播放状态.停止)
            {
                _回放标识++;
                _当前播放时间 = 实际开始时间;
                _播放索引 = 0;
                _当前播放状态 = E播放状态.播放;
                _播放定时器 = new Timer(定时执行, _回放标识, 0, _定时器间隔);
            }
            else
            {
                _当前播放状态 = E播放状态.播放;
            }
            On播放状态变化(_当前播放状态);
        }

        void 定时执行(object __参数)
        {
            var __回放标识 = (int)__参数;
            Debug.WriteLine("{0}:{1}", __回放标识, Thread.CurrentThread.ManagedThreadId);
            if (_当前播放状态 != E播放状态.播放)
            {
                return;
            }

            if (_播放索引 >= _GPS数据列表.Count)
            {
                停止();
                return;
            }
            var __匹配GPS = _GPS数据列表[_播放索引++];
            On位置更新(__匹配GPS);

            _当前播放时间 = __匹配GPS.时间;
            On当前时间变化(_当前播放时间);
            //var __进度 = ((int)(_当前播放时间.Subtract(实际开始时间).TotalSeconds) * _刻度 / (int)(实际结束时间.Subtract(实际开始时间).TotalSeconds));
            var __进度 = (int)(_播放索引 * _刻度 / _GPS数据列表.Count);
            On播放进度变化(Math.Min(_刻度, __进度));
        }

        public void 暂停()
        {
            _当前播放状态 = E播放状态.暂停;
            On播放状态变化(_当前播放状态);
        }

        public void 停止()
        {
            if (_GPS数据列表.Count > 0)
            {
                On位置更新(_GPS数据列表[_GPS数据列表.Count - 1]);
            }
            _当前播放状态 = E播放状态.停止;
            On播放状态变化(_当前播放状态);
            On播放进度变化(100);
            On当前时间变化(实际结束时间);
            _播放定时器.Dispose();
        }

        public void 改变播放参数(int __频率)
        {
            _定时器间隔 = 1000 / __频率;
            if (_当前播放状态 == E播放状态.播放)
            {
                _播放定时器.Change(0, _定时器间隔);
            }
        }

        public void 跳转进度(int __进度)
        {
            if (_GPS数据列表.Count > 0)
            {
                _播放索引 = _GPS数据列表.Count * __进度 / _刻度;
            }
        }

        public event Action<int> 播放进度变化;

        protected virtual void On播放进度变化(int __进度)
        {
            var handler = 播放进度变化;
            if (handler != null) handler(__进度);
        }

        public event Action<DateTime> 当前时间变化;

        protected virtual void On当前时间变化(DateTime __时间)
        {
            var handler = 当前时间变化;
            if (handler != null) handler(__时间);
        }

        public event Action<MGPS> 位置更新;

        protected virtual void On位置更新(MGPS __位置)
        {
            var handler = 位置更新;
            if (handler != null) handler(__位置);
        }

        public event Action<E播放状态> 播放状态变化;

        protected virtual void On播放状态变化(E播放状态 __状态)
        {
            var handler = 播放状态变化;
            if (handler != null) handler(__状态);
        }
    }
}
