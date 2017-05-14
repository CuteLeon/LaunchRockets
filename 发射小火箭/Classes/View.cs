using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace 发射小火箭
{
    /// <summary>
    /// 视图基类
    /// </summary>
    class View
    {
        /// <summary>
        /// 世界的尺寸
        /// </summary>
        protected readonly Size in_WorldSize;
        /// <summary>
        /// 世界的地面高度
        /// </summary>
        protected readonly int GroundTop;

        public View(Size WorldSize)
        {
            in_WorldSize = WorldSize;
            GroundTop = (int)(in_WorldSize.Height * 0.9);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
