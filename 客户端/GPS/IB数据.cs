﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using DTO;
using DTO.GPS数据;
using Utility.存储;
using 通用访问;

namespace GPS
{
    public interface IB数据
    {
        M轨迹查询结果 查询(M轨迹查询条件 __条件);

        List<MGPS> 查询轨迹(List<Tuple<string, DateTime, DateTime>> __条件);

        M最后位置查询结果 查询(M最后位置查询条件 __条件);

        M活跃号码查询结果 查询(M活跃号码查询条件 __条件);

        int 统计(M活跃号码查询条件 __条件);

        float 统计(M频率统计条件 __条件);
    }

    class B数据 : IB数据
    {
        private IT客户端 _IT客户端;

        private string _对象名称 = "GPS数据";

        public B数据(IT客户端 __IT客户端)
        {
            _IT客户端 = __IT客户端;
        }

        public M轨迹查询结果 查询(M轨迹查询条件 __条件)
        {
            var __返回值 = _IT客户端.执行方法(_对象名称, "查询轨迹", new Dictionary<string, string> { { "条件", HJSON.序列化(__条件) } }, 30000);
            //return HJSON.反序列化<M轨迹查询结果>(__返回值);

            var __解压 = H序列化.AES解压(__返回值);
            return HJSON.反序列化<M轨迹查询结果>(__解压);
        }

        public M最后位置查询结果 查询(M最后位置查询条件 __条件)
        {
            var __返回值 = _IT客户端.执行方法(_对象名称, "查询最后位置", new Dictionary<string, string> { { "条件", HJSON.序列化(__条件) } }, 30000);
            return HJSON.反序列化<M最后位置查询结果>(H序列化.AES解压(__返回值));
        }

        public List<MGPS> 查询轨迹(List<Tuple<string, DateTime, DateTime>> __条件)
        {
            var __结果 = new List<MGPS>();
            __条件.ForEach(q =>
            {
                var __返回值 = 查询(new M轨迹查询条件 { 号码 = q.Item1, 开始时间 = q.Item2, 结束时间 = q.Item3 });
                __结果.AddRange(__返回值.列表);
            });
            return __结果;
        }

        public M活跃号码查询结果 查询(M活跃号码查询条件 __条件)
        {
            var __返回值 = _IT客户端.执行方法(_对象名称, "查询活跃号码", new Dictionary<string, string> { { "条件", HJSON.序列化(__条件) } }, 60000);
            return HJSON.反序列化<M活跃号码查询结果>(__返回值);
        }

        public int 统计(M活跃号码查询条件 __条件)
        {
            var __返回值 = _IT客户端.执行方法(_对象名称, "统计活跃号码", new Dictionary<string, string> { { "条件", HJSON.序列化(__条件) } }, 30000);
            return int.Parse(__返回值);
        }

        public float 统计(M频率统计条件 __条件)
        {
            var __返回值 = _IT客户端.执行方法(_对象名称, "统计频率", new Dictionary<string, string> { { "条件", HJSON.序列化(__条件) } }, 30000);
            return float.Parse(__返回值);
        }
    }

    class B数据_模拟 : IB数据
    {
        private readonly double _参照经度 = 118.7816;

        private readonly double _参照纬度 = 32.0617;

        public M轨迹查询结果 查询(M轨迹查询条件 __条件)
        {
            var __列表 = new List<MGPS>();
            for (int i = 0; i < 1000; i++)
            {
                __列表.Add(new MGPS { 经度 = 118 + i * 0.0001, 纬度 = 32 + i * 0.0001, 时间 = DateTime.Now.AddSeconds(-30 * i) });
            }
            return new M轨迹查询结果 { 总数量 = 1000, 列表 = __列表 };
        }

        public M最后位置查询结果 查询(M最后位置查询条件 __条件)
        {
            var __列表 = new List<M号码位置>();
            for (int i = 0; i < 1000; i++)
            {
                __列表.Add(new M号码位置
                {
                    号码 = i.ToString(), 
                    GPS = new MGPS
                    {
                        经度 = 118.7 + i * 0.0001,
                        纬度 = 32.04 + i * 0.0001,
                        时间 = DateTime.Now.Date.AddDays(-1).AddSeconds(1 * i),
                        精度 = 10,
                        速度 = 10,
                        方向 = 30,
                        高度 = 0,
                    }
                });
            }
            return new M最后位置查询结果 { 总数 = 1000, 列表 = __列表 };
        }

        public List<MGPS> 查询轨迹(List<Tuple<string, DateTime, DateTime>> __条件)
        {
            Thread.Sleep(500);
            var __列表 = new List<MGPS>();
            var __随机数 = new Random();
            var __最后经度 = _参照经度 + __随机数.NextDouble() * 0.05 * (__随机数.NextDouble() > 0.5 ? -1 : 1);
            var __最后纬度 = _参照纬度 + __随机数.NextDouble() * 0.05 * (__随机数.NextDouble() > 0.5 ? -1 : 1);
            for (int i = 0; i < 1000; i++)
            {
                __最后经度 += __随机数.NextDouble() * 0.0002 * (__随机数.NextDouble() > 0.5 ? -1 : 1);
                __最后纬度 += __随机数.NextDouble() * 0.0002 * (__随机数.NextDouble() > 0.5 ? -1 : 1);

                __列表.Add(new MGPS
                {
                    经度 = __最后经度,
                    纬度 = __最后纬度,
                    时间 = DateTime.Now.Date.AddDays(-1).AddSeconds(1 * i),
                    精度 = 10,
                    速度 = 10,
                    方向 = 30,
                    高度 = 0,
                });
            }
            return __列表;
        }

        public M活跃号码查询结果 查询(M活跃号码查询条件 __条件)
        {
            return new M活跃号码查询结果 { 总数 = 0 };
        }

        public int 统计(M活跃号码查询条件 __条件)
        {
            return 0;
        }

        public float 统计(M频率统计条件 __条件)
        {
            return 0;
        }

    }
}
