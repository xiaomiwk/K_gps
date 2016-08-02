namespace GIS服务器.服务管理
{
    partial class F数据库
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.inMSSQLSERVER = new System.Windows.Forms.RadioButton();
            this.in内存数据库 = new System.Windows.Forms.RadioButton();
            this.outMSSQLSERVER = new System.Windows.Forms.Panel();
            this.do保存 = new Utility.WindowsForm.U按钮();
            this.outSQL状态 = new System.Windows.Forms.Label();
            this.doGIS检测 = new Utility.WindowsForm.U按钮();
            this.inGIS名称 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.doGIS删除 = new Utility.WindowsForm.U按钮();
            this.outGIS状态 = new System.Windows.Forms.Label();
            this.doGIS创建 = new Utility.WindowsForm.U按钮();
            this.doSQLServer检测 = new Utility.WindowsForm.U按钮();
            this.inSQL密码 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.inSQL账号 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inSQL名称 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.outMSSQLSERVER.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 550F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 440F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 535);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.outMSSQLSERVER);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(178, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 434);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.inMSSQLSERVER);
            this.panel2.Controls.Add(this.in内存数据库);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(536, 70);
            this.panel2.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(204, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(247, 17);
            this.label7.TabIndex = 71;
            this.label7.Text = "！使用内存数据库时，不能保存GPS轨迹数据\r\n";
            // 
            // inMSSQLSERVER
            // 
            this.inMSSQLSERVER.AutoSize = true;
            this.inMSSQLSERVER.Location = new System.Drawing.Point(2, 38);
            this.inMSSQLSERVER.Name = "inMSSQLSERVER";
            this.inMSSQLSERVER.Size = new System.Drawing.Size(121, 21);
            this.inMSSQLSERVER.TabIndex = 1;
            this.inMSSQLSERVER.TabStop = true;
            this.inMSSQLSERVER.Text = "MS SQL SERVER";
            this.inMSSQLSERVER.UseVisualStyleBackColor = true;
            // 
            // in内存数据库
            // 
            this.in内存数据库.AutoSize = true;
            this.in内存数据库.Location = new System.Drawing.Point(3, 8);
            this.in内存数据库.Name = "in内存数据库";
            this.in内存数据库.Size = new System.Drawing.Size(86, 21);
            this.in内存数据库.TabIndex = 0;
            this.in内存数据库.TabStop = true;
            this.in内存数据库.Text = "内存数据库";
            this.in内存数据库.UseVisualStyleBackColor = true;
            // 
            // outMSSQLSERVER
            // 
            this.outMSSQLSERVER.Controls.Add(this.label2);
            this.outMSSQLSERVER.Controls.Add(this.inSQL名称);
            this.outMSSQLSERVER.Controls.Add(this.label10);
            this.outMSSQLSERVER.Controls.Add(this.do保存);
            this.outMSSQLSERVER.Controls.Add(this.outSQL状态);
            this.outMSSQLSERVER.Controls.Add(this.doGIS检测);
            this.outMSSQLSERVER.Controls.Add(this.inGIS名称);
            this.outMSSQLSERVER.Controls.Add(this.label6);
            this.outMSSQLSERVER.Controls.Add(this.label3);
            this.outMSSQLSERVER.Controls.Add(this.doGIS删除);
            this.outMSSQLSERVER.Controls.Add(this.outGIS状态);
            this.outMSSQLSERVER.Controls.Add(this.doGIS创建);
            this.outMSSQLSERVER.Controls.Add(this.doSQLServer检测);
            this.outMSSQLSERVER.Controls.Add(this.inSQL密码);
            this.outMSSQLSERVER.Controls.Add(this.label5);
            this.outMSSQLSERVER.Controls.Add(this.inSQL账号);
            this.outMSSQLSERVER.Controls.Add(this.label4);
            this.outMSSQLSERVER.Controls.Add(this.label1);
            this.outMSSQLSERVER.Location = new System.Drawing.Point(19, 80);
            this.outMSSQLSERVER.Name = "outMSSQLSERVER";
            this.outMSSQLSERVER.Size = new System.Drawing.Size(514, 351);
            this.outMSSQLSERVER.TabIndex = 3;
            // 
            // do保存
            // 
            this.do保存.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do保存.FlatAppearance.BorderSize = 0;
            this.do保存.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do保存.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do保存.Location = new System.Drawing.Point(200, 134);
            this.do保存.Name = "do保存";
            this.do保存.Size = new System.Drawing.Size(100, 26);
            this.do保存.TabIndex = 71;
            this.do保存.Text = "保存";
            this.do保存.UseVisualStyleBackColor = false;
            this.do保存.大小 = new System.Drawing.Size(100, 26);
            this.do保存.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do保存.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // outSQL状态
            // 
            this.outSQL状态.AutoSize = true;
            this.outSQL状态.Location = new System.Drawing.Point(91, 169);
            this.outSQL状态.Name = "outSQL状态";
            this.outSQL状态.Size = new System.Drawing.Size(53, 17);
            this.outSQL状态.TabIndex = 70;
            this.outSQL状态.Text = "检测中...";
            // 
            // doGIS检测
            // 
            this.doGIS检测.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.doGIS检测.FlatAppearance.BorderSize = 0;
            this.doGIS检测.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.doGIS检测.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.doGIS检测.Location = new System.Drawing.Point(94, 289);
            this.doGIS检测.Name = "doGIS检测";
            this.doGIS检测.Size = new System.Drawing.Size(100, 26);
            this.doGIS检测.TabIndex = 69;
            this.doGIS检测.Text = "检测";
            this.doGIS检测.UseVisualStyleBackColor = false;
            this.doGIS检测.大小 = new System.Drawing.Size(100, 26);
            this.doGIS检测.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.doGIS检测.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // inGIS名称
            // 
            this.inGIS名称.Location = new System.Drawing.Point(94, 251);
            this.inGIS名称.Name = "inGIS名称";
            this.inGIS名称.ReadOnly = true;
            this.inGIS名称.Size = new System.Drawing.Size(206, 23);
            this.inGIS名称.TabIndex = 68;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 17);
            this.label6.TabIndex = 67;
            this.label6.Text = "名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(3, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 66;
            this.label3.Text = "GIS数据库";
            // 
            // doGIS删除
            // 
            this.doGIS删除.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.doGIS删除.FlatAppearance.BorderSize = 0;
            this.doGIS删除.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.doGIS删除.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.doGIS删除.Location = new System.Drawing.Point(306, 289);
            this.doGIS删除.Name = "doGIS删除";
            this.doGIS删除.Size = new System.Drawing.Size(100, 26);
            this.doGIS删除.TabIndex = 65;
            this.doGIS删除.Text = "删除";
            this.doGIS删除.UseVisualStyleBackColor = false;
            this.doGIS删除.大小 = new System.Drawing.Size(100, 26);
            this.doGIS删除.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.doGIS删除.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // outGIS状态
            // 
            this.outGIS状态.AutoSize = true;
            this.outGIS状态.Location = new System.Drawing.Point(91, 324);
            this.outGIS状态.Name = "outGIS状态";
            this.outGIS状态.Size = new System.Drawing.Size(53, 17);
            this.outGIS状态.TabIndex = 61;
            this.outGIS状态.Text = "检测中...";
            // 
            // doGIS创建
            // 
            this.doGIS创建.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.doGIS创建.FlatAppearance.BorderSize = 0;
            this.doGIS创建.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.doGIS创建.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.doGIS创建.Location = new System.Drawing.Point(200, 289);
            this.doGIS创建.Name = "doGIS创建";
            this.doGIS创建.Size = new System.Drawing.Size(100, 26);
            this.doGIS创建.TabIndex = 60;
            this.doGIS创建.Text = "新建";
            this.doGIS创建.UseVisualStyleBackColor = false;
            this.doGIS创建.大小 = new System.Drawing.Size(100, 26);
            this.doGIS创建.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.doGIS创建.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // doSQLServer检测
            // 
            this.doSQLServer检测.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.doSQLServer检测.FlatAppearance.BorderSize = 0;
            this.doSQLServer检测.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.doSQLServer检测.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.doSQLServer检测.Location = new System.Drawing.Point(94, 134);
            this.doSQLServer检测.Name = "doSQLServer检测";
            this.doSQLServer检测.Size = new System.Drawing.Size(100, 26);
            this.doSQLServer检测.TabIndex = 59;
            this.doSQLServer检测.Text = "检测";
            this.doSQLServer检测.UseVisualStyleBackColor = false;
            this.doSQLServer检测.大小 = new System.Drawing.Size(100, 26);
            this.doSQLServer检测.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.doSQLServer检测.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // inSQL密码
            // 
            this.inSQL密码.Location = new System.Drawing.Point(94, 95);
            this.inSQL密码.Name = "inSQL密码";
            this.inSQL密码.Size = new System.Drawing.Size(206, 23);
            this.inSQL密码.TabIndex = 58;
            this.inSQL密码.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 17);
            this.label5.TabIndex = 57;
            this.label5.Text = "密码";
            // 
            // inSQL账号
            // 
            this.inSQL账号.Location = new System.Drawing.Point(94, 66);
            this.inSQL账号.Name = "inSQL账号";
            this.inSQL账号.Size = new System.Drawing.Size(206, 23);
            this.inSQL账号.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 55;
            this.label4.Text = "账号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 54;
            this.label1.Text = "数据库实例";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(204, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(281, 17);
            this.label8.TabIndex = 72;
            this.label8.Text = "！切换数据库，需要重启Windows 服务后才能生效\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(306, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 17);
            this.label2.TabIndex = 74;
            this.label2.Text = "例如: 127.0.0.1 或者 .\\SQLEXPRESS";
            // 
            // inSQL名称
            // 
            this.inSQL名称.Location = new System.Drawing.Point(94, 37);
            this.inSQL名称.Name = "inSQL名称";
            this.inSQL名称.Size = new System.Drawing.Size(206, 23);
            this.inSQL名称.TabIndex = 73;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(56, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 17);
            this.label10.TabIndex = 72;
            this.label10.Text = "名称";
            // 
            // F数据库
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F数据库";
            this.Size = new System.Drawing.Size(900, 535);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.outMSSQLSERVER.ResumeLayout(false);
            this.outMSSQLSERVER.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton inMSSQLSERVER;
        private System.Windows.Forms.RadioButton in内存数据库;
        private System.Windows.Forms.Panel outMSSQLSERVER;
        private Utility.WindowsForm.U按钮 do保存;
        private System.Windows.Forms.Label outSQL状态;
        private Utility.WindowsForm.U按钮 doGIS检测;
        private System.Windows.Forms.TextBox inGIS名称;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private Utility.WindowsForm.U按钮 doGIS删除;
        private System.Windows.Forms.Label outGIS状态;
        private Utility.WindowsForm.U按钮 doGIS创建;
        private Utility.WindowsForm.U按钮 doSQLServer检测;
        private System.Windows.Forms.TextBox inSQL密码;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inSQL账号;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inSQL名称;
        private System.Windows.Forms.Label label10;
    }
}
