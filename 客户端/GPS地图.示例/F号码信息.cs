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
    public partial class F号码信息 : UserControlK
    {
        public F号码信息(M个号 __个号)
        {
            InitializeComponent();
            this.out号码.Text = __个号.号码.ToString();
            this.out厂商.Text = __个号.厂商;
            this.out名称.Text = __个号.名称;
            this.out型号.Text = __个号.型号;
            this.out手机.Text = __个号.手机;
            this.out备注.Text = __个号.备注;
            this.out职务.Text = __个号.职务;
            this.out警号.Text = __个号.警号;
            this.out警种.Text = __个号.警种;
            this.out部门.Text = __个号.部门;
            this.do关闭.Click += (sender1, e1) => this.ParentForm.Close();
        }
    }
}
