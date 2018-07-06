using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmProduct : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.Product p = new DAL.Product();
            dgvData.DataSource = p.Select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmProductNew().ShowDialog();
            btnSearch.PerformClick();
        }
    }
}
