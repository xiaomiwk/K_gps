using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO.插件;
using Utility.WindowsForm;
using Utility.存储;
using Utility.扩展;
using Utility.通用;
using 通用访问;

namespace 管理工具
{
    public partial class F配置 : UserControl
    {
        private IT客户端 _IT客户端 = H容器.取出<IT客户端>();

        public F配置()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.in保留.Items.AddRange(new object[] { 200, 400});
            this.out互联插件.CellContentClick += out互联插件_CellContentClick;
            this.do保存.Click += do保存_Click;
            this.do刷新.Click += do刷新_Click;
            this.do检测连接.Click += do检测连接_Click;

            this.do刷新.PerformClick();
        }

        void do检测连接_Click(object sender, EventArgs e)
        {
            var __账号 = this.in账号.Text;
            var __密码 = this.in密码.Text;
            var __数据源 = this.in数据源.Text;
            var __结果 = "";
            HUI线程.异步执行(this, () =>
            {
                __结果 = _IT客户端.执行方法("数据库", "检测连接", new Dictionary<string, string> { { "账号", __账号 }, { "密码", __密码 }, { "数据源", __数据源 } });

            }, () =>
            {
                new F对话框_确定(__结果).ShowDialog();
            });
        }

        void do刷新_Click(object sender, EventArgs e)
        {
            this.in账号.Text = _IT客户端.查询属性值("数据库", "账号");
            this.in密码.Text = _IT客户端.查询属性值("数据库", "密码");
            this.in数据源.Text = _IT客户端.查询属性值("数据库", "数据源");
            try
            {
                this.in保留.SelectedItem = int.Parse(_IT客户端.查询属性值("数据库", "保留天数"));
            }
            catch (Exception)
            {
                this.in保留.SelectedIndex = 0;
            }

            this.inGPS过滤_省.SelectedIndexChanged += in省_SelectedIndexChanged;
            List<string> __所有省 = H行政区位置.所有.Select(q => q.省).Distinct().ToList();
            this.inGPS过滤_省.DataSource = __所有省;
            this.inGPS过滤_开启.Checked = bool.Parse(_IT客户端.查询属性值("GPS过滤", "启用"));
            this.inGPS过滤_省.SelectedItem = _IT客户端.查询属性值("GPS过滤", "省");
            this.inGPS过滤_市.SelectedItem = _IT客户端.查询属性值("GPS过滤", "市");

            this.out互联插件.Rows.Clear();
            var __插件列表 = HJSON.反序列化<List<M插件参数>>(_IT客户端.查询属性值("插件", "配置"));
            __插件列表.ForEach(q =>
            {
                var __行 = this.out互联插件.Rows.Add(q.启用, q.名称, q.目录, q.描述, q.有管理界面 ? "管理" : "");
                this.out互联插件.Rows[__行].Tag = q;
            });

        }

        private void in省_SelectedIndexChanged(object sender, EventArgs e)
        {
            var __省名称 = (string)inGPS过滤_省.SelectedValue;
            //var __省 = H行政区位置.所有.Find(q => q.省 == __省名称 && (q.市 == "" || q.省 == q.市));
            IEnumerable<string> __省内市 = H行政区位置.所有.Where(q => q.省 == __省名称).Select(q => q.市).Distinct();
            inGPS过滤_市.DataSource = __省内市.ToList();
        }


        void do保存_Click(object sender, EventArgs e)
        {
            var __账号 = this.in账号.Text;
            var __密码 = this.in密码.Text;
            var __数据源 = this.in数据源.Text;
            var __保留天数 = this.in保留.Text;
            var __GPS过滤_开启 = this.inGPS过滤_开启.Checked;
            var __GPS过滤_省 = this.inGPS过滤_省.Text;
            var __GPS过滤_市 = this.inGPS过滤_市.Text;
            var __插件配置 = new List<M插件配置>();
            for (int i = 0; i < this.out互联插件.Rows.Count; i++)
            {
                __插件配置.Add(new M插件配置
                {
                    目录 = this.out互联插件.Rows[i].Cells[1].Value.ToString(),
                    启用 = (bool)this.out互联插件.Rows[i].Cells[0].Value
                });
            }
            _IT客户端.执行方法("数据库", "设置连接参数", new Dictionary<string, string> { { "账号", __账号 }, { "密码", __密码 }, { "数据源", __数据源 } });
            _IT客户端.执行方法("数据库", "设置保留天数", new Dictionary<string, string> {{"天数",__保留天数}});
            _IT客户端.执行方法("GPS过滤", "设置", new Dictionary<string, string> {{"启用",__GPS过滤_开启.ToString()},{"省",__GPS过滤_省},{"市",__GPS过滤_市}});
            _IT客户端.执行方法("插件", "设置", new Dictionary<string, string> {{"配置",HJSON.序列化(__插件配置)}});
        }

        void out互联插件_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == this.out互联插件.ColumnCount - 1)
            {
                var __绑定 = this.out互联插件.Rows[e.RowIndex].Tag as M插件参数;
                if (!__绑定.有管理界面)
                {
                    return;
                }
                var __配置程序路径 = string.Format("插件\\{0}.管理工具\\管理工具.exe", __绑定.名称);
                var __绝对路径 = H路径.获取绝对路径(__配置程序路径, true);
                if (!H路径.验证文件是否存在(__绝对路径))
                {
                    new F对话框_确定(__绝对路径 + "不存在, 无法配置").ShowDialog();
                    return;
                }
                var __服务器地址 = _IT客户端.设备地址;
                var __日志目录 = H路径.获取绝对路径("日志");
                Process.Start(__绝对路径, string.Format("{0} {1} {2} {3}", __服务器地址.Address, __服务器地址.Port, __日志目录, __绑定.名称));
            }
        }
    }
}
