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
            DrawXPoint += IndexRandom.Next(50);
            string RocketImageName = "Rocket_" + IndexRandom.Next(Rocket.RocketTypeCount).ToString();
            Rocket NewRocket = new Rocket(RocketImageName, new Point(DrawXPoint, GroundTop), -IndexRandom.Next(100, 200));
            
            NewRocket.CurvePoints = new PointF[6];
            NewRocket.CurvePoints[0] = new PointF(NewRocket.Location.X+NewRocket.PointIndex* 3, in_WorldSize.Height * 2);//x2:首个关键点放置在地下深处，使小火箭起飞时更自然
            NewRocket.CurvePoints[1] = new PointF(NewRocket.CurvePoints[0].X, NewRocket.Location.Y);//起飞点
            NewRocket.CurvePoints[2] = new PointF(IndexRandom.Next(in_WorldSize.Width),IndexRandom.Next(GroundTop));//随机关键点_1
            NewRocket.CurvePoints[3] = new PointF(IndexRandom.Next(in_WorldSize.Width), IndexRandom.Next(GroundTop));//随机关键点_2
            NewRocket.CurvePoints[4] = new PointF(IndexRandom.Next(in_WorldSize.Width), 0);//与上边界的交点，也是预计消失点
            NewRocket.CurvePoints[5] = new PointF(NewRocket.CurvePoints[4].X,-NewRocket.Height);//继续从消失点向上飞行，使消失更自然
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
            foreach(Rocket rocket in in_Rockets)//.Where(rocket=>rocket.Location.X<in_WorldSize.Width))
            {
                rocket.Move();
            }
            if (in_Rockets.Count > 0)
                in_Rockets.RemoveAll(rocket=>rocket.PointIndex>=rocket.CurvePoints.Length);

            if (in_Rockets.Count > 0) while (in_Rockets.Last().Location.X + in_Rockets.Last().Width < in_WorldSize.Width) CreateNewRocket((int)in_Rockets.Last().Location.X + in_Rockets.Last().Width);
        }

        public Bitmap CreateNewRockets()
        {
            in_Rockets = new List<Rocket>();
            int DrawXPoint = in_WorldSize.Width/2;
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
                    
                    if (GameForm.MainForm.ShowPath.Checked) MapGraphics.DrawCurve(Pens.Red, Element.CurvePoints);
                    if (GameForm.MainForm.ShowPoints.Checked)
                        foreach (PointF P in Element.CurvePoints)
                            MapGraphics.FillEllipse(Brushes.Yellow, P.X, P.Y, 3, 3);
                }
                
                if (GameForm.MainForm.ShowRocketCount.Checked) MapGraphics.DrawString("火箭个数：" + in_Rockets.Count.ToString(), new Font("微软雅黑", 18, FontStyle.Bold), Brushes.DeepSkyBlue, new Point(100, 300));
            }
            return Map;
        }

        public PointF[] CreateBezierPoints(PointF[] KeyPoint)
        {
            PointF[] MyPoints = new PointF[] { };
            using (GraphicsPath MyGraphicsPath = new GraphicsPath())
            {
                MyGraphicsPath.AddCurve(KeyPoint, 1,4, (float)0.5);
                MyGraphicsPath.Flatten();
                MyPoints = MyGraphicsPath.PathPoints;
            }
            return MyPoints;
        }
    }
}
