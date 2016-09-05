using Utility.WindowsForm;

namespace GPS地图.示例
{
    partial class F显示模板
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.out地图容器 = new System.Windows.Forms.Panel();
            this.do折叠 = new Utility.WindowsForm.U按钮();
            this.out统计面板 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.out从未有过 = new System.Windows.Forms.Label();
            this.out失效 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.out很久未更新 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.out短期未更新 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.out最近更新 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.out共计 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.out组号列表 = new Utility.WindowsForm.DataGridViewK();
            this.in全选 = new System.Windows.Forms.CheckBox();
            this.out个号列表 = new Utility.WindowsForm.DataGridViewK();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.out地图容器.SuspendLayout();
            this.out统计面板.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.out组号列表)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.out个号列表)).BeginInit();
            this.SuspendLayout();
            // 
            // out地图容器
            // 
            this.out地图容器.Controls.Add(this.do折叠);
            this.out地图容器.Controls.Add(this.out统计面板);
            this.out地图容器.Dock = System.Windows.Forms.DockStyle.Fill;
            this.out地图容器.Location = new System.Drawing.Point(0, 0);
            this.out地图容器.Name = "out地图容器";
            this.out地图容器.Size = new System.Drawing.Size(826, 710);
            this.out地图容器.TabIndex = 48;
            // 
            // do折叠
            // 
            this.do折叠.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(149)))), ((int)(((byte)(169)))));
            this.do折叠.FlatAppearance.BorderSize = 0;
            this.do折叠.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do折叠.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do折叠.Location = new System.Drawing.Point(3, 315);
            this.do折叠.Name = "do折叠";
            this.do折叠.Size = new System.Drawing.Size(5, 20);
            this.do折叠.TabIndex = 52;
            this.toolTip1.SetToolTip(this.do折叠, "显示/隐藏号码列表");
            this.do折叠.UseVisualStyleBackColor = false;
            this.do折叠.大小 = new System.Drawing.Size(5, 20);
            this.do折叠.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do折叠.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(149)))), ((int)(((byte)(169)))));
            // 
            // out统计面板
            // 
            this.out统计面板.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.out统计面板.Controls.Add(this.label1);
            this.out统计面板.Controls.Add(this.out从未有过);
            this.out统计面板.Controls.Add(this.out失效);
            this.out统计面板.Controls.Add(this.label11);
            this.out统计面板.Controls.Add(this.out很久未更新);
            this.out统计面板.Controls.Add(this.label8);
            this.out统计面板.Controls.Add(this.label6);
            this.out统计面板.Controls.Add(this.out短期未更新);
            this.out统计面板.Controls.Add(this.label4);
            this.out统计面板.Controls.Add(this.out最近更新);
            this.out统计面板.Controls.Add(this.label2);
            this.out统计面板.Controls.Add(this.out共计);
            this.out统计面板.Location = new System.Drawing.Point(247, 7);
            this.out统计面板.Name = "out统计面板";
            this.out统计面板.Size = new System.Drawing.Size(532, 19);
            this.out统计面板.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 17);
            this.label1.TabIndex = 59;
            this.toolTip1.SetToolTip(this.label1, "共计");
            // 
            // out从未有过
            // 
            this.out从未有过.AutoSize = true;
            this.out从未有过.Location = new System.Drawing.Point(482, 1);
            this.out从未有过.Name = "out从未有过";
            this.out从未有过.Size = new System.Drawing.Size(15, 17);
            this.out从未有过.TabIndex = 63;
            this.out从未有过.Text = "0";
            this.toolTip1.SetToolTip(this.out从未有过, "从未有过");
            // 
            // out失效
            // 
            this.out失效.AutoSize = true;
            this.out失效.Location = new System.Drawing.Point(388, 1);
            this.out失效.Name = "out失效";
            this.out失效.Size = new System.Drawing.Size(15, 17);
            this.out失效.TabIndex = 64;
            this.out失效.Text = "0";
            this.toolTip1.SetToolTip(this.out失效, "失效");
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(461, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 17);
            this.label11.TabIndex = 60;
            this.label11.Text = "X";
            this.toolTip1.SetToolTip(this.label11, "从未有过");
            // 
            // out很久未更新
            // 
            this.out很久未更新.AutoSize = true;
            this.out很久未更新.Location = new System.Drawing.Point(293, 1);
            this.out很久未更新.Name = "out很久未更新";
            this.out很久未更新.Size = new System.Drawing.Size(15, 17);
            this.out很久未更新.TabIndex = 67;
            this.out很久未更新.Text = "0";
            this.toolTip1.SetToolTip(this.out很久未更新, "很久未更新");
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Yellow;
            this.label8.Location = new System.Drawing.Point(368, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 17);
            this.label8.TabIndex = 61;
            this.toolTip1.SetToolTip(this.label8, "失效");
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(272, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 17);
            this.label6.TabIndex = 66;
            this.toolTip1.SetToolTip(this.label6, "很久未更新");
            // 
            // out短期未更新
            // 
            this.out短期未更新.AutoSize = true;
            this.out短期未更新.Location = new System.Drawing.Point(205, 1);
            this.out短期未更新.Name = "out短期未更新";
            this.out短期未更新.Size = new System.Drawing.Size(15, 17);
            this.out短期未更新.TabIndex = 65;
            this.out短期未更新.Text = "0";
            this.toolTip1.SetToolTip(this.out短期未更新, "短期未更新");
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(184, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 62;
            this.toolTip1.SetToolTip(this.label4, "短期未更新");
            // 
            // out最近更新
            // 
            this.out最近更新.AutoSize = true;
            this.out最近更新.Location = new System.Drawing.Point(114, 1);
            this.out最近更新.Name = "out最近更新";
            this.out最近更新.Size = new System.Drawing.Size(15, 17);
            this.out最近更新.TabIndex = 59;
            this.out最近更新.Text = "0";
            this.toolTip1.SetToolTip(this.out最近更新, "最近更新");
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SkyBlue;
            this.label2.Location = new System.Drawing.Point(93, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 58;
            this.toolTip1.SetToolTip(this.label2, "最近更新");
            // 
            // out共计
            // 
            this.out共计.AutoSize = true;
            this.out共计.Location = new System.Drawing.Point(21, 1);
            this.out共计.Name = "out共计";
            this.out共计.Size = new System.Drawing.Size(15, 17);
            this.out共计.TabIndex = 57;
            this.out共计.Text = "0";
            this.toolTip1.SetToolTip(this.out共计, "共计");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.out地图容器);
            this.splitContainer1.Size = new System.Drawing.Size(1000, 710);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.TabIndex = 49;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.out组号列表);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.in全选);
            this.splitContainer2.Panel2.Controls.Add(this.out个号列表);
            this.splitContainer2.Size = new System.Drawing.Size(170, 710);
            this.splitContainer2.SplitterDistance = 243;
            this.splitContainer2.TabIndex = 0;
            // 
            // out组号列表
            // 
            this.out组号列表.AllowUserToAddRows = false;
            this.out组号列表.AllowUserToDeleteRows = false;
            this.out组号列表.AllowUserToResizeColumns = false;
            this.out组号列表.AllowUserToResizeRows = false;
            this.out组号列表.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.out组号列表.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.out组号列表.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.out组号列表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.out组号列表.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.Column1});
            this.out组号列表.Dock = System.Windows.Forms.DockStyle.Fill;
            this.out组号列表.GridColor = System.Drawing.SystemColors.ControlLight;
            this.out组号列表.Location = new System.Drawing.Point(0, 0);
            this.out组号列表.Name = "out组号列表";
            this.out组号列表.ReadOnly = true;
            this.out组号列表.RowHeadersVisible = false;
            this.out组号列表.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.out组号列表.RowTemplate.Height = 23;
            this.out组号列表.Size = new System.Drawing.Size(170, 243);
            this.out组号列表.TabIndex = 49;
            // 
            // in全选
            // 
            this.in全选.AutoSize = true;
            this.in全选.BackColor = System.Drawing.Color.White;
            this.in全选.Location = new System.Drawing.Point(93, 1);
            this.in全选.Name = "in全选";
            this.in全选.Size = new System.Drawing.Size(51, 21);
            this.in全选.TabIndex = 49;
            this.in全选.Text = "显示";
            this.in全选.UseVisualStyleBackColor = false;
            // 
            // out个号列表
            // 
            this.out个号列表.AllowUserToAddRows = false;
            this.out个号列表.AllowUserToDeleteRows = false;
            this.out个号列表.AllowUserToResizeColumns = false;
            this.out个号列表.AllowUserToResizeRows = false;
            this.out个号列表.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.out个号列表.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.out个号列表.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.out个号列表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.out个号列表.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column2});
            this.out个号列表.Dock = System.Windows.Forms.DockStyle.Fill;
            this.out个号列表.GridColor = System.Drawing.SystemColors.ControlLight;
            this.out个号列表.Location = new System.Drawing.Point(0, 0);
            this.out个号列表.Name = "out个号列表";
            this.out个号列表.RowHeadersVisible = false;
            this.out个号列表.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.out个号列表.RowTemplate.Height = 23;
            this.out个号列表.Size = new System.Drawing.Size(170, 463);
            this.out个号列表.TabIndex = 48;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "组号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // Column1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column1.HeaderText = "呼叫";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 70;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "个号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "";
            this.Column2.Name = "Column2";
            this.Column2.Width = 70;
            // 
            // F显示模板
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(730, 0);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F显示模板";
            this.Size = new System.Drawing.Size(1000, 710);
            this.out地图容器.ResumeLayout(false);
            this.out统计面板.ResumeLayout(false);
            this.out统计面板.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.out组号列表)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.out个号列表)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel out统计面板;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label out从未有过;
        private System.Windows.Forms.Label out失效;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label out很久未更新;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label out短期未更新;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label out最近更新;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label out共计;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private U按钮 do折叠;
        internal System.Windows.Forms.Panel out地图容器;
        private System.Windows.Forms.SplitContainer splitContainer2;
        public DataGridViewK out组号列表;
        private System.Windows.Forms.CheckBox in全选;
        public DataGridViewK out个号列表;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
    }
}
