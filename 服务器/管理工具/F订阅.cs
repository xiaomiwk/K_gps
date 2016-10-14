using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using DTO;
using DTO.订阅;
using Utility.WindowsForm;
using Utility.通用;
using 通用访问;

namespace 管理工具
{
    public partial class F订阅 : UserControl
    {
        private IT客户端 _IT客户端 = H容器.取出<IT客户端>();

        public F订阅()
        {
            InitializeComponent();

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.out客户端列表.CellContentClick += out客户端列表_CellContentClick;
            this.do查询.Click += do查询_Click;
            this.do查询.PerformClick();
        }

        void do查询_Click(object sender, EventArgs e)
        {
            this.out客户端数量.Text = _IT客户端.查询属性值("订阅", "客户端总数");
            this.out号码数量.Text = _IT客户端.查询属性值("订阅", "号码总数");

            this.out客户端列表.Rows.Clear();
            var __客户端概要列表 = HJSON.反序列化<List<M客户端概要>>(_IT客户端.执行方法("订阅", "查询客户端概要", null));
            for (int i = 0; i < __客户端概要列表.Count; i++)
            {
                this.out客户端列表.Rows.Add(string.Format("{0}:{1}", __客户端概要列表[i].IP, __客户端概要列表[i].端口号), __客户端概要列表[i].订阅总数, __客户端概要列表[i].开始时间, "详细");
            }

            this.out号码列表.Rows.Clear();
            var __号码段列表 = HJSON.反序列化<List<string>>(_IT客户端.执行方法("订阅", "查询所有号码", null));
            for (int i = 0; i < __号码段列表.Count; i++)
            {
                this.out号码列表.Rows.Add(new object[] { __号码段列表[i] });
            }
        }

        void out客户端列表_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.out客户端列表.ColumnCount - 1 && e.RowIndex >= 0)
            {
                var __地址 = this.out客户端列表.Rows[e.RowIndex].Cells[0].Value.ToString();
                var __号码段列表 = HJSON.反序列化<List<string>>(_IT客户端.执行方法("订阅", "查询客户端明细",
                    new Dictionary<string, string> { { "IP", __地址.Split(':')[0] }, { "端口号", __地址.Split(':')[1] } }));
                new F空窗口(new F订阅_详细(__号码段列表), "订阅明细").ShowDialog(this.ParentForm);
            }
        }
    }
}
