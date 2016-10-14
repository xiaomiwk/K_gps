using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO;
using DTO.订阅;
using Utility.WindowsForm;

namespace GPS地图.示例.数据分析
{
    public partial class F查询活跃号码 : UserControlK
    {
        private List<string> _列表;

        public F查询活跃号码(List<string> __列表)
        {
            _列表 = __列表;
            InitializeComponent();
            this.out总数.Text = string.Format("总数: {0}", __列表.Count);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            for (int i = 0; i < _列表.Count; i++)
            {
                this.out号码列表.Rows.Add(_列表[i]);
            }

        }
    }
}
