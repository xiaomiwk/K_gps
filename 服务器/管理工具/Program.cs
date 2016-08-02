using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utility.WindowsForm;
using Utility.扩展;
using Utility.通用;

namespace 管理工具
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            H调试.初始化();
            HUI线程.初始化();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new F空窗口(new F登录(), "连接到GIS服务器"));
            //Application.Run(new F主窗口());
        }
    }
}
