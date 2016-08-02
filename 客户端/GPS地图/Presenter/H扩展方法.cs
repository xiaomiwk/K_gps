using DTO;
using 显示地图;

public static class H扩展方法
{
    public static M经纬度 转M经纬度(this MGPS GPS)
    {
        return new M经纬度(GPS.经度, GPS.纬度);
    }
}
