using System;
using System.Drawing;

namespace 发射小火箭
{
    /// <summary>
    /// 小火箭
    /// </summary>
    class Rocket: Interfaces.IRocketMove
    {
        /// <summary>
        /// 小火箭的所有种类总数
        /// </summary>
        public static int RocketTypeCount = 29;
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
        private readonly Bitmap IniBitmap;
        /// <summary>
        /// 小火箭的图像
        /// </summary>
        public Bitmap RocketImage;
        /// <summary>
        /// 小火箭的坐标
        /// </summary>
        public PointF Location;
        /// <summary>
        /// 样条曲线路径点
        /// </summary>
        public PointF[] CurvePoints;
        /// <summary>
        /// 当前坐标的序号
        /// </summary>
        private int in_PointIndex = 0;

        public int PointIndex
        {
            get{return in_PointIndex;}
            set{
                in_PointIndex = value;
                if (in_PointIndex>0 && in_PointIndex + 1 < CurvePoints.Length)
                {
                    this.Location = CurvePoints[PointIndex];
                    float Angle = (float)Math.Atan2(CurvePoints[in_PointIndex - 1].X - CurvePoints[in_PointIndex + 1].X,CurvePoints[in_PointIndex - 1].Y - CurvePoints[in_PointIndex + 1].Y);
                    Angle = (float)(-Angle / (2 * Math.PI) * 360);

                    this.RocketImage = BitmapController.GetRotateBitmap(IniBitmap, Angle);
                }
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Rocket(string RocketImageName,Point location,int PointIndex)
        {
            Bitmap TempRocketImage = (Bitmap)Resources.RocketResource.ResourceManager.GetObject(RocketImageName);
            Width =new Random().Next((int)(DefaultWidth* 0.6), TempRocketImage.Width+1);
            Height = TempRocketImage.Height * Width/DefaultWidth;
            RocketImage = new Bitmap(TempRocketImage, Width, Height);
            IniBitmap = new Bitmap(RocketImage);
            TempRocketImage.Dispose();
            Location =new Point ( location.X, location.Y-Height);
            in_PointIndex = PointIndex ;
        }

        public void Move()
        {
            PointIndex += 1;
            if (PointIndex < 0)
            {
                Location.X -= 3;
            }
        }
    }
}
