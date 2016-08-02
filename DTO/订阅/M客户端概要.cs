using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace DTO.订阅
{
    public class M客户端概要
    {
        public IPAddress IP { get; set; }

        public int 端口号 { get; set; }

        public int 订阅总数 { get; set; }

        public DateTime 开始时间 { get; set; }

    }
}
