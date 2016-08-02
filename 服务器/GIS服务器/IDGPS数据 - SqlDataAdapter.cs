using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DTO;
using DTO.GPS数据;
using Utility.存储;
using Utility.通用;

namespace GIS服务器
{
    public interface IDGPS数据
    {
        void 保存(int __号码, MGPS __位置);

        M轨迹查询结果 查询轨迹(M轨迹查询条件 __条件);

        M最后位置查询结果 查询最后位置(M最后位置查询条件 __条件);

        Dictionary<int, MGPS> 查询最后位置(DateTime __开始时间);

        void 清除过期数据(int __过期天数);
    }

    internal class DGPS数据_模拟 : IDGPS数据
    {
        private Dictionary<int, MGPS> _最后位置缓存 = new Dictionary<int, MGPS>();

        private readonly double _参照经度 = 118.7816;

        private readonly double _参照纬度 = 32.0617;

        public void 保存(int __号码, MGPS __位置)
        {
            _最后位置缓存[__号码] = __位置;
        }

        public M轨迹查询结果 查询轨迹(M轨迹查询条件 __条件)
        {
            Thread.Sleep(1000);
            var __结果 = new M轨迹查询结果
            {
                总数量 = 24 * 60 * 60 / 15,
                列表 = new List<MGPS>()
            };
            var __随机数 = new Random();
            var __经度 = _参照经度 + __随机数.NextDouble() * 0.0002 * (__随机数.NextDouble() > 0.5 ? -1 : 1);
            var __纬度 = _参照纬度 + __随机数.NextDouble() * 0.0002 * (__随机数.NextDouble() > 0.5 ? -1 : 1);

            for (int i = 0; i < __结果.总数量; i++)
            {
                __经度 += __随机数.NextDouble() * 0.0005 * (__随机数.NextDouble() > 0.5 ? -1 : 1);
                __纬度 += __随机数.NextDouble() * 0.0005 * (__随机数.NextDouble() > 0.5 ? -1 : 1);
                __结果.列表.Add(new MGPS { 经度 = __经度, 纬度 = __纬度, 精度 = 20, 时间 = DateTime.Now.Date.AddSeconds(15 * i), 速度 = 10 });
            }
            return __结果;
        }

        public Dictionary<int, MGPS> 查询最后位置(DateTime 开始时间)
        {
            return new Dictionary<int, MGPS>(_最后位置缓存);
        }

        public M最后位置查询结果 查询最后位置(M最后位置查询条件 __条件)
        {
            var __位置列表 = _最后位置缓存.Select(__kv => new M号码位置 { 号码 = __kv.Key, GPS = __kv.Value }).ToList();
            return new M最后位置查询结果 { 总数量 = _最后位置缓存.Count, 列表 = __位置列表 };
        }

        public void 清除过期数据(int 过期天数)
        {

        }

    }

    internal class DGPS数据 : IDGPS数据
    {
        private string _表前缀 = "一天位置_";

        /// <summary>
        /// 毫秒/次
        /// </summary>
        private const int _批量增加GPS频率 = 5000;

        /// <summary>
        /// 毫秒/次
        /// </summary>
        private const int _批量更新最后GPS频率 = 60000;

        private const string _建一天位置表 = @"
IF NOT EXISTS (SELECT NAME FROM SYSOBJECTS WHERE XTYPE='U' AND NAME = '{0}')
	BEGIN
        CREATE TABLE {0}(
	        [Id] [int] PRIMARY KEY CLUSTERED IDENTITY NOT NULL,
	        [号码] [int] NOT NULL,
	        [时间] [datetime2](0) NOT NULL,
	        [经度] [decimal](10, 7) NOT NULL,
	        [纬度] [decimal](10, 7) NOT NULL,
	        [高度] [smallint] NOT NULL,
	        [速度] [smallint] NOT NULL,
	        [方向] [smallint] NOT NULL,
	        [精度] [smallint] NOT NULL
        ) ON [PRIMARY]

