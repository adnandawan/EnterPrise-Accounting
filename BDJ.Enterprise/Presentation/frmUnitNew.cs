using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmUnitNew : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public frmUnitNew()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            if(txtName.Text == "")
            {
                er++;
                ep.SetError(txtName, "Required");
            }
            if(txtPrimaryqty.Text == "")
            {
                er++;
                ep.SetError(txtPrimaryqty, "Required");
            }
            if (er > 0)
                return;
            DAL.Unit unit = new DAL.Unit();
            unit.Name = txtName.Text;
            unit.PrimaryQty = Convert.ToDouble(txtPrimaryqty.Text);
            unit.Description = txtDescription.Text;

            if (unit.Insert())
            {
                MessageBox.Show("Data Saved");
                MyControls.Helper.clear(this);
                txtName.Focus();
            }
            else
                MessageBox.Show(unit.Error);
        }
    }
}
