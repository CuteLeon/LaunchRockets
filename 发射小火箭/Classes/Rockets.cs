using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;

namespace 发射小火箭
{
    /// <summary>
    /// 火箭列表
    /// </summary>
    class Rockets:View
    {
        Random IndexRandom = new Random();
        /// <summary>
        /// 记录小火箭的列表
        /// </summary>
        private List<Rocket> in_Rockets = new List<Rocket>();

        /// <summary>
        /// 构造函数
        /// </summary>
        public Rockets(Size WorldSize):base(WorldSize){
            CreateNewRockets();
        }

        /// <summary>
        /// 小火箭索引器
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public Rocket this[int Index]
        {
            get {
                return in_Rockets[Index];}
        }

        /// <summary>
        /// 获取小火箭总数
        /// </summary>
        /// <returns>小火箭总数</returns>
        public int Count()
        {
            return in_Rockets.Count;
        }

        /// <summary>
        /// 覆写 ToString() 方法，输出小火箭总数
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "#################"
                    + "\n  世界尺寸："+ in_WorldSize.Width.ToString() + "x" + in_WorldSize.Height.ToString()
                    +"\n  小火箭数：" + in_Rockets.Count.ToString()
                    + "\n#################";
        }

        /// <summary>
        /// 构造新的小火箭加入小火箭列表
        /// </summary>
        private int CreateNewRocket(int DrawXPoint)
        {
            DrawXPoint += IndexRandom.Next(150);
            string RocketImageName = "Rocket_" + IndexRandom.Next(Rocket.RocketTypeCount).ToString();
            Rocket NewRocket = new Rocket(RocketImageName, new Point(DrawXPoint, GroundTop));
            //NewRocket.CurvePoints = new PointF[7];
            //NewRocket.CurvePoints[0] = new PointF(NewRocket.Location.X ,NewRocket.Location.Y);
            //for (int Index = 1; Index < 6; Index++)
            //    NewRocket.CurvePoints[Index] = new PointF(IndexRandom.Next(in_WorldSize.Width),IndexRandom.Next(GroundTop));
            //NewRocket.CurvePoints[6] = new PointF(IndexRandom.Next(in_WorldSize.Width), 0);

            NewRocket.CurvePoints = new PointF[5];
            NewRocket.CurvePoints[0] = new PointF(NewRocket.Location.X, in_WorldSize .Height );
            NewRocket.CurvePoints[1] = new PointF(NewRocket.Location.X, NewRocket.Location.Y);
            NewRocket.CurvePoints[2] = new PointF(IndexRandom.Next(in_WorldSize.Width),IndexRandom.Next(GroundTop));
            NewRocket.CurvePoints[3] = new PointF(IndexRandom.Next(in_WorldSize.Width), IndexRandom.Next(GroundTop));
            NewRocket.CurvePoints[4] = new PointF(IndexRandom.Next(in_WorldSize.Width), 0);
            NewRocket.CurvePoints = CreateBezierPoints(NewRocket.CurvePoints);
            in_Rockets.Add(NewRocket);
            return DrawXPoint + NewRocket.Width;
        }

        public Bitmap UpdateRockets()
        {
            Update();
            return DrawRockets();
        }

        /// <summary>
        /// 更新所有小火箭的状态
        /// </summary>
        public new void Update()
        {
            foreach(Rocket rocket in in_Rockets)
            {
                rocket.Move();
            }
            if (in_Rockets.Count > 0)
                in_Rockets.RemoveAll(rocket=>rocket.PointIndex>=rocket.CurvePoints.Length);

            if (in_Rockets.Count > 0) while (in_Rockets.Last().Location.X + in_Rockets.Last().Width < in_WorldSize.Width) CreateNewRocket((int)in_Rockets.Last().Location.X + in_Rockets.Last().Width);
        }

        /// <summary>
        /// 简单枚举器：用于过滤返回满足条件的对象
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Rocket> GetRocketAlive()
        {
            //in_Rockets.Where(rocket=>rocket.Location.Y>0 );
            foreach (Rocket rocket in in_Rockets)
            {
                //if()
                yield return rocket;
            }
        }

        public Bitmap CreateNewRockets()
        {
            in_Rockets = new List<Rocket>();
            int DrawXPoint = 0;
            while(DrawXPoint<in_WorldSize.Width)
                DrawXPoint = CreateNewRocket(DrawXPoint);

            return DrawRockets();
        }

        public Bitmap DrawRockets()
        {
            Bitmap Map = new Bitmap(in_WorldSize.Width,in_WorldSize.Height);
            using (Graphics MapGraphics = Graphics.FromImage(Map))
            {
                MapGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                MapGraphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                foreach (Rocket Element in in_Rockets)
                {
                    MapGraphics.DrawImage(Element.RocketImage, Element.Location.X, Element.Location.Y, Element.Width, Element.Height);
                    //Debug:显示路径和路径点
                    //MapGraphics.DrawCurve(Pens.Red, Element.CurvePoints);
                    //foreach (PointF P in Element.CurvePoints)
                    //    MapGraphics.FillEllipse(Brushes.Yellow, P.X, P.Y, 3, 3);
                }
                //Debug:显示火箭个数
                //MapGraphics.DrawString("火箭个数：" + in_Rockets.Count.ToString(), new Font("微软雅黑", 18, FontStyle.Bold), Brushes.DeepSkyBlue, new Point(100, 300));
            }
            return Map;
        }

        public PointF[] CreateBezierPoints(PointF[] KeyPoint)
        {
            PointF[] MyPoints = new PointF[] { };
            using (GraphicsPath MyGraphicsPath = new GraphicsPath())
            {
                MyGraphicsPath.AddCurve(KeyPoint, 1,3, (float)0.5);
                MyGraphicsPath.Flatten();
                MyPoints = MyGraphicsPath.PathPoints;
            }
            return MyPoints;
        }
    }
}
