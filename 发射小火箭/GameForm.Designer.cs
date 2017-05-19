namespace 发射小火箭
{
    partial class GameForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GameEngine = new System.Windows.Forms.Timer(this.components);
            this.ShowRocketCount = new System.Windows.Forms.CheckBox();
            this.ShowElementCount = new System.Windows.Forms.CheckBox();
            this.ShowPoints = new System.Windows.Forms.CheckBox();
            this.ShowPath = new System.Windows.Forms.CheckBox();
            this.FPSTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.FPSTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // GameEngine
            // 
            this.GameEngine.Enabled = true;
            this.GameEngine.Tick += new System.EventHandler(this.GameEngine_Tick);
            // 
            // ShowRocketCount
            // 
            this.ShowRocketCount.AutoSize = true;
            this.ShowRocketCount.BackColor = System.Drawing.Color.Transparent;
            this.ShowRocketCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowRocketCount.ForeColor = System.Drawing.Color.White;
            this.ShowRocketCount.Location = new System.Drawing.Point(62, 114);
            this.ShowRocketCount.Name = "ShowRocketCount";
            this.ShowRocketCount.Size = new System.Drawing.Size(125, 25);
            this.ShowRocketCount.TabIndex = 8;
            this.ShowRocketCount.Text = "显示火箭计数";
            this.ShowRocketCount.UseVisualStyleBackColor = false;
            // 
            // ShowElementCount
            // 
            this.ShowElementCount.AutoSize = true;
            this.ShowElementCount.BackColor = System.Drawing.Color.Transparent;
            this.ShowElementCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowElementCount.ForeColor = System.Drawing.Color.White;
            this.ShowElementCount.Location = new System.Drawing.Point(62, 85);
            this.ShowElementCount.Name = "ShowElementCount";
            this.ShowElementCount.Size = new System.Drawing.Size(125, 25);
            this.ShowElementCount.TabIndex = 7;
            this.ShowElementCount.Text = "显示元素计数";
            this.ShowElementCount.UseVisualStyleBackColor = false;
            // 
            // ShowPoints
            // 
            this.ShowPoints.AutoSize = true;
            this.ShowPoints.BackColor = System.Drawing.Color.Transparent;
            this.ShowPoints.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowPoints.ForeColor = System.Drawing.Color.White;
            this.ShowPoints.Location = new System.Drawing.Point(62, 56);
            this.ShowPoints.Name = "ShowPoints";
            this.ShowPoints.Size = new System.Drawing.Size(125, 25);
            this.ShowPoints.TabIndex = 6;
            this.ShowPoints.Text = "显示飞行坐标";
            this.ShowPoints.UseVisualStyleBackColor = false;
            // 
            // ShowPath
            // 
            this.ShowPath.AutoSize = true;
            this.ShowPath.BackColor = System.Drawing.Color.Transparent;
            this.ShowPath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowPath.ForeColor = System.Drawing.Color.White;
            this.ShowPath.Location = new System.Drawing.Point(62, 27);
            this.ShowPath.Name = "ShowPath";
            this.ShowPath.Size = new System.Drawing.Size(125, 25);
            this.ShowPath.TabIndex = 5;
            this.ShowPath.Text = "显示飞行路径";
            this.ShowPath.UseVisualStyleBackColor = false;
            // 
            // FPSTrackBar
            // 
            this.FPSTrackBar.Location = new System.Drawing.Point(11, 30);
            this.FPSTrackBar.Maximum = 200;
            this.FPSTrackBar.Minimum = 10;
            this.FPSTrackBar.Name = "FPSTrackBar";
            this.FPSTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.FPSTrackBar.Size = new System.Drawing.Size(45, 104);
            this.FPSTrackBar.TabIndex = 9;
            this.FPSTrackBar.TickFrequency = 10;
            this.FPSTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.FPSTrackBar.Value = 50;
            this.FPSTrackBar.Scroll += new System.EventHandler(this.FPSTrackBar_Scroll);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(693, 506);
            this.Controls.Add(this.FPSTrackBar);
            this.Controls.Add(this.ShowRocketCount);
            this.Controls.Add(this.ShowElementCount);
            this.Controls.Add(this.ShowPoints);
            this.Controls.Add(this.ShowPath);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发射小火箭——[发呆专用系列]";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.FPSTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer GameEngine;
        public System.Windows.Forms.CheckBox ShowRocketCount;
        public System.Windows.Forms.CheckBox ShowElementCount;
        public System.Windows.Forms.CheckBox ShowPoints;
        public System.Windows.Forms.CheckBox ShowPath;
        private System.Windows.Forms.TrackBar FPSTrackBar;
    }
}

