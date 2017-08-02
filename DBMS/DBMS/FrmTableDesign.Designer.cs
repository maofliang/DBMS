namespace DBMS
{
    partial class FrmTableDesign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTableDesign));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnAddField = new System.Windows.Forms.ToolStripButton();
            this.tsBtnInsertField = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelField = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnSavaFields = new System.Windows.Forms.ToolStripButton();
            this.dgvFields = new System.Windows.Forms.DataGridView();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FieldLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldNotNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FieldIsKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FieldFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFields)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAddField,
            this.tsBtnInsertField,
            this.tsBtnDelField,
            this.toolStripSeparator1,
            this.tsBtnSavaFields});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(740, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnAddField
            // 
            this.tsBtnAddField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnAddField.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAddField.Image")));
            this.tsBtnAddField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddField.Name = "tsBtnAddField";
            this.tsBtnAddField.Size = new System.Drawing.Size(60, 22);
            this.tsBtnAddField.Text = "添加字段";
            this.tsBtnAddField.Click += new System.EventHandler(this.tsBtnAddField_Click);
            // 
            // tsBtnInsertField
            // 
            this.tsBtnInsertField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnInsertField.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnInsertField.Image")));
            this.tsBtnInsertField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnInsertField.Name = "tsBtnInsertField";
            this.tsBtnInsertField.Size = new System.Drawing.Size(60, 22);
            this.tsBtnInsertField.Text = "插入字段";
            this.tsBtnInsertField.Click += new System.EventHandler(this.tsBtnInsertField_Click);
            // 
            // tsBtnDelField
            // 
            this.tsBtnDelField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnDelField.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDelField.Image")));
            this.tsBtnDelField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelField.Name = "tsBtnDelField";
            this.tsBtnDelField.Size = new System.Drawing.Size(60, 22);
            this.tsBtnDelField.Text = "删除字段";
            this.tsBtnDelField.Click += new System.EventHandler(this.tsBtnDelField_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnSavaFields
            // 
            this.tsBtnSavaFields.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnSavaFields.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSavaFields.Image")));
            this.tsBtnSavaFields.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSavaFields.Name = "tsBtnSavaFields";
            this.tsBtnSavaFields.Size = new System.Drawing.Size(36, 22);
            this.tsBtnSavaFields.Text = "保存";
            this.tsBtnSavaFields.Click += new System.EventHandler(this.tsBtnSavaFields_Click);
            // 
            // dgvFields
            // 
            this.dgvFields.AllowUserToAddRows = false;
            this.dgvFields.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvFields.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FieldName,
            this.FieldType,
            this.FieldLength,
            this.FieldNotNull,
            this.FieldIsKey,
            this.FieldFlag});
            this.dgvFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFields.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvFields.Location = new System.Drawing.Point(0, 25);
            this.dgvFields.MultiSelect = false;
            this.dgvFields.Name = "dgvFields";
            this.dgvFields.RowTemplate.Height = 23;
            this.dgvFields.Size = new System.Drawing.Size(740, 396);
            this.dgvFields.TabIndex = 1;
            this.dgvFields.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvFields_EditingControlShowing);
            // 
            // FieldName
            // 
            this.FieldName.HeaderText = "字段名";
            this.FieldName.MinimumWidth = 80;
            this.FieldName.Name = "FieldName";
            this.FieldName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FieldName.Width = 200;
            // 
            // FieldType
            // 
            this.FieldType.HeaderText = "类型";
            this.FieldType.Items.AddRange(new object[] {
            "int",
            "long",
            "double",
            "char",
            "varchar"});
            this.FieldType.MinimumWidth = 70;
            this.FieldType.Name = "FieldType";
            this.FieldType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FieldType.Width = 120;
            // 
            // FieldLength
            // 
            this.FieldLength.HeaderText = "长度";
            this.FieldLength.MinimumWidth = 70;
            this.FieldLength.Name = "FieldLength";
            this.FieldLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FieldLength.Width = 120;
            // 
            // FieldNotNull
            // 
            this.FieldNotNull.HeaderText = "不是null";
            this.FieldNotNull.MinimumWidth = 80;
            this.FieldNotNull.Name = "FieldNotNull";
            this.FieldNotNull.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FieldNotNull.Width = 120;
            // 
            // FieldIsKey
            // 
            this.FieldIsKey.HeaderText = "主键";
            this.FieldIsKey.MinimumWidth = 70;
            this.FieldIsKey.Name = "FieldIsKey";
            this.FieldIsKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FieldIsKey.Width = 120;
            // 
            // FieldFlag
            // 
            this.FieldFlag.HeaderText = "标记";
            this.FieldFlag.Name = "FieldFlag";
            this.FieldFlag.Visible = false;
            // 
            // FrmTableDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 421);
            this.Controls.Add(this.dgvFields);
            this.Controls.Add(this.toolStrip1);
            this.MinimumSize = new System.Drawing.Size(430, 230);
            this.Name = "FrmTableDesign";
            this.Text = "设计表";
            this.Load += new System.EventHandler(this.FrmTableDesign_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFields)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnAddField;
        private System.Windows.Forms.ToolStripButton tsBtnInsertField;
        private System.Windows.Forms.ToolStripButton tsBtnDelField;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnSavaFields;
        private System.Windows.Forms.DataGridView dgvFields;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewComboBoxColumn FieldType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldLength;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FieldNotNull;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FieldIsKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldFlag;
    }
}