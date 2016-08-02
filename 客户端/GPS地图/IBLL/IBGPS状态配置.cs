using GPS地图.DTO;

namespace GPS地图.IBLL
{
    public interface IBGPS状态配置
    {
        void 保存(MGPS状态配置 参数);

        MGPS状态配置 查询();
    }
}
