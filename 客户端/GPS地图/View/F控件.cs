using System;
using System.Windows.Forms;
using GPS地图.IView;
using Utility.WindowsForm;

namespace GPS地图.View
{
    public class F控件 : UserControl, IV控件
    {
        private F等待 _等待窗口;

        public F控件()
        {
            this.Disposed += F控件基类_Disposed;
        }

        void F控件基类_Disposed(object sender, EventArgs e)
        {
            On已关闭();
        }

        #region IV控件

        public event Action 已关闭;

        protected virtual void On已关闭()
        {
            Action handler = 已关闭;
            if (handler != null) handler();
        }

        public virtual void 显示等待(string 内容 = null)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(显示等待), 内容);
                return;
            }
            if (_等待窗口 != null)
            {
                _等待窗口.提示 = 内容;
                return;
            }
            _等待窗口 = new F等待 { 提示 = 内容 };
            this.创建局部覆盖控件(_等待窗口, null);
        }

        public virtual void 隐藏等待()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(隐藏等待));
                return;
            }
            if (_等待窗口 == null)
            {
                return;
            }
            _等待窗口.隐藏();
            _等待窗口 = null;
        }

        public virtual void 显示成功(string 概要内容, string 详细内容 = null)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string, string>(显示成功), 概要内容, 详细内容);
                return;
            }
            new F对话框_确定(概要内容, "操作成功").ShowDialog();
        }

        public virtual void 显示失败(string 概要内容, string 详细内容 = null)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string, string>(显示失败), 概要内容, 详细内容);
                return;
            }
            new F对话框_确定(概要内容, "操作失败").ShowDialog(); ;
        }

        public void UI线程执行(Action 方法)
        {
            if (!this.Created || this.Disposing || this.IsDisposed)
            {
                return;
            }
            try
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(方法);
                }
                else
                {
                    方法();
                }
            }
            catch (ObjectDisposedException)
            {
            }
        }

        #endregion

    }
}
