using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmVoucher : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmVoucher()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.Voucher voucher = new DAL.Voucher();
            dgvVoucher.DataSource = voucher.Select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmVoucherNew().ShowDialog();
            btnSearch.PerformClick();

        }

        private void frmVoucher_Load(object sender, EventArgs e)
        {

        }
    }
}
