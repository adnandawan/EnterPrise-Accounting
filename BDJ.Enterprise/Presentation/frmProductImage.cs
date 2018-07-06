using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmProductImage : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmProductImage()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmProductImageNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.ProductImage pi = new DAL.ProductImage();
            dgvData.DataSource = pi.Select().Tables[0];
        }
    }
}
