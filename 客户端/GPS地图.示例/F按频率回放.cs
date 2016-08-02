using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using GPS地图.DTO;
using GPS地图.View;
using GPS;
using Utility.WindowsForm;

namespace GPS地图.示例
{
    public partial class F按频率回放 : UserControl
    {
        private F显示模板 _F显示;

        public F按频率回放()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.in号码.Text = "72021200";
            this.in开始时间.Value = DateTime.Now.Date;
            this.in结束时间.Value = DateTime.Now.Date.AddDays(1);
            this.in号码.KeyDown += in号码范围_KeyDown;
            this.do查询.Click += do查询_Click;
        }

        void in号码范围_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.do查询.PerformClick();
            }
        }

        void do查询_Click(object sender, EventArgs e)
        {
            var __输入 = this.in号码.Text;
            int __号码;
            var __开始时间 = this.in开始时间.Value;
            var __结束时间 = this.in结束时间.Value;
            try
            {
                __号码 = int.Parse(__输入);
            }
            catch (Exception)
            {
                new F对话框_确定("输入错误!").ShowDialog();
                return;
            }
            var __等待窗口 = new F等待() {背景颜色 = Color.White};
            this.out显示号码.创建全覆盖控件(__等待窗口, null);
            __等待窗口.居中();

            List<MGPS> __轨迹;
            try
            {
                __轨迹 = BGPS应用.轨迹.查询轨迹(new List<Tuple<int, DateTime, DateTime>> { new Tuple<int, DateTime, DateTime>(__号码, __开始时间, __结束时间) });
            }
            catch (Exception ex)
            {
                __等待窗口.隐藏();
                new F对话框_确定("查询失败!"+ Environment.NewLine + ex).ShowDialog();
                return;
            }
            var __标识 = __输入;
            var __显示参数 = new M图标显示参数 { 名称 = __标识, 图片 = GPS地图.Properties.Resources.最近更新, 名称一直显示 = true };
            var __回放 = new M回放
            {
                标识 = __标识,
                位置 = __轨迹,
                静态轨迹颜色 = Color.Red,
                显示参数 = __显示参数,
            };
            if (_F显示 != null)
            {
                _F显示.Dispose();
            }

            var __F回放 = new F回放_按频率(__回放) { Dock = DockStyle.Fill };
            __F回放.SizeChanged += (sender1, e1) => __等待窗口.隐藏();

            _F显示 = new F显示模板() { Dock = DockStyle.Fill, 显示统计 = false, 控件 = __F回放, 显示GPS = __F回放.显示GPS, 数据交互 = __F回放.接收GPS };
            this.out显示号码.Controls.Clear();
            this.out显示号码.Controls.Add(_F显示);
            _F显示.设置号码(new Dictionary<string, M图标显示参数>() { { __标识, __显示参数 } });
        }
    }
}
