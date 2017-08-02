namespace DBMS
{
    partial class FrmTableName
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
            this.lblSetTableName = new System.Windows.Forms.Label();
            this.txtSetTableName = new System.Windows.Forms.TextBox();
            this.btnSetTableName = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSetTableName
            // 
            this.lblSetTableName.AutoSize = true;
            this.lblSetTableName.Location = new System.Drawing.Point(20, 13);
            this.lblSetTableName.Name = "lblSetTableName";
            this.lblSetTableName.Size = new System.Drawing.Size(65, 12);
            this.lblSetTableName.TabIndex = 0;
            this.lblSetTableName.Text = "输入表名：";
            // 
            // txtSetTableName
            // 
            this.txtSetTableName.Location = new System.Drawing.Point(21, 37);
            this.txtSetTableName.Name = "txtSetTableName";
            this.txtSetTableName.Size = new System.Drawing.Size(300, 21);
            this.txtSetTableName.TabIndex = 1;
            // 
            // btnSetTableName
            // 
            this.btnSetTableName.Location = new System.Drawing.Point(20, 70);
            this.btnSetTableName.Name = "btnSetTableName";
            this.btnSetTableName.Size = new System.Drawing.Size(75, 23);
            this.btnSetTableName.TabIndex = 2;
            this.btnSetTableName.Text = "确定";
            this.btnSetTableName.UseVisualStyleBackColor = true;
            this.btnSetTableName.Click += new System.EventHandler(this.btnSetTableName_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(110, 70);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmTableName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 107);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSetTableName);
            this.Controls.Add(this.txtSetTableName);
            this.Controls.Add(this.lblSetTableName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTableName";
            this.Text = "新建表";
            this.Load += new System.EventHandler(this.FrmTableName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSetTableName;
        private System.Windows.Forms.TextBox txtSetTableName;
        private System.Windows.Forms.Button btnSetTableName;
        private System.Windows.Forms.Button btnCancel;
    }
}