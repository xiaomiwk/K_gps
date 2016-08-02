using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using GIS.IBLL.外部接口;
using GIS.IPresenter.外部接口;
using GIS.外部接口;
using Utility.通用;
using 显示地图;

namespace GIS.IPresenter.实现
{
    class P实时 : P窗体基类, IP控件基类<IV实时>
    {
        private static readonly string _类型名 = typeof(P实时).Name;

        private readonly IB订阅 _IB订阅 = H容器.取出<IB订阅>();

        private readonly IB地图路径 _IB地图路径 = H容器.取出<IB地图路径>();

        private IV实时 _IV;

        private Dictionary<string, M号码属性> _当前显示号码集 = new Dictionary<string, M号码属性>();

        private readonly ReaderWriterLockSlim m_lock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        private IF地图 _IF地图;

        public void 处理视图(IV实时 视图, object 初始化参数)
        {
            _IV = 视图;
            _IV.初始化 += 初始化;
            _IV.开始加载 += 开始加载;
        }

        void 初始化()
        {
            H调试.记录(_类型名 + ": 初始化");
        }

        void 开始加载()
        {
            H调试.记录(_类型名 + ": 开始加载");

            //订阅事件
            _IB订阅.位置更新 += _IB订阅_GPS数据上报;
            _IB订阅.GPS更新状态变化 += _IB订阅_GPS更新状态变化;
            _IV.处理定位号码 = _IV_请求定位号码;
            _IV.处理定位号码集 = _IV_请求定位号码集;
            _IV.处理显示号码 = _IV_请求显示号码;
            _IV.处理显示号码集 = _IV_请求显示号码集;
            _IV.处理隐藏号码 = _IV_请求隐藏号码;
            _IV.处理隐藏号码集 = _IV_请求隐藏号码集;
            _IV.处理矩形圈选结束 = _IV_矩形圈选结束;
            _IV.处理圆形圈选结束 = _IV_圆形圈选结束;

            _IF地图 = _IV.IF地图;
            _IF地图.进入点 += IF地图_进入点;
            _IF地图.离开点 += IF地图_离开点;
            _IF地图.单击点 += IF地图_单击点;

            //初始化资源
            var __地图路径列表 = _IB地图路径.查询();
            if (__地图路径列表.Count == 0)
            {
                _IV.显示操作失败("拷贝地图文件到程序目录的\"GIS资源\\离线地图\"目录!");
            }
            else if (!__地图路径列表.Values.ToList().Contains(true))
            {
                _IV.显示操作失败("请配置地图路径!");
            }
            else
            {
                try
                {
                    foreach (var kv in __地图路径列表)
                    {
                        if (kv.Value)
                        {
                            _IV.IF地图.加载地图(kv.Key);
                        }
                    }
                    _IV.IF地图.应用地图(_IV.IF地图.所有地图源[0]);
                }
                catch (Exception ex)
                {
                    _IV.显示操作失败(ex.Message);
                }
            }
        }

        void _IV_请求显示号码集(Dictionary<string, M号码显示参数> __号码集)
        {
            foreach (var __kv in __号码集)
            {
                _IV_请求显示号码(__kv.Key, __kv.Value);
            }
        }

        void _IV_请求显示号码(string __号码, M号码显示参数 __显示参数)
        {
            m_lock.EnterReadLock();
            var __已显示 = _当前显示号码集.ContainsKey(__号码);
            m_lock.ExitReadLock();

            if (!__已显示)
            {
                m_lock.EnterWriteLock();
                _当前显示号码集[__号码] = new M号码属性();
                m_lock.ExitWriteLock();
            }

            m_lock.EnterReadLock();
            if (!_当前显示号码集.ContainsKey(__号码))
            {
                m_lock.ExitReadLock();
                return;
            }
            var __号码属性 = _当前显示号码集[__号码];
            __号码属性.显示参数 = __显示参数;
            var __GPS = _IB订阅.查询最后GPS(__号码);
            if (__GPS != null)
            {
                if (__号码属性.绘图标识.HasValue)
                {
                    _IF地图.删除点(__号码属性.绘图标识.Value);
                }
                var __图标 = _IV.生成图片(__号码, _IB订阅.查询GPS更新状态(__号码));
                if (__图标 == null)
                {
                    m_lock.ExitReadLock();
                    return;
                }
                var __标识 = _IF地图.添加点(__GPS.转M经纬度(), __图标, __显示参数.昵称, new M号码绑定对象(__号码));
                __号码属性.绘图标识 = __标识;
                __号码属性.位置 = __GPS.转M经纬度();
            }
            m_lock.ExitReadLock();
        }

        void _IV_请求隐藏号码集(List<string> __号码集)
        {
            __号码集.ForEach(_IV_请求隐藏号码);
        }

        void _IV_请求隐藏号码(string __号码)
        {
            m_lock.EnterReadLock();
            var __已显示 = _当前显示号码集.ContainsKey(__号码);
            if (!__已显示)
            {
                H调试.记录(_类型名 + ": _IV_请求隐藏号码", __号码 + "不在当前显示号码集中");
                m_lock.ExitReadLock();
                return;
            }
            if (_当前显示号码集[__号码].绘图标识.HasValue)
            {
                _IF地图.删除点(_当前显示号码集[__号码].绘图标识.Value);
            }
            m_lock.ExitReadLock();

            m_lock.EnterWriteLock();
            if (_当前显示号码集.ContainsKey(__号码))
            {
                _当前显示号码集.Remove(__号码);
            }
            m_lock.ExitWriteLock();
        }

