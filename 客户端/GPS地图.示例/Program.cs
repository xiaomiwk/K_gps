using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GPS;
using GPS地图.View;
using Utility.WindowsForm;
using Utility.通用;

namespace GPS地图.示例
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new F空窗口(new F主窗口(), "地图应用示例"));
            Application.Run(new F空窗口(new F登录(), "连接到GIS服务器"));
        }
    }
}
