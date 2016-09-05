namespace 管理工具
{
    partial class F主窗口
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uTab1 = new Utility.WindowsForm.UTab();
            this.SuspendLayout();
            // 
            // uTab1
            // 
            this.uTab1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uTab1.Location = new System.Drawing.Point(3, 3);
            this.uTab1.Name = "uTab1";
            this.uTab1.Size = new System.Drawing.Size(970, 594);
            this.uTab1.TabIndex = 5;
            this.uTab1.标题宽度 = 120;
            // 
            // F主窗口
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.uTab1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F主窗口";
            this.Size = new System.Drawing.Size(975, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private Utility.WindowsForm.UTab uTab1;
    }
}