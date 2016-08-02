using System.Windows.Forms;

namespace GPS地图.View.配置
{
    partial class F配置_GPS状态
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.in无信号间隔 = new System.Windows.Forms.TextBox();
            this.labelX3 = new System.Windows.Forms.Label();
            this.in关机间隔 = new System.Windows.Forms.TextBox();
            this.labelX5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelX1 = new System.Windows.Forms.Label();
            this.labelX4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.in停止显示间隔 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // in无信号间隔
            // 
            this.in无信号间隔.Location = new System.Drawing.Point(135, 32);
            this.in无信号间隔.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.in无信号间隔.Name = "in无信号间隔";
            this.in无信号间隔.Size = new System.Drawing.Size(55, 23);
            this.in无信号间隔.TabIndex = 25;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.Location = new System.Drawing.Point(28, 32);
            this.labelX3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(95, 17);
            this.labelX3.TabIndex = 24;
            this.labelX3.Text = "短期未更新间隔:";
            // 
            // in关机间隔
            // 
            this.in关机间隔.Location = new System.Drawing.Point(135, 76);
            this.in关机间隔.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.in关机间隔.Name = "in关机间隔";
            this.in关机间隔.Size = new System.Drawing.Size(55, 23);
            this.in关机间隔.TabIndex = 28;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.Location = new System.Drawing.Point(28, 76);
            this.labelX5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(95, 17);
            this.labelX5.TabIndex = 27;
            this.labelX5.Text = "长期未更新间隔:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GPS地图.Properties.Resources.短期未更新;
            this.pictureBox1.Location = new System.Drawing.Point(236, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 30);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GPS地图.Properties.Resources.很久未更新;
            this.pictureBox2.Location = new System.Drawing.Point(236, 76);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 30);
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.Location = new System.Drawing.Point(198, 35);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(28, 17);
            this.labelX1.TabIndex = 32;
            this.labelX1.Text = "(秒)";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.Location = new System.Drawing.Point(198, 79);
            this.labelX4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(28, 17);
            this.labelX4.TabIndex = 33;
            this.labelX4.Text = "(秒)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 17);
            this.label1.TabIndex = 37;
            this.label1.Text = "(秒)";
            // 
            // in停止显示间隔
            // 
            this.in停止显示间隔.Location = new System.Drawing.Point(135, 120);
            this.in停止显示间隔.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.in停止显示间隔.Name = "in停止显示间隔";
            this.in停止显示间隔.Size = new System.Drawing.Size(55, 23);
            this.in停止显示间隔.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 120);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 35;
            this.label2.Text = "停止显示间隔:";
            // 
            // F配置_GPS更新状态
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.in停止显示间隔);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.in关机间隔);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.in无信号间隔);
            this.Controls.Add(this.labelX3);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FGPS更新状态";
            this.Size = new System.Drawing.Size(473, 291);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox in无信号间隔;
        public Label labelX3;
        private TextBox in关机间隔;
        public Label labelX5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        public Label labelX1;
        public Label labelX4;
        public Label label1;
        private TextBox in停止显示间隔;
        public Label label2;
    }
}
