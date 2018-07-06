namespace BDJ.Enterprise.Presentation
{
    partial class frmVoucher
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvVoucher = new MyControls.MyGrid();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAutoNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPostfix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAutoPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucher)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnNew
            // 
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dgvVoucher
            // 
            this.dgvVoucher.AllowUserToAddRows = false;
            this.dgvVoucher.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MistyRose;
            this.dgvVoucher.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVoucher.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVoucher.BackgroundColor = System.Drawing.Color.White;
            this.dgvVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVoucher.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colDescription,
            this.colAutoNumber,
            this.colCurrentNumber,
            this.colPrefix,
            this.colPostfix,
            this.colLength,
            this.colAutoPrint});
            this.dgvVoucher.Location = new System.Drawing.Point(0, 41);
            this.dgvVoucher.Name = "dgvVoucher";
            this.dgvVoucher.ReadOnly = true;
            this.dgvVoucher.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVoucher.Size = new System.Drawing.Size(644, 296);
            this.dgvVoucher.TabIndex = 3;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // colAutoNumber
            // 
            this.colAutoNumber.DataPropertyName = "autonumber";
            this.colAutoNumber.HeaderText = "AutoNumber";
            this.colAutoNumber.Name = "colAutoNumber";
            this.colAutoNumber.ReadOnly = true;
            // 
            // colCurrentNumber
            // 
            this.colCurrentNumber.DataPropertyName = "currentnumber";
            this.colCurrentNumber.HeaderText = "CurrentNumber";
            this.colCurrentNumber.Name = "colCurrentNumber";
            this.colCurrentNumber.ReadOnly = true;
            // 
            // colPrefix
            // 
            this.colPrefix.DataPropertyName = "prefix";
            this.colPrefix.HeaderText = "Prefix";
            this.colPrefix.Name = "colPrefix";
            this.colPrefix.ReadOnly = true;
            // 
            // colPostfix
            // 
            this.colPostfix.DataPropertyName = "postfix";
            this.colPostfix.HeaderText = "Postfix";
            this.colPostfix.Name = "colPostfix";
            this.colPostfix.ReadOnly = true;
            // 
            // colLength
            // 
            this.colLength.DataPropertyName = "length";
            this.colLength.HeaderText = "Length";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            // 
            // colAutoPrint
            // 
            this.colAutoPrint.DataPropertyName = "auto print";
            this.colAutoPrint.HeaderText = "Auto Print";
            this.colAutoPrint.Name = "colAutoPrint";
            this.colAutoPrint.ReadOnly = true;
            // 
            // frmVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(643, 337);
            this.Controls.Add(this.dgvVoucher);
            this.Name = "frmVoucher";
            this.Load += new System.EventHandler(this.frmVoucher_Load);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.dgvVoucher, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyControls.MyGrid dgvVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAutoNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPostfix;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAutoPrint;
    }
}
