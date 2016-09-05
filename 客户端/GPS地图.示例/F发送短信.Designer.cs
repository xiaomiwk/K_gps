namespace GPS地图.示例
{
    partial class F发送短信
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.do发送 = new Utility.WindowsForm.U按钮();
            this.in号码 = new System.Windows.Forms.TextBox();
            this.in内容 = new System.Windows.Forms.TextBox();
            this.in组号 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "号码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "内容：";
            // 
            // do发送
            // 
            this.do发送.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.do发送.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do发送.FlatAppearance.BorderSize = 0;
            this.do发送.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do发送.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do发送.Location = new System.Drawing.Point(96, 367);
            this.do发送.Name = "do发送";
            this.do发送.Size = new System.Drawing.Size(100, 26);
            this.do发送.TabIndex = 24;
            this.do发送.Text = "发送";
            this.do发送.UseVisualStyleBackColor = false;
            this.do发送.大小 = new System.Drawing.Size(100, 26);
            this.do发送.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do发送.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // in号码
            // 
            this.in号码.Location = new System.Drawing.Point(96, 12);
            this.in号码.Name = "in号码";
            this.in号码.Size = new System.Drawing.Size(146, 23);
            this.in号码.TabIndex = 26;
            // 
            // in内容
            // 
            this.in内容.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.in内容.Location = new System.Drawing.Point(96, 52);
            this.in内容.Multiline = true;
            this.in内容.Name = "in内容";
            this.in内容.Size = new System.Drawing.Size(203, 305);
            this.in内容.TabIndex = 27;
            // 
            // in组号
            // 
            this.in组号.AutoSize = true;
            this.in组号.Location = new System.Drawing.Point(248, 14);
            this.in组号.Name = "in组号";
            this.in组号.Size = new System.Drawing.Size(51, 21);
            this.in组号.TabIndex = 28;
            this.in组号.Text = "组号";
            this.in组号.UseVisualStyleBackColor = true;
            // 
            // F发送短信
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.in组号);
            this.Controls.Add(this.in内容);
            this.Controls.Add(this.in号码);
            this.Controls.Add(this.do发送);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F发送短信";
            this.Size = new System.Drawing.Size(368, 401);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private Utility.WindowsForm.U按钮 do发送;
        private System.Windows.Forms.TextBox in号码;
        private System.Windows.Forms.TextBox in内容;
        private System.Windows.Forms.CheckBox in组号;
    }
}
