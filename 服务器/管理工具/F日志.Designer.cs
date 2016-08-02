using Utility.WindowsForm;

namespace 管理工具
{
    partial class F日志
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
            this.do查询 = new Utility.WindowsForm.U按钮();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.in类别 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.out日志列表 = new Utility.WindowsForm.DataGridViewK();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.u分页1 = new Utility.WindowsForm.U分页();
            this.in起始时间 = new System.Windows.Forms.DateTimePicker();
            this.in结束时间 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.out日志列表)).BeginInit();
            this.SuspendLayout();
            // 
            // do查询
            // 
            this.do查询.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do查询.FlatAppearance.BorderSize = 0;
            this.do查询.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do查询.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do查询.Location = new System.Drawing.Point(655, 13);
            this.do查询.Name = "do查询";
            this.do查询.Size = new System.Drawing.Size(100, 26);
            this.do查询.TabIndex = 44;
            this.do查询.Text = "查询";
            this.do查询.UseVisualStyleBackColor = false;
            this.do查询.大小 = new System.Drawing.Size(100, 26);
            this.do查询.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do查询.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(414, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 17);
            this.label12.TabIndex = 42;
            this.label12.Text = "终止时间";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(185, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 40;
            this.label9.Text = "起始时间";
            // 
            // in类别
            // 
            this.in类别.FormattingEnabled = true;
            this.in类别.Location = new System.Drawing.Point(54, 15);
            this.in类别.Name = "in类别";
            this.in类别.Size = new System.Drawing.Size(109, 25);
            this.in类别.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 17);
            this.label8.TabIndex = 38;
            this.label8.Text = "类别";
            // 
            // out日志列表
            // 
            this.out日志列表.AllowUserToAddRows = false;
            this.out日志列表.AllowUserToDeleteRows = false;
            this.out日志列表.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out日志列表.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.out日志列表.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.out日志列表.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.out日志列表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.out日志列表.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column1,
            this.Column2});
            this.out日志列表.GridColor = System.Drawing.SystemColors.ControlLight;
            this.out日志列表.Location = new System.Drawing.Point(20, 55);
            this.out日志列表.Name = "out日志列表";
            this.out日志列表.ReadOnly = true;
            this.out日志列表.RowHeadersVisible = false;
            this.out日志列表.RowTemplate.Height = 23;
            this.out日志列表.Size = new System.Drawing.Size(863, 404);
            this.out日志列表.TabIndex = 37;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "时间";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "类别";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 130;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "描述";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 550;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "账号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            this.Column2.Width = 150;
            // 
            // u分页1
            // 
            this.u分页1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.u分页1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.u分页1.Location = new System.Drawing.Point(21, 470);
            this.u分页1.Name = "u分页1";
            this.u分页1.Size = new System.Drawing.Size(600, 23);
            this.u分页1.TabIndex = 45;
            this.u分页1.总条数 = 0;
            this.u分页1.每页条数 = 50;
            // 
            // in起始时间
            // 
            this.in起始时间.CustomFormat = "yyyy-MM-dd HH:mm";
            this.in起始时间.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.in起始时间.Location = new System.Drawing.Point(247, 15);
            this.in起始时间.Name = "in起始时间";
            this.in起始时间.Size = new System.Drawing.Size(142, 23);
            this.in起始时间.TabIndex = 46;
            // 
            // in结束时间
            // 
            this.in结束时间.CustomFormat = "yyyy-MM-dd HH:mm";
            this.in结束时间.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.in结束时间.Location = new System.Drawing.Point(476, 15);
            this.in结束时间.Name = "in结束时间";
            this.in结束时间.Size = new System.Drawing.Size(142, 23);
            this.in结束时间.TabIndex = 47;
            // 
            // F日志
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.in结束时间);
            this.Controls.Add(this.in起始时间);
            this.Controls.Add(this.u分页1);
            this.Controls.Add(this.do查询);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.in类别);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.out日志列表);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F日志";
            this.Size = new System.Drawing.Size(900, 500);
            ((System.ComponentModel.ISupportInitialize)(this.out日志列表)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utility.WindowsForm.U按钮 do查询;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox in类别;
        private System.Windows.Forms.Label label8;
        private DataGridViewK out日志列表;
        private Utility.WindowsForm.U分页 u分页1;
        private System.Windows.Forms.DateTimePicker in起始时间;
        private System.Windows.Forms.DateTimePicker in结束时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}
