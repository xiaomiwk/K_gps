using System;
using System.Windows.Forms;
using Utility.Windows;

namespace GIS服务器.服务管理
{
    public partial class F服务_未安装 : UserControl
    {
        private Action _刷新;

        public F服务_未安装(Action __刷新)
        {
            _刷新 = __刷新;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.do服务_安装.Click += do服务_安装_Click;
        }

        void do服务_安装_Click(object sender, EventArgs e)
        {
            H服务管理.安装(Program.服务名, Program.程序名);
            if (_刷新 != null)
            {
                _刷新();
            }
        }

    }
}
