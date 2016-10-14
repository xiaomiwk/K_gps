using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.GPS数据
{
    public class M活跃号码查询条件
    {
        public DateTime 开始时间 { get; set; }

        public DateTime 结束时间 { get; set; }

        public List<string> 号码列表 { get; set; }

    }
}
