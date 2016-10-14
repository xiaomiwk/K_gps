using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DTO.订阅;
using Utility.任务;
using Utility.存储;
using Utility.通用;
using 通用访问;
using 通用访问.DTO;
using 通用访问.自定义序列化;

namespace GIS服务器
{
    public interface IB订阅
    {
        void 初始化();

    }

    class B订阅 : IB订阅
    {
        private IB插件 _IB插件 = H容器.取出<IB插件>();

        private IBGPS数据 _IBGPS数据 = H容器.取出<IBGPS数据>();

        private IT服务端 _IT服务端 = H容器.取出<IT服务端>();

        private Dictionary<string, M号码状态> _号码状态缓存 = new Dictionary<string, M号码状态>();

        private Dictionary<IPEndPoint, List<string>> _客户端订阅缓存 = new Dictionary<IPEndPoint, List<string>>();

        private ConcurrentDictionary<IPEndPoint, DateTime> _客户端连接时间缓存 = new ConcurrentDictionary<IPEndPoint, DateTime>();

        private H串行 _任务 = new H串行();

        public void 初始化()
        {
            配置通用访问("订阅");
            var __位置缓存 = _IBGPS数据.查询最后位置(DateTime.Now.AddDays(-1));
            foreach (var __kv in __位置缓存)
            {
                _号码状态缓存[__kv.Key] = new M号码状态 { 最后位置 = __kv.Value };
            }
            _IB插件.GPS上报 += _IB插件_GPS上报;
            _IT服务端.客户端已连接 += q => _客户端连接时间缓存[q] = DateTime.Now;
            _IT服务端.客户端已断开 += _IT服务端_客户端已断开;
        }

        void _IT服务端_客户端已断开(IPEndPoint obj)
        {
            DateTime __时间;
            _客户端连接时间缓存.TryRemove(obj, out __时间);
            if (_客户端订阅缓存.ContainsKey(obj))
            {
                var __号码列表 = _客户端订阅缓存[obj];
                __号码列表.ForEach(q =>
                {
                    if (_号码状态缓存.ContainsKey(q))
                    {
                        _号码状态缓存[q].订购者.RemoveAll(k => k.Equals(obj));
                    }
                });
                _客户端订阅缓存.Remove(obj);
            }
        }

        void _IB插件_GPS上报(string __号码, MGPS __GPS)
        {
            if (!_号码状态缓存.ContainsKey(__号码))
            {
                _号码状态缓存[__号码] = new M号码状态() { 最后位置 = __GPS };
            }
            _号码状态缓存[__号码].最后位置 = __GPS;

            var __地址列表 = 查询号码(__号码);
            if (__地址列表.Count == 0)
            {
                return;
            }
            _IT服务端.触发事件("订阅", "GPS上报", new Dictionary<string, string> { { "号码", __号码.ToString() }, { "GPS", HJSON.序列化(__GPS) } }, __地址列表);
        }

        private void 配置通用访问(string __对象名称)
        {
            var __对象 = new M对象(__对象名称, null);
            __对象.添加属性("号码总数", () => 订阅号码总数.ToString(), E角色.客户);
            __对象.添加属性("客户端总数", () => _客户端订阅缓存.Count.ToString(), E角色.客户);
            __对象.添加方法("增加", (__实参列表, __地址) =>
            {
                var __号码列表 = HJSON.反序列化<List<string>>(__实参列表["号码列表"]);
                _任务.执行(() => 增加(__号码列表, __地址));
                return null;
            }, E角色.客户, new List<M形参> { new M形参("号码列表", "string", E数据结构.单值数组) });
            __对象.添加方法("删除", (__实参列表, __地址) =>
            {
                var __号码列表 = HJSON.反序列化<List<string>>(__实参列表["号码列表"]);
                _任务.执行(() => 删除(__号码列表, __地址));
                return null;
            }, E角色.客户, new List<M形参> { new M形参("号码列表", "string", E数据结构.单值数组) });
            __对象.添加方法("查询客户端概要", q => HJSON.序列化(查询客户端概要(), new IPAddressConverter()), E角色.客户);
            __对象.添加方法("查询客户端明细", q =>
            {
                var __IP = IPAddress.Parse(q["IP"]);
                int __端口号 = int.Parse(q["端口号"]);
                return HJSON.序列化(查询客户端(__IP, __端口号));
            }, E角色.客户, new List<M形参> {
                new M形参("IP", new M元数据("string") { 描述 = "可选" }), 
                new M形参("端口号", new M元数据("int") { 描述 = "可选" }),
            });
            __对象.添加方法("查询所有号码", q => HJSON.序列化(所有号码), E角色.客户);
            __对象.添加方法("查询号码", q =>
            {
                var __号码 = q["号码"];
                return HJSON.序列化(查询号码(__号码), new IPEndPointConverter());
            }, E角色.客户, new List<M形参> {
                new M形参("号码", "string"), 
            });

            __对象.添加事件("GPS上报", E角色.客户, new List<M形参> {
                new M形参("号码", "string"),
                new M形参("GPS", new M元数据{ 结构 = E数据结构.对象, 子成员列表 = new List<M子成员>
                {
                    new M子成员("经度", "double"),
                    new M子成员("纬度", "double"),
                    new M子成员("时间", "string"),
                    new M子成员("速度", "int?"),
                    new M子成员("高度", "int?"),
                    new M子成员("方向", "int?"),
                    new M子成员("精度", "int?"),
                }}),
            });

            __对象.添加事件("状态上报", E角色.客户, new List<M形参> {
                new M形参("号码", "string"),
                new M形参("状态", "string"),
            });

            _IT服务端.添加对象(__对象名称, () => __对象);
        }

