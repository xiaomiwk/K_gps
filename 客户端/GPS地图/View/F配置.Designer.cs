using System.Windows.Forms;
using GPS地图.View.配置;

namespace GPS地图.View
{
    partial class F配置
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
            this.panelEx1 = new System.Windows.Forms.Panel();
            this.do取消 = new System.Windows.Forms.Button();
            this.do确定 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.outGIS服务器 = new GPS地图.View.配置.F配置_服务器();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.outGPS时间参数 = new GPS地图.View.配置.F配置_GPS状态();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.out地图路径 = new GPS地图.View.配置.F配置_地图路径();
            this.labelX2 = new System.Windows.Forms.Label();
            this.panelEx1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.BackColor = System.Drawing.Color.White;
            this.panelEx1.Controls.Add(this.do取消);
            this.panelEx1.Controls.Add(this.do确定);
            this.panelEx1.Controls.Add(this.tabControl1);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(525, 364);
            this.panelEx1.TabIndex = 0;
            // 
            // do取消
            // 
            this.do取消.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.do取消.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do取消.FlatAppearance.BorderSize = 0;
            this.do取消.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do取消.ForeColor = System.Drawing.Color.White;
            this.do取消.Location = new System.Drawing.Point(420, 328);
            this.do取消.Name = "do取消";
            this.do取消.Size = new System.Drawing.Size(90, 26);
            this.do取消.TabIndex = 22;
            this.do取消.Text = "取消";
            this.do取消.UseVisualStyleBackColor = false;
            // 
            // do确定
            // 
            this.do确定.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.do确定.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do确定.FlatAppearance.BorderSize = 0;
            this.do确定.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do确定.ForeColor = System.Drawing.Color.White;
            this.do确定.Location = new System.Drawing.Point(324, 328);
            this.do确定.Name = "do确定";
            this.do确定.Size = new System.Drawing.Size(90, 26);
            this.do确定.TabIndex = 21;
            this.do确定.Text = "确定";
            this.do确定.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ItemSize = new System.Drawing.Size(96, 28);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(502, 305);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.outGIS服务器);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(494, 269);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "GIS服务器";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // outGIS服务器
            // 
            this.outGIS服务器.BackColor = System.Drawing.Color.White;
            this.outGIS服务器.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outGIS服务器.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.outGIS服务器.Location = new System.Drawing.Point(3, 3);
            this.outGIS服务器.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.outGIS服务器.Name = "outGIS服务器";
            this.outGIS服务器.Size = new System.Drawing.Size(488, 263);
            this.outGIS服务器.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.outGPS时间参数);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(494, 269);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "GPS更新状态";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // outGPS时间参数
            // 
            this.outGPS时间参数.BackColor = System.Drawing.Color.White;
            this.outGPS时间参数.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outGPS时间参数.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.outGPS时间参数.Location = new System.Drawing.Point(3, 3);
            this.outGPS时间参数.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.outGPS时间参数.Name = "outGPS时间参数";
            this.outGPS时间参数.Size = new System.Drawing.Size(488, 263);
            this.outGPS时间参数.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.out地图路径);
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(494, 269);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "地图路径";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // out地图路径
            // 
            this.out地图路径.BackColor = System.Drawing.Color.White;
            this.out地图路径.Dock = System.Windows.Forms.DockStyle.Fill;
            this.out地图路径.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.out地图路径.Location = new System.Drawing.Point(3, 3);
            this.out地图路径.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.out地图路径.Name = "out地图路径";
            this.out地图路径.Size = new System.Drawing.Size(488, 263);
            this.out地图路径.TabIndex = 1;
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelX2.AutoSize = true;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.labelX2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelX2.Location = new System.Drawing.Point(16, 329);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(154, 17);
            this.labelX2.TabIndex = 19;
            this.labelX2.Text = "提示: 修改参数后, 重启生效";
            // 
            // F配置
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F配置";
            this.Size = new System.Drawing.Size(525, 364);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelEx1;
        public Label labelX2;
        private TabControl tabControl1;
        public TabPage tabPage2;
        private F配置_GPS状态 outGPS时间参数;
        public TabPage tabPage3;
        private F配置_地图路径 out地图路径;
        public Button do取消;
        public Button do确定;
        public TabPage tabPage1;
        private F配置_服务器 outGIS服务器;

    }
}
