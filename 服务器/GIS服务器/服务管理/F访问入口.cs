using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Utility.Windows;
using Utility.WindowsForm;
using Utility.存储;
using Utility.扩展;
using Utility.通用;

namespace GIS服务器.服务管理
{
    public partial class F访问入口 : UserControl
    {

        public F访问入口()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.in端口号.Text = H程序配置.获取字符串("端口号");
            this.in管理工具路径.Text = H程序配置.获取字符串("管理工具路径");
            this.do保存.Click += do保存_Click;
            this.do选择.Click += Do选择_Click;
        }

        private void Do选择_Click(object sender, EventArgs e)
        {
            OpenFileDialog __对话框 = new OpenFileDialog() { InitialDirectory = H路径.程序目录 };
            if (__对话框.ShowDialog() == DialogResult.OK)
            {
                this.in管理工具路径.Text = __对话框.FileName;
            }
        }

        void do保存_Click(object sender, EventArgs e)
        {
            H程序配置.设置(new Dictionary<string, string>
            {
                { "端口号", this.in端口号.Text },
                { "管理工具路径", this.in管理工具路径.Text }
            });
        }

    }
}
