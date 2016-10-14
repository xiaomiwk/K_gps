using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;

namespace 插件接口
{
    public interface IPluginGPS输出
    {
        void 初始化();

        void 开启();

        void 关闭();

        string 接口名称 { get; }

        string 接口描述 { get; }

        void 接收GPS(string 号码, MGPS gps);

        void 接收状态(string 号码, string 状态, string 描述);

        bool 有管理界面 { get; }

        bool 运行中 { get; }

        Action<string> 记录日志 { get; set; }
    }
}
