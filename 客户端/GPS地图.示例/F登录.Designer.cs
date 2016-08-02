namespace GPS地图.示例
{
    partial class F登录
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
            this.inIP2 = new System.Windows.Forms.TextBox();
            this.inIP = new System.Windows.Forms.ComboBox();
            this.do连接 = new Utility.WindowsForm.U按钮();
            this.in端口号 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inIP2
            // 
            this.inIP2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inIP2.Location = new System.Drawing.Point(114, 33);
            this.inIP2.Name = "inIP2";
            this.inIP2.Size = new System.Drawing.Size(165, 16);
            this.inIP2.TabIndex = 24;
            // 
            // inIP
            // 
            this.inIP.FormattingEnabled = true;
            this.inIP.Location = new System.Drawing.Point(112, 29);
            this.inIP.Name = "inIP";
            this.inIP.Size = new System.Drawing.Size(186, 25);
            this.inIP.TabIndex = 23;
            this.inIP.TabStop = false;
            // 
            // do连接
            // 
            this.do连接.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do连接.FlatAppearance.BorderSize = 0;
            this.do连接.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do连接.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do连接.Location = new System.Drawing.Point(112, 110);
            this.do连接.Name = "do连接";
            this.do连接.Size = new System.Drawing.Size(100, 26);
            this.do连接.TabIndex = 22;
            this.do连接.Text = "连接(&C)";
            this.do连接.UseVisualStyleBackColor = false;
            this.do连接.大小 = new System.Drawing.Size(100, 26);
            this.do连接.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do连接.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // in端口号
            // 
            this.in端口号.Location = new System.Drawing.Point(112, 64);
            this.in端口号.Name = "in端口号";
            this.in端口号.Size = new System.Drawing.Size(186, 23);
            this.in端口号.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "端口号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "IP";
            // 
            // F登录
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inIP2);
            this.Controls.Add(this.inIP);
            this.Controls.Add(this.do连接);
            this.Controls.Add(this.in端口号);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F登录";
            this.Size = new System.Drawing.Size(336, 152);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inIP2;
        private System.Windows.Forms.ComboBox inIP;
        private Utility.WindowsForm.U按钮 do连接;
        private System.Windows.Forms.TextBox in端口号;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;


    }
}
