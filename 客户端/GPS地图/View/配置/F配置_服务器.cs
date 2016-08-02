using System;
using System.Windows.Forms;
using GPS地图.DTO;

namespace GPS地图.View.配置
{
    public partial class F配置_服务器 : UserControl
    {
        public F配置_服务器()
        {
            InitializeComponent();
        }

        public void 设置(M服务器 连接配置)
        {
            this.in服务器IP地址.Text = 连接配置.服务器IP.ToString();
            this.in服务器端口号.Text = 连接配置.服务器端口号.ToString();
        }

        public M服务器 获取()
        {
            var __ip描述 = this.in服务器IP地址.Text;
            var __端口号描述 = this.in服务器端口号.Text.Trim();

            var __ip = __ip描述.ToIP("服务器IP地址");
            var __端口号 = __端口号描述.ToInt("服务器端口号");
            return new M服务器
                {
                    服务器IP = __ip,
                    服务器端口号 = __端口号,
                };
        }

    }
}
