using System;
using System.Collections.Generic;
using System.Drawing;
using GPS地图.DTO;

namespace GPS地图.IService
{
    public interface IS显示GPS
    {
        void 显示(Dictionary<string, M图标显示参数> 标识集);

        void 隐藏(List<string> 标识集);

        void 定位(List<string> 标识集);

        event Action<string> 单击标识;

        event Action<string> 鼠标进入标识;

        event Action<string> 鼠标离开标识;

        Func<string, EGPS状态, Image> 更新图片 { get; set; }

    }
}
