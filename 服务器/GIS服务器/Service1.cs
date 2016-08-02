using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Utility.通用;
using 通用访问;

namespace GIS服务器
{
    partial class Service1 : ServiceBase
    {
        private B控制器 _B控制器 = new B控制器();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _B控制器.配置();
            _B控制器.开启();
        }

        protected override void OnStop()
        {
            _B控制器.关闭();
        }
    }
}
