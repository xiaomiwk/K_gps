using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPS地图.示例
{
    public class M组号 : IComparable<M组号>
    {
        public int 号码 { get; set; }

        public string 名称 { get; set; }

        public Dictionary<string, string> 参数 { get; set; }

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
            var __组号 = obj as M组号;
            if (__组号 != null)
            {
                return 号码 == __组号.号码;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 号码.GetHashCode();
        }

        public int CompareTo(M组号 other)
        {
            return this.号码.CompareTo(other.号码);
        }
    }

}
