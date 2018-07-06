namespace BDJ.Enterprise.Presentation
{
    partial class frmVoucherNew
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkAutoNumber = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCurrentNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPostfix = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.chkAutoPrint = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 380);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(282, 380);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(15, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(349, 20);
            this.txtName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(15, 64);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(349, 59);
            this.txtDescription.TabIndex = 2;
            // 
            // chkAutoNumber
            // 
            this.chkAutoNumber.AutoSize = true;
            this.chkAutoNumber.Location = new System.Drawing.Point(15, 140);
            this.chkAutoNumber.Name = "chkAutoNumber";
            this.chkAutoNumber.Size = new System.Drawing.Size(97, 17);
            this.chkAutoNumber.TabIndex = 3;
            this.chkAutoNumber.Text = "Auto Number ?";
            this.chkAutoNumber.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Current Number";
            // 
            // txtCurrentNumber
            // 
            this.txtCurrentNumber.Location = new System.Drawing.Point(15, 183);
            this.txtCurrentNumber.Name = "txtCurrentNumber";
            this.txtCurrentNumber.Size = new System.Drawing.Size(349, 20);
            this.txtCurrentNumber.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Prefix";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(15, 223);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(349, 20);
            this.txtPrefix.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Postfix";
            // 
            // txtPostfix
            // 
            this.txtPostfix.Location = new System.Drawing.Point(15, 260);
            this.txtPostfix.Name = "txtPostfix";
            this.txtPostfix.Size = new System.Drawing.Size(349, 20);
            this.txtPostfix.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Length";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(15, 301);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(349, 20);
            this.txtLength.TabIndex = 2;
            // 
            // chkAutoPrint
            // 
            this.chkAutoPrint.AutoSize = true;
            this.chkAutoPrint.Location = new System.Drawing.Point(15, 340);
            this.chkAutoPrint.Name = "chkAutoPrint";
            this.chkAutoPrint.Size = new System.Drawing.Size(72, 17);
            this.chkAutoPrint.TabIndex = 4;
            this.chkAutoPrint.Text = "Auto Print";
            this.chkAutoPrint.UseVisualStyleBackColor = true;
            // 
            // frmVoucherNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(386, 418);
            this.Controls.Add(this.chkAutoPrint);
            this.Controls.Add(this.chkAutoNumber);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.txtPostfix);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCurrentNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmVoucherNew";
            this.Text = "  ";
            this.Load += new System.EventHandler(this.frmVoucherNew_Load);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtCurrentNumber, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtPrefix, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtPostfix, 0);
            this.Controls.SetChildIndex(this.txtLength, 0);
            this.Controls.SetChildIndex(this.txtDescription, 0);
            this.Controls.SetChildIndex(this.chkAutoNumber, 0);
            this.Controls.SetChildIndex(this.chkAutoPrint, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkAutoNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCurrentNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPostfix;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.CheckBox chkAutoPrint;
    }
}
