using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility.WindowsForm;

namespace GPS地图.示例
{
    public partial class F个号信息 : UserControlK
    {
        F显示模板 _显示;

        M个号 _个号;

        public F个号信息(M个号 __个号, F显示模板 __显示)
        {
            InitializeComponent();
            _显示 = __显示;
            _个号 = __个号;
        }

        public static void 显示(M个号 __个号, F显示模板 __显示)
        {
            new F空窗口(new F个号信息(__个号, __显示), "个号: " + (string.IsNullOrEmpty(__个号.名称) ? __个号.号码.ToString() : __个号.名称)).Show();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.out号码.Text = _个号.号码.ToString();
            this.out名称.Text = _个号.名称;

            this.dataGridViewK1.DataSource = _个号.参数.Select(q => new { 名称 = q.Key, 值 = q.Value }).ToList();
            this.do发送短信.Click += Do发送短信_Click;
            this.do呼叫.Click += Do呼叫_Click;
            this.do定位.Click += Do定位_Click;
            this.in半透明.CheckedChanged += In半透明_CheckedChanged;
            this.in置顶.CheckedChanged += In置顶_CheckedChanged;
        }

        private void In置顶_CheckedChanged(object sender, EventArgs e)
        {
            if (this.in置顶.Checked)
            {
                this.ParentForm.TopMost = true;
            }
            else
            {
                this.ParentForm.TopMost = false;
            }
        }

        private void In半透明_CheckedChanged(object sender, EventArgs e)
        {
            if (this.in半透明.Checked)
            {
                this.ParentForm.Opacity = 0.7d;
            }
            else
            {
                this.ParentForm.Opacity = 1d;
            }
        }

        private void Do呼叫_Click(object sender, EventArgs e)
        {
            H外部服务.呼叫(_个号.号码.ToString(), false);
        }

        private void Do发送短信_Click(object sender, EventArgs e)
        {
            new F空窗口(new F发送短信(_个号.号码.ToString(), false), "发送短信").ShowDialog();
        }

        private void Do定位_Click(object sender, EventArgs e)
        {
            H外部服务.立刻定位(_个号.号码.ToString());
            System.Threading.Thread.Sleep(500);
            _显示.显示GPS.定位(new List<string> { _个号.号码.ToString() });
        }
    }
}
