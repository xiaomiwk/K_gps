using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO.日志;
using Utility.WindowsForm;
using Utility.通用;
using 通用访问;

namespace 管理工具
{
    public partial class F日志 : UserControl
    {
        private IT客户端 _IT客户端 = H容器.取出<IT客户端>();

        public F日志()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.in结束时间.Value = DateTime.Now.Date.AddDays(1);
            this.in起始时间.Value = DateTime.Now.Date;
            this.in类别.Items.AddRange(new object[] {"系统","订阅","优能PDT"});

            this.out日志列表.CellDoubleClick += out日志列表_CellDoubleClick;
            this.u分页1.跳转 += __页数 => do查询.PerformClick();
            this.do查询.Click += do查询_Click;
        }

        void do查询_Click(object sender, EventArgs e)
        {
            var __条件 = new M查询条件 { 类别 = this.in类别.Text, 每页数量 = this.u分页1.每页条数, 开始时间 = this.in起始时间.Value, 结束时间 = this.in结束时间.Value, 页码 = this.u分页1.当前页码 };
            var __返回值 = _IT客户端.执行方法("日志", "查询", new Dictionary<string, string> { { "条件", HJSON.序列化(__条件) } });
            var __结果 = HJSON.反序列化<M查询结果>(__返回值);
            this.u分页1.总条数 = __结果.总数;
            this.out日志列表.Rows.Clear();
            for (int i = 0; i < __结果.列表.Count; i++)
            {
                this.out日志列表.Rows.Add(__结果.列表[i].时间, __结果.列表[i].类别, __结果.列表[i].描述, __结果.列表[i].账号);
            }
        }

        void out日志列表_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                var __值 = this.out日志列表.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (__值 != null && __值.ToString().Length > 20)
                {
                    new F对话框_确定(this.out日志列表.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), "详细") { Width = 500, Height = 300 }.ShowDialog();
                }
            }
        }
    }
}
