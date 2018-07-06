using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmCashFlow : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmCashFlow()
        {
            InitializeComponent();
        }

        private void frmCashFlow_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.Reports r = new DAL.Reports();
            myGrid1.DataSource = r.CashFlow().Tables[0];

        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }
    }
}
