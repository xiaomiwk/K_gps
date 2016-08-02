using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility.通用;

namespace GIS服务器
{
    public interface ID数据库
    {
        [NoLog]
        bool 连接SQLSERVER(string __账号, string __密码, string __数据源);

        [NoLog]
        bool 存在GIS数据库(string __账号, string __密码, string __数据源, string __数据库名称);

        void 创建数据库(string __账号, string __密码, string __数据源, string __数据库名称, string __路径);

        void 删除数据库(string __账号, string __密码, string __数据源, string __数据库名称);
    }
}
