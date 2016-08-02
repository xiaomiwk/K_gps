using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.GPS数据
{
    public class M休眠号码查询条件
    {
        public DateTime 开始时间 { get; set; }
        public DateTime 结束时间 { get; set; }
        //public DateTime 活跃时间 { get; set; }
        public string 号码范围 { get; set; }

    }
}
