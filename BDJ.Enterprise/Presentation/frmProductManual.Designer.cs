namespace BDJ.Enterprise.Presentation
{
    partial class frmProductManual
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
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileName = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.myGrid1)).BeginInit();
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
            this.myGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductId,
            this.colProduct,
            this.colFileName});
            this.myGrid1.Location = new System.Drawing.Point(-1, 41);
            this.myGrid1.Name = "myGrid1";
            this.myGrid1.ReadOnly = true;
            this.myGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.myGrid1.Size = new System.Drawing.Size(645, 296);
            this.myGrid1.TabIndex = 3;
            this.myGrid1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.myGrid1_CellContentDoubleClick);
            // 
            // colProductId
            // 
            this.colProductId.DataPropertyName = "productId";
            this.colProductId.HeaderText = "ProductId";
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            this.colProductId.Visible = false;
            // 
            // colProduct
            // 
            this.colProduct.DataPropertyName = "product";
            this.colProduct.HeaderText = "Product";
            this.colProduct.Name = "colProduct";
            this.colProduct.ReadOnly = true;
            // 
            // colFileName
            // 
            this.colFileName.DataPropertyName = "fileName";
            this.colFileName.HeaderText = "FileName";
            this.colFileName.Name = "colFileName";
            this.colFileName.ReadOnly = true;
            this.colFileName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmProductManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(643, 337);
            this.Controls.Add(this.myGrid1);
            this.Name = "frmProductManual";
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.myGrid1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyControls.MyGrid myGrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewLinkColumn colFileName;
    }
}
