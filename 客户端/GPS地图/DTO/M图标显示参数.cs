using System;
using System.Drawing;

namespace GPS地图.DTO
{
    [Serializable]
    public class M图标显示参数
    {
        public string 名称 { get; set; }

        public string 描述 { get; set; }

        public bool 名称一直显示 { get; set; }

        public int 显示轨迹数 { get; set; }

        public Color 轨迹显示颜色 { get; set; }

        public Image 图片 { get; set; }

        public override string ToString()
        {
            return string.Format("名称:{0}", 名称);
        }

    }
}
