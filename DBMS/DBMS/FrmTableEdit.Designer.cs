namespace DBMS
{
    partial class FrmTableEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTableEdit));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnAddRecord = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelRecord = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnSaveRecords = new System.Windows.Forms.ToolStripButton();
            this.dgvRecords = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAddRecord,
            this.tsBtnDelRecord,
            this.toolStripSeparator1,
            this.tsBtnSaveRecords});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(844, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnAddRecord
            // 
            this.tsBtnAddRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnAddRecord.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAddRecord.Image")));
            this.tsBtnAddRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddRecord.Name = "tsBtnAddRecord";
            this.tsBtnAddRecord.Size = new System.Drawing.Size(60, 22);
            this.tsBtnAddRecord.Text = "添加记录";
            this.tsBtnAddRecord.Click += new System.EventHandler(this.tsBtnAddRecord_Click);
            // 
            // tsBtnDelRecord
            // 
            this.tsBtnDelRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnDelRecord.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDelRecord.Image")));
            this.tsBtnDelRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelRecord.Name = "tsBtnDelRecord";
            this.tsBtnDelRecord.Size = new System.Drawing.Size(60, 22);
            this.tsBtnDelRecord.Text = "删除记录";
            this.tsBtnDelRecord.Click += new System.EventHandler(this.tsBtnDelRecord_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnSaveRecords
            // 
            this.tsBtnSaveRecords.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnSaveRecords.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSaveRecords.Image")));
            this.tsBtnSaveRecords.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSaveRecords.Name = "tsBtnSaveRecords";
            this.tsBtnSaveRecords.Size = new System.Drawing.Size(36, 22);
            this.tsBtnSaveRecords.Text = "保存";
            this.tsBtnSaveRecords.Click += new System.EventHandler(this.tsBtnSaveRecords_Click);
            // 
            // dgvRecords
            // 
            this.dgvRecords.AllowUserToAddRows = false;
            this.dgvRecords.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecords.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvRecords.Location = new System.Drawing.Point(0, 25);
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.RowTemplate.Height = 23;
            this.dgvRecords.Size = new System.Drawing.Size(844, 496);
            this.dgvRecords.TabIndex = 1;
            this.dgvRecords.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecords_CellValueChanged);
            // 
            // FrmTableEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 521);
            this.Controls.Add(this.dgvRecords);
            this.Controls.Add(this.toolStrip1);
            this.MinimumSize = new System.Drawing.Size(430, 230);
            this.Name = "FrmTableEdit";
            this.Text = "编辑表";
            this.Load += new System.EventHandler(this.FrmTableEdit_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnAddRecord;
        private System.Windows.Forms.ToolStripButton tsBtnDelRecord;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnSaveRecords;
        private System.Windows.Forms.DataGridView dgvRecords;
    }
}