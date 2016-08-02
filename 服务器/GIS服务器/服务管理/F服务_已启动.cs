using System;
using System.Diagnostics;
using System.Windows.Forms;
using Utility.Windows;
using Utility.WindowsForm;
using Utility.存储;
using Utility.扩展;

namespace GIS服务器.服务管理
{
    public partial class F服务_已启动 : UserControl
    {
        private Action _刷新;

        public F服务_已启动(Action __刷新)
        {
            _刷新 = __刷新;

            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.do重启.Click += do重启_Click;
            this.do关闭.Click += do关闭_Click;
            this.do管理工具.Click += Do管理工具_Click;
        }

        private void Do管理工具_Click(object sender, EventArgs e)
        {
            var __路径 = H程序配置.获取字符串("管理工具路径");
            var __绝对路径 = H路径.获取绝对路径(__路径);
            if (!H路径.验证文件是否存在(__绝对路径))
            {
                new F对话框_确定("管理工具不存在").ShowDialog();
                return;
            }
            var __端口号 = H程序配置.获取字符串("端口号");
            Process.Start(__绝对路径, "127.0.0.1 " + __端口号);
        }

        void do重启_Click(object sender, EventArgs e)
        {
            if (new F对话框_是否("确定要重启吗?").ShowDialog() != DialogResult.Yes)
            {
                return;
            }
            HUI线程.异步执行(this, () =>
            {
                H服务管理.重启(Program.服务名);
            }, () =>
            {
                _刷新?.Invoke();
            });
        }

        void do关闭_Click(object sender, EventArgs e)
        {
            if (new F对话框_是否("确定要关闭吗?").ShowDialog() != DialogResult.Yes)
            {
                return;
            }
            HUI线程.异步执行(this, () =>
            {
                H服务管理.关闭(Program.服务名);
            }, () =>
            {
                _刷新?.Invoke();
            });
        }

    }
}
