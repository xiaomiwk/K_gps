using System;
using System.Collections.Generic;
using GPS地图.DTO;

namespace GPS地图.IView
{
    public interface IV配置
    {
        void 设置GPS更新状态参数(MGPS状态配置 参数);

        MGPS状态配置 获取GPS时间参数();

        //void 设置GIS服务器(M服务器 连接配置);

        //M服务器 获取GIS服务器();

        void 设置地图路径(Dictionary<string,bool> 路径配置);

        List<string> 获取地图路径();

        event Action 提交设置;
    }
}
