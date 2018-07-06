using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmProductNew : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public frmProductNew()
        {
            InitializeComponent();
        }

        private void frmProductNew_Load(object sender, EventArgs e)
        {
            DAL.Brand b = new DAL.Brand();
            DAL.Category c = new DAL.Category();
            cmbBrand.Source(b.Select());
            cmbCategory.Source(c.Select());
            MyControls.Helper.Numeric(txtDiscount);
        }

        private void frmProductNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            if(txtName.Text == "")
            {
                er++;
                ep.SetError(txtName, "Required");
            }
            //validation baki
            DAL.Product p = new DAL.Product();
            p.BrandId = Convert.ToInt32(cmbBrand.SelectedValue);
            p.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
            p.Code = txtCode.Text;
            p.Description = txtDescription.Text;
            p.Discount = Convert.ToDouble(txtDiscount.Text);
            p.Name = txtName.Text;
            p.Offers = txtOffer.Text;
            p.Tag = txtTag.Text;
            p.Type = cmbType.Text;
            if(p.Insert())
            {
                MessageBox.Show("Data Saved");
                MyControls.Helper.clear(this);
                txtName.Focus();
                
            }
            else
            {
                MessageBox.Show(p.Error);
            }
        }
    }
}
