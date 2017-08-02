namespace DBMS
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.mns1 = new System.Windows.Forms.MenuStrip();
            this.数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsp1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnRefreshTvw = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCreateTable = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnCreateSQL = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelCurSQL = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelAllSQL = new System.Windows.Forms.ToolStripButton();
            this.tsBtnExeCurSQL = new System.Windows.Forms.ToolStripButton();
            this.tvwDB = new System.Windows.Forms.TreeView();
            this.pnlResult = new System.Windows.Forms.Panel();
            this.tabResult = new System.Windows.Forms.TabControl();
            this.tspResult = new System.Windows.Forms.ToolStrip();
            this.tsBtnDelCurResult = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelAllResult = new System.Windows.Forms.ToolStripButton();
            this.tabSQL = new System.Windows.Forms.TabControl();
            this.cmsTreeNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设计表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建表ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.删除表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTreeRoot = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新建表ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mns1.SuspendLayout();
            this.tsp1.SuspendLayout();
            this.pnlResult.SuspendLayout();
            this.tspResult.SuspendLayout();
            this.cmsTreeNode.SuspendLayout();
            this.cmsTreeRoot.SuspendLayout();
            this.SuspendLayout();
            // 
            // mns1
            // 
            this.mns1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据库ToolStripMenuItem,
            this.查询ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.mns1.Location = new System.Drawing.Point(0, 0);
            this.mns1.Name = "mns1";
            this.mns1.Size = new System.Drawing.Size(984, 25);
            this.mns1.TabIndex = 0;
            this.mns1.Text = "menuStrip1";
            // 
            // 数据库ToolStripMenuItem
            // 
            this.数据库ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建表ToolStripMenuItem,
            this.刷新ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.数据库ToolStripMenuItem.Name = "数据库ToolStripMenuItem";
            this.数据库ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.数据库ToolStripMenuItem.Text = "数据库";
            // 
            // 新建表ToolStripMenuItem
            // 
            this.新建表ToolStripMenuItem.Name = "新建表ToolStripMenuItem";
            this.新建表ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.新建表ToolStripMenuItem.Text = "新建表";
            this.新建表ToolStripMenuItem.Click += new System.EventHandler(this.新建表ToolStripMenuItem_Click);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建查询ToolStripMenuItem});
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.查询ToolStripMenuItem.Text = "查询";
            // 
            // 新建查询ToolStripMenuItem
            // 
            this.新建查询ToolStripMenuItem.Name = "新建查询ToolStripMenuItem";
            this.新建查询ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.新建查询ToolStripMenuItem.Text = "新建查询";
            this.新建查询ToolStripMenuItem.Click += new System.EventHandler(this.新建查询ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.关于ToolStripMenuItem.Text = "关于…";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // tsp1
            // 
            this.tsp1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnRefreshTvw,
            this.tsBtnCreateTable,
            this.toolStripSeparator1,
            this.tsBtnCreateSQL,
            this.tsBtnDelCurSQL,
            this.tsBtnDelAllSQL,
            this.tsBtnExeCurSQL});
            this.tsp1.Location = new System.Drawing.Point(0, 25);
            this.tsp1.Name = "tsp1";
            this.tsp1.Size = new System.Drawing.Size(984, 25);
            this.tsp1.TabIndex = 1;
            this.tsp1.Text = "toolStrip1";
            // 
            // tsBtnRefreshTvw
            // 
            this.tsBtnRefreshTvw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnRefreshTvw.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRefreshTvw.Image")));
            this.tsBtnRefreshTvw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRefreshTvw.Name = "tsBtnRefreshTvw";
            this.tsBtnRefreshTvw.Size = new System.Drawing.Size(36, 22);
            this.tsBtnRefreshTvw.Text = "刷新";
            this.tsBtnRefreshTvw.Click += new System.EventHandler(this.tsBtnRefreshTvw_Click);
            // 
            // tsBtnCreateTable
            // 
            this.tsBtnCreateTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnCreateTable.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCreateTable.Image")));
            this.tsBtnCreateTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCreateTable.Name = "tsBtnCreateTable";
            this.tsBtnCreateTable.Size = new System.Drawing.Size(48, 22);
            this.tsBtnCreateTable.Text = "新建表";
            this.tsBtnCreateTable.ToolTipText = "新建表";
            this.tsBtnCreateTable.Click += new System.EventHandler(this.tsBtnCreateTable_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnCreateSQL
            // 
            this.tsBtnCreateSQL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnCreateSQL.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCreateSQL.Image")));
            this.tsBtnCreateSQL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCreateSQL.Name = "tsBtnCreateSQL";
            this.tsBtnCreateSQL.Size = new System.Drawing.Size(60, 22);
            this.tsBtnCreateSQL.Text = "新建查询";
            this.tsBtnCreateSQL.ToolTipText = "新建查询";
            this.tsBtnCreateSQL.Click += new System.EventHandler(this.tsBtnCreateSQL_Click);
            // 
            // tsBtnDelCurSQL
            // 
            this.tsBtnDelCurSQL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnDelCurSQL.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDelCurSQL.Image")));
            this.tsBtnDelCurSQL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelCurSQL.Name = "tsBtnDelCurSQL";
            this.tsBtnDelCurSQL.Size = new System.Drawing.Size(84, 22);
            this.tsBtnDelCurSQL.Text = "关闭当前查询";
            this.tsBtnDelCurSQL.Click += new System.EventHandler(this.tsBtnDelCurSQL_Click);
            // 
            // tsBtnDelAllSQL
            // 
            this.tsBtnDelAllSQL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnDelAllSQL.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDelAllSQL.Image")));
            this.tsBtnDelAllSQL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelAllSQL.Name = "tsBtnDelAllSQL";
            this.tsBtnDelAllSQL.Size = new System.Drawing.Size(84, 22);
            this.tsBtnDelAllSQL.Text = "关闭全部查询";
            this.tsBtnDelAllSQL.Click += new System.EventHandler(this.tsBtnDelAllSQL_Click);
            // 
            // tsBtnExeCurSQL
            // 
            this.tsBtnExeCurSQL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnExeCurSQL.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnExeCurSQL.Image")));
            this.tsBtnExeCurSQL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnExeCurSQL.Name = "tsBtnExeCurSQL";
            this.tsBtnExeCurSQL.Size = new System.Drawing.Size(36, 22);
            this.tsBtnExeCurSQL.Text = "执行";
            this.tsBtnExeCurSQL.ToolTipText = "执行当前查询";
            this.tsBtnExeCurSQL.Click += new System.EventHandler(this.tsBtnExeCurSQL_Click);
            // 
            // tvwDB
            // 
            this.tvwDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvwDB.Location = new System.Drawing.Point(6, 56);
            this.tvwDB.Name = "tvwDB";
            this.tvwDB.Size = new System.Drawing.Size(180, 501);
            this.tvwDB.TabIndex = 2;
            this.tvwDB.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwDB_NodeMouseClick);
            this.tvwDB.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwDB_NodeMouseDoubleClick);
            // 
            // pnlResult
            // 
            this.pnlResult.Controls.Add(this.tabResult);
            this.pnlResult.Controls.Add(this.tspResult);
            this.pnlResult.Location = new System.Drawing.Point(192, 242);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Size = new System.Drawing.Size(790, 316);
            this.pnlResult.TabIndex = 4;
            // 
            // tabResult
            // 
            this.tabResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResult.Location = new System.Drawing.Point(0, 25);
            this.tabResult.Name = "tabResult";
            this.tabResult.SelectedIndex = 0;
            this.tabResult.Size = new System.Drawing.Size(790, 291);
            this.tabResult.TabIndex = 1;
            // 
            // tspResult
            // 
            this.tspResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnDelCurResult,
            this.tsBtnDelAllResult});
            this.tspResult.Location = new System.Drawing.Point(0, 0);
            this.tspResult.Name = "tspResult";
            this.tspResult.Size = new System.Drawing.Size(790, 25);
            this.tspResult.TabIndex = 0;
            this.tspResult.Text = "toolStrip2";
            // 
            // tsBtnDelCurResult
            // 
            this.tsBtnDelCurResult.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnDelCurResult.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDelCurResult.Image")));
            this.tsBtnDelCurResult.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelCurResult.Name = "tsBtnDelCurResult";
            this.tsBtnDelCurResult.Size = new System.Drawing.Size(72, 22);
            this.tsBtnDelCurResult.Text = "关闭当前项";
            this.tsBtnDelCurResult.Click += new System.EventHandler(this.tsBtnDelCurResult_Click);
            // 
            // tsBtnDelAllResult
            // 
            this.tsBtnDelAllResult.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnDelAllResult.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDelAllResult.Image")));
            this.tsBtnDelAllResult.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelAllResult.Name = "tsBtnDelAllResult";
            this.tsBtnDelAllResult.Size = new System.Drawing.Size(60, 22);
            this.tsBtnDelAllResult.Text = "全部关闭";
            this.tsBtnDelAllResult.Click += new System.EventHandler(this.tsBtnDelAllResult_Click);
            // 
            // tabSQL
            // 
            this.tabSQL.Location = new System.Drawing.Point(192, 56);
            this.tabSQL.Name = "tabSQL";
            this.tabSQL.SelectedIndex = 0;
            this.tabSQL.Size = new System.Drawing.Size(790, 180);
            this.tabSQL.TabIndex = 5;
            // 
            // cmsTreeNode
            // 
            this.cmsTreeNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开表ToolStripMenuItem,
            this.设计表ToolStripMenuItem,
            this.新建表ToolStripMenuItem1,
            this.toolStripSeparator3,
            this.删除表ToolStripMenuItem,
            this.清空表ToolStripMenuItem,
            this.toolStripSeparator4,
            this.重命名ToolStripMenuItem});
            this.cmsTreeNode.Name = "cmsTreeNode";
            this.cmsTreeNode.Size = new System.Drawing.Size(113, 148);
            // 
            // 打开表ToolStripMenuItem
            // 
            this.打开表ToolStripMenuItem.Name = "打开表ToolStripMenuItem";
            this.打开表ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.打开表ToolStripMenuItem.Text = "打开表";
            this.打开表ToolStripMenuItem.Click += new System.EventHandler(this.打开表ToolStripMenuItem_Click);
            // 
            // 设计表ToolStripMenuItem
            // 
            this.设计表ToolStripMenuItem.Name = "设计表ToolStripMenuItem";
            this.设计表ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.设计表ToolStripMenuItem.Text = "设计表";
            this.设计表ToolStripMenuItem.Click += new System.EventHandler(this.设计表ToolStripMenuItem_Click);
            // 
            // 新建表ToolStripMenuItem1
            // 
            this.新建表ToolStripMenuItem1.Name = "新建表ToolStripMenuItem1";
            this.新建表ToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.新建表ToolStripMenuItem1.Text = "新建表";
            this.新建表ToolStripMenuItem1.Click += new System.EventHandler(this.新建表ToolStripMenuItem1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(109, 6);
            // 
            // 删除表ToolStripMenuItem
            // 
            this.删除表ToolStripMenuItem.Name = "删除表ToolStripMenuItem";
            this.删除表ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.删除表ToolStripMenuItem.Text = "删除表";
            this.删除表ToolStripMenuItem.Click += new System.EventHandler(this.删除表ToolStripMenuItem_Click);
            // 
            // 清空表ToolStripMenuItem
            // 
            this.清空表ToolStripMenuItem.Name = "清空表ToolStripMenuItem";
            this.清空表ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.清空表ToolStripMenuItem.Text = "清空表";
            this.清空表ToolStripMenuItem.Click += new System.EventHandler(this.清空表ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(109, 6);
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.重命名ToolStripMenuItem.Text = "重命名";
            this.重命名ToolStripMenuItem.Click += new System.EventHandler(this.重命名ToolStripMenuItem_Click);
            // 
            // cmsTreeRoot
            // 
            this.cmsTreeRoot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建表ToolStripMenuItem2,
            this.刷新ToolStripMenuItem1});
            this.cmsTreeRoot.Name = "cmsTreeRoot";
            this.cmsTreeRoot.Size = new System.Drawing.Size(113, 48);
            // 
            // 新建表ToolStripMenuItem2
            // 
            this.新建表ToolStripMenuItem2.Name = "新建表ToolStripMenuItem2";
            this.新建表ToolStripMenuItem2.Size = new System.Drawing.Size(112, 22);
            this.新建表ToolStripMenuItem2.Text = "新建表";
            this.新建表ToolStripMenuItem2.Click += new System.EventHandler(this.新建表ToolStripMenuItem2_Click);
            // 
            // 刷新ToolStripMenuItem1
            // 
            this.刷新ToolStripMenuItem1.Name = "刷新ToolStripMenuItem1";
            this.刷新ToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.刷新ToolStripMenuItem1.Text = "刷新";
            this.刷新ToolStripMenuItem1.Click += new System.EventHandler(this.刷新ToolStripMenuItem1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tabSQL);
            this.Controls.Add(this.pnlResult);
            this.Controls.Add(this.tvwDB);
            this.Controls.Add(this.tsp1);
            this.Controls.Add(this.mns1);
            this.MainMenuStrip = this.mns1;
            this.MinimumSize = new System.Drawing.Size(600, 390);
            this.Name = "FrmMain";
            this.Text = "DBMS Management Studio ";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.mns1.ResumeLayout(false);
            this.mns1.PerformLayout();
            this.tsp1.ResumeLayout(false);
            this.tsp1.PerformLayout();
            this.pnlResult.ResumeLayout(false);
            this.pnlResult.PerformLayout();
            this.tspResult.ResumeLayout(false);
            this.tspResult.PerformLayout();
            this.cmsTreeNode.ResumeLayout(false);
            this.cmsTreeRoot.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mns1;
        private System.Windows.Forms.ToolStripMenuItem 数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tsp1;
        private System.Windows.Forms.ToolStripButton tsBtnRefreshTvw;
        private System.Windows.Forms.ToolStripButton tsBtnCreateTable;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnCreateSQL;
        private System.Windows.Forms.ToolStripButton tsBtnExeCurSQL;
        private System.Windows.Forms.TreeView tvwDB;
        private System.Windows.Forms.Panel pnlResult;
        private System.Windows.Forms.TabControl tabResult;
        private System.Windows.Forms.ToolStrip tspResult;
        private System.Windows.Forms.ToolStripButton tsBtnDelCurResult;
        private System.Windows.Forms.ToolStripButton tsBtnDelAllResult;
        private System.Windows.Forms.ToolStripButton tsBtnDelCurSQL;
        private System.Windows.Forms.ToolStripButton tsBtnDelAllSQL;
        private System.Windows.Forms.TabControl tabSQL;
        private System.Windows.Forms.ContextMenuStrip cmsTreeNode;
        private System.Windows.Forms.ToolStripMenuItem 打开表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设计表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建表ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 删除表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsTreeRoot;
        private System.Windows.Forms.ToolStripMenuItem 新建表ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem1;
    }
}