        CREATE NONCLUSTERED INDEX [号码与时间] ON {0}
        (
	        [号码] ASC,
	        [时间] ASC
        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	END
";

        private const string _建最后位置表 = @"
IF NOT EXISTS (SELECT NAME FROM SYSOBJECTS WHERE XTYPE='U' AND NAME = '最后位置')
	BEGIN
        CREATE TABLE [dbo].[最后位置](
	        [号码] [int] NOT NULL,
	        [时间] [datetime2](0) NOT NULL,
	        [经度] [decimal](10, 7) NOT NULL,
	        [纬度] [decimal](10, 7) NOT NULL,
	        [高度] [smallint] NOT NULL,
	        [速度] [smallint] NOT NULL,
	        [方向] [smallint] NOT NULL,
	        [精度] [smallint] NOT NULL,
         CONSTRAINT [PK_最后位置] PRIMARY KEY CLUSTERED 
        (
	        [号码] ASC
        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
        ) ON [PRIMARY]

	END
";

        private readonly string _连接字符串;

        private BlockingCollection<M号码位置> _数据缓存 = new BlockingCollection<M号码位置>(50000);

        private Dictionary<int, MGPS> _最后位置 = new Dictionary<int, MGPS>();

        public DGPS数据()
        {
            _连接字符串 = new SqlConnectionStringBuilder
            {
                DataSource = H程序配置.获取字符串("数据库地址"),
                UserID = H程序配置.获取字符串("数据库账号"),
                Password = H程序配置.获取字符串("数据库密码"),
                InitialCatalog = H程序配置.获取字符串("数据库名称"),
                IntegratedSecurity = false,
                UserInstance = false,
            }.ToString();

            Let.Us.Retry(1000, 100, null, exs => H调试.记录致命("建最后位置表失败:" + exs.Last().Message)).Do(() =>
            {
                using (var __连接 = new SqlConnection(_连接字符串))
                {
                    SQLHelper.ExecuteNonQuery(__连接, _建最后位置表);
                }
            });
            DataTable __位置表;
            Dictionary<int, DataRow> __位置映射;
            _最后位置 = 查询最后位置(out __位置表, out __位置映射);

            Task.Factory.StartNew(() =>
            {
                var __当前表 = "";
                while (true)
                {
                    var __更新数量 = 0;
                    Let.Us.DoAndSleep(_批量增加GPS频率, __耗时 => H调试.记录(string.Format("批量增加GPS {1} 条, 耗时 {0} 毫秒", __耗时, __更新数量)))
                        .Do(() => __更新数量 = 批量增加GPS(ref __当前表));
                }
            });

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    var __更新数量 = 0;
                    Let.Us.DoAndSleep(_批量更新最后GPS频率, __耗时 => H调试.记录(string.Format("批量更新最后GPS {1} 条, 耗时 {0} 毫秒", __耗时, __更新数量)))
                        .Do(() => { __更新数量 = 批量更新最后GPS(__位置表, __位置映射); });

                    //var __秒表 = new Stopwatch();
                    //__秒表.Start();
                    //var __更新数量 = 批量更新最后GPS(__位置表, __位置映射);
                    //__秒表.Stop();
                    //H调试.记录(string.Format("批量更新最后GPS {1} 耗时 {0} 毫秒", __秒表.Elapsed.TotalMilliseconds, __更新数量));
                    //var __休眠 = _批量更新最后GPS频率 - (int)__秒表.Elapsed.TotalMilliseconds;
                    //if (__休眠 > 0)
                    //{
                    //    Thread.Sleep(__休眠);
                    //}
                }
            });
        }

        private Dictionary<int, MGPS> 查询最后位置(out DataTable __位置表, out Dictionary<int, DataRow> __位置映射)
        {
            var __结果 = new Dictionary<int, MGPS>();
            __位置表 = new DataTable();
            __位置映射 = new Dictionary<int, DataRow>();

            using (var __连接 = new SqlConnection(_连接字符串))
            {
                using (var __适配器 = 创建访问器(__连接))
                {
                    __连接.Open();
                    __适配器.Fill(__位置表);
                }
            }
            foreach (DataRow __row in __位置表.Rows)
            {
                var __号码 = __row.Field<int>("号码");
                __结果[__号码] = new MGPS
                {
                    经度 = (double)__row.Field<decimal>("经度"),
                    纬度 = (double)__row.Field<decimal>("纬度"),
                    时间 = __row.Field<DateTime>("时间"),
                    方向 = __row.Field<short>("方向"),
                    高度 = __row.Field<short>("高度"),
                    精度 = __row.Field<short>("精度"),
                    速度 = __row.Field<short>("速度"),
                };
                __位置映射[__号码] = __row;
            }
            return __结果;
        }

