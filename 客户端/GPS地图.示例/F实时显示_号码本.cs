using GPS地图.示例.圈选;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility.WindowsForm;
using Utility.存储;
using 显示地图;

namespace GPS地图.示例
{
    public partial class F实时显示_号码本 : UserControl
    {
        private F实时显示 _F显示号码;

        private TreeNode _根节点;

        Func<List<M部门>> _刷新部门;

        List<M个号> _所有个号 = new List<M个号>();

        List<M组号> _所有组号 = new List<M组号>();

        public F实时显示_号码本(Func<List<M部门>> __刷新部门)
        {
            InitializeComponent();
            _刷新部门 = __刷新部门;
            _F显示号码 = new F实时显示() { Dock = DockStyle.Fill };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _根节点 = this.out单位列表.Nodes[0];
            _根节点.Nodes.Clear();

            this.out显示号码.Controls.Add(_F显示号码);

            this.out单位列表.AfterCheck += out单位列表_AfterCheck;
            this.do重新加载.Click += do重新加载_Click;
            this.do清空号码.Click += do清空号码_Click;

            this.do重新加载.PerformClick();

            this.do折叠.Click += (sender1, e1) => this.splitContainer1.Panel1Collapsed = !this.splitContainer1.Panel1Collapsed;
            _F显示号码.out个号列表.CellMouseDoubleClick += Out个号列表_CellMouseDoubleClick;
            _F显示号码.out组号列表.CellMouseDoubleClick += Out组号列表_CellMouseDoubleClick;
            _F显示号码.out组号列表.CellMouseClick += Out组号列表_CellMouseClick;
            _F显示号码.显示GPS.单击标识 += 显示GPS_单击标识;

            if (H程序配置.获取Bool值("圈选"))
            {
                添加简单圈选(_F显示号码._FGPS.地图);
            }
        }

        void 显示GPS_单击标识(string __标识)
        {
            var __个号 = _所有个号.Find(q => q.号码.ToString() == __标识);
            if (__个号 != null)
            {
                F个号信息.显示(__个号, _F显示号码);
            }
        }

        void do清空号码_Click(object sender, EventArgs e)
        {
            _根节点.Nodes.Clear();
            _F显示号码.设置号码(new List<M个号>());
        }

        void do重新加载_Click(object sender, EventArgs e)
        {
            _根节点.Nodes.Clear();
            if (_刷新部门 != null)
            {
                var __所有部门 = _刷新部门();
                _所有个号.Clear();
                __所有部门.ForEach(q => _所有个号.AddRange(q.含嵌套个号列表));
                _所有组号.Clear();
                __所有部门.ForEach(q => _所有组号.AddRange(q.含嵌套组号列表));
                显示部门(_根节点, __所有部门);
                _根节点.Expand();
            }
            _F显示号码.设置号码(new List<M个号>());
        }

        void out单位列表_AfterCheck(object sender, TreeViewEventArgs e)
        {
            var __选中 = e.Node.Checked;
            this.out单位列表.AfterCheck -= out单位列表_AfterCheck;
            递归选择(e.Node, __选中);
            this.out单位列表.AfterCheck += out单位列表_AfterCheck;

            var __选择个号 = new List<M个号>();
            var __选择组号 = new List<M组号>();
            获取选择(_根节点, __选择个号, __选择组号);
            _F显示号码.设置号码(__选择个号, __选择组号);
        }

        private void 递归选择(TreeNode __node, bool __选中)
        {
            __node.Checked = __选中;
            if (__node.Nodes.Count > 0)
            {
                foreach (TreeNode __node1 in __node.Nodes)
                {
                    递归选择(__node1, __选中);
                }
            }
        }

