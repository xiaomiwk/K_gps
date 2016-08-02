using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using 通用访问;

namespace GPS
{
    public static class BGPS应用
    {
        private static IT客户端 _IT客户端;

        private static IB订阅 _IB订阅;

        private static IB轨迹 _IB轨迹;

        public static bool 连接正常
        {
            get { return _IT客户端 != null && _IT客户端.连接正常; }
        }

        public static void 连接(IPEndPoint __服务器地址, bool __自动重连 = true)
        {
            if (_IT客户端 == null)
            {
                _IT客户端 = FT通用访问工厂.创建客户端();
                _IT客户端.自动重连 = __自动重连;
                _IT客户端.已连接 += On已连接;
                _IT客户端.已断开 += On已断开;
            }
            _IT客户端.连接(__服务器地址);
        }

        public static void 断开()
        {
            _IT客户端.断开();
        }

        public static IB订阅 订阅
        {
            get { return _IB订阅 ?? (_IB订阅 = (_IT客户端 == null ? (IB订阅)new B订阅_模拟() : new B订阅(_IT客户端))); }
        }

        public static IB轨迹 轨迹
        {
            get { return _IB轨迹 ?? (_IB轨迹 = (_IT客户端 == null ? (IB轨迹)new BGPS数据_模拟() : new BGPS数据(_IT客户端))); }
        }

        /// <summary>
        /// true:主动断开,false:被动断开
        /// </summary>
        public static event Action<bool> 已断开;

        public static event Action 已连接;

        private static void On已断开(bool obj)
        {
            var handler = 已断开;
            if (handler != null) handler(obj);
        }

        private static void On已连接()
        {
            var handler = 已连接;
            if (handler != null) handler();
        }
    }
}
