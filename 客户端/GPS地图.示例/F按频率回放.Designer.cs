﻿using Utility.WindowsForm;

namespace GPS地图.示例
{
    partial class F按频率回放
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
            this.out显示号码 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.in日期 = new System.Windows.Forms.DateTimePicker();
            this.in号码 = new System.Windows.Forms.TextBox();
            this.do查询 = new Utility.WindowsForm.U按钮();
            this.in显示轨迹 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.in结束时间 = new System.Windows.Forms.DateTimePicker();
            this.in开始时间 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "号码";
            // 
            // out显示号码
            // 
            this.out显示号码.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out显示号码.Location = new System.Drawing.Point(9, 32);
            this.out显示号码.Name = "out显示号码";
            this.out显示号码.Size = new System.Drawing.Size(988, 625);
            this.out显示号码.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 51;
            this.label1.Text = "日期";
            // 
            // in日期
            // 
            this.in日期.CustomFormat = "yyyy-MM-dd";
            this.in日期.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.in日期.Location = new System.Drawing.Point(206, 3);
            this.in日期.Name = "in日期";
            this.in日期.Size = new System.Drawing.Size(105, 23);
            this.in日期.TabIndex = 52;
            // 
            // in号码
            // 
            this.in号码.Location = new System.Drawing.Point(44, 3);
            this.in号码.Name = "in号码";
            this.in号码.Size = new System.Drawing.Size(100, 23);
            this.in号码.TabIndex = 49;
            // 
            // do查询
            // 
            this.do查询.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do查询.FlatAppearance.BorderSize = 0;
            this.do查询.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do查询.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do查询.Location = new System.Drawing.Point(563, 1);
            this.do查询.Name = "do查询";
            this.do查询.Size = new System.Drawing.Size(100, 26);
            this.do查询.TabIndex = 36;
            this.do查询.Text = "查询";
            this.do查询.UseVisualStyleBackColor = false;
            this.do查询.大小 = new System.Drawing.Size(100, 26);
            this.do查询.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do查询.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // in显示轨迹
            // 
            this.in显示轨迹.AutoSize = true;
            this.in显示轨迹.Location = new System.Drawing.Point(673, 6);
            this.in显示轨迹.Name = "in显示轨迹";
            this.in显示轨迹.Size = new System.Drawing.Size(75, 21);
            this.in显示轨迹.TabIndex = 60;
            this.in显示轨迹.Text = "显示轨迹";
            this.in显示轨迹.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 17);
            this.label2.TabIndex = 53;
            this.label2.Text = "-";
            // 
            // in结束时间
            // 
            this.in结束时间.CustomFormat = "HH:mm";
            this.in结束时间.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.in结束时间.Location = new System.Drawing.Point(467, 3);
            this.in结束时间.Name = "in结束时间";
            this.in结束时间.ShowUpDown = true;
            this.in结束时间.Size = new System.Drawing.Size(60, 23);
            this.in结束时间.TabIndex = 54;
            this.in结束时间.Value = new System.DateTime(2016, 10, 8, 23, 59, 0, 0);
            // 
            // in开始时间
            // 
            this.in开始时间.CustomFormat = "HH:mm";
            this.in开始时间.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.in开始时间.Location = new System.Drawing.Point(382, 3);
            this.in开始时间.Name = "in开始时间";
            this.in开始时间.ShowUpDown = true;
            this.in开始时间.Size = new System.Drawing.Size(60, 23);
            this.in开始时间.TabIndex = 61;
            this.in开始时间.Value = new System.DateTime(2016, 10, 8, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 62;
            this.label3.Text = "时间";
            // 
            // F按频率回放
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(730, 0);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.in开始时间);
            this.Controls.Add(this.in显示轨迹);
            this.Controls.Add(this.in结束时间);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.in日期);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.out显示号码);
            this.Controls.Add(this.in号码);
            this.Controls.Add(this.do查询);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F按频率回放";
            this.Size = new System.Drawing.Size(1000, 660);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private Utility.WindowsForm.U按钮 do查询;
        private System.Windows.Forms.TextBox in号码;
        private System.Windows.Forms.Panel out显示号码;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker in日期;
        private System.Windows.Forms.CheckBox in显示轨迹;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker in结束时间;
        private System.Windows.Forms.DateTimePicker in开始时间;
        private System.Windows.Forms.Label label3;
    }
}
