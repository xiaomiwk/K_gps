using Utility.WindowsForm;

namespace GPS地图.示例
{
    partial class F按时间回放
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
            this.label9 = new System.Windows.Forms.Label();
            this.do查询 = new Utility.WindowsForm.U按钮();
            this.out显示号码 = new System.Windows.Forms.Panel();
            this.in显示轨迹 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.in开始时间 = new System.Windows.Forms.DateTimePicker();
            this.in结束时间 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.in日期 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.in号码列表 = new Utility.WindowsForm.TextBoxK();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "号码列表";
            // 
            // do查询
            // 
            this.do查询.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do查询.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do查询.FlatAppearance.BorderSize = 0;
            this.do查询.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do查询.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do查询.Location = new System.Drawing.Point(809, 2);
            this.do查询.Name = "do查询";
            this.do查询.Size = new System.Drawing.Size(100, 26);
            this.do查询.TabIndex = 36;
            this.do查询.Text = "查询";
            this.do查询.UseVisualStyleBackColor = false;
            this.do查询.大小 = new System.Drawing.Size(100, 26);
            this.do查询.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do查询.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // out显示号码
            // 
            this.out显示号码.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out显示号码.Location = new System.Drawing.Point(9, 32);
            this.out显示号码.Name = "out显示号码";
            this.out显示号码.Size = new System.Drawing.Size(988, 625);
            this.out显示号码.TabIndex = 50;
            // 
            // in显示轨迹
            // 
            this.in显示轨迹.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.in显示轨迹.AutoSize = true;
            this.in显示轨迹.Location = new System.Drawing.Point(921, 7);
            this.in显示轨迹.Name = "in显示轨迹";
            this.in显示轨迹.Size = new System.Drawing.Size(75, 21);
            this.in显示轨迹.TabIndex = 59;
            this.in显示轨迹.Text = "显示轨迹";
            this.in显示轨迹.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(591, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 68;
            this.label3.Text = "时间";
            // 
            // in开始时间
            // 
            this.in开始时间.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.in开始时间.CustomFormat = "HH:mm";
            this.in开始时间.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.in开始时间.Location = new System.Drawing.Point(628, 3);
            this.in开始时间.Name = "in开始时间";
            this.in开始时间.ShowUpDown = true;
            this.in开始时间.Size = new System.Drawing.Size(60, 23);
            this.in开始时间.TabIndex = 67;
            this.in开始时间.Value = new System.DateTime(2016, 10, 8, 0, 0, 0, 0);
            // 
            // in结束时间
            // 
            this.in结束时间.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.in结束时间.CustomFormat = "HH:mm";
            this.in结束时间.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.in结束时间.Location = new System.Drawing.Point(713, 3);
            this.in结束时间.Name = "in结束时间";
            this.in结束时间.ShowUpDown = true;
            this.in结束时间.Size = new System.Drawing.Size(60, 23);
            this.in结束时间.TabIndex = 66;
            this.in结束时间.Value = new System.DateTime(2016, 10, 8, 23, 59, 0, 0);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(694, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 17);
            this.label2.TabIndex = 65;
            this.label2.Text = "-";
            // 
            // in日期
            // 
            this.in日期.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.in日期.CustomFormat = "yyyy-MM-dd";
            this.in日期.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.in日期.Location = new System.Drawing.Point(456, 3);
            this.in日期.Name = "in日期";
            this.in日期.Size = new System.Drawing.Size(105, 23);
            this.in日期.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(418, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 63;
            this.label1.Text = "日期";
            // 
            // in号码列表
            // 
            this.in号码列表.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.in号码列表.Location = new System.Drawing.Point(68, 3);
            this.in号码列表.Name = "in号码列表";
            this.in号码列表.Size = new System.Drawing.Size(316, 23);
            this.in号码列表.TabIndex = 71;
            this.in号码列表.水印 = "例如: 72020200,72020500";
            this.in号码列表.水印颜色 = System.Drawing.Color.Gray;
            // 
            // F按时间回放
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(730, 0);
            this.Controls.Add(this.in号码列表);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.in开始时间);
            this.Controls.Add(this.in结束时间);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.in日期);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.in显示轨迹);
            this.Controls.Add(this.out显示号码);
            this.Controls.Add(this.do查询);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F按时间回放";
            this.Size = new System.Drawing.Size(1000, 660);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private Utility.WindowsForm.U按钮 do查询;
        private System.Windows.Forms.Panel out显示号码;
        private System.Windows.Forms.CheckBox in显示轨迹;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker in开始时间;
        private System.Windows.Forms.DateTimePicker in结束时间;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker in日期;
        private System.Windows.Forms.Label label1;
        private TextBoxK in号码列表;
    }
}
