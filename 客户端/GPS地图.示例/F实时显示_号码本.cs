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

        List<M个号> _所有个号 = new List<M个号>();

        public F实时显示_号码本()
        {
            InitializeComponent();
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

            _F显示号码.显示GPS.单击标识 += 显示GPS_单击标识;

            添加简单圈选(_F显示号码._FGPS.地图);
        }

        void 显示GPS_单击标识(string __标识)
        {
            var __匹配 = _所有个号.Find(q => q.号码.ToString() == __标识);
            if (__匹配 != null)
            {
                new F空窗口(new F号码信息(__匹配), "号码信息") { 允许最大化 = false }.ShowDialog();
            }
        }

        void do清空号码_Click(object sender, EventArgs e)
        {
            _根节点.Nodes.Clear();
            _F显示号码.设置号码(new List<int>());
        }

        void do重新加载_Click(object sender, EventArgs e)
        {
            _根节点.Nodes.Clear();
            if (H路径.验证文件是否存在("部门数据.json", true))
            {
                var __所有部门 = H序列化.FromJSON字符串<List<M部门>>(File.ReadAllText(H路径.获取绝对路径("部门数据.json", true), Encoding.UTF8), false, 50000000);
                __所有部门.ForEach(q => _所有个号.AddRange(q.含嵌套个号列表));
                显示部门(_根节点, __所有部门);
                _根节点.Expand();
            }
            _F显示号码.设置号码(new List<int>());
        }

        void out单位列表_AfterCheck(object sender, TreeViewEventArgs e)
        {
            var __选中 = e.Node.Checked;
            this.out单位列表.AfterCheck -= out单位列表_AfterCheck;
            递归选择(e.Node, __选中);
            this.out单位列表.AfterCheck += out单位列表_AfterCheck;

            var __选择个号 = new List<M个号>();
            获取选择(_根节点, __选择个号);
            _F显示号码.设置号码(__选择个号.Select(q => q.号码).Distinct().ToList());
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

        private void 获取选择(TreeNode __node, List<M个号> __列表)
        {
            if (__node.Checked)
            {
                var __部门 = __node.Tag as M部门;
                if (__部门 != null)
                {
                    __列表.AddRange(__部门.个号列表);
                }
            }
            if (__node.Nodes.Count > 0)
            {
                foreach (TreeNode __node1 in __node.Nodes)
                {
                    获取选择(__node1, __列表);
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
            new F空窗口(new F号码列表(__号码列表), "选中号码").ShowDialog();
        }

    }
}
