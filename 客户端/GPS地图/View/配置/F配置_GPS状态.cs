using System;
using System.Windows.Forms;
using GPS地图.DTO;
using Utility.存储;

namespace GPS地图.View.配置
{
    public partial class F配置_GPS状态 : UserControl
    {
        public F配置_GPS状态()
        {
            InitializeComponent();
            加载图片(this.out很久未更新间隔, "很久未更新间隔.png");
            加载图片(this.out短期未更新间隔, "短期未更新间隔.png");
        }

        void 加载图片(PictureBox __图片框, string __图片路径)
        {
            if (H路径.验证文件是否存在(__图片路径, true))
            {
                __图片框.ImageLocation = H路径.获取绝对路径(__图片路径, true);
            }
        }

        public void 设置(MGPS状态配置 __参数)
        {
            this.in短期未更新间隔.Text = __参数.短期未更新间隔.ToString();
            this.in很久未更新间隔.Text = __参数.很久未更新间隔.ToString();
            this.in停止显示间隔.Text = __参数.停止显示间隔.ToString();
        }

        public MGPS状态配置 获取()
        {
            var __短期未更新间隔 = this.in短期未更新间隔.Text.Trim().ToInt("短期未更新间隔");
            var __很久未更新间隔 = this.in很久未更新间隔.Text.Trim().ToInt("很久未更新间隔");
            var __停止显示间隔 = this.in停止显示间隔.Text.Trim().ToInt("停止显示间隔");
            return new MGPS状态配置
            {
                很久未更新间隔 = __很久未更新间隔,
                短期未更新间隔 = __短期未更新间隔,
                停止显示间隔 = __停止显示间隔
            };
        }
    }
}
