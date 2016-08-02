using Utility.WindowsForm;

namespace GPS地图.示例
{
    partial class F实时显示_号码段
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
            this.in号码范围 = new Utility.WindowsForm.TextBoxK();
            this.do查询 = new Utility.WindowsForm.U按钮();
            this.out显示号码 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "号码范围";
            // 
            // in号码范围
            // 
            this.in号码范围.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.in号码范围.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.in号码范围.Location = new System.Drawing.Point(68, 3);
            this.in号码范围.Name = "in号码范围";
            this.in号码范围.Size = new System.Drawing.Size(823, 23);
            this.in号码范围.TabIndex = 49;
            this.in号码范围.Text = "例如: 72020200,72020300-72020399,72020500";
            this.in号码范围.水印 = "例如: 72020200,72020300-72020399,72020500";
            this.in号码范围.水印颜色 = System.Drawing.SystemColors.ControlDark;
            // 
            // do查询
            // 
            this.do查询.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do查询.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do查询.FlatAppearance.BorderSize = 0;
            this.do查询.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do查询.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do查询.Location = new System.Drawing.Point(897, 1);
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
            this.out显示号码.Size = new System.Drawing.Size(988, 675);
            this.out显示号码.TabIndex = 50;
            // 
            // F实时显示_号码段
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(730, 0);
            this.Controls.Add(this.out显示号码);
            this.Controls.Add(this.in号码范围);
            this.Controls.Add(this.do查询);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F实时显示_号码段";
            this.Size = new System.Drawing.Size(1000, 710);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private Utility.WindowsForm.U按钮 do查询;
        private TextBoxK in号码范围;
        private System.Windows.Forms.Panel out显示号码;
    }
}
