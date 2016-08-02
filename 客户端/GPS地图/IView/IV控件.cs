using System;

namespace GPS地图.IView
{
    public interface IV控件
    {
        event Action 已关闭;

        void 显示等待(string 内容 = null);

        void 隐藏等待();

        void 显示成功(string 概要内容, string 详细内容 = null);

        void 显示失败(string 概要内容, string 详细内容 = null);

        void UI线程执行(Action 执行);

    }
}
