using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.存储;
using Utility.通用;
using 通用命令.状态;
using 通用访问;
using 通用访问.DTO;

namespace GIS服务器
{
    public interface IB数据库
    {
        [NoLog]
        string 地址 { get; }

        [NoLog]
        string 名称 { get; }

        [NoLog]
        string 账号 { get; }

        [NoLog]
        string 密码 { get; }

        void 保存连接参数(string __账号, string __密码, string __数据源);

        [NoLog]
        string 检测SQLSERVER(string __账号, string __密码, string __数据源);

        [NoLog]
        string 检测GIS数据库(string __账号, string __密码, string __数据源);

        [NoLog]
        bool 检测GIS数据库();

        void 创建数据库(string __路径);

        void 删除数据库();

        void 初始化();

        event Action<int> 清除过期数据;

        bool SQLSERVER正常 { get; set; }

        bool GIS数据库正常 { get; set; }
    }

    class B数据库 : IB数据库
    {
        ID数据库 _D数据库 = H容器.取出<ID数据库>();

        int _清除过期数据延迟 = 10 * 60 * 1000;  //10分钟

        int _清除过期数据频率 = 24 * 60 * 60 * 1000;  //24小时/次

        public bool SQLSERVER正常 { get; set; }

        public bool GIS数据库正常 { get; set; }

        public string 地址 { get; set; }

        public string 名称 { get; set; }

        public string 账号 { get; set; }

        public string 密码 { get; set; }

        public B数据库()
        {
            地址 = H程序配置.获取字符串("数据库地址");
            名称 = H程序配置.获取字符串("数据库名称");
            账号 = H程序配置.获取字符串("数据库账号");
            密码 = H程序配置.获取字符串("数据库密码");
        }

