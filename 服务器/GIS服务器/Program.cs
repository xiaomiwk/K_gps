using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;
using GIS服务器.服务管理;
using Utility.WindowsForm;
using Utility.扩展;
using Utility.通用;
using Utility.存储;

namespace GIS服务器
{
    class Program
    {
        public static string 服务名 = "GIS服务器";

        public static string 程序名 = "GIS服务器.exe";

        [STAThread]
        static void Main(string[] args)
        {
            H调试.初始化();
            if (!Environment.UserInteractive)
            {
                var ServicesToRun = new ServiceBase[] { new Service1() };
                ServiceBase.Run(ServicesToRun);
                return;
            }
            //if (System.Diagnostics.Debugger.IsAttached)
            //{
            //    var __B控制器 = new B控制器();
            //    __B控制器.配置();
            //    __B控制器.开启();
            //    Application.Run(new F对话框_确定("程序处于调试模式, 按确定键关闭", "GIS服务器 - 调试模式 " + H调试.查询版本()));
            //    __B控制器.关闭();
            //    return;
            //}
            HUI线程.初始化();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            H容器.注入<ID数据库, D数据库>();
            H容器.注入<IB数据库, B数据库>();
            Application.Run(new F空窗口(new F主窗口(), "GIS服务器 - 运行环境 " + H调试.查询版本()));
        }
    }
}
