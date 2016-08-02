using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.GPS数据
{
    public class M轨迹查询结果
    {
        public int 总数量 { get; set; }

        public List<MGPS> 列表 { get; set; }
    }
}
