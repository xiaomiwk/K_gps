using System;
using System.Drawing;
using System.Windows.Forms;
using 显示地图;

namespace GPS地图.示例.圈选
{
    class F圈选_圆形
    {
        F地图 _F地图;

        private UInt64 _圈选图形索引;

        private Point _起点;

        private Point _终点;

        public F圈选_圆形(F地图 __F地图)
        {
            this._F地图 = __F地图;

        }

        public void 清除()
        {
            if (_圈选图形索引 == 0)
            {
                return;
            }
            _F地图.删除圆(_圈选图形索引);
        }

        public void 开始()
        {
            _F地图.MouseDown += out地图_MouseDown;
            _F地图.MouseMove += out地图_MouseMove;
            _F地图.MouseUp += out地图_MouseUp;
        }

        public void 结束()
        {
            _F地图.MouseDown -= out地图_MouseDown;
            _F地图.MouseMove -= out地图_MouseMove;
            _F地图.MouseUp -= out地图_MouseUp;

            //Debug.WriteLine("鼠标释放位置: " + e.Location);
            var __圆心 = _F地图.屏幕坐标转经纬度(_起点);
            var __当前位置 = _F地图.屏幕坐标转经纬度(_终点);
            //获取圈选内容
            var __半径 = H地图算法.测量两点间间距(__圆心, __当前位置);
            On圈选结束(__圆心, __半径);
        }

        public event Action<M经纬度, int> 圈选结束;

        protected virtual void On圈选结束(M经纬度 圆心, int 半径)
        {
            var handler = 圈选结束;
            if (handler != null) handler(HGPS坐标转换.转原始坐标(圆心), 半径);
        }

        void out地图_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || e.Clicks != 1)
            {
                return;
            }
            _起点 = e.Location;
            //Debug.WriteLine("鼠标按下位置: " + _鼠标按下位置);
        }

        void out地图_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }
            绘制圆形(e);
        }

        private void 绘制圆形(MouseEventArgs e)
        {
            if (_圈选图形索引 > 0)
            {
                _F地图.删除圆(_圈选图形索引);
            }
            var __圆心 = _F地图.屏幕坐标转经纬度(_起点);
            var __当前位置 = _F地图.屏幕坐标转经纬度(e.Location);
            var __半径 = H地图算法.测量两点间间距(__圆心, __当前位置);
            _圈选图形索引 = _F地图.添加圆(
                __圆心,
                __半径,
                new M区域绘制参数 { 边框宽度 = 1, 边框颜色 = Color.FromArgb(255, 0, 0, 255), 填充颜色 = Color.FromArgb(55, 135, 206, 235) });
        }

        void out地图_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }
            _终点 = e.Location;
        }

    }
}