        void _IB订阅_GPS数据上报(string __号码, MGPS __GPS)
        {
            m_lock.EnterReadLock();
            if (!_当前显示号码集.ContainsKey(__号码))
            {
                //H调试.记录(_类型名 + ": _IB订阅_GPS数据上报", __号码 + "不在当前显示号码集中");
                m_lock.ExitReadLock();
                return;
            }
            var __号码属性 = _当前显示号码集[__号码];
            if (__号码属性.绘图标识.HasValue)
            {
                _IF地图.删除点(__号码属性.绘图标识.Value);
            }
            var __图标 = _IV.生成图片(__号码, _IB订阅.查询GPS更新状态(__号码));
            if (__图标 == null)
            {
                m_lock.ExitReadLock();
                return;
            }
            var __显示参数 = __号码属性.显示参数;
            var __标识 = _IF地图.添加点(__GPS.转M经纬度(), __图标, __显示参数.昵称, new M号码绑定对象(__号码));
            __号码属性.绘图标识 = __标识;
            __号码属性.位置 = __GPS.转M经纬度();
            m_lock.ExitReadLock();
        }

        void _IB订阅_GPS更新状态变化(string __号码, EGPS更新状态 __状态)
        {
            m_lock.EnterReadLock();
            if (!_当前显示号码集.ContainsKey(__号码))
            {
                m_lock.ExitReadLock();
                return;
            }
            var __号码属性 = _当前显示号码集[__号码];
            m_lock.ExitReadLock();
            switch (__状态)
            {
                case EGPS更新状态.从未有过:
                    break;
                case EGPS更新状态.最近更新:
                case EGPS更新状态.短期未更新:
                case EGPS更新状态.很久未更新:
                    _IV_请求显示号码(__号码, __号码属性.显示参数);
                    break;
                case EGPS更新状态.失效:
                    if (__号码属性.绘图标识.HasValue)
                    {
                        _IF地图.删除点(__号码属性.绘图标识.Value);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("状态");
            }
        }

        void _IV_请求定位号码(string __号码)
        {
            m_lock.EnterReadLock();
            if (_当前显示号码集.ContainsKey(__号码))
            {
                var __位置 = _当前显示号码集[__号码].位置;
                if (__位置 != null)
                {
                    _IF地图.定位(__位置);
                }
            }
            m_lock.ExitReadLock();
        }

        void _IV_请求定位号码集(List<string> __号码集)
        {
            var __经纬度集 = new List<M经纬度>();
            m_lock.EnterReadLock();
            __号码集.ForEach(__号码 =>
            {
                if (_当前显示号码集.ContainsKey(__号码))
                {
                    var __位置 = _当前显示号码集[__号码].位置;
                    if (__位置 != null)
                    {
                        __经纬度集.Add(__位置);
                    }
                }
            });
            m_lock.ExitReadLock();
            _IF地图.定位(__经纬度集);
        }

        void _IV_矩形圈选结束(M经纬度 __左上角, M经纬度 __右下角)
        {
            var __匹配号码集 = new List<string>();
            var __矩形点集 = new List<M经纬度>
                    {
                        __左上角,
                        __左上角.偏移(__右下角.经度 - __左上角.经度, 0),
                        __右下角,
                        __右下角.偏移(__左上角.经度 - __右下角.经度, 0),
                    };
            m_lock.EnterReadLock();
            foreach (var kv in _当前显示号码集)
            {
                var __号码 = kv.Key;
                var __位置 = kv.Value.位置;
                if (__位置 != null)
                {
                    if (H地图算法.判断点在矩形内(_IF地图.纠偏(__位置), __矩形点集))
                    {
                        __匹配号码集.Add(__号码);
                    }
                }
            }
            m_lock.ExitReadLock();
            if (__匹配号码集.Count > 0)
            {
                _IV.触发圈选结束(__匹配号码集);
            }
        }

        void _IV_圆形圈选结束(M经纬度 __圆心, int __半径)
        {
            var __匹配号码集 = new List<string>();
            m_lock.EnterReadLock();
            foreach (var kv in _当前显示号码集)
            {
                var __号码 = kv.Key;
                var __位置 = kv.Value.位置;
                if (__位置 != null)
                {
                    if (H地图算法.判断点在圆形内(_IF地图.纠偏(__位置), __圆心, __半径))
                    {
                        __匹配号码集.Add(__号码);
                    }
                }
            }
            m_lock.ExitReadLock();
            if (__匹配号码集.Count > 0)
            {
                _IV.触发圈选结束(__匹配号码集);
            }
        }

        void IF地图_单击点(object obj)
        {
            var __绑定对象 = obj as M号码绑定对象;
            if (__绑定对象 != null)
            {
                _IV.触发单击号码(__绑定对象.号码);
            }
        }

        void IF地图_离开点(object obj)
        {
            var __绑定对象 = obj as M号码绑定对象;
            if (__绑定对象 != null)
            {
                _IV.触发离开号码(__绑定对象.号码);
            }
        }

        void IF地图_进入点(object obj)
        {
            var __绑定对象 = obj as M号码绑定对象;
            if (__绑定对象 != null)
            {
                _IV.触发进入号码(__绑定对象.号码);
            }
        }

    }
}