        private int 批量更新最后GPS(DataTable __位置表, Dictionary<int, DataRow> __位置映射)
        {
            var __缓存 = new Dictionary<int, MGPS>(_最后位置);
            foreach (var __kv in __缓存)
            {
                var __号码 = __kv.Key;
                var __GPS = __kv.Value;
                DataRow __行;
                if (!__位置映射.ContainsKey(__号码))
                {
                    __行 = __位置表.NewRow();
                    __位置表.Rows.Add(__行);
                    __位置映射[__号码] = __行;
                }
                else
                {
                    __行 = __位置映射[__号码];
                }
                设置行(__行, __号码, __GPS);
            }

            DataTable __待更新;
            using (var __连接 = new SqlConnection(_连接字符串))
            {
                using (var __适配器 = 创建访问器(__连接))
                {
                    __连接.Open();
                    __待更新 = __位置表.GetChanges();
                    if (__待更新 != null && __待更新.Rows.Count > 0)
                    {
                        __适配器.Update(__待更新);
                    }
                    __位置表.AcceptChanges();
                }
            }
            return __待更新 == null ? 0 : __待更新.Rows.Count;
        }

        private int 批量增加GPS(ref string __当前表)
        {
            var __上报数据列表 = new List<M号码位置>();
            M号码位置 __上报数据;
            //while ((_上报数据列表.TryTake(out __上报数据) || _上报数据列表.IsAddingCompleted) && !_上报数据列表.IsCompleted)
            while (_数据缓存.TryTake(out __上报数据))
            {
                __上报数据列表.Add(__上报数据);
            }
            foreach (var __分组 in __上报数据列表.GroupBy(x => x.GPS.时间.Date))
            {
                var __表名 = _表前缀 + __分组.Key.ToString("yyyyMMdd");
                if (__当前表 != __表名)
                {
                    var __sql = string.Format(_建一天位置表, __表名);
                    Let.Us.Retry(1000, 100, null, exs => H调试.记录致命("建一天位置表失败:" + exs.Last().Message)).Do(() =>
                    {
                        using (var __连接 = new SqlConnection(_连接字符串))
                        {
                            SQLHelper.ExecuteNonQuery(__连接, __sql);
                        }
                    });
                    __当前表 = __表名;
                }
                var _一天位置表 = new DataTable();
                _一天位置表.Columns.AddRange(new[]
                {
                    new DataColumn("号码", typeof (int)),
                    new DataColumn("时间", typeof(DateTime)),
                    new DataColumn("经度", typeof(decimal)),
                    new DataColumn("纬度", typeof(decimal)),
                    new DataColumn("高度", typeof(short)),
                    new DataColumn("速度", typeof(short)),
                    new DataColumn("方向", typeof(short)),
                    new DataColumn("精度", typeof(short)),
                });
                __上报数据列表.ForEach(__数据 =>
                {
                    var __行 = _一天位置表.NewRow();
                    设置行(__行, __数据.号码, __数据.GPS);
                    _一天位置表.Rows.Add(__行);
                });

                using (var __批量复制 = new SqlBulkCopy(_连接字符串 /*, SqlBulkCopyOptions.TableLock*/))
                {
                    __批量复制.BatchSize = 500;
                    __批量复制.DestinationTableName = __表名;
                    __批量复制.ColumnMappings.Add("号码", "号码");
                    __批量复制.ColumnMappings.Add("时间", "时间");
                    __批量复制.ColumnMappings.Add("经度", "经度");
                    __批量复制.ColumnMappings.Add("纬度", "纬度");
                    __批量复制.ColumnMappings.Add("高度", "高度");
                    __批量复制.ColumnMappings.Add("速度", "速度");
                    __批量复制.ColumnMappings.Add("方向", "方向");
                    __批量复制.ColumnMappings.Add("精度", "精度");
                    __批量复制.WriteToServer(_一天位置表);
                }
            }
            return __上报数据列表.Count;
        }

