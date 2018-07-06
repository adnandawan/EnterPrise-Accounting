using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmLedger : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmLedger()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.Ledger ledger = new DAL.Ledger();
           
            dgvData.DataSource = ledger.Select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmLedgerNew().ShowDialog();
            btnSearch.PerformClick();
        }
    }
}
