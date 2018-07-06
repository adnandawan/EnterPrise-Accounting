using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmTransaction : BDJ.Enterprise.Presentation.frmDashboard
    {
        public int VoucherId { get; set; }
        public frmTransaction()
        {
            InitializeComponent();
        }

        private void frmTransaction_Load(object sender, EventArgs e)
        {
            cmbVoucher.Source(new DAL.Voucher().Select());
            cmbVoucher.SelectedValue = VoucherId;
            cmbVoucher.Enabled = false;


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmTransactionNew TransactionNew = new Presentation.frmTransactionNew();
            TransactionNew.VoucherId = this.VoucherId;
            TransactionNew.ShowDialog();
            btnSearch.PerformClick();
        }
    }
}
