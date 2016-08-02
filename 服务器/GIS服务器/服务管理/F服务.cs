using System;
using System.ServiceProcess;
using System.Windows.Forms;
using Utility.Windows;
using Utility.通用;

namespace GIS服务器.服务管理
{
    public partial class F服务 : UserControl
    {
        private enum E基本状态
        {
            未安装, 未启动, 已启动
        }
        private E基本状态? _当前状态;

        private F服务_未安装 _未安装;

        private F服务_未启动 _未启动;

        private F服务_已启动 _已启动;

        public F服务()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _未安装 = new F服务_未安装(刷新) { Dock = DockStyle.Fill };
            _未启动 = new F服务_未启动(刷新) { Dock = DockStyle.Fill };
            _已启动 = new F服务_已启动(刷新) { Dock = DockStyle.Fill };
            this.u容器1.添加控件(_未安装);
            this.u容器1.添加控件(_未启动);
            this.u容器1.添加控件(_已启动);

            this.u容器1.激活控件(_未安装);

            刷新();

            this.timer1.Interval = 3000;
            this.timer1.Tick += timer1_Tick;
            this.timer1.Start();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            刷新();
        }

        private void 刷新()
        {
            try
            {
                var __状态 = 查询服务状态();
                if (_当前状态 == __状态)
                {
                    return;
                }
                _当前状态 = __状态;
                switch (__状态)
                {
                    case E基本状态.未安装:
                        this.u容器1.激活控件(_未安装);
                        break;
                    case E基本状态.未启动:
                        this.u容器1.激活控件(_未启动);
                        break;
                    case E基本状态.已启动:
                        this.u容器1.激活控件(_已启动);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception ex)
            {
                H调试.记录异常(ex);
            }
        }

        E基本状态 查询服务状态()
        {
            ServiceControllerStatus __状态;
            try
            {
                __状态 = H服务管理.查询状态(Program.服务名);
            }
            catch (M预计异常)
            {
                return E基本状态.未安装;
            }
            catch (Exception ex)
            {
                H调试.记录异常(ex);
                throw new M预计异常("查询服务状态失败：{0}", ex.Message);
            }
            switch (__状态)
            {
                case ServiceControllerStatus.StartPending:
                case ServiceControllerStatus.Running:
                    return E基本状态.已启动;
                case ServiceControllerStatus.StopPending:
                case ServiceControllerStatus.Stopped:
                    return E基本状态.未启动;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    }
}
