using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DTO;
using GPS地图.DTO;
using Utility.通用;

namespace GPS地图.IBLL.实现
{
    class B回放_按时间 : IB回放_按时间
    {
        private readonly Dictionary<string, List<MGPS>> _未播轨迹列表 = new Dictionary<string, List<MGPS>>();

        private DateTime _当前播放时间;

        private int _播放倍速;

        private E播放状态 _当前播放状态;

        private Timer _播放定时器;

        private const int _定时器间隔 = 1000;

        private int _回放标识;

        Dictionary<string, List<MGPS>> _GPS数据列表 = new Dictionary<string, List<MGPS>>();

        public void 初始化(Dictionary<string, List<MGPS>> 回放参数)
        {
            _当前播放状态 = E播放状态.初始化;
            On播放状态变化(_当前播放状态);

            //查询GPS数据
            实际开始时间 = DateTime.MaxValue;
            实际结束时间 = DateTime.MinValue;
            foreach (var __kv in 回放参数)
            {
                if (__kv.Value.Count > 0)
                {
                    if (__kv.Value.First().时间 < 实际开始时间)
                    {
                        实际开始时间 = __kv.Value.First().时间;
                    }
                    if (__kv.Value.Last().时间 > 实际结束时间)
                    {
                        实际结束时间 = __kv.Value.Last().时间;
                    }
                    _GPS数据列表[__kv.Key] = new List<MGPS>(__kv.Value);
                }
            }
        }

        public DateTime 实际开始时间 { get; set; }

        public DateTime 实际结束时间 { get; set; }

        public DateTime 当前时间
        {
            get { return _当前播放时间; }
        }

        public void 播放(int __倍速)
        {
            _播放倍速 = __倍速;
            if (_当前播放状态 == E播放状态.初始化 || _当前播放状态 == E播放状态.停止)
            {
                _回放标识++;
                _当前播放时间 = 实际开始时间;
                _未播轨迹列表.Clear();
                foreach (var __kv in _GPS数据列表)
                {
                    var __GPS列表拷贝 = new List<MGPS>(__kv.Value);
                    _未播轨迹列表[__kv.Key] = __GPS列表拷贝;
                }
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
            _当前播放时间 = _当前播放时间.AddMilliseconds(_定时器间隔 * _播放倍速);
            On当前时间变化(_当前播放时间);
            const int __刻度 = 100;
            var __进度 = ((int)(_当前播放时间.Subtract(实际开始时间).TotalSeconds) * __刻度 / (int)(实际结束时间.Subtract(实际开始时间).TotalSeconds));
            On播放进度变化(Math.Min(__刻度, __进度));
            foreach (var __kv in _未播轨迹列表)
            {
                var __号码 = __kv.Key;
                var __GPS列表 = __kv.Value;
                //查找对应时段内的轨迹，如果有则删除原标记，添加新标记
                var __匹配GPS = __GPS列表.FindLast(q => q.时间 <= _当前播放时间);
                if (__匹配GPS != null)
                {
                    On位置更新(__号码, __匹配GPS);
                    __GPS列表.RemoveAll(q => q.时间 <= _当前播放时间);
                }
            }

            if (实际结束时间 <= _当前播放时间)
            {
                停止();
            }
        }

        public void 暂停()
        {
            _当前播放状态 = E播放状态.暂停;
            On播放状态变化(_当前播放状态);
        }

        public void 停止()
        {
            _当前播放状态 = E播放状态.停止;
            On播放状态变化(_当前播放状态);
            On播放进度变化(100);
            On当前时间变化(实际结束时间);
            _播放定时器.Dispose();
        }

        public void 改变播放参数(int __倍速)
        {
            _播放倍速 = __倍速;
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

        public event Action<string, MGPS> 位置更新;

        protected virtual void On位置更新(string __名称, MGPS __位置)
        {
            var handler = 位置更新;
            if (handler != null) handler(__名称, __位置);
        }

        public event Action<E播放状态> 播放状态变化;

        protected virtual void On播放状态变化(E播放状态 __状态)
        {
            var handler = 播放状态变化;
            if (handler != null) handler(__状态);
        }

    }
}