        public SqlDataAdapter 创建访问器(SqlConnection __连接)
        {
            var __访问器 = new SqlDataAdapter();

            var __命令 = new SqlCommand("SELECT [号码],[时间],[经度],[纬度],[高度],[速度],[方向],[精度] FROM [DGISServer].[dbo].[最后位置]", __连接);
            __访问器.SelectCommand = __命令;

            __命令 = new SqlCommand("INSERT INTO 最后位置([号码],[时间],[经度],[纬度],[高度],[速度],[方向],[精度]) VALUES (@号码,@时间,@经度,@纬度,@高度,@速度,@方向,@精度)", __连接);
            __命令.Parameters.Add("@号码", SqlDbType.Int, 4, "号码");
            __命令.Parameters.Add("@时间", SqlDbType.DateTime2, 6, "时间");
            __命令.Parameters.Add("@经度", SqlDbType.Decimal, 9, "经度");
            __命令.Parameters.Add("@纬度", SqlDbType.Decimal, 9, "纬度");
            __命令.Parameters.Add("@高度", SqlDbType.SmallInt, 2, "高度");
            __命令.Parameters.Add("@速度", SqlDbType.SmallInt, 2, "速度");
            __命令.Parameters.Add("@方向", SqlDbType.SmallInt, 2, "方向");
            __命令.Parameters.Add("@精度", SqlDbType.SmallInt, 2, "精度");
            __访问器.InsertCommand = __命令;

            __命令 = new SqlCommand("UPDATE 最后位置 SET 时间 = @时间, 经度 = @经度, 纬度 = @纬度, 高度 = @高度, 速度 = @速度, 方向 = @方向, 精度 = @精度 " + "WHERE 号码 = @号码", __连接);
            __命令.Parameters.Add("@号码", SqlDbType.Int, 4, "号码");
            __命令.Parameters.Add("@时间", SqlDbType.DateTime2, 6, "时间");
            __命令.Parameters.Add("@经度", SqlDbType.Decimal, 9, "经度");
            __命令.Parameters.Add("@纬度", SqlDbType.Decimal, 9, "纬度");
            __命令.Parameters.Add("@高度", SqlDbType.SmallInt, 2, "高度");
            __命令.Parameters.Add("@速度", SqlDbType.SmallInt, 2, "速度");
            __命令.Parameters.Add("@方向", SqlDbType.SmallInt, 2, "方向");
            __命令.Parameters.Add("@精度", SqlDbType.SmallInt, 2, "精度");
            __访问器.UpdateCommand = __命令;

            __命令 = new SqlCommand("DELETE FROM 最后位置 WHERE 号码 = @号码", __连接);
            __命令.Parameters.Add("@号码", SqlDbType.Int, 4, "号码");//.SourceVersion = DataRowVersion.Original
            __访问器.DeleteCommand = __命令;

            return __访问器;
        }

        void 设置行(DataRow __行, int __号码, MGPS __位置)
        {
            __行["号码"] = __号码;
            __行["时间"] = __位置.时间;
            __行["经度"] = __位置.经度;
            __行["纬度"] = __位置.纬度;
            __行["高度"] = __位置.高度;
            __行["速度"] = __位置.速度;
            __行["方向"] = __位置.方向;
            __行["精度"] = __位置.精度;
        }

        public void 保存(int __号码, MGPS __位置)
        {
            _数据缓存.TryAdd(new M号码位置 { 号码 = __号码, GPS = __位置 });
            _最后位置[__号码] = __位置;
        }

        public M轨迹查询结果 查询轨迹(M轨迹查询条件 __条件)
        {
            var __结果 = new M轨迹查询结果 { 列表 = new List<MGPS>() };
            var __表名 = _表前缀 + __条件.开始时间.Date.ToString("yyyyMMdd");
            var __页码 = __条件.页码 ?? 1;
            var __每页数量 = __条件.每页数量 ?? 10000;
            using (var __连接 = new SqlConnection(_连接字符串))
            {
                var __sql = string.Format("SELECT 1 FROM SYSOBJECTS WHERE XTYPE='U' AND NAME = '{0}'", __表名);
                var __数量 = (int)SQLHelper.ExecuteScalar(__连接, __sql);
                if (__数量 == 0)
                {
                    return __结果;
                }

                __sql = string.Format("SELECT COUNT(*) FROM {0} WHERE 号码 = @号码 AND 时间 >= @开始时间 AND 时间 <= @结束时间 ", __表名);
                var __号码 = new SqlParameter("号码", __条件.号码);
                var __开始时间 = new SqlParameter("开始时间", __条件.开始时间);
                var __结束时间 = new SqlParameter("结束时间", __条件.结束时间);
                __数量 = (int)SQLHelper.ExecuteScalar(__连接, __sql, new DbParameter[] { __号码, __开始时间, __结束时间 });
                if (__数量 == 0)
                {
                    return __结果;
                }
                __结果.总数量 = __数量;

                __sql = 获取分页SQL(__表名, "时间, 经度, 纬度, 高度, 速度, 方向, 精度", "号码 = @号码 AND 时间 >= @开始时间 AND 时间 <= @结束时间", "时间 ASC", __页码, __每页数量);
                __号码 = new SqlParameter("号码", __条件.号码);
                __开始时间 = new SqlParameter("开始时间", __条件.开始时间);
                __结束时间 = new SqlParameter("结束时间", __条件.结束时间);
                using (var __访问器 = SQLHelper.ExecuteReader(__连接, __sql, new DbParameter[] { __号码, __开始时间, __结束时间 }))
                {
                    while (__访问器.Read())
                    {
                        var __GPS = new MGPS
                        {
                            时间 = __访问器.GetDateTime(0),
                            经度 = (double)__访问器.GetDecimal(1),
                            纬度 = (double)__访问器.GetDecimal(2),
                            高度 = __访问器.GetInt16(3),
                            速度 = __访问器.GetInt16(4),
                            方向 = __访问器.GetInt16(5),
                            精度 = __访问器.GetInt16(6),
                        };
                        __结果.列表.Add(__GPS);
                    }
                }
            }
            return __结果;
        }

