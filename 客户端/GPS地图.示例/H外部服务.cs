using GPS;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Utility.存储;
using Utility.扩展;
using Utility.通用;

namespace GPS地图.示例
{
    static class H外部服务
    {
        static string _号码簿地址;

        static H外部服务()
        {
            _号码簿地址 = H程序配置.获取字符串("号码簿地址");
        }

        public static List<M部门> 获取部门()
        {
            var __webapi地址 = string.Format("http://{0}/numberbook.k", _号码簿地址);
            try
            {
                var __json = HttpClient.发送请求(__webapi地址, null, "GET", Encoding.UTF8);
                File.WriteAllText(H路径.获取绝对路径("部门数据.json", true), __json, Encoding.UTF8);
                return H序列化.FromJSON字符串<List<M部门>>(__json, false, 50000000) ?? new List<M部门>();
            }
            catch (Exception ex)
            {
                H日志.记录提示(string.Format("从webapi {0} 同步失败", __webapi地址), ex.Message);
            }
            if (!H路径.验证文件是否存在("部门数据.json", true))
            {
                //File.WriteAllText(H路径.获取绝对路径("部门数据.json", true), HJSON.序列化(H部门测试数据.部门列表), Encoding.UTF8);
                return new List<M部门>();
            }
            return H序列化.FromJSON字符串<List<M部门>>(File.ReadAllText(H路径.获取绝对路径("部门数据.json", true), Encoding.UTF8), false, 20000000) ?? new List<M部门>();
        }

        public static void 呼叫(string __号码, bool __组号码)
        {
            var __webapi地址 = string.Format("http://{0}/call.k", _号码簿地址);
            try
            {
                HttpClient.发送请求(__webapi地址, new Dictionary<string, string> { { "号码", __号码 }, { "组号码", __组号码.ToString() } }, "POST", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                H日志.记录提示(string.Format("从webapi {0} 呼叫失败", __webapi地址), ex.Message);
                throw new ApplicationException("呼叫失败，服务不存在");
            }
        }

        public static void 发短信(string __号码, bool __组号码, string __内容)
        {
            var __webapi地址 = string.Format("http://{0}/sendmessage.k", _号码簿地址);
            try
            {
                HttpClient.发送请求(__webapi地址, new Dictionary<string, string> { { "号码", __号码 }, { "组号码", __组号码.ToString() }, { "内容", __内容 } }, "POST", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                H日志.记录提示(string.Format("从webapi {0} 发短信失败", __webapi地址), ex.Message);
                throw new ApplicationException("发短信失败，服务不存在");
            }
        }

        public static void 立刻定位(string __号码)
        {
            try
            {
                BGPS应用.IT客户端.执行方法("NEOTRO.MNIS", "立刻上报", new Dictionary<string, string> { { "号码范围", __号码 }, { "类型", "有计划信道"} });
            }
            catch (Exception ex)
            {
                H日志.记录异常(ex);
                throw new ApplicationException("立刻定位失败，" + ex.Message);
            }
        }
    }
}