        public void 初始化()
        {
            配置通用访问("数据库");
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    检测状态();
                    Thread.Sleep(10000);
                }
            });

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(_清除过期数据延迟);
                while (true)
                {
                    try
                    {
                        if (GIS数据库正常)
                        {
                            On清除过期数据(H程序配置.获取Int32值("保留天数"));
                        }
                    }
                    catch (Exception ex)
                    {
                        H日志.记录异常(ex);
                    }
                    Thread.Sleep(_清除过期数据频率);
                }
            });
        }

        void 检测状态()
        {
            if (!H容器.可取出<IB状态_S>())
            {
                return;
            }
            var __IB状态_S = H容器.取出<IB状态_S>();
            var __连接成功 = _D数据库.连接SQLSERVER(账号, 密码, 地址);
            if (__连接成功 != SQLSERVER正常)
            {
                if (__连接成功)
                {
                    __IB状态_S.清除告警(new M上报清除 { 标识 = "连接SQLSERVER" });
                }
                else
                {
                    __IB状态_S.新增告警(new M上报告警
                    {
                        标识 = "连接SQLSERVER",
                        产生时间 = DateTime.Now,
                        重要性 = E重要性.紧急,
                        描述 = "无法连接SQLSERVER",
                        原因 = "",
                        解决方案 = "请尝试重启机器, 如无法恢复, 请联系开发人员"
                    });
                }
                SQLSERVER正常 = __连接成功;
            }
            if (SQLSERVER正常)
            {
                __连接成功 = _D数据库.存在GIS数据库(账号, 密码, 地址, 名称);
                if (__连接成功 != GIS数据库正常)
                {
                    if (__连接成功)
                    {
                        __IB状态_S.清除告警(new M上报清除 { 标识 = "连接GIS数据库" });
                    }
                    else
                    {
                        __IB状态_S.新增告警(new M上报告警
                        {
                            标识 = "连接GIS数据库",
                            产生时间 = DateTime.Now,
                            重要性 = E重要性.紧急,
                            描述 = "无法连接GIS数据库",
                            原因 = "",
                            解决方案 = "请尝试重启机器, 如无法恢复, 请联系开发人员"
                        });
                    }
                    GIS数据库正常 = __连接成功;
                }
            }
            else
            {
                GIS数据库正常 = false;
            }
            __IB状态_S.设置属性("", "连接SQLSERVER", () => new M业务概要 { 当前值 = SQLSERVER正常 ? "已连接" : "未连接", 正常 = SQLSERVER正常 });
            __IB状态_S.设置属性("", "连接GIS数据库", () => new M业务概要 { 当前值 = GIS数据库正常 ? "已连接" : "未连接", 正常 = GIS数据库正常 });
        }

        void 配置通用访问(string __对象名称)
        {
            if (!H容器.可取出<IT服务端>())
            {
                return;
            }
            var __IT服务端 = H容器.取出<IT服务端>();
            var __对象 = new M对象(__对象名称, null);
            __对象.添加方法("设置连接参数", __实参列表 =>
            {
                var __账号 = __实参列表["账号"];
                var __密码 = __实参列表["密码"];
                var __数据源 = __实参列表["数据源"];
                保存连接参数(__账号, __密码, __数据源);
                return "";
            }, E角色.工程, new List<M形参> { new M形参("账号", "string"), new M形参("密码", "string"), new M形参("数据源", "string") });
            __对象.添加属性("账号", () => 账号, E角色.工程);
            __对象.添加属性("密码", () => 密码, E角色.工程);
            __对象.添加属性("数据源", () => 地址, E角色.工程);
            __对象.添加属性("保留天数", () => H程序配置.获取字符串("保留天数"), E角色.工程);
            __对象.添加方法("设置保留天数", __实参列表 =>
            {
                var __天数 = __实参列表["天数"];
                H程序配置.设置("保留天数", __天数);
                return "";
            }, E角色.工程, new List<M形参> { new M形参("天数", "int") });
            __对象.添加方法("检测连接", __实参列表 =>
            {
                var __账号 = __实参列表["账号"];
                var __密码 = __实参列表["密码"];
                var __数据源 = __实参列表["数据源"];
                if (_D数据库.连接SQLSERVER(__账号, __密码, __数据源))
                {
                    if (_D数据库.存在GIS数据库(__账号, __密码, __数据源, 名称))
                    {
                        return "连接 MS SQL SERVER 成功, GIS数据库已存在";
                    }
                    return "连接 MS SQL SERVER 成功, GIS数据库未创建";
                }
                return "连接 MS SQL SERVER 失败";
            }, E角色.工程, new List<M形参> { new M形参("账号", "string"), new M形参("密码", "string"), new M形参("数据源", "string") });

            __IT服务端.添加对象(__对象名称, () => __对象);
        }

        public event Action<int> 清除过期数据;

        private void On清除过期数据(int obj)
        {
            var handler = 清除过期数据;
            if (handler != null) handler(obj);
        }

        public void 保存连接参数(string __账号, string __密码, string __数据源) { H程序配置.设置(new Dictionary<string, string> { { "数据库地址", __数据源 }, { "数据库账号", __账号 }, { "数据库密码", __密码 } }); }

        public string 检测SQLSERVER(string __账号, string __密码, string __数据源)
        {
            //检测是否安装

            //检测是否启动

            //检测是否能连接
            if (_D数据库.连接SQLSERVER(__账号, __密码, __数据源))
            {
                return "连接 MS SQL SERVER成功";
            }
            return "连接 MS SQL SERVER失败";

        }

        public string 检测GIS数据库(string __账号, string __密码, string __数据源)
        {
            if (!_D数据库.连接SQLSERVER(__账号, __密码, __数据源))
            {
                return "连接 MS SQL SERVER失败";
            }

            //检测存在
            if (_D数据库.存在GIS数据库(__账号, __密码, __数据源, 名称))
            {
                return "GIS数据库已存在";


                //检测是否能连接

            }
            return "GIS数据库未创建";
        }

        public bool 检测GIS数据库() { return _D数据库.存在GIS数据库(账号, 密码, 地址, 名称); }

        public void 创建数据库(string __路径) { _D数据库.创建数据库(账号, 密码, 地址, 名称, __路径); }

        public void 删除数据库() { _D数据库.删除数据库(账号, 密码, 地址, 名称); }
    }
}
