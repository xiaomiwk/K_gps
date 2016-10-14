using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GPS地图.View;
using GPS地图.示例.圈选;
using GPS地图.示例.数据分析;
using Utility.WindowsForm;
using 显示地图;
using DTO.GPS数据;

namespace GPS地图.示例
{
    public partial class F扩展 : UserControlK
    {
        private List<M经纬度> _圈选数据 = new List<M经纬度>();

        public F扩展()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.in日期.Value = DateTime.Now.Date;

            this.do单次圈选.Click += do单次圈选_Click;
            this.do多次圈选.Click += do多次圈选_Click;
            this.do简单圈选.Click += do简单圈选_Click;

            this.do测距.Click += do测距_Click;

            this.do查询最后位置.Click += Do查询最后位置_Click;
            this.do查询活跃号码.Click += Do查询活跃号码_Click;
            this.do统计活跃号码.Click += Do统计活跃号码_Click;
            this.do统计频率.Click += Do统计频率_Click;
        }

        Tuple<DateTime, DateTime> 获取时间()
        {
            var __日期 = this.in日期.Value.Date;
            var __时间 = this.in开始时间.Value;
            var __开始时间 = __日期.AddHours(__时间.Hour).AddMinutes(__时间.Minute);
            __时间 = this.in结束时间.Value;
            var __结束时间 = __日期.AddHours(__时间.Hour).AddMinutes(__时间.Minute).AddSeconds(59).AddMilliseconds(999);
            return new Tuple<DateTime, DateTime>(__开始时间, __结束时间);
        }

