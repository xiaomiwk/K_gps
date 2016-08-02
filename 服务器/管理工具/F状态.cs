using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility.WindowsForm;
using Utility.通用;
using 通用命令.名片;
using 通用命令.状态;
using 通用访问;

namespace 管理工具
{
    public partial class F状态 : UserControl
    {
        private IT客户端 _IT客户端 = H容器.取出<IT客户端>();

        private IB状态_C _IB状态;

        private IB名片_C _IB名片;

        private Dictionary<string, int> _告警缓存 = new Dictionary<string, int>();

        public F状态()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.out告警列表.CellDoubleClick += out告警列表_CellDoubleClick;
            this.out告警列表.RowsAdded += out告警列表_RowsAdded;
            this.out状态列表.RowsAdded += out状态列表_RowsAdded;

            _IB名片 = new B名片_C(_IT客户端);
            _IB状态 = new B状态_C(_IT客户端);

            刷新();

            _IB状态.健康状态变化 += q => 刷新(); 
            _IB状态.新增了告警 += _IB状态_新增了告警;
            _IB状态.清除了告警 += _IB状态_清除了告警;

            this.do刷新.Click += (sender1, e1) => 刷新();
            this.outGIS服务器版本.Text = _IB名片.名片.版本号;
        }

        void _IB状态_清除了告警(M上报清除 __清除)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<M上报清除>(_IB状态_清除了告警), __清除);
                return;
            }

            if (_告警缓存.ContainsKey(__清除.标识))
            {
                this.out告警列表.Rows.RemoveAt(_告警缓存[__清除.标识]);
            }
        }

        void _IB状态_新增了告警(M上报告警 __告警)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<M上报告警>(_IB状态_新增了告警), __告警);
                return;
            }
            if (_告警缓存.ContainsKey(__告警.标识))
            {
                this.out告警列表.Rows.RemoveAt(_告警缓存[__告警.标识]);
            }
            _告警缓存[__告警.标识] = this.out告警列表.Rows.Add(__告警.产生时间.ToString(), __告警.重要性.ToString(), __告警.类别, __告警.描述, __告警.解决方案);
        }

        private void 刷新()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(刷新));
                return;
            }
            var __概要状态 = _IB状态.查询概要状态();
            var __状态列表 = _IB状态.查询业务概要();
            var __告警列表 = _IB状态.查询未清除告警(null);
            this.out状态列表.Rows.Clear();
            __状态列表.ForEach(__状态 => this.out状态列表.Rows.Add(__状态.类别, __状态.属性, __状态.当前值, __状态.正常 ? "是" : "否", __状态.正常范围, __状态.单位, __状态.描述));
            this.out告警列表.Rows.Clear();
            _告警缓存.Clear();
            __告警列表.ForEach(__告警 => _告警缓存[__告警.标识] = this.out告警列表.Rows.Add(__告警.产生时间.ToString(), __告警.重要性.ToString(), __告警.类别, __告警.描述, __告警.解决方案));
            this.out启动时间.Text = __概要状态.启动时间.ToString();
        }

        void out告警列表_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var __级别 = this.out告警列表.Rows[e.RowIndex].Cells[1].Value.ToString();
            switch (__级别)
            {
                case "紧急":
                    this.out告警列表.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.Red;
                    break;
                case "重要":
                    this.out告警列表.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.Orange;
                    break;
                //case "次要":
                //    this.out告警列表.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.Red;
                //    break;
            }
        }

        void out状态列表_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var __正常 = this.out状态列表.Rows[e.RowIndex].Cells[3].Value.ToString();
            this.out状态列表.Rows[e.RowIndex].Cells[3].Style.BackColor = (__正常 == "否" ? Color.Red : Color.White);
        }

        void out告警列表_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 3 && e.ColumnIndex != 4)
            {
                return;
            }
            if (e.RowIndex >= 0)
            {
                var __值 = this.out告警列表.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (__值 != null && __值.ToString().Length > 20)
                {
                    new F对话框_确定(this.out告警列表.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), "详细") { Width = 500, Height = 300 }.ShowDialog();
                }
            }
        }

    }
}
