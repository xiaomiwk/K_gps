using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GPS地图.IBLL;
using Utility.通用;
using 显示地图;

namespace GPS地图.View
{
    public partial class F纯地图 : F控件
    {
        public F地图 地图 { get; private set; }

        public F纯地图()
        {
            H接口注册.设置();
            InitializeComponent();
            this.地图 = new F地图 { Dock = DockStyle.Fill };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.Controls.Add(地图);
            显示等待("加载地图");
            加载地图(H容器.取出<IB地图路径配置>().查询());
            隐藏等待();
        }

        void 加载地图(Dictionary<string, bool> __地图路径列表)
        {
            if (__地图路径列表.Count == 0)
            {
                显示失败("请拷贝地图文件到程序目录的\"离线地图\"目录!");
            }
            else if (!__地图路径列表.Values.ToList().Contains(true))
            {
                显示失败("请配置地图路径!");
            }
            else
            {
                try
                {
                    var __列表 = new List<string>();
                    foreach (var kv in __地图路径列表)
                    {
                        if (kv.Value)
                        {
                            __列表.Add(kv.Key);
                        }
                    }
                    if (__列表.Count > 1)
                    {
                        var __切换 = new FDemo切换
                        {
                            Anchor = AnchorStyles.Top | AnchorStyles.Right,
                            Left = this.Width - 40,
                            Top = 5
                        };
                        this.Controls.Add(__切换);
                        __切换.BringToFront();
                        __切换.初始化(地图, __列表, 0);
                    }
                    地图.加载地图(__列表[0]);
                }
                catch (Exception ex)
                {
                    显示失败(ex.Message);
                }
            }
        }

    }
}
