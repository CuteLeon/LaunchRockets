using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace 发射小火箭
{
    /// <summary>
    /// 小火箭
    /// </summary>
    class Rocket:IMove,IPathPoint
    {
        /// <summary>
        /// 小火箭的所有种类总数
        /// </summary>
        public static int RocketTypeCount = 87;
        /// <summary>
        /// 小火箭图像默认宽度
        /// </summary>
        public static int DefaultWidth = 80;
        /// <summary>
        /// 小火箭的宽度
        /// </summary>
        public readonly int Width;
        /// <summary>
        /// 小火箭的高度
        /// </summary>
        public readonly int Height;
        /// <summary>
        /// 小火箭的图像
        /// </summary>
        public readonly Bitmap RocketImage;
        /// <summary>
        /// 小火箭的坐标
        /// </summary>
        public Point Location;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Rocket(string RocketImageName,Point location)
        {
            Bitmap TempRocketImage = (Bitmap)RocketResource.ResourceManager.GetObject(RocketImageName);
            if (TempRocketImage == null) throw new Exception("无法获取 名称:[" + RocketImageName + "] 指代的图像资源。");
            Width =new Random().Next((int)(DefaultWidth* 0.6), TempRocketImage.Width+1);
            Height = TempRocketImage.Height * Width/DefaultWidth;
            RocketImage = new Bitmap(TempRocketImage, Width, Height);
            TempRocketImage.Dispose();
            Location = location;
            Debug.Print("New "
                            + RocketImageName 
                            + " : ("+Location.X.ToString() + "," + Location.Y+ ")"
                            + " ("+ Width+"x"+Height+")");
        }

        public void Move()
        {
            //throw new NotImplementedException();
            Location.X += 5;
        }

        public void CreateBezierPoints()
        {
            //throw new NotImplementedException();
            //最后一个路径点需要在屏幕边缘，撞击边缘，小火箭炸毁
        }
    }
}
