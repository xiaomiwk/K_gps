using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.Windows;
using Utility.存储;
using Utility.通用;
using 通用命令.FTP;
using 通用命令.名片;
using 通用命令.状态;
using 通用命令.系统;
using 通用访问;

namespace GIS服务器
{
    class B通用命令
    {
        public static void 配置(IT服务端 __IT服务端)
        {
            H容器.注入<IB名片_S, B名片_S>(true, false, "", __IT服务端);
            H容器.注入<IB系统_S, B系统_S>(true, false, "", __IT服务端);
            H容器.注入<IB状态_S, B状态_S>(true, false, "", __IT服务端);
            H容器.注入<IBFTP_S, BFTP_S>(true, false, "", __IT服务端);

            var __版本号 = H程序配置.获取字符串("版本号");
            if (string.IsNullOrEmpty(__版本号))
            {
                __版本号 = H调试.查询版本();
            }
            H容器.取出<IB名片_S>().初始化(
                new M名片 { 名称 = "GIS服务器", 描述 = "", 版本号 = __版本号, 版本时间 = H程序配置.获取字符串("版本时间") },
                new List<M参数>
                {
                    new M参数("IP列表", HJSON.序列化(H网络配置.获取IP配置())), 
                    new M参数("操作系统", Environment.OSVersion.ToString()),
                    new M参数("64位系统", Environment.Is64BitOperatingSystem.ToString()),
                    new M参数("登录账号", Environment.UserName),
                });
            H容器.取出<IB状态_S>().初始化(null, DateTime.Now);
            H容器.取出<IBFTP_S>();
            H容器.取出<IB系统_S>().初始化(() =>
            {
                H日志.记录提示("重启");
                H服务管理.重启("GIS服务器", new TimeSpan(0, 1, 0));
            }, () =>
            {
                H日志.记录提示("关闭");
                H服务管理.关闭("GIS服务器", new TimeSpan(0, 1, 0));
            }, () => new List<M版本记录>
            {
                //new M版本记录{ 版本号 = "1.0.0.0", 修改记录 = "xxx", 标签 = new List<string>{ "a", "b"}}, 
                //new M版本记录{ 版本号 = "1.0.1.0", 修改记录 = "yyy", 标签 = new List<string>{ "a1", "b1"}}, 
            });
        }

        public static void 开启()
        {
            //H容器.取出<IBFTP_S>().开启();
        }

        #region 应用示例
        void 设置状态()
        {
            H容器.取出<IB状态_S>().设置属性("类别1", "属性1", () => new M业务概要 { 当前值 = "1", 正常 = true });
            H容器.取出<IB状态_S>().设置属性("类别1", "属性2", () => new M业务概要 { 当前值 = "1", 正常 = false });
        }

        void 发布告警()
        {
            H容器.取出<IB状态_S>().新增告警(new M上报告警
            {
                标识 = "1",
                产生时间 = DateTime.Now,
                来源设备类型 = "来源设备类型",
                来源设备标识 = "来源设备标识",
                重要性 = E重要性.次要,
                类别 = "类别",
                描述 = "描述",
                原因 = "原因",
                解决方案 = "解决方案"
            });

            H容器.取出<IB状态_S>().清除告警(new M上报清除
            {
                标识 = "1",
                来源设备类型 = "来源设备类型",
                来源设备标识 = "来源设备标识",
            });
        }

        #endregion

    }
}
