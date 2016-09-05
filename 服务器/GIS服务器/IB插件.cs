using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using DTO;
using DTO.插件;
using Utility.存储;
using Utility.扩展;
using Utility.通用;
using 插件接口;
using 通用访问;
using 通用访问.DTO;

namespace GIS服务器
{
    public interface IB插件
    {
        void 初始化();

        void 开启();

        void 关闭();

        event Action<int, MGPS> GPS上报;

        //List<M插件参数> 查询();
    }

    class B插件 : IB插件
    {
        private IBGPS过滤 _IBGPS过滤 = H容器.取出<IBGPS过滤>();

        private IB日志 _IB日志 = H容器.取出<IB日志>();

        private List<M插件参数> _所有插件 = new List<M插件参数>();

        private List<IPluginGPS输入> _输入插件列表 = new List<IPluginGPS输入>();

        private List<IPluginGPS输出> _输出插件列表 = new List<IPluginGPS输出>();

        public void 初始化()
        {
            var __路径 = Path.Combine(Path.GetDirectoryName(Assembly.GetAssembly(typeof(B插件)).Location), "插件");
            if (!Directory.Exists(__路径))
            {
                H日志.记录错误("插件目录不存在");
                return;
            }
            var __子目录 = Directory.GetDirectories(__路径);
            if (__子目录.Length == 0)
            {
                H日志.记录错误("无任何插件");
                return;
            }
            配置通用访问("插件");

            H日志.记录提示("开始加载插件");
            var __输入插件 = new List<IPluginGPS输入>();
            var __输出插件 = new List<IPluginGPS输出>();
            for (int i = 0; i < __子目录.Length; i++)
            {
                var __目录名 = new DirectoryInfo(__子目录[i]).Name;
                var __入口路径 = Path.Combine(__子目录[i], __目录名 + ".dll");
                if (!File.Exists(__入口路径))
                {
                    continue;
                }
                var __输入实例 = H反射.获取实例<IPluginGPS输入>(__入口路径);
                if (__输入实例 != null)
                {
                    __输入插件.Add(__输入实例);
                }
                var __输出实例 = H反射.获取实例<IPluginGPS输出>(__入口路径);
                if (__输出实例 != null)
                {
                    __输出插件.Add(__输出实例);
                }
            }

            var __插件配置 = HJSON.反序列化<List<M插件配置>>(H程序配置.获取字符串("插件配置"));
            Action<string, string> __记录日志 = (__插件名称, __内容) => _IB日志.增加(new DTO.日志.M日志 { 描述 = __内容, 时间 = DateTime.Now, 类别 = __插件名称 });
            __输入插件.ForEach(q =>
            {
                var __启用 = 查询启用(__插件配置, q.接口名称);
                _所有插件.Add(new M插件参数
                {
                    描述 = q.接口描述,
                    名称 = q.接口名称,
                    启用 = __启用,
                    有管理界面 = q.有管理界面,
                });
                if (__启用)
                {
                    _输入插件列表.Add(q);
                }
                q.记录日志 = __内容 => __记录日志(q.接口名称, __内容);
            });
            __输出插件.ForEach(q =>
            {
                var __启用 = 查询启用(__插件配置, q.接口名称);
                _所有插件.Add(new M插件参数
                {
                    描述 = q.接口描述,
                    名称 = q.接口名称,
                    启用 = __启用,
                    有管理界面 = q.有管理界面,
                });
                if (__启用)
                {
                    _输出插件列表.Add(q);
                }
                q.记录日志 = __内容 => __记录日志(q.接口名称, __内容);
            });
            H日志.记录提示("插件状态", H序列化.ToJSON字符串(_所有插件));

            _输入插件列表.ForEach(__插件 =>
            {
                __插件.GPS上报 += (__号码, __GPS) =>
                {
                    if (!_IBGPS过滤.判断合法(__号码, __GPS))
                    {
                        return;
                    }
                    OnGps上报(__号码, __GPS);
                    _输出插件列表.ForEach(k =>
                    {
                        try
                        {
                            k.接收GPS(__号码, __GPS);
                        }
                        catch (Exception ex)
                        {
                            H调试.记录异常(ex);
                        }
                    });
                };
            });
            _输出插件列表.ForEach(q =>
            {
                q.初始化();
            });

            _输入插件列表.ForEach(q =>
            {
                q.初始化();
            });
        }

        private void 配置通用访问(string __对象名称)
        {
            var __对象 = new M对象(__对象名称, null);
            __对象.添加属性("配置", () => HJSON.序列化(查询状态()), E角色.工程);
            __对象.添加方法("设置", q =>
            {
                var __配置 = HJSON.反序列化<List<M插件配置>>(q["配置"]);
                设置(__配置);
                return null;
            }, E角色.工程, new List<M形参> { new M形参("配置", new M元数据{ 结构 = E数据结构.对象数组, 子成员列表 = new List<M子成员>
            {
                new M子成员("插件名称","string"),new M子成员("启用","bool")
            }}) });
            H容器.取出<IT服务端>().添加对象(__对象名称, () => __对象);
        }

        public void 开启()
        {
            _输出插件列表.ForEach(q =>
            {
                if (_所有插件.Find(k => k.名称 == q.接口名称).启用)
                {
                    q.开启();
                }
            });
            _输入插件列表.ForEach(q =>
            {
                if (_所有插件.Find(k => k.名称 == q.接口名称).启用)
                {
                    q.开启();
                }
            });
        }

        public void 关闭()
        {
            _输出插件列表.ForEach(q =>
            {
                if (_所有插件.Find(k => k.名称 == q.接口名称).启用)
                {
                    q.关闭();
                }
            });
            _输入插件列表.ForEach(q =>
            {
                if (_所有插件.Find(k => k.名称 == q.接口名称).启用)
                {
                    q.关闭();
                }
            });
        }

        public List<M插件参数> 查询状态()
        {
            return new List<M插件参数>(_所有插件);
        }

        public void 设置(List<M插件配置> __配置)
        {
            __配置.ForEach(q =>
            {
                var __匹配 = _所有插件.Find(k => k.名称 == q.名称);
                if (__匹配 != null)
                {
                    __匹配.启用 = q.启用;
                }
            });
            H程序配置.设置("插件配置", HJSON.序列化(__配置, false).Replace('"', '\''));
        }

        public bool 查询启用(List<M插件配置> __配置, string __插件名称)
        {
            var __匹配 = __配置.Find(q => q.名称 == __插件名称);
            if (__匹配 == null)
            {
                return false;
            }
            return __匹配.启用;
        }

        public event Action<int, MGPS> GPS上报;

        protected virtual void OnGps上报(int arg1, MGPS arg2)
        {
            var handler = GPS上报;
            if (handler != null) handler(arg1, arg2);
        }
    }

}
