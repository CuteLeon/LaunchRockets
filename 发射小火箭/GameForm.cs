using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 发射小火箭
{
    //TODO:发射时加火焰和烟雾
    public partial class GameForm : Form
    {
        public static GameForm MainForm;
        /// <summary>
        /// 记录小火箭列表
        /// </summary>
        Rockets RocketList;
        Map GameMap;

        public GameForm()
        {
            MainForm = this;
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.Selectable, true);
            this.Icon = (Icon)Resources.RocketResource.LaunchRocket;
            this.SetBounds(0, 0, Screen.FromHandle(this.Handle).Bounds.Width, Screen.FromHandle(this.Handle).Bounds.Height);
            RocketList=new Rockets(this.ClientSize);
            GameMap = new Map(this.ClientSize);
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = BitmapController.MergeBitmaps(GameMap.CreateNewMap(), RocketList.CreateNewRockets());
        }

        private void GameForm_MouseClick(object sender, MouseEventArgs e)
        {
            this.BackgroundImage.Dispose();
            this.BackgroundImage =BitmapController.MergeBitmaps( GameMap.CreateNewMap(), RocketList.CreateNewRockets());
        }

        private void GameEngine_Tick(object sender, EventArgs e)
        {
            this.BackgroundImage.Dispose();
            this.BackgroundImage = BitmapController.MergeBitmaps(GameMap.UpdateMap(), RocketList.UpdateRockets());
            //this.CreateGraphics().Clear(Color.Black);
            //this.CreateGraphics().DrawImageUnscaled(GameMap .UpdateMap (),0,0);
            //this.CreateGraphics().DrawImageUnscaled(RocketList.UpdateRockets (), 0, 0);
            GC.Collect();
        }

        private void FPSTrackBar_Scroll(object sender, EventArgs e)
        {
            GameEngine.Interval = FPSTrackBar.Value;
        }
    }
}
