using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GPS地图.DTO;

namespace GPS地图.IView
{
    public interface IV地图 : IV控件
    {
        /// <param name="路径列表">键为路径, 值为描述</param>
        void 加载地图(Dictionary<string, bool> 路径列表);

        List<ulong> 添加图标(List<M图标> 图标集);

        void 删除图标(List<ulong> 图标集);

        void 删除所有图标();

        void 定位(List<ulong> 图标集);

        event Action<M图标, MouseEventArgs> 单击图标;

        event Action<M图标> 进入图标;

        event Action<M图标> 离开图标;

        void 添加静态轨迹(List<M静态轨迹> 轨迹集);

        void 显隐静态轨迹();

        List<M图标> 查询所有图标();
    }
}
