using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 发射小火箭
{
    /// <summary>
    /// 小火箭路径点
    /// </summary>
    interface IPathPoint
    {

        /// <summary>
        /// 创建贝塞尔曲线路径点
        /// </summary>
        void CreateBezierPoints();

    }
}
