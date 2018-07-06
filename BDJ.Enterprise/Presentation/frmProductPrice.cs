using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmProductPrice : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmProductPrice()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmProductPriceNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.ProductPrice pp = new DAL.ProductPrice();
            dgvData.DataSource = pp.Select().Tables[0];


        }

        private void frmProductPrice_Load(object sender, EventArgs e)
        {

        }
    }
}
