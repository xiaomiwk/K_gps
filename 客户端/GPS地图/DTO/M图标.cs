using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using DTO;

namespace GPS地图.DTO
{
    public class M图标
    {
        public MGPS 位置 { get; set; }

        public M图标显示参数 显示参数 { get; set; }

        public object 业务标识 { get; set; }

        public List<MGPS> 轨迹 { get; set; }
    }

}
