using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GPS地图.View.配置
{
    public partial class F配置_地图路径 : UserControl
    {
        private Dictionary<string, string> _文件名映射 = new Dictionary<string, string>();

        public F配置_地图路径()
        {
            InitializeComponent();
        }

        public void 设置(Dictionary<string, bool> 路径)
        {
            foreach (var kv in 路径)
            {
                var __文件名 = Path.GetFileNameWithoutExtension(kv.Key);
                _文件名映射[__文件名] = kv.Key;
                this.in地图路径列表.Items.Add(__文件名, kv.Value);
            }
        }

        public List<string> 获取()
        {
            return this.in地图路径列表.CheckedItems.Cast<string>().Select(q => _文件名映射[q]).ToList();
        }
    }
}
