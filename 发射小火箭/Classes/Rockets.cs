using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

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
        public Rockets(Size WorldSize):base(WorldSize){}

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
        private void CreateNewRocket()
        {
            try
            {
                string RocketImageName = "Rocket_" + new Random().Next(Rocket.RocketTypeCount).ToString();
                in_Rockets.Add(new Rocket(RocketImageName,new Point(new Random().Next(in_WorldSize.Width), GroundTop)));
            }
            catch (Exception ex) {
                Debug.Print("创建新的小火箭时出错："+ ex.Message);
            }
        }

        /// <summary>
        /// 更新所有小火箭的状态
        /// </summary>
        public void UpdateRockets()
        {
            foreach (Rocket rocket in GetRocketAlive())
            {
                rocket.Move();
            }
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

        public void CreateNewRockets()
        {
            in_Rockets = new List<Rocket>();
            int DrawXPoint = 0;
        }

    }
}
