using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using DTO;
using DTO.插件;
using Utility.存储;
using Utility.通用;
using 通用访问;
using 通用访问.DTO;

namespace GIS服务器
{
    public interface IBGPS过滤
    {
        bool 判断合法(string __号码, MGPS __GPS);
    }

    internal class BGPS过滤 : IBGPS过滤
    {
        private IT服务端 _IT服务端 = H容器.取出<IT服务端>();

        private MGPS过滤 _MGPS过滤;

        private List<PointF[]> _边界坐标 = new List<PointF[]>();

        public BGPS过滤()
        {
            _MGPS过滤 = HJSON.反序列化<MGPS过滤>(H程序配置.获取字符串("GPS过滤"));
            var __省 = _MGPS过滤.省;
            var __市 = _MGPS过滤.市;
            设置区域(__省, __市);
            配置通用访问("GPS过滤");
        }

        private void 设置区域(string __省, string __市)
        {
            _边界坐标.Clear();
            var __区域 = H行政区位置.所有.Find(q => q.省 == __省 && (string.IsNullOrEmpty(__市) || __市 == q.市));
            if (__区域 != null)
            {
                foreach (var __kv in __区域.边界坐标)
                {
                    _边界坐标.Add(__kv.Select(q => new PointF {X = (float) q.Item1, Y = (float) q.Item2}).ToArray());
                }
            }
        }

        private void 配置通用访问(string __对象名称)
        {
            var __对象 = new M对象(__对象名称, null);
            __对象.添加属性("启用", () => _MGPS过滤.启用.ToString(), E角色.工程);
            __对象.添加属性("省", () => _MGPS过滤.省, E角色.工程);
            __对象.添加属性("市", () => _MGPS过滤.市, E角色.工程);
            __对象.添加方法("设置", q =>
            {
                _MGPS过滤.启用 = bool.Parse(q["启用"]);
                _MGPS过滤.省 = q["省"];
                _MGPS过滤.市 = q["市"];
                H程序配置.设置("GPS过滤", HJSON.序列化(_MGPS过滤, false).Replace('"', '\''));
                设置区域(_MGPS过滤.省, _MGPS过滤.市);
                return null;
            }, E角色.工程, new List<M形参> { new M形参("启用", "bool"), new M形参("省", "string"), new M形参("市", "string") });
            _IT服务端.添加对象(__对象名称, () => __对象);
        }

        public bool 判断合法(string __号码, MGPS __GPS)
        {
            if (!_MGPS过滤.启用)
            {
                return true;
            }
            if (_边界坐标.Count == 0)
            {
                return true;
            }
            return _边界坐标.Exists(__子区域 => 判断点在多边形内(new PointF { X = (float)__GPS.经度, Y = (float)__GPS.纬度 }, __子区域));
        }

        public static bool 判断点在多边形内(PointF 点, PointF[] 多边形)
        {
            int wn = 0, j = 0; //wn 计数器 j第二个点指针
            for (int i = 0; i < 多边形.Length; i++)
            {//开始循环
                if (i == 多边形.Length - 1)
                    j = 0;//如果 循环到最后一点 第二个指针指向第一点
                else
                    j = j + 1; //如果不是 ，则找下一点


                if (多边形[i].Y <= 点.Y) // 如果多边形的点 小于等于 选定点的 Y 坐标
                {
                    if (多边形[j].Y > 点.Y) // 如果多边形的下一点 大于于 选定点的 Y 坐标
                    {
                        if (isLeft(多边形[i], 多边形[j], 点) > 0)
                        {
                            wn++;
                        }
                    }
                }
                else
                {
                    if (多边形[j].Y <= 点.Y)
                    {
                        if (isLeft(多边形[i], 多边形[j], 点) < 0)
                        {
                            wn--;
                        }
                    }
                }
            }
            if (wn == 0)
            {
                return false;

            }
            else
            {
                return true;
            }

        }

        private static float isLeft(PointF P0, PointF P1, PointF P2)
        {
            float abc = ((P1.X - P0.X) * (P2.Y - P0.Y) - (P2.X - P0.X) * (P1.Y - P0.Y));
            return abc;
        }
    }

}
