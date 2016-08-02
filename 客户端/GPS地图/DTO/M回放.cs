using System;
using System.Collections.Generic;
using System.Drawing;
using DTO;

namespace GPS地图.DTO
{
    [Serializable]
    public class M回放
    {
        public string 标识 { get; set; }

        public List<MGPS> 位置 { get; set; }

        public M图标显示参数 显示参数 { get; set; }

        public Color 静态轨迹颜色 { get; set; }
    }
}
