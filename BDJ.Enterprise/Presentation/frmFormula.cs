using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmFormula : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmFormula()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmFormulaNew().ShowDialog();
            btnSearch.PerformClick();
        }
    }
}
