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
    public partial class F号码列表 : UserControlK
    {
        public F号码列表(List<M个号> __号码列表)
        {
            InitializeComponent();
            this.out人数共计.Text = __号码列表.Count.ToString();
            this.out号码列表.DataSource = __号码列表;
            this.do关闭.Click += (sender1, e1) => this.ParentForm.Close();
            this.out号码列表.CellMouseDoubleClick += Out号码列表_CellMouseDoubleClick;
        }

        private void Out号码列表_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var __个号 = this.out号码列表.Rows[e.RowIndex].DataBoundItem as M个号;
            if (__个号 != null)
            {
                new F空窗口(new F号码信息(__个号), "号码信息").ShowDialog();
            }
        }
    }
}
