using System;
using System.Windows.Forms;
using Utility.Windows;
using Utility.WindowsForm;
using Utility.扩展;

namespace GIS服务器.服务管理
{
    public partial class F服务_未启动 : UserControl
    {
        private Action _刷新;

        public F服务_未启动(Action __刷新)
        {
            _刷新 = __刷新;

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.do启动.Click += do启动_Click;
            this.do卸载.Click += do卸载_Click;
        }

        void do卸载_Click(object sender, EventArgs e)
        {
            if (new F对话框_是否("确定要删除吗?").ShowDialog() != DialogResult.Yes)
            {
                return;
            }
            HUI线程.异步执行(this, () =>
            {
                H服务管理.卸载(Program.服务名);
            }, () =>
            {
                if (_刷新 != null)
                {
                    _刷新();
                }
            });
        }

        void do启动_Click(object sender, EventArgs e)
        {
            HUI线程.异步执行(this, () =>
            {
                H服务管理.开启(Program.服务名);
            }, () =>
            {
                if (_刷新 != null)
                {
                    _刷新();
                }
            });
        }
    }
}
