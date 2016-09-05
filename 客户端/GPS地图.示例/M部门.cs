using System.Collections.Generic;
using System.Linq;

namespace GPS地图.示例
{
    public class M部门
    {
        public string 名称 { get; set; }

        public string 描述 { get; set; }

        public List<M个号> 个号列表 { get; set; }

        public List<M组号> 组号列表 { get; set; }

        public List<M部门> 下属部门 { get; set; }

        public M部门()
        {
            this.个号列表 = new List<M个号>();
            this.组号列表 = new List<M组号>();
            this.下属部门 = new List<M部门>();
        }

        internal List<M个号> 含嵌套个号列表
        {
            get
            {
                return 查询嵌套个号(this);
            }
        }

        internal List<M组号> 含嵌套组号列表
        {
            get
            {
                return 查询嵌套组号(this);
            }
        }

        internal List<M部门> 含嵌套部门列表
        {
            get
            {
                return 查询嵌套部门(this);
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

        private static List<M组号> 查询嵌套组号(M部门 部门)
        {
            var __结果 = new List<M组号>();
            if (部门.组号列表 != null && 部门.组号列表.Count > 0)
            {
                __结果.AddRange(部门.组号列表);
            }

            if (部门.下属部门 != null && 部门.下属部门.Count > 0)
            {
                部门.下属部门.ForEach(q => __结果.AddRange(查询嵌套组号(q)));
            }
            return __结果.Distinct().ToList();
        }

        private static List<M部门> 查询嵌套部门(M部门 部门)
        {
            var __结果 = new List<M部门>();
            if (部门.下属部门 != null && 部门.下属部门.Count > 0)
            {
                部门.下属部门.ForEach(q => __结果.AddRange(查询嵌套部门(q)));
            }
            return __结果.Distinct().ToList();
        }

    }
}
