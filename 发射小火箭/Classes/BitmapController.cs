using System.Drawing;
using System.Drawing.Drawing2D;

namespace 发射小火箭
{
    class BitmapController
    {
        /// <summary>
        /// 返回旋转任意角度后的图像
        /// </summary>
        /// <param name="BitmapRes">需要旋转处理的图像</param>
        /// <param name="Angle">旋转角度[单位：度]</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Bitmap GetRotateBitmap(Bitmap BitmapRes, float Angle)
        {
            Bitmap ReturnBitmap =new Bitmap(BitmapRes.Width, BitmapRes.Height);
            using (Graphics MyGraphics = Graphics.FromImage(ReturnBitmap)) {
                MyGraphics.SmoothingMode = SmoothingMode.HighQuality;
                MyGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                MyGraphics.TranslateTransform(BitmapRes.Width / 2, BitmapRes.Height / 2);
                MyGraphics.RotateTransform(Angle, MatrixOrder.Prepend);

                MyGraphics.TranslateTransform(-BitmapRes.Width / 2, -BitmapRes.Height / 2);
                MyGraphics.DrawImage(BitmapRes, 0, 0, BitmapRes.Width, BitmapRes.Height);
            }
            return ReturnBitmap;
        }

        /// <summary>
        /// 合并图层
        /// </summary>
        /// <param name="Background"></param>
        /// <param name="Cover"></param>
        /// <returns></returns>
        public static Bitmap MergeBitmaps(Bitmap Background, Bitmap Cover)
        {
            using (Graphics MergeGraphics = Graphics.FromImage(Background))
            {
                MergeGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                MergeGraphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                MergeGraphics.DrawImage(Cover,0,0);
            }
            return Background;
        }
    }
}
