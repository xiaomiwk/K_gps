using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GPS地图.DTO;
using GPS地图.IService;

namespace GPS地图.示例
{
    public partial class F显示模板 : UserControl
    {
        protected Dictionary<string, EGPS状态> _状态缓存 = new Dictionary<string, EGPS状态>();

        protected Dictionary<string, bool> _显示缓存 = new Dictionary<string, bool>();

        protected Dictionary<string, M图标显示参数> _参数缓存 = new Dictionary<string, M图标显示参数>();

        private Dictionary<string, DataGridViewRow> _行缓存 = new Dictionary<string, DataGridViewRow>();

        private Dictionary<EGPS状态, Image> _图片缓存 = new Dictionary<EGPS状态, Image>
        {
            { EGPS状态.最近更新, GPS地图.Properties.Resources.最近更新 },
            { EGPS状态.短期未更新, GPS地图.Properties.Resources.短期未更新 },
            { EGPS状态.很久未更新, GPS地图.Properties.Resources.很久未更新 },
        };

        public Control 控件 { get; set; }

        public IS显示GPS 显示GPS { get; set; }

        public IS数据交互 数据交互 { get; set; }

        public F显示模板()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.out共计.Text = "";
            this.timer1.Interval = 3000;
            this.timer1.Start();

            this.in全选.CheckedChanged += in全选_CheckedChanged;
            this.timer1.Tick += timer1_Tick;
            this.out号码列表.CellMouseClick += out号码列表_CellClick;
            this.out号码列表.CellMouseDoubleClick += Out号码列表_CellMouseDoubleClick;

            if (!DesignMode)
            {
                数据交互.状态更新 += 数据交互_状态更新;
            }
            this.out地图容器.Controls.Add(控件);

            this.do折叠.Click += (sender1, e1) => this.splitContainer1.Panel1Collapsed = !this.splitContainer1.Panel1Collapsed;
        }

        public bool 显示统计
        {
            get { return this.out统计面板.Visible; }
            set { this.out统计面板.Visible = value; }
        }

        public virtual void 设置号码(Dictionary<string, M图标显示参数> __列表)
        {
            _参数缓存 = __列表;
            if (_状态缓存.Count > 0)
            {
                显示GPS.隐藏(_状态缓存.Select(q => q.Key).ToList());
            }
            this.out号码列表.Rows.Clear();
            _状态缓存.Clear();
            _行缓存.Clear();
            _显示缓存.Clear();
            foreach (var __kv in __列表)
            {
                var __标识 = __kv.Key;
                var __行号 = this.out号码列表.Rows.Add(true, __标识);
                _行缓存[__标识] = this.out号码列表.Rows[__行号];
                _状态缓存[__标识] = 数据交互.查询(__标识);
                _显示缓存[__标识] = true;
            }
            显示GPS.更新图片 = 更新图片;
            显示GPS.显示(__列表);
            this.in全选.Checked = true;
        }

        protected virtual Image 更新图片(string __标识, EGPS状态 __状态)
        {
            if (_图片缓存.ContainsKey(__状态))
            {
                return _图片缓存[__状态];
            }
            return null;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (显示统计)
            {
                统计(_状态缓存);
            }
            foreach (var __kv in _行缓存)
            {
                var __标识 = __kv.Key;
                var __状态 = _状态缓存[__标识];
                设置表格颜色(_行缓存[__标识], __状态);
            }
        }

        void out号码列表_CellClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 0 || e.RowIndex < 0)
            {
                return;
            }
            var __标识 = this.out号码列表.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (!_显示缓存[__标识])
            {
                显示GPS.显示(new Dictionary<string, M图标显示参数> { { __标识, _参数缓存[__标识] } });
            }
            else
            {
                显示GPS.隐藏(new List<string> { __标识 });
            }
            _显示缓存[__标识] = !_显示缓存[__标识];

        }

        private void Out号码列表_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.RowIndex < 0)
            {
                return;
            }
            var __标识 = this.out号码列表.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (!_显示缓存[__标识])
            {
                显示GPS.显示(new Dictionary<string, M图标显示参数> { { __标识, _参数缓存[__标识] } });
                _显示缓存[__标识] = true;
                this.out号码列表.Rows[e.RowIndex].Cells[0].Value = true;
            }
            显示GPS.定位(new List<string> { __标识 });
        }

        void 数据交互_状态更新(string __标识, EGPS状态 __状态)
        {
            if (!_状态缓存.ContainsKey(__标识))
            {
                return;
            }
            _状态缓存[__标识] = __状态;
        }

        void in全选_CheckedChanged(object sender, EventArgs e)
        {
            var __显示 = this.in全选.Checked;
            if (__显示)
            {
                var __参数 = new Dictionary<string, M图标显示参数>();
                foreach (var __kv in _状态缓存)
                {
                    if (!_显示缓存[__kv.Key])
                    {
                        __参数[__kv.Key] = new M图标显示参数 { 名称 = __kv.Key, 图片 = 更新图片(__kv.Key, __kv.Value) };
                    }
                }
                显示GPS.显示(__参数);
            }
            else
            {
                显示GPS.隐藏(_显示缓存.Where(q => q.Value).Select(q => q.Key).ToList());
            }
            foreach (var __kv in _行缓存)
            {
                __kv.Value.Cells[0].Value = __显示;
            }
            var __镜像 = new Dictionary<string, bool>(_显示缓存);
            foreach (var __kv in __镜像)
            {
                var __标识 = __kv.Key;
                _显示缓存[__标识] = __显示;
            }
        }

        private void 统计(Dictionary<string, EGPS状态> __状态缓存)
        {
            var __类别 = new Dictionary<EGPS状态, int>();
            foreach (var __kv in __状态缓存)
            {
                if (!__类别.ContainsKey(__kv.Value))
                {
                    __类别[__kv.Value] = 0;
                }
                __类别[__kv.Value]++;
            }
            this.out从未有过.Text = "0";
            this.out最近更新.Text = "0";
            this.out短期未更新.Text = "0";
            this.out很久未更新.Text = "0";
            this.out失效.Text = "0";

            this.out共计.Text = __状态缓存.Count.ToString();
            foreach (var __kv in __类别)
            {
                switch (__kv.Key)
                {
                    case EGPS状态.从未有过:
                        this.out从未有过.Text = __kv.Value.ToString();
                        break;
                    case EGPS状态.最近更新:
                        this.out最近更新.Text = __kv.Value.ToString();
                        break;
                    case EGPS状态.短期未更新:
                        this.out短期未更新.Text = __kv.Value.ToString();
                        break;
                    case EGPS状态.很久未更新:
                        this.out很久未更新.Text = __kv.Value.ToString();
                        break;
                    case EGPS状态.停止显示:
                        this.out失效.Text = __kv.Value.ToString();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        void 设置表格颜色(DataGridViewRow __行, EGPS状态 __状态)
        {
            var __样式 = __行.Cells[1].Style;
            switch (__状态)
            {
                case EGPS状态.最近更新:
                    __样式.BackColor = Color.SkyBlue;
                    break;
                case EGPS状态.短期未更新:
                    __样式.BackColor = Color.Red;
                    break;
                case EGPS状态.很久未更新:
                    __样式.BackColor = Color.Gray;
                    break;
                case EGPS状态.停止显示:
                    __样式.BackColor = Color.Yellow;
                    break;
                default:
                    __样式.BackColor = Color.White;
                    break;
            }
        }

    }
}
