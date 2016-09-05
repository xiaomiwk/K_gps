using System;
using System.Collections.Generic;
using DTO;
using GPS地图.DTO;
using Utility.通用;

namespace GPS地图.IBLL
{
    public interface IB回放_按时间
    {
        void 初始化(Dictionary<string, List<MGPS>> 回放参数);

        DateTime 实际开始时间 { get; }

        DateTime 实际结束时间 { get;}

        DateTime 当前时间 { get; }

        void 播放(int 倍速);

        void 暂停();

        void 停止();

        void 改变播放参数(int 倍速);

        event Action<E播放状态> 播放状态变化;

        /// <summary>
        /// 0-100
        /// </summary>
        event Action<int> 播放进度变化;

        event Action<DateTime> 当前时间变化;

        /// <summary>
        /// 第一个参数: 标识
        /// </summary>
        event Action<string, MGPS> 位置更新;

    }
}
