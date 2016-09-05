using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using INET;
using Utility.Windows;
using Utility.WindowsForm;
using Utility.存储;
using Utility.通用;
using 通用访问;

namespace 管理工具
{
    public partial class F登录 : UserControlK
    {
        private List<M访问记录> _访问记录;

        private F空窗口 _F主窗口;

        private IT客户端 _IT客户端;

        public F登录()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.do连接.Click += do连接_Click;
            this.inIP.SelectedIndexChanged += inIP_SelectedIndexChanged;
            _访问记录 = H序列化.FromJSON字符串<List<M访问记录>>(H程序配置.获取字符串("访问记录"));
            if (_访问记录.Count > 0)
            {
                this.inIP.Items.AddRange(_访问记录.Select(q => string.Format("{0}:{1}", q.IP, q.端口号)).ToArray());
                this.inIP.SelectedIndex = 0;
            }
            this.ParentForm.FormClosing += OnClosing;

            var __参数 = Environment.GetCommandLineArgs();
            if (__参数.Length > 2)
            {
                var __地址 = __参数[1];
                var __端口号 = __参数[2];
                this.inIP2.Text = __地址;
                this.in端口号.Text = __端口号;
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

        void do连接_Click(object sender, EventArgs e)
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
            H日志输出.设置(q =>
            {
                if (q.等级 <= TraceEventType.Information)
                {
                    if (q.异常 != null)
                    {
                        H日志.记录异常(q.异常, q.概要, q.详细, q.等级, q.方法, q.文件, q.行号);
                    }
                    else
                    {
                        H日志.记录(q.概要, q.等级, q.详细, q.方法, q.文件, q.行号);
                    }
                }
            });
            _IT客户端 = FT通用访问工厂.创建客户端();
            H容器.注入<IT客户端>(_IT客户端, false);
            _IT客户端.自动重连 = true;
            _IT客户端.已断开 += q => 设置连接状态();
            _IT客户端.已连接 += 设置连接状态;
            _IT客户端.连接(new IPEndPoint(IPAddress.Parse(__ip), int.Parse(__port)));
            this.ParentForm.ShowInTaskbar = false;
            this.ParentForm.Visible = false;
            _F主窗口 = new F空窗口(new F主窗口(),"");
            设置连接状态();
            _F主窗口.FormClosing += OnClosing;
            _F主窗口.ShowDialog();
        }

        void 设置连接状态()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(设置连接状态));
                return;
            }
            if (_F主窗口 != null)
            {
                _F主窗口.标题 = "GIS服务器管理工具 " + H调试.查询版本() + (_IT客户端.连接正常 ? "" : " | 断开");
            }
        }

        void OnClosing(object sender, CancelEventArgs e)
        {
            if (_IT客户端 != null)
            {
                if (_IT客户端.连接正常)
                {
                    _IT客户端.断开();
                }
            }
            Application.Exit();
        }

        private class M访问记录
        {
            public string IP { get; set; }

            public int 端口号 { get; set; }
        }
    }
}
