using System.Windows.Forms;

namespace GPS地图.View
{
    partial class F回放_按时间
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.out进度 = new System.Windows.Forms.TrackBar();
            this.in速度 = new System.Windows.Forms.ComboBox();
            this.out时间 = new System.Windows.Forms.Label();
            this.do停止 = new System.Windows.Forms.Button();
            this.do播放 = new System.Windows.Forms.Button();
            this.do暂停 = new System.Windows.Forms.Button();
            this.out地图 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.out进度)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.out进度);
            this.panel1.Controls.Add(this.in速度);
            this.panel1.Controls.Add(this.out时间);
            this.panel1.Controls.Add(this.do停止);
            this.panel1.Controls.Add(this.do播放);
            this.panel1.Controls.Add(this.do暂停);
            this.panel1.Location = new System.Drawing.Point(0, 647);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 49);
            this.panel1.TabIndex = 9;
            // 
            // out进度
            // 
            this.out进度.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out进度.BackColor = System.Drawing.Color.WhiteSmoke;
            this.out进度.Location = new System.Drawing.Point(125, 15);
            this.out进度.Name = "out进度";
            this.out进度.Size = new System.Drawing.Size(546, 45);
            this.out进度.TabIndex = 6;
            // 
            // in速度
            // 
            this.in速度.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.in速度.DisplayMember = "Text";
            this.in速度.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.in速度.ItemHeight = 20;
            this.in速度.Location = new System.Drawing.Point(806, 12);
            this.in速度.Name = "in速度";
            this.in速度.Size = new System.Drawing.Size(139, 28);
            this.in速度.TabIndex = 4;
            // 
            // out时间
            // 
            this.out时间.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.out时间.AutoSize = true;
            this.out时间.ForeColor = System.Drawing.Color.DimGray;
            this.out时间.Location = new System.Drawing.Point(691, 15);
            this.out时间.Name = "out时间";
            this.out时间.Size = new System.Drawing.Size(105, 20);
            this.out时间.TabIndex = 3;
            this.out时间.Text = "00-00 00:00:00";
            // 
            // do停止
            // 
            this.do停止.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(140)))), ((int)(((byte)(170)))));
            this.do停止.FlatAppearance.BorderSize = 0;
            this.do停止.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do停止.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.do停止.ForeColor = System.Drawing.Color.White;
            this.do停止.Location = new System.Drawing.Point(66, 8);
            this.do停止.Name = "do停止";
            this.do停止.Size = new System.Drawing.Size(30, 30);
            this.do停止.TabIndex = 1;
            this.do停止.Text = " █";
            this.do停止.UseVisualStyleBackColor = false;
            // 
            // do播放
            // 
            this.do播放.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(140)))), ((int)(((byte)(170)))));
            this.do播放.FlatAppearance.BorderSize = 0;
            this.do播放.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do播放.ForeColor = System.Drawing.Color.White;
            this.do播放.Location = new System.Drawing.Point(15, 8);
            this.do播放.Name = "do播放";
            this.do播放.Size = new System.Drawing.Size(30, 30);
            this.do播放.TabIndex = 0;
            this.do播放.Text = "▶";
            this.do播放.UseVisualStyleBackColor = false;
            // 
            // do暂停
            // 
            this.do暂停.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(140)))), ((int)(((byte)(170)))));
            this.do暂停.FlatAppearance.BorderSize = 0;
            this.do暂停.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do暂停.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.do暂停.ForeColor = System.Drawing.Color.White;
            this.do暂停.Location = new System.Drawing.Point(15, 8);
            this.do暂停.Name = "do暂停";
            this.do暂停.Size = new System.Drawing.Size(30, 30);
            this.do暂停.TabIndex = 7;
            this.do暂停.Text = " ‖";
            this.do暂停.UseVisualStyleBackColor = false;
            // 
            // out地图
            // 
            this.out地图.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out地图.Location = new System.Drawing.Point(0, 0);
            this.out地图.Name = "out地图";
            this.out地图.Size = new System.Drawing.Size(1000, 645);
            this.out地图.TabIndex = 10;
            // 
            // F回放_按时间
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.out地图);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F回放_按时间";
            this.Size = new System.Drawing.Size(1000, 696);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.out进度)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar out进度;
        public ComboBox in速度;
        public Label out时间;
        private Button do停止;
        private Button do播放;
        private System.Windows.Forms.Panel out地图;
        private Button do暂停;


    }
}
