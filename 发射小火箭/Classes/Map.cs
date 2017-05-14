using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace 发射小火箭
{
    /// <summary>
    /// 绘制背景类
    /// </summary>
    class Map:View 
    {
        //TODO:绘制背景

        Random IndexRandom = new Random();
        List<VisualElement>[] VisualElementLists;
        private List<VisualElement> Buildings;
        private List<VisualElement> Trees;
        private List<VisualElement> Mountains;
        private List<VisualElement> Grounds;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="WorldSize">世界尺寸</param>
        public Map(Size WorldSize):base(WorldSize){
            Buildings = new List<VisualElement>();
            Trees = new List<VisualElement>();
            Mountains = new List<VisualElement>();
            Grounds = new List<VisualElement>();
            VisualElementLists = new List<VisualElement>[] { Mountains, Grounds, Buildings ,Trees};
        }

        /// <summary>
        /// 重置新的地图
        /// </summary>
        /// <returns></returns>
        public Bitmap CreateNewMap()
        {
            Buildings = new List<VisualElement>();
            Trees = new List<VisualElement>();
            Mountains = new List<VisualElement>();
            Grounds = new List<VisualElement>();
            VisualElementLists = new List<VisualElement>[] { Mountains, Grounds, Buildings, Trees };

            int DrawXPoint = 0;

            //创建地面可视化元素列表
            while (DrawXPoint < in_WorldSize.Width)
            {
                DrawXPoint = CreateNewGround(DrawXPoint);
            }

            //创建山可视化元素列表
            DrawXPoint = 0;
            while (DrawXPoint < in_WorldSize.Width)
            {
                DrawXPoint =CreateNewMountain(DrawXPoint);
            }

            //创建建筑可视化元素列表
            DrawXPoint = 0;
            while (DrawXPoint < in_WorldSize.Width)
            {
                DrawXPoint = CreateNewBuilding (DrawXPoint);
            }
            //创建树木可视化元素列表
            DrawXPoint = 0;
            while (DrawXPoint < in_WorldSize.Width)
            {
                DrawXPoint = CreateNewTree(DrawXPoint);
            }

            return DrawMap();
        }

        /// <summary>
        /// 更新地图
        /// </summary>
        /// <returns></returns>
        public Bitmap UpdateMap()
        {
            foreach (List<VisualElement> VisualElementList in VisualElementLists)
            {
                foreach (VisualElement Element in VisualElementList)
                {
                    Element.Update();
                }
                if (VisualElementList.Count > 0)
                    if (VisualElementList.First().X <= -VisualElementList.First().Width)
                        VisualElementList.RemoveAt(0);
            }
            if (Mountains.Count >0) if (Mountains.Last().X +Mountains.Last().Width<in_WorldSize .Width) CreateNewMountain (Mountains.Last().X + Mountains.Last().Width);
            if (Trees.Count > 0) if (Trees.Last().X + Trees.Last().Width < in_WorldSize.Width) CreateNewTree (Trees.Last().X + Trees.Last().Width);
            if (Buildings.Count > 0) if (Buildings.Last().X + Buildings.Last().Width < in_WorldSize.Width) CreateNewBuilding (Buildings.Last().X + Buildings.Last().Width);
            if (Grounds.Count > 0) if (Grounds.Last().X + Grounds.Last().Width < in_WorldSize.Width) CreateNewGround (Grounds.Last().X + Grounds.Last().Width);

            return DrawMap();
        }

        /// <summary>
        /// 根据数据绘制地图
        /// </summary>
        /// <returns></returns>
        public Bitmap DrawMap()
        {
            Bitmap Map = new Bitmap(Resources.EnvironmentResource.SkyGroundImage, in_WorldSize.Width, in_WorldSize.Height);
            using (Graphics MapGraphics = Graphics.FromImage(Map))
            {
                MapGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                MapGraphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                foreach (List<VisualElement> VisualElementList in VisualElementLists)
                {
                    foreach (VisualElement Element in VisualElementList)
                    {
                        MapGraphics.DrawImage(Element.Bitmap, Element.X, Element.Y, Element.Width, Element.Height);
                    }
                }

                MapGraphics.DrawString("  元素个数：", new Font("微软雅黑", 20), Brushes.DeepSkyBlue, new Point(100, 100));
                MapGraphics.DrawString("   山：" + Mountains.Count .ToString(),new Font ("微软雅黑",18,FontStyle.Bold),Brushes.DeepSkyBlue,new Point (120,150));
                MapGraphics.DrawString("建筑：" + Buildings.Count.ToString(), new Font("微软雅黑", 18, FontStyle.Bold), Brushes.DeepSkyBlue, new Point(120, 180));
                MapGraphics.DrawString("   树：" + Trees .Count.ToString(), new Font("微软雅黑", 18, FontStyle.Bold), Brushes.DeepSkyBlue, new Point(120, 210));
                MapGraphics.DrawString("   地：" + Grounds.Count.ToString(), new Font("微软雅黑", 18, FontStyle.Bold), Brushes.DeepSkyBlue, new Point(120, 240));
            }
            return Map;
        }

        private int CreateNewGround(int DrawXPoint)
        {
            Bitmap ObjectBitmap = new Bitmap(Resources.EnvironmentResource.Ground, Resources.EnvironmentResource.Ground.Width, in_WorldSize.Height - GroundTop);
            Grounds.Add(new VisualElement(ObjectBitmap, DrawXPoint, GroundTop, 15));
            return DrawXPoint+ObjectBitmap.Width;
        }

        private int CreateNewTree(int DrawXPoint)
        {
            DrawXPoint += IndexRandom.Next(IndexRandom.Next(500));
            Bitmap ObjectBitmap = (Bitmap)Resources.TreeResource.ResourceManager.GetObject("Tree_" + IndexRandom.Next(3).ToString());
            Trees.Add(new VisualElement(ObjectBitmap, DrawXPoint, GroundTop - ObjectBitmap.Height, 15));
            return DrawXPoint + ObjectBitmap .Width;
        }

        private int CreateNewBuilding(int DrawXPoint)
        {
            DrawXPoint += IndexRandom.Next(IndexRandom.Next(150));
            Bitmap ObjectBitmap = (Bitmap)Resources.BuildingResource.ResourceManager.GetObject("Building_" + IndexRandom.Next(5).ToString());
            Buildings.Add(new VisualElement(ObjectBitmap, DrawXPoint, GroundTop - ObjectBitmap.Height, 10));
            return DrawXPoint + ObjectBitmap.Width;
        }

        private int CreateNewMountain(int DrawXPoint)
        {
            DrawXPoint += IndexRandom.Next(IndexRandom.Next(100));
            Bitmap ObjectBitmap = (Bitmap)Resources.EnvironmentResource.ResourceManager.GetObject("Environment_" + IndexRandom.Next(2).ToString());
            Mountains.Add(new VisualElement(ObjectBitmap, DrawXPoint, GroundTop - ObjectBitmap.Height, 5));
            return DrawXPoint + ObjectBitmap.Width / 2;
        }
    }
}
