using GPS.IBLL.实现;
using GPS地图.IBLL;
using GPS地图.IBLL.实现;
using Utility.通用;

namespace GPS地图
{
    public class H接口注册
    {
        private static bool _已初始化;

        public static void 设置()
        {
            if (!_已初始化)
            {
                _已初始化 = true;
            }
            else
            {
                return;
            }
            H调试.初始化();
            H容器.注入<IB服务器配置, B服务器配置>();
            H容器.注入<IBGPS状态配置, BGPS状态配置>();
            H容器.注入<IB地图路径配置, B地图路径配置>();
            H容器.注入<IB回放_按时间, B回放_按时间>();
            H容器.注入<IB回放_按频率, B回放_按频率>();
        }
    }
}
