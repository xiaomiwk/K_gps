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
    public partial class F个号列表 : UserControlK
    {
        F显示模板 _显示;

        public F个号列表(List<M个号> __号码列表, F显示模板 __显示)
        {
            InitializeComponent();
            _显示 = __显示;
            this.out人数共计.Text = __号码列表.Count.ToString();
            //this.out号码列表.DataSource = __号码列表.Select(q => new { q.号码, q.名称, 参数 = 获取描述(q.参数) }).ToList();
            this.out号码列表.DataSource = __号码列表;
            this.do关闭.Click += (sender1, e1) => this.ParentForm.Close();
            this.out号码列表.CellMouseDoubleClick += Out号码列表_CellMouseDoubleClick;
            this.out号码列表.CellFormatting += Out号码列表_CellFormatting;
            
        }

        private void Out号码列表_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 2) {
                return;
            }
            var __个号 = this.out号码列表.Rows[e.RowIndex].DataBoundItem as M个号;
            if (__个号 != null)
            {
                e.Value = 获取描述(__个号.参数);
            }
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
                F个号信息.显示(__个号, _显示);
            }
        }

        string 获取描述(Dictionary<string, string> __参数)
        {
            if (__参数 == null || __参数.Count == 0)
            {
                return string.Empty;
            }
            var __sb = new StringBuilder();
            foreach (var __kv in __参数)
            {
                __sb.AppendFormat("{0}:{1}, ", __kv.Key, __kv.Value);
            }
            return __sb.ToString();
        }
    }
}
