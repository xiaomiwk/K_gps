namespace GPS地图.示例.数据分析
{
    partial class F查询活跃号码
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
            this.out号码列表 = new Utility.WindowsForm.DataGridViewK();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.out总数 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.out号码列表)).BeginInit();
            this.SuspendLayout();
            // 
            // out号码列表
            // 
            this.out号码列表.AllowUserToAddRows = false;
            this.out号码列表.AllowUserToDeleteRows = false;
            this.out号码列表.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out号码列表.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.out号码列表.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.out号码列表.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.out号码列表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.out号码列表.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.out号码列表.GridColor = System.Drawing.SystemColors.ControlLight;
            this.out号码列表.Location = new System.Drawing.Point(3, 3);
            this.out号码列表.Name = "out号码列表";
            this.out号码列表.ReadOnly = true;
            this.out号码列表.RowHeadersVisible = false;
            this.out号码列表.RowTemplate.Height = 23;
            this.out号码列表.Size = new System.Drawing.Size(174, 485);
            this.out号码列表.TabIndex = 41;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "号码";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // out总数
            // 
            this.out总数.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.out总数.AutoSize = true;
            this.out总数.Location = new System.Drawing.Point(0, 497);
            this.out总数.Name = "out总数";
            this.out总数.Size = new System.Drawing.Size(43, 17);
            this.out总数.TabIndex = 42;
            this.out总数.Text = "label1";
            // 
            // F查询活跃号码
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.out总数);
            this.Controls.Add(this.out号码列表);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F查询活跃号码";
            this.Size = new System.Drawing.Size(180, 514);
            ((System.ComponentModel.ISupportInitialize)(this.out号码列表)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utility.WindowsForm.DataGridViewK out号码列表;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label out总数;
    }
}
