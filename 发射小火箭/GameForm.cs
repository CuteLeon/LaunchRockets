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

        public GameForm()
        {
            InitializeComponent();
            this.SetBounds(0, 0, Screen.FromHandle(this.Handle).Bounds.Width, Screen.FromHandle(this.Handle).Bounds.Height);
            RocketList=new Rockets(this.ClientSize);
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            Debug.Print( RocketList.ToString());
        }
    }
}
