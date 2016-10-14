using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;

namespace 插件接口
{
    public interface IPluginGPS输入
    {
        void 初始化();

        void 开启();

        void 关闭();

        string 接口名称 { get; }

        string 接口描述 { get; }

        /// <summary>
        /// string 号码, MGPS 位置
        /// </summary>
        event Action<string, MGPS> GPS上报;

        /// <summary>
        /// string 号码, string 状态, string 描述
        /// </summary>
        event Action<string, string, string> 状态上报;

        bool 有管理界面 { get; }

        bool 运行中 { get; }

        Action<string> 记录日志 { get; set; }
    }
}
