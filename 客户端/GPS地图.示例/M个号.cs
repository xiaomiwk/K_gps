using System;

namespace GPS地图.示例
{
    public class M个号 : IComparable<M个号>
    {
        public int 号码 { get; set; }

        public string 名称 { get; set; }

        public string 部门 { get; set; }

        public string 职务 { get; set; }

        public string 手机 { get; set; }

        public string 警种 { get; set; }

        public string 警号 { get; set; }

        public string 厂商 { get; set; }

        public string 型号 { get; set; }

        public string 备注 { get; set; }

        public void 浅复制(M个号 __源)
        {
            this.号码 = __源.号码;
            this.名称 = __源.名称;
            this.部门 = __源.部门;
            this.职务 = __源.职务;
            this.手机 = __源.手机;
            this.警种 = __源.警种;
            this.警号 = __源.警号;
            this.厂商 = __源.厂商;
            this.型号 = __源.型号;
            this.备注 = __源.备注;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(名称))
            {
                return string.Format("{0}({1})", 名称.Trim(), 号码);
            }
            return 号码.ToString();
        }

        public override bool Equals(object obj)
        {
            var __个号 = obj as M个号;
            if (__个号 != null)
            {
                return 号码 == __个号.号码;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 号码.GetHashCode();
        }

        public int CompareTo(M个号 other)
        {
            return this.号码.CompareTo(other.号码);
        }
    }

}
