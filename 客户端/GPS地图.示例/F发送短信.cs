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
    public partial class F发送短信 : UserControlK
    {
        public F发送短信(string __号码, bool __组号)
        {
            InitializeComponent();
            this.in号码.Text = __号码;
            this.in组号.Checked = __组号;
            this.in组号.Enabled = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.do发送.Click += Do发送_Click;
        }

        private void Do发送_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.in号码.Text.Trim()))
            {
                new F对话框_确定("请输入号码").ShowDialog();
                this.in号码.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.in内容.Text.Trim()))
            {
                new F对话框_确定("请输入内容").ShowDialog();
                this.in内容.Focus();
                return;
            }
            H外部服务.发短信(this.in号码.Text, this.in组号.Checked, this.in内容.Text.Trim());
            this.ParentForm.Close();
        }
    }
}
