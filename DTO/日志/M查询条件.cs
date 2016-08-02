using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.日志
{
    public class M查询条件
    {
        //开始时间, 结束时间, 类别(系统/登录/跟踪/轨迹/定位/地址服务/统计, 可选), 页数, 每页数量
        public DateTime 开始时间 { get; set; }
        public DateTime 结束时间 { get; set; }
        public string 类别 { get; set; }

        public int? 页码 { get; set; }
        public int? 每页数量 { get; set; }

    }
}
