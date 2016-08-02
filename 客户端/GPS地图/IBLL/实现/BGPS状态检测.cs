using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using DTO;
using GPS地图.DTO;
using Utility.通用;

namespace GPS地图.IBLL.实现
{
    class BGPS状态检测
    {
        private readonly IBGPS状态配置 _IBGPS状态配置 = H容器.取出<IBGPS状态配置>();

        private Timer _定时器;

        private class M状态
        {
            public EGPS状态 跟踪状态 { get; set; }

            public MGPS 最后位置 { get; set; }

            public List<MGPS> 位置缓存 { get; set; }

            public M状态()
            {
                this.位置缓存 = new List<MGPS>();
            }
        }

        private readonly Dictionary<string, M状态> _所有状态 = new Dictionary<string, M状态>();

        private readonly ReaderWriterLockSlim _状态锁 = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        private readonly int _定时器间隔秒数;

        private readonly int _短期未更新间隔; 

        private readonly int _很久未更新间隔;

        private readonly int _失效间隔;

        private const int _单号码轨迹缓存数量 = 5;

        private bool _暂停;

        public Func<DateTime> 时间偏移 { get; set; }

        public BGPS状态检测()
        {
            var __状态配置 = _IBGPS状态配置.查询();
            _短期未更新间隔 = __状态配置.短期未更新间隔;
            _很久未更新间隔 = __状态配置.很久未更新间隔;
            _失效间隔 = __状态配置.停止显示间隔;
            _定时器间隔秒数 = _短期未更新间隔 / 2;
        }

        public void 开始()
        {
            _定时器 = new Timer(定时执行, null, 0, _定时器间隔秒数 * 1000);
        }

        public void 暂停()
        {
            _暂停 = true;
        }

        public void 继续()
        {
            _暂停 = false;
        }

        public void 关闭()
        {
            if (_定时器 != null)
            {
                _定时器.Dispose();
            }
        }

        public void 清空状态()
        {
            _状态锁.EnterWriteLock();
            _所有状态.Clear();
            _状态锁.ExitWriteLock();
        }

        /// <returns>true: 状态已变更; false: 状态未变更</returns>
        public bool 接收GPS数据(string __标识, MGPS __GPS, bool __修改GPS时间 = false)
        {
            M状态 __状态;
            _状态锁.EnterReadLock();
            if (!_所有状态.ContainsKey(__标识))
            {
                _状态锁.ExitReadLock();
                _状态锁.EnterWriteLock();
                _所有状态[__标识] = new M状态();
                __状态 = _所有状态[__标识];
                _状态锁.ExitWriteLock();
            }
            else
            {
                __状态 = _所有状态[__标识];
                _状态锁.ExitReadLock();
            }
            __状态.位置缓存.Add(__GPS);
            if (__状态.位置缓存.Count > _单号码轨迹缓存数量)
            {
                __状态.位置缓存.RemoveAt(0);
            }

            if (__修改GPS时间)
            {
                if (__状态.最后位置 != null)
                {
                    __GPS.时间 = DateTime.Now; //未用报文中的时间，因为涉及到时间判断，需要客户端与服务器同步, 但要排除从服务器接收到的第一次缓存数据
                }
            }
            __状态.最后位置 = __GPS;
            var __旧状态 = __状态.跟踪状态;
            var __新状态 = 计算状态(__GPS);
            if (__旧状态 != __新状态)
            {
                __状态.跟踪状态 = __新状态;
                On状态变化(__标识, __新状态);
                return true;
            }
            return false;
        }

        public void 删除GPS数据(string __标识)
        {
            _状态锁.EnterWriteLock();
            if (_所有状态.ContainsKey(__标识))
            {
                _所有状态.Remove(__标识);
            }
            _状态锁.ExitWriteLock();
        }

        public List<MGPS> 查询缓存(string __标识)
        {
            _状态锁.EnterReadLock();
            if (_所有状态.ContainsKey(__标识))
            {
                var __缓存 = _所有状态[__标识].位置缓存;
                _状态锁.ExitReadLock();
                return __缓存;
            }
            _状态锁.ExitReadLock();
            return new List<MGPS>();
        }

        public EGPS状态 查询状态(string __标识)
        {
            _状态锁.EnterReadLock();
            if (_所有状态.ContainsKey(__标识))
            {
                var __状态 = _所有状态[__标识].跟踪状态;
                _状态锁.ExitReadLock();
                return __状态;
            }
            _状态锁.ExitReadLock();
            return EGPS状态.从未有过;
        }

        private EGPS状态 计算状态(MGPS __位置)
        {
            try
            {
                var __最后时间 = __位置.时间;
                var __当前时间 = 时间偏移 == null ? DateTime.Now : 时间偏移();
                if (__最后时间.AddSeconds(_失效间隔) < __当前时间)
                {
                    return EGPS状态.停止显示;
                }
                if (__最后时间.AddSeconds(_很久未更新间隔) < __当前时间)
                {
                    return EGPS状态.很久未更新;
                }
                if (__最后时间.AddSeconds(_短期未更新间隔) < __当前时间)
                {
                    return EGPS状态.短期未更新;
                }
                return EGPS状态.最近更新;
            }
            catch (Exception ex)
            {
                H调试.记录异常(ex, __位置 == null ? "位置为null" : "");
            }
            return EGPS状态.停止显示;
        }

        public MGPS 查询位置(string __标识)
        {
            _状态锁.EnterReadLock();
            if (_所有状态.ContainsKey(__标识))
            {
                var __位置 = _所有状态[__标识].最后位置;
                _状态锁.ExitReadLock();
                return __位置;
            }
            _状态锁.ExitReadLock();
            return null;
        }

        public MGPS 查询位置(string __标识, out EGPS状态 __EGPS状态)
        {
            _状态锁.EnterReadLock();
            if (_所有状态.ContainsKey(__标识))
            {
                var __位置 = _所有状态[__标识].最后位置;
                __EGPS状态 = _所有状态[__标识].跟踪状态;
                _状态锁.ExitReadLock();
                return __位置;
            }
            _状态锁.ExitReadLock();
            __EGPS状态 = EGPS状态.从未有过;
            return null;
        }

        public event Action<string, EGPS状态> 状态变化;

        protected virtual void On状态变化(string __标识, EGPS状态 __新状态)
        {
            var handler = 状态变化;
            if (handler != null) handler(__标识, __新状态);
        }

        void 定时执行(object 参数)
        {
            while (_暂停)
            {
                return;
            }
            var __状态拷贝 = new Dictionary<string, M状态>();
            _状态锁.EnterReadLock();
            foreach (var kv in _所有状态)
            {
                __状态拷贝[kv.Key] = kv.Value;
            }
            _状态锁.ExitReadLock();
            foreach (var __kv in __状态拷贝)
            {
                var __号码 = __kv.Key;
                var __状态 = __kv.Value;
                var __旧状态 = __状态.跟踪状态;
                var __新状态 = 计算状态(__状态.最后位置);
                if (__新状态 != __旧状态)
                {
                    Debug.WriteLine("{0}: {1} -> {2}", __号码, __旧状态, __新状态);
                    __状态.跟踪状态 = __新状态;
                    On状态变化(__号码, __新状态);
                }
            }
        }

    }
}
