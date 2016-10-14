using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using GPS;
using GPS地图.View;
using Utility.Windows;
using Utility.WindowsForm;
using Utility.存储;
using Utility.通用;

namespace GPS地图.示例
{
    public partial class F登录 : UserControlK
    {
        private List<M访问记录> _访问记录;

        private F空窗口 _窗口;

        public F登录()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.do连接.Click += do登录_Click;
            this.inIP.SelectedIndexChanged += inIP_SelectedIndexChanged;
            _访问记录 = H序列化.FromJSON字符串<List<M访问记录>>(H程序配置.获取字符串("访问记录"));
            if (_访问记录.Count > 0)
            {
                this.inIP.Items.AddRange(_访问记录.Select(q => string.Format("{0}:{1}", q.IP, q.端口号)).ToArray());
                this.inIP.SelectedIndex = 0;
            }
            this.ParentForm.FormClosing += OnClosing;

            var __参数 = Environment.GetCommandLineArgs();
            if (__参数.Length >= 3)
            {
                this.inIP2.Text = __参数[1];
                this.in端口号.Text = __参数[2];
                this.do连接.PerformClick();
            }

        }

        void inIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.inIP.SelectedIndex > -1)
            {
                var __temp = (string)this.inIP.SelectedItem;
                var __ip = __temp.Split(':')[0];
                var __port = __temp.Split(':')[1];
                this.inIP.SelectedIndex = -1;
                this.inIP2.Text = __ip;
                this.in端口号.Text = __port;
            }
            this.inIP2.Focus();
        }

        void do登录_Click(object sender, EventArgs e)
        {
            var __ip = this.inIP2.Text;
            var __port = this.in端口号.Text;
            var __最后访问 = _访问记录.Find(q => q.IP.ToString() == __ip && q.端口号.ToString() == __port);
            if (__最后访问 == null)
            {
                if (!H检测网络.IsHostAlive(__ip, int.Parse(__port), 2000))
                {
                    new F对话框_确定("连接失败").ShowDialog();
                    return;
                }
                else
                {
                    __最后访问 = new M访问记录 { IP = __ip, 端口号 = int.Parse(__port) };
                }
            }
            else
            {
                _访问记录.Remove(__最后访问);
            }
            _访问记录.Insert(0, __最后访问);
            H程序配置.设置("访问记录", H序列化.ToJSON字符串(_访问记录));
            B入口.已断开 += q => 设置连接状态();
            B入口.已连接 += 设置连接状态;
            B入口.连接(new IPEndPoint(IPAddress.Parse(__ip), int.Parse(__port)), true);
            this.ParentForm.ShowInTaskbar = false;
            this.ParentForm.Visible = false;
            _窗口 = new F空窗口(new F主窗口(), 获取标题())
            {
                允许设置 = true,
                点击设置 = () => new F空窗口(new F配置(), "配置").ShowDialog()
            };
            _窗口.ShowDialog();
            Application.Exit();
        }

        void 设置连接状态()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(设置连接状态));
                return;
            }
            if (_窗口 != null)
            {
                _窗口.标题 = 获取标题();
            }
        }

        private string 获取标题()
        {
            return "地图 " + H调试.查询版本() + (B入口.连接正常 ? "" : " | 已断开");
        }

        void OnClosing(object sender, CancelEventArgs e)
        {
            if (B入口.连接正常)
            {
                B入口.断开();
            }
        }

        private class M访问记录
        {
            public string IP { get; set; }

            public int 端口号 { get; set; }
        }
    }
}
