using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GPS地图.DTO;
using GPS地图.IView;
using GPS地图.Presenter;
using Utility.通用;

namespace GPS地图.View
{
    public partial class F配置 : UserControl, IV配置
    {
        public F配置()
        {
            H接口注册.设置();
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.tabControl1.Controls.RemoveAt(0);
            H容器.虚方法拦截<P配置>().处理视图(this);
            this.do取消.Click += do取消_Click;
            this.do确定.Click += do确定_Click;
        }

        void do确定_Click(object sender, EventArgs e)
        {
            this.On提交设置();
            this.ParentForm.Close();
        }

        void do取消_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        public void 设置GPS更新状态参数(MGPS状态配置 参数)
        {
            this.outGPS时间参数.设置(参数);
        }

        public MGPS状态配置 获取GPS时间参数()
        {
            return this.outGPS时间参数.获取();
        }

        //public void 设置GIS服务器(M服务器 连接配置)
        //{
        //    this.outGIS服务器.设置(连接配置);
        //}

        //public M服务器 获取GIS服务器()
        //{
        //    return this.outGIS服务器.获取();
        //}

        public void 设置地图路径(Dictionary<string, bool> 连接配置)
        {
            out地图路径.设置(连接配置);
        }

        public List<string> 获取地图路径()
        {
            return out地图路径.获取();
        }


        public event Action 提交设置;

        protected virtual void On提交设置()
        {
            Action handler = 提交设置;
            if (handler != null) handler();
        }
    }
}
