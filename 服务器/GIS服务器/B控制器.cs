using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using INET;
using Utility.通用;
using 通用访问;
using Utility.存储;

namespace GIS服务器
{
    class B控制器
    {
        private IT服务端 _IT服务端;

        public void 配置()
        {
            var __调试编解码 = H程序配置.获取Bool值("调试编解码");
            H日志输出.设置(q =>
            {
                if (q.等级 < TraceEventType.Information || __调试编解码)
                {
                    if (q.异常 != null)
                    {
                        H日志.记录异常(q.异常, q.概要, q.详细, q.等级, q.方法, q.文件, q.行号);
                    }
                    else
                    {
                        H日志.记录(q.概要, q.等级, q.详细, q.方法, q.文件, q.行号);
                    }
                }
            }, TraceEventType.Verbose);
            _IT服务端 = FT通用访问工厂.创建服务端();
            _IT服务端.端口 = H程序配置.获取Int32值("端口号");
            H容器.注入(_IT服务端, false);
            B通用命令.配置(_IT服务端);

            H容器.注入<IB数据库, B数据库>();
            H容器.注入<IB插件, B插件>();
            H容器.注入<IB订阅, B订阅>();
            H容器.注入<IBGPS数据, BGPS数据>();
            if (H程序配置.获取Bool值("内存数据库"))
            {
                H容器.注入<ID数据库, D数据库_内存>();
                H容器.注入<IDGPS数据, DGPS数据_内存>(__拦截: false);
                H容器.注入<IB日志, B日志_内存>(__拦截: false);
            }
            else
            {
                H容器.注入<ID数据库, D数据库>();
                H容器.注入<IDGPS数据, DGPS数据>(__拦截: false);
                H容器.注入<IB日志, B日志_内存>(__拦截: false); //未保存到数据库
            }
            H容器.注入<IBGPS过滤, BGPS过滤>(__拦截: false);

            H容器.取出<IB数据库>().初始化();
            H容器.取出<IB订阅>().初始化();
            H容器.取出<IB插件>().初始化();
            H容器.取出<IBGPS数据>().初始化();
            H容器.取出<IB日志>().初始化();
        }

        public void 开启()
        {
            HB日志.记录("系统", "开启");
            B通用命令.开启();
            H容器.取出<IB插件>().开启();

            _IT服务端.开启();
        }

        public void 关闭()
        {
            HB日志.记录("系统", "关闭");
            H容器.取出<IB插件>().关闭();
            _IT服务端.关闭();
        }
    }
}
