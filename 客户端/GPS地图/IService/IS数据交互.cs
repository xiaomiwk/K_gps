using System;
using DTO;
using GPS地图.DTO;

namespace GPS地图.IService
{
    public interface IS数据交互
    {
        Func<DateTime> 参照时间 { get; set; }

        void 增加(string 标识, MGPS GPS);

        void 删除(string 标识);

        EGPS状态 查询(string 标识);

        event Action<string, EGPS状态> 状态更新;

    }
}
