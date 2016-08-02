using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using DTO;

namespace GPS地图.DTO
{
    public class M静态轨迹
    {
        public string 名称 { get; set; }

        public Color 显示颜色 { get; set; }

        public List<MGPS> GPS { get; set; }
    }

}
