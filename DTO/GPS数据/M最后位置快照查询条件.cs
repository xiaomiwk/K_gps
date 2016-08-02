using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.GPS数据
{
    public class M最后位置快照查询条件
    {
        //号码, 开始时间, 结束时间, 页码(可选), 每页数量(可选)

        public string 号码范围 { get; set; }
        public DateTime 开始时间 { get; set; }
        public DateTime 结束时间 { get; set; }
        public int 图片宽度 { get; set; }
        public int 图片长度 { get; set; }
    }
}
