using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.订阅;

namespace DTO.GPS数据
{
    public class M最后位置查询条件
    {
        //号码, 开始时间, 结束时间, 页码(可选), 每页数量(可选)

        public List<M号码段> 号码范围 { get; set; }
        public DateTime 开始时间 { get; set; }
        public DateTime 结束时间 { get; set; }
        public int? 页码 { get; set; }
        public int? 每页数量 { get; set; }
    }
}
