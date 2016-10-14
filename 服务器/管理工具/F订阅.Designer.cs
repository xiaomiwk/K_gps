using Utility.WindowsForm;

namespace 管理工具
{
    partial class F订阅
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.out客户端列表 = new Utility.WindowsForm.DataGridViewK();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.out客户端数量 = new System.Windows.Forms.Label();
            this.out号码数量 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.do查询 = new Utility.WindowsForm.U按钮();
            this.out号码列表 = new Utility.WindowsForm.DataGridViewK();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.out客户端列表)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.out号码列表)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "客户端数量";
            // 
            // out客户端列表
            // 
            this.out客户端列表.AllowUserToAddRows = false;
            this.out客户端列表.AllowUserToDeleteRows = false;
            this.out客户端列表.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.out客户端列表.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.out客户端列表.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.out客户端列表.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.out客户端列表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.out客户端列表.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3});
            this.out客户端列表.GridColor = System.Drawing.SystemColors.ControlLight;
            this.out客户端列表.Location = new System.Drawing.Point(19, 54);
            this.out客户端列表.Name = "out客户端列表";
            this.out客户端列表.ReadOnly = true;
            this.out客户端列表.RowHeadersVisible = false;
            this.out客户端列表.RowTemplate.Height = 23;
            this.out客户端列表.Size = new System.Drawing.Size(548, 405);
            this.out客户端列表.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "地址";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "订阅号码数量";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "开始时间";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column3
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column3.HeaderText = "";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // out客户端数量
            // 
            this.out客户端数量.AutoSize = true;
            this.out客户端数量.Location = new System.Drawing.Point(90, 18);
            this.out客户端数量.Name = "out客户端数量";
            this.out客户端数量.Size = new System.Drawing.Size(29, 17);
            this.out客户端数量.TabIndex = 2;
            this.out客户端数量.Text = "500";
            // 
            // out号码数量
            // 
            this.out号码数量.AutoSize = true;
            this.out号码数量.Location = new System.Drawing.Point(653, 18);
            this.out号码数量.Name = "out号码数量";
            this.out号码数量.Size = new System.Drawing.Size(36, 17);
            this.out号码数量.TabIndex = 7;
            this.out号码数量.Text = "6500";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(591, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "号码数量";
            // 
            // do查询
            // 
            this.do查询.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.do查询.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do查询.FlatAppearance.BorderSize = 0;
            this.do查询.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do查询.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do查询.Location = new System.Drawing.Point(19, 468);
            this.do查询.Name = "do查询";
            this.do查询.Size = new System.Drawing.Size(100, 26);
            this.do查询.TabIndex = 8;
            this.do查询.Text = "查询";
            this.do查询.UseVisualStyleBackColor = false;
            this.do查询.大小 = new System.Drawing.Size(100, 26);
            this.do查询.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do查询.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // out号码列表
            // 
            this.out号码列表.AllowUserToAddRows = false;
            this.out号码列表.AllowUserToDeleteRows = false;
            this.out号码列表.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.out号码列表.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.out号码列表.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.out号码列表.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.out号码列表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.out号码列表.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.out号码列表.GridColor = System.Drawing.SystemColors.ControlLight;
            this.out号码列表.Location = new System.Drawing.Point(594, 54);
            this.out号码列表.Name = "out号码列表";
            this.out号码列表.ReadOnly = true;
            this.out号码列表.RowHeadersVisible = false;
            this.out号码列表.RowTemplate.Height = 23;
            this.out号码列表.Size = new System.Drawing.Size(224, 405);
            this.out号码列表.TabIndex = 42;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "号码";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // F订阅
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.out号码列表);
            this.Controls.Add(this.do查询);
            this.Controls.Add(this.out号码数量);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.out客户端数量);
            this.Controls.Add(this.out客户端列表);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F订阅";
            this.Size = new System.Drawing.Size(900, 500);
            ((System.ComponentModel.ISupportInitialize)(this.out客户端列表)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.out号码列表)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DataGridViewK out客户端列表;
        private System.Windows.Forms.Label out客户端数量;
        private System.Windows.Forms.Label out号码数量;
        private System.Windows.Forms.Label label3;
        private Utility.WindowsForm.U按钮 do查询;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
        private DataGridViewK out号码列表;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}
