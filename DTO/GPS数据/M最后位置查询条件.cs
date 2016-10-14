using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.订阅;

namespace DTO.GPS数据
{
    public class M最后位置查询条件
    {
        public List<string> 号码列表 { get; set; }

        public int? 页码 { get; set; }

        public int? 每页数量 { get; set; }
    }
}
