using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility.WindowsForm;
using Utility.通用;

namespace 管理工具
{
    public partial class F主窗口 : FormK
    {
        public string 标题
        {
            get { return this.u窗体头1.标题; }
            set { this.u窗体头1.标题 = value; this.Text = value; }
        }

        public F主窗口()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.u窗体头1.标题 += " " + H调试.查询版本();
            this.uTab1.添加("状态", new F状态 { Dock = DockStyle.Fill });
            this.uTab1.添加("配置", new F配置 { Dock = DockStyle.Fill });
            this.uTab1.添加("订阅", new F订阅 { Dock = DockStyle.Fill });
            this.uTab1.添加("日志", new F日志 { Dock = DockStyle.Fill });

            this.uTab1.激活("状态");
        }
    }
}