        public M最后位置查询结果 查询最后位置(M最后位置查询条件 __条件)
        {
            var __temp = new Dictionary<int, MGPS>(_最后位置);
            var __结果 = new List<M号码位置>();
            var __匹配数量 = 0;
            foreach (var __kv in __temp)
            {
                if (__kv.Value.时间 < __条件.开始时间 || __kv.Value.时间 > __条件.结束时间)
                {
                    continue;
                }
                if (__条件.号码范围 != null && __条件.号码范围.Count > 0 && !__条件.号码范围.Exists(q => q.起始 <= __kv.Key && q.结束 >= __kv.Key))
                {
                    continue;
                }
                __匹配数量++;
                if (__条件.每页数量.HasValue && __条件.页码.HasValue && __匹配数量 >= (__条件.页码 - 1) * __条件.每页数量 && __匹配数量 < __条件.页码 * __条件.每页数量)
                {
                    continue;
                }
                __结果.Add(new M号码位置 { 号码 = __kv.Key, GPS = __kv.Value });
            }
            return new M最后位置查询结果 { 列表 = __结果, 总数量 = __结果.Count }; ;
        }

        public Dictionary<int, MGPS> 查询最后位置(DateTime __开始时间)
        {
            var __结果 = new Dictionary<int, MGPS>();
            var __temp = new Dictionary<int, MGPS>(_最后位置);
            foreach (var __kv in __temp)
            {
                if (__kv.Value.时间 >= __开始时间)
                {
                    __结果[__kv.Key] = __kv.Value;
                }
            }
            return __结果;
        }

        public void 清除过期数据(int __天数)
        {
            var __表列表 = new List<string>();
            var __sql = string.Format("SELECT NAME FROM SYSOBJECTS WHERE XTYPE='U' AND NAME LIKE '{0}%'", _表前缀);
            using (var __连接 = new SqlConnection(_连接字符串))
            {
                using (var __访问器 = SQLHelper.ExecuteReader(__连接, __sql))
                {
                    while (__访问器.Read())
                    {
                        __表列表.Add(__访问器["NAME"].ToString());
                    }
                }
                var __保留时间 = DateTime.Today.AddDays(-__天数);
                __表列表.ForEach(__表名 =>
                {
                    var __日期 = __表名.Split('_')[1];
                    if (__保留时间 > new DateTime(int.Parse(__日期.Substring(0, 4)), int.Parse(__日期.Substring(4, 2)), int.Parse(__日期.Substring(6, 2))))
                    {
                        SQLHelper.ExecuteNonQuery(__连接, "DROP TABLE " + __表名);
                    }
                });
            }
        }

        string 获取分页SQL(string __表名, string __selectSql, string __whereSql, string __sortSql, Int64 __页数, int __每页数量)
        {
            var __分页查询 = string.Format("SELECT {{4}} FROM (SELECT {{4}}, ROW_NUMBER() OVER(ORDER BY {{3}}) 行索引 FROM {0} WHERE {{2}}) 临时表 WHERE 行索引 > {{0}} AND 行索引 <= {{1}} ORDER BY {{3}}", __表名);
            if (string.IsNullOrEmpty(__whereSql))
            {
                __whereSql = " 1 = 1 ";
            }
            if (__页数 < 1)
            {
                __页数 = 1;
            }
            var __sql = string.Format(__分页查询, __页数 * __每页数量 - __每页数量, __页数 * __每页数量, __whereSql, __sortSql, __selectSql);
            return __sql;
        }
    }

}
