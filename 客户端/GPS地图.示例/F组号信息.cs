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
    public partial class F组号信息 : UserControlK
    {
        M组号 _组号;
        public F组号信息(M组号 __号码)
        {
            _组号 = __号码;
            InitializeComponent();
            this.out号码.Text = __号码.号码.ToString();
            this.out名称.Text = __号码.名称;
            //this.out厂商.Text = __个号.厂商;
            //this.out型号.Text = __个号.型号;
            //this.out手机.Text = __个号.手机;
            //this.out备注.Text = __个号.备注;
            //this.out职务.Text = __个号.职务;
            //this.out警号.Text = __个号.警号;
            //this.out警种.Text = __个号.警种;
            //this.out部门.Text = __个号.部门;

            this.dataGridViewK1.DataSource = __号码.参数.Select(q => new { 名称 = q.Key, 值 = q.Value }).ToList();
            this.do发送短信.Click += Do发送短信_Click;
            this.do呼叫.Click += Do呼叫_Click;
            this.in半透明.CheckedChanged += In半透明_CheckedChanged;
            this.in置顶.CheckedChanged += In置顶_CheckedChanged;
        }

        private void Do呼叫_Click(object sender, EventArgs e)
        {
            H外部服务.呼叫(_组号.号码.ToString(), true);
        }

        private void Do发送短信_Click(object sender, EventArgs e)
        {
            new F空窗口(new F发送短信(_组号.号码.ToString(), true), "发送短信").ShowDialog();
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
    }
}
