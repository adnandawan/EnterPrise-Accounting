using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmUnit : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmUnit()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.Unit unit = new DAL.Unit();
            dgvUnit.DataSource = unit.Select().Tables[0];

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmUnitNew().ShowDialog();
            btnSearch.PerformClick();
        }
    }
}
