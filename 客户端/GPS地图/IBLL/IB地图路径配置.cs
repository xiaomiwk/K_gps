using System.Collections.Generic;
using Utility.通用;

namespace GPS地图.IBLL
{
    public interface IB地图路径配置
    {
        /// <summary>
        /// string : 地图路径; bool : true-已选择
        /// </summary>
        /// <returns></returns>
        [NoLog]
        Dictionary<string, bool> 查询();

        void 保存(List<string> 已选择的路径);
    }
}
