using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmBrand : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmBrand()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.Brand brand = new DAL.Brand();
            dgvData.DataSource = brand.Select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmBrandNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void frmBrand_Load(object sender, EventArgs e)
        {

        }
    }
}
