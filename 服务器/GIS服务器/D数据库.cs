using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using Utility.任务;
using Utility.通用;

namespace GIS服务器
{
    public class D数据库_内存 : ID数据库
    {
        [NoLog]
        public bool 连接SQLSERVER(string __账号, string __密码, string __数据源) {
            return true;
        }

        [NoLog]
        public bool 存在GIS数据库(string __账号, string __密码, string __数据源, string __数据库名称)
        {
            return true;
        }

        public void 创建数据库(string __账号, string __密码, string __数据源, string __数据库名称, string __路径)
        {
        }

        public void 删除数据库(string __账号, string __密码, string __数据源, string __数据库名称)
        {
        }
    }

    public class D数据库 : ID数据库
    {
        private readonly string _创建数据库 = @"
USE [master];

CREATE DATABASE [{0}]
	ON
	PRIMARY ( NAME = N'{0}_Data', FILENAME = N'{1}\{0}.mdf' , SIZE = 50MB, MAXSIZE = UNLIMITED, FILEGROWTH = 50MB)
	LOG ON  ( NAME = N'{0}_Log', FILENAME = N'{1}\{0}_Log.ldf' , SIZE = 50MB, MAXSIZE = 10GB, FILEGROWTH = 50MB);

ALTER DATABASE [{0}]
	SET RECOVERY SIMPLE
	WITH ROLLBACK IMMEDIATE;

ALTER DATABASE [{0}]
	SET AUTO_CLOSE OFF 
	WITH ROLLBACK IMMEDIATE;
";
        private readonly string _删除数据库 = @"
USE [master];

DROP DATABASE [{0}];

";

        static SqlConnectionStringBuilder 生成连接字符串(string __账号, string __密码, string __数据源)
        {
            return new SqlConnectionStringBuilder
            {
                DataSource = __数据源,
                UserID = __账号,
                Password = __密码,
                InitialCatalog = "master",
                IntegratedSecurity = false,
                UserInstance = false,
            };
        }

        [NoLog]
        public bool 连接SQLSERVER(string __账号, string __密码, string __数据源)
        {
            var __字符串 = 生成连接字符串(__账号, __密码, __数据源).ToString();
            try
            {
                return H限时执行.执行(() =>
                {
                    using (var __连接 = new SqlConnection(__字符串))
                    {
                        H限时执行.执行(() => __连接.Open(), 5000);
                        return true;
                    }
                }, 5000);
            }
            catch (Exception ex)
            {
                H日志.记录提示(__字符串, ex.Message);
                return false;
            }
        }

        [NoLog]
        public bool 存在GIS数据库(string __账号, string __密码, string __数据源, string __数据库名称)
        {
            var __字符串 = 生成连接字符串(__账号, __密码, __数据源).ToString();
            try
            {
                return H限时执行.执行(() =>
                {
                    using (var __连接 = new SqlConnection(__字符串))
                    {
                        __连接.Open();
                        return new SqlCommand("select * from [master].[dbo].[sysdatabases] where [name]='" + __数据库名称 + "'", __连接).ExecuteScalar() != null;
                    }
                }, 5000);
            }
            catch (Exception ex)
            {
                H日志.记录提示(__字符串, ex.Message);
                return false;
            }
        }

        public  void 创建数据库(string __账号, string __密码, string __数据源, string __数据库名称, string __路径)
        {
            using (var __连接 = new SqlConnection(生成连接字符串(__账号, __密码, __数据源).ToString()))
            {
                var __sql = string.Format(_创建数据库, __数据库名称, __路径);
                using (var __命令 = new SqlCommand(__sql, __连接))
                {
                    __连接.Open();
                    __命令.ExecuteNonQuery();
                }
            }
        }

        public  void 删除数据库(string __账号, string __密码, string __数据源, string __数据库名称)
        {
            try
            {
                var __sql = String.Format(_删除数据库, __数据库名称);
                using (var __连接 = new SqlConnection(生成连接字符串(__账号, __密码, __数据源).ToString()))
                {
                    using (var __命令 = new SqlCommand(__sql, __连接))
                    {
                        __连接.Open();
                        __命令.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("删除数据库失败", ex);
            }
        }



    }
}