        private void 增加(List<string> __号码列表, IPEndPoint __地址)
        {
            HB日志.记录("订阅", string.Format("{0} 增加 {1}", __地址, string.Join(",",__号码列表)));
            if (!_客户端订阅缓存.ContainsKey(__地址))
            {
                _客户端订阅缓存[__地址] = __号码列表;
            }
            else
            {
                var __合并 = new List<int>();
                _客户端订阅缓存[__地址].AddRange(__号码列表);
                _客户端订阅缓存[__地址] = _客户端订阅缓存[__地址].Distinct().ToList();
            }
            __号码列表.ForEach(q =>
            {
                if (!_号码状态缓存.ContainsKey(q))
                {
                    _号码状态缓存[q] = new M号码状态();
                }
                if (!_号码状态缓存[q].订购者.Contains(__地址))
                {
                    _号码状态缓存[q].订购者.Add(__地址);
                }
                if (_号码状态缓存[q].最后位置 != null && _号码状态缓存[q].最后位置.时间.AddMinutes(2) > DateTime.Now)
                {
                    _IT服务端.触发事件("订阅", "GPS上报", new Dictionary<string, string> { { "号码", q }, { "GPS", HJSON.序列化(_号码状态缓存[q].最后位置) } }, new List<IPEndPoint> { __地址 });
                }
            });
        }

        private void 删除(List<string> __号码列表, IPEndPoint __地址)
        {
            HB日志.记录("订阅", string.Format("{0} 删除 {1}", __地址, string.Join(",", __号码列表)));
            if (_客户端订阅缓存.ContainsKey(__地址))
            {
                __号码列表.ForEach(q => _客户端订阅缓存[__地址].Remove(q));
            }
            __号码列表.ForEach(q =>
            {
                if (_号码状态缓存.ContainsKey(q))
                {
                    if (_号码状态缓存[q].订购者.Contains(__地址))
                    {
                        _号码状态缓存[q].订购者.Remove(__地址);
                    }
                }
            });
        }

        private List<string> 查询客户端(IPAddress __IP, int __端口号)
        {
            var __地址 = new IPEndPoint(__IP, __端口号);
            if (_客户端订阅缓存.ContainsKey(__地址))
            {
                return _客户端订阅缓存[__地址];
            }
            return new List<string>();
        }

        private List<IPEndPoint> 查询号码(string __号码)
        {
            return new List<IPEndPoint>(_号码状态缓存[__号码].订购者.Distinct());
        }

        private List<M客户端概要> 查询客户端概要()
        {
            var __结果 = new List<M客户端概要>();
            foreach (var __kv in _客户端订阅缓存)
            {
                var __订阅总数 = __kv.Value.Count;
                DateTime __时间;
                _客户端连接时间缓存.TryGetValue(__kv.Key, out __时间);
                __结果.Add(new M客户端概要 { IP = __kv.Key.Address, 端口号 = __kv.Key.Port, 订阅总数 = __订阅总数, 开始时间 = __时间 });
            }
            return __结果;
        }

        private int 订阅号码总数 { get { return _号码状态缓存.Count(k => k.Value.订购者.Count > 0); } }

        private List<string> 所有号码
        {
            get
            {
                var __结果 = _号码状态缓存.Where(k => k.Value.订购者.Count > 0).Select(k => k.Key).ToList();
                if (__结果.Count == 0)
                {
                    return __结果;
                }
                __结果.Sort();
                return __结果;
            }
        }

        private class M号码状态
        {
            public MGPS 最后位置 { get; set; }
            public List<IPEndPoint> 订购者 { get; set; }

            public M号码状态()
            {
                订购者 = new List<IPEndPoint>();
            }
        }
    }

}
