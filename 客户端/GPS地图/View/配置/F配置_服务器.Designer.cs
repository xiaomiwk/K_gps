using System.Windows.Forms;

namespace GPS地图.View.配置
{
    partial class F配置_服务器
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
            this.labelX1 = new System.Windows.Forms.Label();
            this.in服务器IP地址 = new System.Windows.Forms.TextBox();
            this.labelX2 = new System.Windows.Forms.Label();
            this.in服务器端口号 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.Location = new System.Drawing.Point(36, 32);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(46, 17);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "IP地址:";
            // 
            // in服务器IP地址
            // 
            this.in服务器IP地址.Location = new System.Drawing.Point(135, 32);
            this.in服务器IP地址.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.in服务器IP地址.Name = "in服务器IP地址";
            this.in服务器IP地址.Size = new System.Drawing.Size(171, 23);
            this.in服务器IP地址.TabIndex = 1;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.Location = new System.Drawing.Point(36, 76);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(47, 17);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "端口号:";
            // 
            // in服务器端口号
            // 
            this.in服务器端口号.Location = new System.Drawing.Point(135, 76);
            this.in服务器端口号.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.in服务器端口号.Name = "in服务器端口号";
            this.in服务器端口号.Size = new System.Drawing.Size(171, 23);
            this.in服务器端口号.TabIndex = 3;
            // 
            // F配置_服务器
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.in服务器端口号);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.in服务器IP地址);
            this.Controls.Add(this.labelX1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F配置_服务器";
            this.Size = new System.Drawing.Size(473, 291);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label labelX1;
        private TextBox in服务器IP地址;
        public Label labelX2;
        private TextBox in服务器端口号;
    }
}
