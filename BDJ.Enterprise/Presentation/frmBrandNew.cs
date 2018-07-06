using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmBrandNew : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public frmBrandNew()
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
            if (er > 0)
                return;
            DAL.Brand brand = new DAL.Brand();
            brand.Name = txtName.Text;
            brand.Description = txtDescription.Text;
            if(brand.Insert())
            {
                MessageBox.Show("Data Saved");
                MyControls.Helper.clear(this);
                txtName.Focus();
            }
            else
            {
                MessageBox.Show(brand.Error);
            }
        }

        private void frmBrandNew_Load(object sender, EventArgs e)
        {

        }
    }
}
