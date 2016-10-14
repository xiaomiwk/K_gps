using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO;
using Utility.WindowsForm;
using DTO.GPS数据;

namespace GPS地图.示例.数据分析
{
    public partial class F查询最后位置 : UserControlK
    {
        private List<M号码位置> _列表;

        public F查询最后位置(List<M号码位置> __列表)
        {
            _列表 = __列表;
            InitializeComponent();
            this.out总数.Text = string.Format("总数: {0}", __列表.Count);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            foreach (var __kv in _列表)
            {
                this.out号码列表.Rows.Add(__kv.号码, __kv.GPS.经度, __kv.GPS.纬度, __kv.GPS.时间);
            }
        }
    }
}
