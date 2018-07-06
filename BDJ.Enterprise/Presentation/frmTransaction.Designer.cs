namespace BDJ.Enterprise.Presentation
{
    partial class frmTransaction
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
            this.myGrid1 = new MyControls.MyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbVoucher = new MyControls.MyCombo();
            this.cmbLedger = new MyControls.MyCombo();
            ((System.ComponentModel.ISupportInitialize)(this.myGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(431, 12);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(512, 13);
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(593, 13);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(674, 14);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(755, 14);
            // 
            // myGrid1
            // 
            this.myGrid1.AllowUserToAddRows = false;
            this.myGrid1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MistyRose;
            this.myGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.myGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.myGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myGrid1.Location = new System.Drawing.Point(1, 42);
            this.myGrid1.Name = "myGrid1";
            this.myGrid1.ReadOnly = true;
            this.myGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.myGrid1.Size = new System.Drawing.Size(840, 297);
            this.myGrid1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Voucher";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, -3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ledger";
            // 
            // cmbVoucher
            // 
            this.cmbVoucher.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVoucher.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVoucher.Enabled = false;
            this.cmbVoucher.FormattingEnabled = true;
            this.cmbVoucher.Location = new System.Drawing.Point(265, 13);
            this.cmbVoucher.Name = "cmbVoucher";
            this.cmbVoucher.Size = new System.Drawing.Size(103, 21);
            this.cmbVoucher.TabIndex = 7;
            // 
            // cmbLedger
            // 
            this.cmbLedger.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLedger.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLedger.FormattingEnabled = true;
            this.cmbLedger.Location = new System.Drawing.Point(144, 13);
            this.cmbLedger.Name = "cmbLedger";
            this.cmbLedger.Size = new System.Drawing.Size(103, 21);
            this.cmbLedger.TabIndex = 6;
            // 
            // frmTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(838, 337);
            this.Controls.Add(this.cmbLedger);
            this.Controls.Add(this.cmbVoucher);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.myGrid1);
            this.Name = "frmTransaction";
            this.Load += new System.EventHandler(this.frmTransaction_Load);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.myGrid1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmbVoucher, 0);
            this.Controls.SetChildIndex(this.cmbLedger, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyControls.MyGrid myGrid1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private MyControls.MyCombo cmbVoucher;
        private MyControls.MyCombo cmbLedger;
    }
}
