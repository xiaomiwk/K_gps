using System;
using GPS地图.DTO;
using GPS地图.IService;

namespace GPS地图.IView
{
    public interface IV回放 : IV控件
    {
        IV地图 IV地图 { get; }

        IS显示GPS 显示GPS { get; }

        IS数据交互 接收GPS { get; }

        /// <summary>
        /// int 倍速/频率
        /// </summary>
        event Action<int> 播放;

        /// <summary>
        /// int 倍速/频率
        /// </summary>
        event Action<int> 改变播放参数;

        event Action 暂停;

        event Action 停止;

        void 显示播放状态(E播放状态 状态);

        /// <param name="进度">0-100</param>
        void 显示播放进度(int 进度);

        void 显示播放时间(DateTime 时间);

        void 显示实际时间(DateTime 开始时间, DateTime 结束时间);

        event Action<int> 跳转进度;
    }
}