        private void Do统计频率_Click(object sender, EventArgs e)
        {
            var __时间 = 获取时间();
            var __条件 = new M频率统计条件
            {
                开始时间 = __时间.Item1,
                结束时间 = __时间.Item2,
                号码列表 = this.in号码列表.Text.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries).ToList()
            };
            float __结果 = 0;
            HUI线程.异步执行(this, () =>
            {
                __结果 = GPS.B入口.数据.统计(__条件);
            }, () =>
            {
                new F对话框_确定(string.Format("频率: {0} 秒/次", __结果)).ShowDialog();
            }, ex =>
            {
                new F对话框_确定(string.Format("执行失败\r\n{0}", ex.Message)).ShowDialog();
            });
        }

        private void Do统计活跃号码_Click(object sender, EventArgs e)
        {
            var __时间 = 获取时间();
            var __条件 = new M活跃号码查询条件
            {
                开始时间 = __时间.Item1,
                结束时间 = __时间.Item2,
                号码列表 = this.in号码列表.Text.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries).ToList()
            };
            int __结果 = 0;
            HUI线程.异步执行(this, () =>
            {
                __结果 = GPS.B入口.数据.统计(__条件);
            }, () =>
            {
                new F对话框_确定(string.Format("总数: {0}", __结果)).ShowDialog();
            }, ex =>
            {
                new F对话框_确定(string.Format("执行失败\r\n{0}", ex.Message)).ShowDialog();
            });
        }

        private void Do查询活跃号码_Click(object sender, EventArgs e)
        {
            var __时间 = 获取时间();
            var __条件 = new M活跃号码查询条件
            {
                开始时间 = __时间.Item1,
                结束时间 = __时间.Item2,
                号码列表 = this.in号码列表.Text.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries).ToList()
            };
            M活跃号码查询结果 __结果 = null;
            HUI线程.异步执行(this, () =>
            {
                __结果 = GPS.B入口.数据.查询(__条件);
            }, () =>
            {
                new F空窗口(new F查询活跃号码(__结果.号码列表), "活跃号码").ShowDialog();
            }, ex =>
            {
                new F对话框_确定(string.Format("执行失败\r\n{0}", ex.Message)).ShowDialog();
            });
        }

        private void Do查询最后位置_Click(object sender, EventArgs e)
        {
            var __时间 = 获取时间();
            var __条件 = new M最后位置查询条件
            {
                //号码列表 = this.in号码列表.Text.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries).ToList(),
                //每页数量 = 10000,
                //页码 = 1
            };
            M最后位置查询结果 __结果 = null;
            HUI线程.异步执行(this, () =>
            {
                __结果 = GPS.B入口.数据.查询(__条件);
            }, () =>
            {
                new F空窗口(new F查询最后位置(__结果.列表), "最后位置").ShowDialog();
            }, ex =>
            {
                new F对话框_确定(string.Format("执行失败\r\n{0}", ex.Message)).ShowDialog();
            });
        }

        void do测距_Click(object sender, EventArgs e)
        {
            var __纯地图 = new F纯地图();
            var __测距 = new F测距(__纯地图.地图);
            var __按钮 = new U按钮
            {
                Top = 10,
                Left = 50,
                Text = "开始"
            };
            __按钮.Click += (sender1, e1) =>
            {
                if (__按钮.Text == "开始")
                {
                    __按钮.Text = "结束";
                    __测距.开始();
                }
                else
                {
                    __按钮.Text = "开始";
                    __测距.结束();
                }
            };
            __纯地图.Controls.Add(__按钮);
            __按钮.BringToFront();
            var __空窗口 = new F空窗口(__纯地图, "测距");
            __空窗口.ShowDialog();
            __空窗口.Dispose();
        }

        void do简单圈选_Click(object sender, EventArgs e)
        {
            var __纯地图 = new F纯地图();
            添加简单圈选(__纯地图);
            显示地图(__纯地图, "简单圈选");
        }

        void do单次圈选_Click(object sender, EventArgs e)
        {
            var __纯地图 = new F纯地图();
            添加单次圈选(__纯地图);
            显示地图(__纯地图, "单次圈选");
        }

        void do多次圈选_Click(object sender, EventArgs e)
        {
            var __纯地图 = new F纯地图();
            添加多次圈选(__纯地图);
            显示地图(__纯地图, "多次圈选");
        }

        private void 添加简单圈选(F纯地图 __纯地图)
        {
            var __圈选 = new F圈选_圆形(__纯地图.地图);
            __圈选.圈选结束 += 处理圆形圈选;
            var __按钮 = new U按钮
            {
                Top = 10,
                Left = 50,
                Text = "开始"
            };
            __按钮.Click += (sender1, e1) =>
            {
                if (__按钮.Text == "开始")
                {
                    __按钮.Text = "结束";
                    __圈选.开始();
                }
                else
                {
                    __按钮.Text = "开始";
                    __圈选.结束();
                    __圈选.清除();
                }
            };
            __纯地图.Controls.Add(__按钮);
            __按钮.BringToFront();
        }

        private void 添加单次圈选(F纯地图 __纯地图)
        {
            var __圈选控件 = new F圈选_单次(__纯地图.地图)
            {
                Left = __纯地图.Left + 50,
                Top = __纯地图.Top + 10,
                自动删除圈选 = false
            };
            __圈选控件.处理矩形圈选结束 += 处理矩形圈选;
            __圈选控件.处理圆形圈选结束 += 处理圆形圈选;
            __圈选控件.处理多边形圈选结束 += 处理多边形圈选;
            __圈选控件.请求关闭 += () =>
            {
                __圈选控件.删除圈选区域();
                __纯地图.Controls.Remove(__圈选控件);
                __圈选控件.Dispose();
            };
            __纯地图.Controls.Add(__圈选控件);
            __圈选控件.BringToFront();
        }

        private void 添加多次圈选(F纯地图 __纯地图)
        {
            var __圆形索引 = new List<ulong>();
            var __矩形索引 = new List<ulong>();
            var __多边形索引 = new List<ulong>();
            var __绘制参数 = new M区域绘制参数 { 边框宽度 = 1, 边框颜色 = Color.FromArgb(180, Color.Green), 填充颜色 = Color.FromArgb(20, Color.Green) };
            Action<M经纬度, int> __处理圈选圆形 = (__圆心, __半径) => __圆形索引.Add(__纯地图.地图.添加圆(__圆心, __半径, __绘制参数));
            Action<M经纬度, M经纬度> __处理圈选矩形 = (__左上角, __右下角) => __矩形索引.Add(__纯地图.地图.添加矩形(__左上角, __右下角, __绘制参数));
            Action<List<M经纬度>> __处理圈选多边形 = __顶点列表 => __多边形索引.Add(__纯地图.地图.添加多边形(__顶点列表, __绘制参数));

            var __圈选控件 = new F圈选_多次(__纯地图.地图)
            {
                Left = __纯地图.Left + 50,
                Top = __纯地图.Top + 10,
            };

            __圈选控件.处理矩形圈选结束 += __处理圈选矩形;
            __圈选控件.处理圆形圈选结束 += __处理圈选圆形;
            __圈选控件.处理多边形圈选结束 += __处理圈选多边形;
            __圈选控件.请求关闭 += () =>
            {
                __圆形索引.ForEach(q => __纯地图.地图.删除圆(q));
                __矩形索引.ForEach(q => __纯地图.地图.删除矩形(q));
                __多边形索引.ForEach(q => __纯地图.地图.删除多边形(q));

                __圈选控件.删除圈选区域();
                __纯地图.Controls.Remove(__圈选控件);
                __圈选控件.Dispose();
            };
            __纯地图.Controls.Add(__圈选控件);
            __圈选控件.BringToFront();
        }

        private void 显示地图(F纯地图 __纯地图, string __窗口标题)
        {
            var __空窗口 = new F空窗口(__纯地图, __窗口标题);
            __空窗口.Shown += (sender1, e1) =>
            {
                var __中心位置 = __纯地图.地图.屏幕坐标转经纬度(new Point(this.Width / 2, this.Height / 2));
                var __随机数 = new Random();
                for (int i = 0; i < 5000; i++)
                {
                    var __经度 = __中心位置.经度 - 0.5 + __随机数.NextDouble() * 1;
                    var __纬度 = __中心位置.纬度 - 0.5 + __随机数.NextDouble() * 1;
                    var __经纬度 = new M经纬度(__经度, __纬度) { 类型 = E坐标类型.设备 };
                    _圈选数据.Add(__经纬度);
                }
                __纯地图.地图.添加麻点图(_圈选数据, GPS地图.Properties.Resources.最近更新);
            };
            __空窗口.ShowDialog();
            __空窗口.Dispose();
        }

        void 处理圆形圈选(M经纬度 __圆心, int __半径)
        {
            if (_圈选数据.Count == 0)
            {
                return;
            }
            var __圈选数量 = 0;
            _圈选数据.ForEach(q =>
            {
                if (H地图算法.判断点在圆形内(q, __圆心, __半径))
                {
                    __圈选数量++;
                }
            });
            new F对话框_确定("圈选数量: " + __圈选数量, "操作成功").ShowDialog();
        }

        void 处理矩形圈选(M经纬度 __左上角, M经纬度 __右下角)
        {
            if (_圈选数据.Count == 0)
            {
                return;
            }
            var __圈选数量 = 0;
            var __矩形点集 = new List<M经纬度>
                    {
                        __左上角,
                        __左上角.偏移(__右下角.经度 - __左上角.经度, 0),
                        __右下角,
                        __右下角.偏移(__左上角.经度 - __右下角.经度, 0),
                    };
            _圈选数据.ForEach(q =>
            {
                if (H地图算法.判断点在矩形内(q, __矩形点集))
                {
                    __圈选数量++;
                }
            });
            new F对话框_确定("圈选数量: " + __圈选数量, "操作成功").ShowDialog();
        }

        void 处理多边形圈选(List<M经纬度> __顶点列表)
        {
            if (_圈选数据.Count == 0)
            {
                return;
            }
            var __圈选数量 = 0;
            _圈选数据.ForEach(q =>
            {
                if (H地图算法.判断点在多边形内(q, __顶点列表))
                {
                    __圈选数量++;
                }
            });
            new F对话框_确定("圈选数量: " + __圈选数量, "操作成功").ShowDialog();
        }

    }
}
