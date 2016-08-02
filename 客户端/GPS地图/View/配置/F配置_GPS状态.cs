using System;
using System.Windows.Forms;
using GPS地图.DTO;

namespace GPS地图.View.配置
{
    public partial class F配置_GPS状态 : UserControl
    {
        public F配置_GPS状态()
        {
            InitializeComponent();
        }

        public void 设置(MGPS状态配置 参数)
        {
            this.in无信号间隔.Text = 参数.短期未更新间隔.ToString();
            this.in关机间隔.Text = 参数.很久未更新间隔.ToString();
            this.in停止显示间隔.Text = 参数.停止显示间隔.ToString();
        }

        public MGPS状态配置 获取()
        {
            var __无信号间隔 = this.in无信号间隔.Text.Trim().ToInt("无信号间隔");
            var __关机间隔 = this.in关机间隔.Text.Trim().ToInt("关机间隔");
            var __停止显示间隔 = this.in停止显示间隔.Text.Trim().ToInt("停止显示间隔");
            return new MGPS状态配置
                {
                    很久未更新间隔 = __关机间隔,
                    短期未更新间隔 = __无信号间隔,
                    停止显示间隔 = __停止显示间隔
                };
        }
    }
}
