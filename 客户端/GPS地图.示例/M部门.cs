using System.Collections.Generic;
using System.Linq;

namespace GPS地图.示例
{
    public class M部门
    {
        public string 名称 { get; set; }

        public string 描述 { get; set; }

        public List<M个号> 个号列表 { get; set; }

        public List<M部门> 下属部门 { get; set; }

        public M部门()
        {
            this.个号列表 = new List<M个号>();
            this.下属部门 = new List<M部门>();
        }

        public List<M个号> 含嵌套个号列表
        {
            get
            {
                return 查询嵌套个号(this);
            }
        }

        private static List<M个号> 查询嵌套个号(M部门 部门)
        {
            var __结果 = new List<M个号>();
            if (部门.个号列表 != null && 部门.个号列表.Count > 0)
            {
                __结果.AddRange(部门.个号列表);
            }

            if (部门.下属部门 != null && 部门.下属部门.Count > 0)
            {
                部门.下属部门.ForEach(q => __结果.AddRange(查询嵌套个号(q)));
            }
            return __结果.Distinct().ToList();
        }

        public override string ToString()
        {
            return string.Format("(M部门){0}", 名称);
        }

        public override bool Equals(object obj)
        {
            var __部门 = obj as M部门;
            if (__部门 != null)
            {
                return __部门.名称 == this.名称;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.名称.GetHashCode();
        }

    }
}
