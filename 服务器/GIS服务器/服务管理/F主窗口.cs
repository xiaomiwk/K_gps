using System;
using System.ServiceProcess;
using System.Windows.Forms;
using Utility.Windows;
using Utility.存储;
using Utility.通用;

namespace GIS服务器.服务管理
{
    public partial class F主窗口 : UserControl
    {
        public F主窗口()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.uTab1.添加("数据库环境", new F数据库() { Dock = DockStyle.Fill });
            this.uTab1.添加("访问入口", new F访问入口() { Dock = DockStyle.Fill });
            this.uTab1.添加("Windows 服务", new F服务() { Dock = DockStyle.Fill });
        }
    }
}
