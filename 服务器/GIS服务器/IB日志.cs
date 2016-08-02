using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.日志;
using Utility.通用;
using 通用访问;
using 通用访问.DTO;

namespace GIS服务器
{
    public interface IB日志
    {
        void 初始化();

        void 增加(M日志 __日志);

        M查询结果 查询(M查询条件 __条件);
    }

    internal class B日志_内存 : IB日志
    {
        private List<M日志> _缓存 = new List<M日志>();

        private object _锁 = new object();

        public void 初始化()
        {
            //for (int i = 0; i < 1000; i++)
            //{
            //    _缓存.Add(new M日志 { 类别 = "测试", 描述 =i.ToString(), 时间 = DateTime.Now});
            //}
            配置通用访问("日志");

        }
        private void 配置通用访问(string __对象名称)
        {
            var __对象 = new M对象(__对象名称, null);
            __对象.添加方法("查询", q =>
            {
                var __条件 = HJSON.反序列化<M查询条件>(q["条件"]);
                return HJSON.序列化(查询(__条件));
            }, E角色.工程, new List<M形参> { new M形参("条件", new M元数据{ 结构 = E数据结构.对象, 子成员列表 = new List<M子成员>
            {
                new M子成员("开始时间","string"),
                new M子成员("结束时间","string"),
                new M子成员("类别","string"),
                new M子成员("页数","int"),
                new M子成员("每页数量","int"),
            }}) });
            H容器.取出<IT服务端>().添加对象(__对象名称, () => __对象);
        }

        public void 增加(M日志 __日志)
        {
            lock (_锁)
            {
                if (_缓存.Count >= 10000)
                {
                    _缓存.RemoveAt(0);
                }
                _缓存.Add(__日志);
            }
        }

        public M查询结果 查询(M查询条件 __条件)
        {
            lock (_锁)
            {
                var __结果 = _缓存.Where(q => q.类别 == __条件.类别 || string.IsNullOrEmpty(__条件.类别)).Reverse().ToList();
                var __总数 = __结果.Count;
                var __数量 = __条件.每页数量 ?? 30;
                var __页码 = __条件.页码 ?? 1;
                var __起始索引 = (__页码 - 1)*__数量;
                if (__页码 > 1 && __结果.Count > __起始索引)
                {
                    __结果 = __结果.Skip(__起始索引).ToList();
                }
                return new M查询结果 { 列表 = __结果.Take(Math.Min(__数量, __结果.Count)).ToList(), 总数 = __总数 };
            }
        }
    }

    internal static class HB日志
    {
        private static IB日志 _IB日志 = H容器.取出<IB日志>();

        public static void 记录(string __类别, string __描述)
        {
            _IB日志.增加(new M日志 { 类别 = __类别, 描述 = __描述, 时间 = DateTime.Now, 账号 = ""});
        }
    }
}
