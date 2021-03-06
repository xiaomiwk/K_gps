﻿using System;
using System.Collections.Generic;

namespace GPS地图.示例
{
    public class M个号 : IComparable<M个号>
    {
        public int 号码 { get; set; }

        public string 名称 { get; set; }

        //public string 部门 { get; set; }

        //public string 职务 { get; set; }

        //public string 手机 { get; set; }

        //public string 警种 { get; set; }

        //public string 警号 { get; set; }

        //public string 厂商 { get; set; }

        //public string 型号 { get; set; }

        //public string 备注 { get; set; }

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
