using GPS地图.IBLL;
using GPS地图.IView;
using Utility.通用;

namespace GPS地图.Presenter
{
    public class P配置
    {
        //private readonly IB服务器配置 _IBGIS服务器 = H容器.取出<IB服务器配置>();

        private readonly IBGPS状态配置 _IBGPS时间参数 = H容器.取出<IBGPS状态配置>();

        private readonly IB地图路径配置 _IB地图路径 = H容器.取出<IB地图路径配置>();

        private IV配置 _IV配置;

        public virtual void 处理视图(IV配置 视图)
        {
            _IV配置 = 视图;
            _IV_加载数据();
            _IV配置.提交设置 += _IV配置_提交设置;
        }

        protected virtual void _IV_加载数据()
        {
            _IV配置.设置GPS更新状态参数(_IBGPS时间参数.查询());
            //_IV配置.设置GIS服务器(_IBGIS服务器.查询());
            _IV配置.设置地图路径(_IB地图路径.查询());

        }

        protected virtual void _IV配置_提交设置()
        {
            //_IBGIS服务器.保存(_IV配置.获取GIS服务器());
            _IBGPS时间参数.保存(_IV配置.获取GPS时间参数());
            _IB地图路径.保存(_IV配置.获取地图路径());

        }
    }
}