        private void 获取选择(TreeNode __node, List<M个号> __个号列表, List<M组号> __组号列表)
        {
            if (__node.Checked)
            {
                var __部门 = __node.Tag as M部门;
                if (__部门 != null)
                {
                    __个号列表.AddRange(__部门.个号列表);
                    __组号列表.AddRange(__部门.组号列表);
                }
            }
            if (__node.Nodes.Count > 0)
            {
                foreach (TreeNode __node1 in __node.Nodes)
                {
                    获取选择(__node1, __个号列表, __组号列表);
                }
            }
        }

        private void 显示部门(TreeNode __node, List<M部门> __部门列表)
        {
            if (__部门列表 == null || __部门列表.Count == 0)
            {
                return;
            }
            __部门列表.ForEach(__部门 =>
            {
                var __node1 = new TreeNode(string.Format("{0}({1})", __部门.名称, __部门.含嵌套个号列表.Count)) { Tag = __部门 };
                __node.Nodes.Add(__node1);
                显示部门(__node1, __部门.下属部门);
            });
        }

        private void 添加简单圈选(F地图 __地图)
        {
            var __圈选 = new F圈选_圆形(__地图);
            __圈选.圈选结束 += 处理圆形圈选;
            var __按钮 = new U按钮
            {
                Width = 70,
                Top = 30,
                Left = _F显示号码.out地图容器.Width - 116,
                Anchor = AnchorStyles.Right | AnchorStyles.Top,
                Text = "开始圈选"
            };
            __按钮.Click += (sender1, e1) =>
            {
                if (__按钮.Text == "开始圈选")
                {
                    __按钮.Text = "结束圈选";
                    __圈选.开始();
                }
                else
                {
                    __按钮.Text = "开始圈选";
                    __圈选.结束();
                    __圈选.清除();
                }
            };
            _F显示号码.out地图容器.Controls.Add(__按钮);
            __按钮.BringToFront();
        }

        void 处理圆形圈选(M经纬度 __圆心, int __半径)
        {
            var __所有图标 = _F显示号码._FGPS.查询所有图标();
            if (__所有图标.Count == 0)
            {
                return;
            }
            var __号码列表 = new List<M个号>();
            __所有图标.ForEach(q =>
            {
                if (H地图算法.判断点在圆形内(q.位置.转M经纬度(), __圆心, __半径))
                {
                    var __标识 = (string)q.业务标识;
                    var __匹配 = _所有个号.Find(k => k.号码.ToString() == __标识);
                    if (__匹配 != null)
                    {
                        __号码列表.Add(__匹配);
                    }
                }
            });
            new F空窗口(new F个号列表(__号码列表, _F显示号码), "选中号码").ShowDialog();
        }

        private void Out个号列表_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != 0 || e.RowIndex < 0)
            {
                return;
            }
            var __标识 = (((DataGridView)sender).Rows[e.RowIndex].Tag as M个号).号码.ToString();
            var __个号 = _所有个号.Find(q => q.号码.ToString() == __标识);
            if (__个号 == null)
            {
                return;
            }
            F个号信息.显示(__个号, _F显示号码);
        }

        private void Out组号列表_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != 0 || e.RowIndex < 0)
            {
                return;
            }
            var __标识 = (((DataGridView)sender).Rows[e.RowIndex].Tag as M组号).号码;
            var __组号 = _所有组号.Find(q => q.号码 == __标识);
            if (__组号 == null)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                new F空窗口(new F组号信息(__组号), "组号: " + (string.IsNullOrEmpty(__组号.名称) ? __组号.号码.ToString() : __组号.名称)) { 允许最大化 = false }.Show();
            }
        }

        private void Out组号列表_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.RowIndex < 0)
            {
                return;
            }
            var __标识 = (((DataGridView)sender).Rows[e.RowIndex].Tag as M组号).号码;
            var __组号 = _所有组号.Find(q => q.号码 == __标识);
            if (__组号 == null)
            {
                return;
            }
            if (e.ColumnIndex == 1)
            {
                //呼叫
                H外部服务.呼叫(__组号.号码.ToString(), true);
            }
        }
    }
}
