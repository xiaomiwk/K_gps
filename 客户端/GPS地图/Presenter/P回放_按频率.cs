using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DTO;
using GPS地图.DTO;
using GPS地图.IBLL;
using GPS地图.IView;
using Utility.通用;

namespace GPS地图.Presenter
{
    public class P回放_按频率
    {
        private readonly IB回放_按频率 _IB回放 = H容器.取出<IB回放_按频率>();

        private IV回放 _IV回放;

        private M回放 _回放参数;

        public virtual void 处理视图(IV回放 视图, M回放 __回放参数)
        {
            _IV回放 = 视图;
            _回放参数 = __回放参数;
            _IV回放.显示等待();
            _IV_加载数据();
            _IV_配置事件();
            _IV回放.隐藏等待();
        }

        void _IV_加载数据()
        {
            _IV回放.显示等待("读取轨迹数据");
            if (_回放参数.位置.Count == 0)
            {
                _IV回放.显示失败("无轨迹数据");
                _IV回放.显示播放状态(E播放状态.不可用);
                return;
            }
            _IV回放.显示播放状态(E播放状态.初始化);
            _IV回放.显示等待("绘制轨迹数据");

            _IB回放.初始化(_回放参数.位置);
            var __静态轨迹 = new M静态轨迹 { 名称 = _回放参数.显示参数.名称, GPS = _回放参数.位置, 显示颜色 = _回放参数.静态轨迹颜色 };
            _IV回放.IV地图.添加静态轨迹(new List<M静态轨迹> { __静态轨迹 });
            _IV回放.显示实际时间(_IB回放.实际开始时间, _IB回放.实际结束时间);
            _IV回放.显示播放时间(_IB回放.实际开始时间);
            _IV回放.隐藏等待();

            _IV回放.接收GPS.参照时间 = () => _IB回放.当前时间;
        }

        void _IV_配置事件()
        {
            _IV回放.播放 += _IV_播放;
            _IV回放.改变播放参数 += 倍速 => _IB回放.改变播放参数(倍速);
            _IV回放.停止 += _IB回放.停止;
            _IV回放.暂停 += _IB回放.暂停;
            _IV回放.已关闭 += _IV_已关闭;

            _IB回放.播放进度变化 += 进度 => _IV回放.显示播放进度(进度);
            _IB回放.播放状态变化 += 播放状态 => _IV回放.显示播放状态(播放状态);
            _IB回放.当前时间变化 += 时间 => _IV回放.显示播放时间(时间);
            _IB回放.位置更新 += _IB回放_位置更新;
        }

        protected virtual void _IV_已关闭()
        {
            _IB回放.位置更新 -= _IB回放_位置更新;
        }

        void _IB回放_位置更新(MGPS __GPS)
        {
            _IV回放.UI线程执行(() =>
            {
                _IV回放.接收GPS.增加(_回放参数.显示参数.名称, __GPS);
            });
        }

        protected virtual void _IV_播放(int 速度)
        {
            _IV回放.IV地图.删除所有图标();
            _IB回放.播放(速度);
        }

    }
}
