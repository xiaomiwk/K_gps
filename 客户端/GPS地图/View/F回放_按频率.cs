using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GPS地图.DTO;
using GPS地图.IService;
using GPS地图.IView;
using GPS地图.Presenter;
using Utility.通用;

namespace GPS地图.View
{
    public partial class F回放_按频率 : F控件, IV回放
    {
        private FGPS _FGPS;

        private M回放 _初始化参数;

        public F回放_按频率(M回放 初始化参数)
        {
            H接口注册.设置();
            _初始化参数 = 初始化参数;
            InitializeComponent();
            this._FGPS = new FGPS() { Dock = DockStyle.Fill };
            this._FGPS.地图.设置层级范围(9, 16);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var __1倍速 = new { 速度 = 1, 描述 = "1点/秒" };
            var __3倍速 = new { 速度 = 3, 描述 = "3点/秒" };
            var __5倍速 = new { 速度 = 5, 描述 = "5点/秒" };
            var __倍速列表 = new List<object> { __1倍速, __3倍速, __5倍速 };
            this.in速度.DisplayMember = "描述";
            this.in速度.ValueMember = "速度";
            this.in速度.DataSource = __倍速列表;
            this.in速度.SelectedValue = 3;

            this.out进度.Enabled = false;
            this.out进度.Minimum = 0;
            this.out进度.Maximum = 100;
            this.out进度.TickFrequency = 10;

            this.out地图.Controls.Add(_FGPS);

            H容器.虚方法拦截<P回放_按频率>().处理视图(this, _初始化参数);

            this.do暂停.Click += (sender1, e1) => this.On暂停();
            this.do停止.Click += (sender1, e1) => this.On停止();
            this.do播放.Click += (sender1, e1) => this.On播放((int)this.in速度.SelectedValue);
            this.in速度.SelectedValueChanged += (sender1, e1) => this.On改变播放参数((int)this.in速度.SelectedValue);
            this.out进度.ValueChanged += Out进度_ValueChanged;
        }

        private void Out进度_ValueChanged(object sender, EventArgs e)
        {
            this.On跳转进度(this.out进度.Value);
        }

        #region IV回放

        public void 显示播放状态(E播放状态 状态)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<E播放状态>(显示播放状态), 状态);
                return;
            }
            this.in速度.Enabled = true;
            this.do暂停.Enabled = true;
            this.do播放.Enabled = true;
            this.do停止.Enabled = true;
            this.out进度.Enabled = false;
            switch (状态)
            {
                case E播放状态.不可用:
                    this.do暂停.Enabled = false;
                    this.do播放.Enabled = false;
                    this.do停止.Enabled = false;
                    this.in速度.Enabled = false;
                    break;
                case E播放状态.初始化:
                    this.do播放.BringToFront();
                    this.do暂停.Enabled = false;
                    this.do停止.Enabled = false;
                    break;
                case E播放状态.播放:
                    this.out进度.Enabled = true;
                    this.do播放.Enabled = false;
                    this.do暂停.BringToFront();
                    break;
                case E播放状态.暂停:
                    this.do播放.BringToFront();
                    this.do暂停.Enabled = false;
                    break;
                case E播放状态.停止:
                    this.do播放.BringToFront();
                    this.do停止.Enabled = false;
                    this.do暂停.Enabled = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("状态");
            }
        }

        public void 显示播放进度(int 进度)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<int>(显示播放进度), 进度);
                return;
            }

            this.out进度.ValueChanged -= Out进度_ValueChanged;
            this.out进度.Value = 进度;
            this.out进度.ValueChanged += Out进度_ValueChanged;
        }

        public void 显示播放时间(DateTime 时间)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<DateTime>(显示播放时间), 时间);
                return;
            }

            this.out时间.Text = 时间.ToString("MM-dd HH:mm:ss");
        }

        /// <summary>
        /// int 倍速
        /// </summary>
        public event Action<int> 播放;

        protected virtual void On播放(int 倍速)
        {
            var handler = 播放;
            if (handler != null) handler(倍速);
        }

        /// <summary>
        /// int 倍速
        /// </summary>
        public event Action<int> 改变播放参数;

        protected virtual void On改变播放参数(int 倍速)
        {
            Action<int> handler = 改变播放参数;
            if (handler != null) handler(倍速);
        }

        public event Action 暂停;

        protected virtual void On暂停()
        {
            Action handler = 暂停;
            if (handler != null) handler();
        }

        public event Action 停止;

        protected virtual void On停止()
        {
            Action handler = 停止;
            if (handler != null) handler();
        }

        public void 显示实际时间(DateTime 开始时间, DateTime 结束时间)
        {
            this.out时间.Text = 开始时间.ToString("MM-dd HH:mm:ss");
        }

        public event Action<int> 跳转进度;

        protected virtual void On跳转进度(int __进度)
        {
            var handler = 跳转进度;
            if (handler != null) handler(__进度);
        }

        #endregion

        public IV地图 IV地图
        {
            get { return _FGPS; }
        }

        public IS显示GPS 显示GPS
        {
            get { return _FGPS.显示GPS; }
        }

        public IS数据交互 接收GPS
        {
            get { return _FGPS.数据交互; }
        }

    }
}
