using System.Collections.Generic;

namespace DTO
{
    public class M号码段
    {
        public int 起始 { get; set; }

        public int 结束 { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}", 起始, 结束);
        }

        public static string ToString(List<M号码段> __列表, bool __排序 = false)
        {
            if (__列表 == null || __列表.Count == 0)
            {
                return "";
            }
            if (__排序)
            {
                __列表 = new List<M号码段>(__列表);
                __列表.Sort((m, n) => m.起始.CompareTo(n.起始));
            }
            var __sb = new System.Text.StringBuilder();
            __列表.ForEach(q =>
            {
                if (q.起始 == q.结束)
                {
                    __sb.Append(q.起始).Append(",");
                }
                else
                {
                    __sb.AppendFormat("{0}-{1},", q.起始, q.结束);
                }
            });
            __sb.Remove(__sb.Length - 1, 1);
            return __sb.ToString();
        }

        public static List<M号码段> 转换(List<int> __号码列表, bool __排序 = false)
        {
            if (__号码列表 == null || __号码列表.Count == 0)
            {
                return new List<M号码段>();
            }
            if (__排序)
            {
                __号码列表 = new List<int>(__号码列表);
                __号码列表.Sort();
            }
            var __结果 = new List<M号码段>();
            var __当前 = new M号码段() { 起始 = __号码列表[0], 结束 = __号码列表[0] };
            __号码列表.ForEach(q =>
            {
                if (q > __当前.结束 + 1)
                {
                    __结果.Add(__当前);
                    __当前 = new M号码段 {起始 = q, 结束 = q};
                }
                else
                {
                    __当前.结束 = q;
                }
            });
            __结果.Add(__当前);
            return __结果;
        }

        public List<int> 转换()
        {
            var __结果 = new List<int>();
            for (int i = 起始; i <= 结束; i++)
            {
                __结果.Add(i);
            }
            return __结果;
        }

    }

}
