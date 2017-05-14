using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace 发射小火箭
{
    /// <summary>
    /// 可视化元素
    /// </summary>
    class VisualElement
    {
        public int X;
        public int Y;
        public readonly int Width;
        public readonly int Height;
        public Bitmap Bitmap;
        private int Speed;

        public VisualElement(Bitmap bitmap, int x,int y,int speed)
        {
            Bitmap = bitmap;
            X = x;
            Y = y;
            Width = bitmap .Width;
            Height = bitmap .Height ;
            Speed = speed;
        }

        public void Update()
        {
            X -= Speed;
            //throw new NotImplementedException();
        }

    }
}
