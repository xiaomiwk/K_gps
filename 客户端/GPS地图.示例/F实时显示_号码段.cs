using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility.WindowsForm;
using Utility.存储;

namespace GPS地图.示例
{
    public partial class F实时显示_号码段 : UserControl
    {
        private F实时显示 _F显示号码;

        public F实时显示_号码段()
        {
            InitializeComponent();
            _F显示号码 = new F实时显示(){ Dock = DockStyle.Fill };
            this.out显示号码.Controls.Add(_F显示号码);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.in号码范围.Text = "72020200,72020300-72020399";
            this.in号码范围.KeyDown += in号码范围_KeyDown;
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
            var __输入 = this.in号码范围.Text;
            List<int> __列表;
            try
            {
                __列表 = H序列化.字符串转单值列表(__输入);
            }
            catch (Exception)
            {
                new F对话框_确定("输入错误!").ShowDialog();
                return;
            }
            _F显示号码.设置号码(__列表.Select(q => new M个号 {  号码 = q }).ToList());
        }
    }
}
