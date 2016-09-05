using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DTO;
using Utility.通用;
using 通用访问;

namespace GPS
{
    public interface IB订阅
    {
        void 增加(List<M号码段> __号码范围);

        void 删除(List<M号码段> __号码范围);

        event Action<int, MGPS> 位置更新;

    }

    class B订阅 : IB订阅
    {
        private IT客户端 _IT客户端;

        private string _对象名称 = "订阅";

        public B订阅(IT客户端 __IT客户端)
        {
            _IT客户端 = __IT客户端;
        }

        public void 增加(List<M号码段> __号码范围)
        {
            _IT客户端.执行方法(_对象名称, "增加", new Dictionary<string, string> { { "号码范围", HJSON.序列化(__号码范围) } });
        }

        public void 删除(List<M号码段> __号码范围)
        {
            _IT客户端.执行方法(_对象名称, "删除", new Dictionary<string, string> { { "号码范围", HJSON.序列化(__号码范围) } });
        }

        private Action<int, MGPS> _GPS上报;

        public event Action<int, MGPS> 位置更新
        {
            add
            {
                if (_GPS上报 == null)
                {
                    _IT客户端.订阅事件(_对象名称, "GPS上报", 处理GPS上报);
                }
                _GPS上报 += value;
            }
            remove
            {
                if (_GPS上报 != null)
                {
                    _GPS上报 -= value;
                    if (_GPS上报 == null)
                    {
                        _IT客户端.注销事件(_对象名称, "GPS上报", 处理GPS上报);
                    }
                }
            }
        }

        private void 处理GPS上报(Dictionary<string, string> __实参列表)
        {
            var __号码 = int.Parse(__实参列表["号码"]);
            var __GPS = HJSON.反序列化<MGPS>(__实参列表["GPS"]);
            if (__GPS.时间 > DateTime.Now)
            {
                __GPS.时间 = DateTime.Now;
            }
            OnGps上报(__号码, __GPS);
        }

        protected virtual void OnGps上报(int __号码, MGPS __GPS)
        {
            var handler = _GPS上报;
            if (handler != null) handler(__号码, __GPS);
        }
    }

    class B订阅_模拟 : IB订阅
    {
        private readonly double _参照经度 = 118.7816;

        private readonly double _参照纬度 = 32.0617;

        private readonly List<int> _订阅列表 = new List<int>();

        private readonly ReaderWriterLockSlim __订阅列表锁 = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        public B订阅_模拟()
        {
            var __随机数 = new Random();
            Task.Factory.StartNew(() =>
            {
                int __更新频率 = 8000;//毫秒/次
                var __轨迹缓存 = new Dictionary<int, Tuple<double, double>>();
                int __数量 = 0;
                while (true)
                {
                    try
                    {
                        __订阅列表锁.EnterReadLock();
                        var __列表 = new List<int>(_订阅列表);
                        if (__列表.Count != __数量)
                        {
                            H调试.记录("模拟订阅数量: " + __列表.Count, TraceEventType.Warning);
                            __数量 = __列表.Count;
                        }
                        __订阅列表锁.ExitReadLock();
                        var __监视器 = new Stopwatch();
                        __监视器.Start();
                        foreach (var __号码 in __列表)
                        {
                            if (!__轨迹缓存.ContainsKey(__号码))
                            {
                                var __初始经度偏移量 = __随机数.NextDouble() * 0.0002 * __数量 * (__随机数.NextDouble() > 0.5 ? -1 : 1);
                                var __初始纬度偏移量 = __随机数.NextDouble() * 0.0002 * __数量 * (__随机数.NextDouble() > 0.5 ? -1 : 1);
                                __轨迹缓存[__号码] = new Tuple<double, double>(_参照经度 + __初始经度偏移量, _参照纬度 + __初始纬度偏移量);
                            }
                            var __经度 = __轨迹缓存[__号码].Item1 + __随机数.NextDouble() * 0.0005 * (__随机数.NextDouble() > 0.2 ? -1 : 1);
                            var __纬度 = __轨迹缓存[__号码].Item2 + __随机数.NextDouble() * 0.0005 * (__随机数.NextDouble() > 0.2 ? -1 : 1);
                            __轨迹缓存[__号码] = new Tuple<double, double>(__经度, __纬度);
                            On位置更新(__号码, new MGPS
                            {
                                时间 = DateTime.Now,
                                精度 = 20,
                                方向 = 60,
                                经度 = __经度,
                                纬度 = __纬度,
                            }
                            );
                            //Thread.Sleep(__随机数.Next(0, __更新频率 / __数量));
                        }
                        if (__列表.Count == 0)
                        {
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            __监视器.Stop();
                            var __耗时 = (int)__监视器.ElapsedMilliseconds;
                            if (__耗时 < __更新频率)
                            {
                                Thread.Sleep(__更新频率 - __耗时);
                            }
                            else
                            {
                                H调试.记录(string.Format("超时: {0}毫秒", __耗时 - __更新频率));
                                Debug.WriteLine(string.Format("超时: {0}毫秒", __耗时 - __更新频率));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        H调试.记录异常(ex);
                    }
                }
            });
        }

        public void 增加(List<M号码段> __号码范围)
        {
            __订阅列表锁.EnterWriteLock();
            __号码范围.ForEach(q =>
            {
                for (int i = q.起始; i <= q.结束; i++)
                {
                    if (!_订阅列表.Contains(i))
                    {
                        _订阅列表.Add(i);
                    }
                }
            });
            __订阅列表锁.ExitWriteLock();
        }

        public void 删除(List<M号码段> __号码范围)
        {
            __订阅列表锁.EnterWriteLock();
            __号码范围.ForEach(q =>
            {
                for (int i = q.起始; i <= q.结束; i++)
                {
                    if (_订阅列表.Contains(i))
                    {
                        _订阅列表.Remove(i);
                    }
                }
            });
            __订阅列表锁.ExitWriteLock();
        }

        public event Action<int, MGPS> 位置更新;

        protected virtual void On位置更新(int arg1, MGPS arg2)
        {
            var handler = 位置更新;
            if (handler != null) handler(arg1, arg2);
        }
    }
}
