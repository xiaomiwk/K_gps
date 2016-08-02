using System;

namespace DTO
{
    public class MGPS
    {
        //经度, 纬度, 时间, 速度(可选), 高度(可选), 方向(可选), 精度(可选)
        public double 经度 { get; set; }

        public double 纬度 { get; set; }

        public DateTime 时间 { get; set; }

        /// <summary>
        /// 公里/小时
        /// </summary>
        public int? 速度 { get; set; }

        /// <summary>
        /// 米
        /// </summary>
        public int? 高度 { get; set; }

        public int? 方向 { get; set; }

        /// <summary>
        /// 米
        /// </summary>
        public int? 精度 { get; set; }
    }
}
