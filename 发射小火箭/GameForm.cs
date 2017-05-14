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
    public partial class GameForm : Form
    {
        /// <summary>
        /// 记录小火箭列表
        /// </summary>
        Rockets RocketList;
        Map GameMap;

        public GameForm()
        {
            InitializeComponent();
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
            //return;
            this.BackgroundImage.Dispose();
            this.BackgroundImage = BitmapController.MergeBitmaps(GameMap.UpdateMap(), RocketList.UpdateRockets());
            GC.Collect();
        }
    }
}
