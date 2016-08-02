using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility.Windows;
using Utility.WindowsForm;
using Utility.存储;
using Utility.扩展;
using Utility.通用;

namespace GIS服务器.服务管理
{
    public partial class F数据库 : UserControl
    {
        private static IB数据库 _IB数据库 = H容器.取出<IB数据库>();

        public F数据库()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var __内存数据库 = H程序配置.获取Bool值("内存数据库");
            this.in内存数据库.Checked = __内存数据库;
            this.inMSSQLSERVER.Checked = !__内存数据库;

            this.inMSSQLSERVER.CheckedChanged += InMSSQLSERVER_CheckedChanged;
            this.doSQLServer检测.Click += (sender1, e1) => this.outSQL状态.Text = 检测SQLServer();
            this.do保存.Click += do保存_Click;
            this.doGIS检测.Click += (sender1, e1) => this.outGIS状态.Text = 检测GIS数据库();
            this.doGIS创建.Click += doGIS创建_Click;
            this.doGIS删除.Click += doGIS删除_Click;

            刷新MSSQLSERVER显示();
        }

        private void InMSSQLSERVER_CheckedChanged(object sender, EventArgs e)
        {
            刷新MSSQLSERVER显示();
            H程序配置.设置("内存数据库", this.in内存数据库.Checked.ToString());
        }

        private void 刷新MSSQLSERVER显示()
        {
            this.outMSSQLSERVER.Visible = this.inMSSQLSERVER.Checked;
            if (this.inMSSQLSERVER.Checked)
            {
                this.inSQL密码.Text = _IB数据库.密码;
                this.inSQL名称.Text = _IB数据库.地址;
                this.inSQL账号.Text = _IB数据库.账号;
                this.inGIS名称.Text = _IB数据库.名称;
                this.doSQLServer检测.PerformClick();
                this.doGIS检测.PerformClick();
            }
        }

        void do保存_Click(object sender, EventArgs e)
        {
            var __密码 = this.inSQL密码.Text;
            var __数据源 = this.inSQL名称.Text;
            var __账号 = this.inSQL账号.Text;
            _IB数据库.保存连接参数(__账号, __密码, __数据源);
        }

        void doGIS创建_Click(object sender, EventArgs e)
        {
            try
            {
                if (_IB数据库.检测GIS数据库())
                {
                    new F对话框_确定("GIS数据库已经存在").ShowDialog();
                    return;
                }

                var __数据源 = this.inSQL名称.Text;
                if (__数据源.StartsWith(".") || __数据源.StartsWith("127.0.0.1") || H网络配置.获取可用IP().Exists(q => __数据源.StartsWith(q.ToString())))
                {
                    new F对话框_确定("请选择GIS数据库文件存放路径").ShowDialog();
                    var __对话框 = new FolderBrowserDialog();
                    if (__对话框.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    HUI线程.异步执行(this, () =>
                    {
                        //后台线程
                        _IB数据库.创建数据库(__对话框.SelectedPath);
                    }, () =>
                    {
                        //成功后UI更新
                        new F对话框_确定("新建GIS数据库成功").ShowDialog();
                        this.BeginInvoke(new Action(() => this.doGIS检测.PerformClick()));
                    }, ex =>
                    {
                        //失败后UI更新
                        new F对话框_确定("新建GIS数据库失败" + Environment.NewLine + ex.Message).ShowDialog();
                    });
                }
                else
                {
                    new F对话框_确定("只能在本机新建数据库").ShowDialog();
                }
            }
            catch (Exception ex)
            {
                new F对话框_确定("新建GIS数据库失败" + Environment.NewLine + ex.Message).ShowDialog();
            }
        }

        void doGIS删除_Click(object sender, EventArgs e)
        {
            if (new F对话框_是否("确定要删除GIS数据库吗? ").ShowDialog() == DialogResult.Yes)
            {
                _IB数据库.删除数据库();
                this.doGIS检测.PerformClick();
            }
        }

        private string 检测SQLServer()
        {
            try
            {
                var __密码 = this.inSQL密码.Text;
                var __数据源 = this.inSQL名称.Text;
                var __账号 = this.inSQL账号.Text;
                return _IB数据库.检测SQLSERVER(__账号, __密码, __数据源);
            }
            catch (Exception ex)
            {
                return "连接SQL SERVER失败! " + ex.Message;
            }
        }

        private string 检测GIS数据库()
        {
            try
            {
                var __密码 = this.inSQL密码.Text;
                var __数据源 = this.inSQL名称.Text;
                var __账号 = this.inSQL账号.Text;
                return _IB数据库.检测GIS数据库(__账号, __密码, __数据源);
            }
            catch (Exception ex)
            {
                return "连接GIS数据库失败! " + ex.Message;
            }
        }


    }
}
