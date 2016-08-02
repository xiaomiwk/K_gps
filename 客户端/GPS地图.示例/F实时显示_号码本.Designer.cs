using Utility.WindowsForm;

namespace GPS地图.示例
{
    partial class F实时显示_号码本
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("所有");
            this.out单位列表 = new Utility.WindowsForm.TreeViewK();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.do清空号码 = new System.Windows.Forms.ToolStripMenuItem();
            this.do重新加载 = new System.Windows.Forms.ToolStripMenuItem();
            this.out显示号码 = new System.Windows.Forms.Panel();
            this.do折叠 = new Utility.WindowsForm.U按钮();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.out显示号码.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // out单位列表
            // 
            this.out单位列表.BackColor = System.Drawing.Color.WhiteSmoke;
            this.out单位列表.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.out单位列表.CheckBoxes = true;
            this.out单位列表.ContextMenuStrip = this.contextMenuStrip1;
            this.out单位列表.Dock = System.Windows.Forms.DockStyle.Fill;
            this.out单位列表.Location = new System.Drawing.Point(0, 0);
            this.out单位列表.Name = "out单位列表";
            treeNode1.Name = "节点0";
            treeNode1.Text = "所有";
            this.out单位列表.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.out单位列表.Size = new System.Drawing.Size(215, 710);
            this.out单位列表.TabIndex = 42;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.do清空号码,
            this.do重新加载});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 48);
            // 
            // do清空号码
            // 
            this.do清空号码.Name = "do清空号码";
            this.do清空号码.Size = new System.Drawing.Size(122, 22);
            this.do清空号码.Text = "清空号码";
            this.do清空号码.Visible = false;
            // 
            // do重新加载
            // 
            this.do重新加载.Name = "do重新加载";
            this.do重新加载.Size = new System.Drawing.Size(122, 22);
            this.do重新加载.Text = "重新加载";
            // 
            // out显示号码
            // 
            this.out显示号码.Controls.Add(this.do折叠);
            this.out显示号码.Dock = System.Windows.Forms.DockStyle.Fill;
            this.out显示号码.Location = new System.Drawing.Point(0, 0);
            this.out显示号码.Name = "out显示号码";
            this.out显示号码.Size = new System.Drawing.Size(781, 710);
            this.out显示号码.TabIndex = 50;
            // 
            // do折叠
            // 
            this.do折叠.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(174)))), ((int)(((byte)(162)))));
            this.do折叠.FlatAppearance.BorderSize = 0;
            this.do折叠.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do折叠.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do折叠.Location = new System.Drawing.Point(3, 285);
            this.do折叠.Name = "do折叠";
            this.do折叠.Size = new System.Drawing.Size(5, 20);
            this.do折叠.TabIndex = 53;
            this.toolTip1.SetToolTip(this.do折叠, "显示/隐藏号码本");
            this.do折叠.UseVisualStyleBackColor = false;
            this.do折叠.大小 = new System.Drawing.Size(5, 20);
            this.do折叠.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do折叠.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(174)))), ((int)(((byte)(162)))));
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
            this.splitContainer1.Panel1.Controls.Add(this.out单位列表);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.out显示号码);
            this.splitContainer1.Size = new System.Drawing.Size(1000, 710);
            this.splitContainer1.SplitterDistance = 215;
            this.splitContainer1.TabIndex = 51;
            // 
            // F实时显示_号码本
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(730, 0);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F实时显示_号码本";
            this.Size = new System.Drawing.Size(1000, 710);
            this.contextMenuStrip1.ResumeLayout(false);
            this.out显示号码.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TreeViewK out单位列表;
        private System.Windows.Forms.Panel out显示号码;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem do清空号码;
        private System.Windows.Forms.ToolStripMenuItem do重新加载;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private U按钮 do折叠;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
