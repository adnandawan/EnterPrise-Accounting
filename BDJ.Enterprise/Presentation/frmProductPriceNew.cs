using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmProductPriceNew : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public frmProductPriceNew()
        {
            InitializeComponent();
        }

        private void frmProductPriceNew_Load(object sender, EventArgs e)
        {
            DAL.Product p = new DAL.Product();
            DAL.Unit u = new DAL.Unit();
            cmbProduct.Source(p.Select());
            cmbUnit.Source(u.Select());
            MyControls.Helper.Numeric(txtPrice);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            if(txtPrice.Text == "")
            {
                er++;
                ep.SetError(txtPrice, "");
            }
            if (er > 0)
                return;
            //Validation baki
            DAL.ProductPrice pp = new DAL.ProductPrice();
            pp.ProductId = Convert.ToInt32(cmbProduct.SelectedValue);
            pp.UnitId = Convert.ToInt32(cmbUnit.SelectedValue);
            pp.Price = Convert.ToDouble(txtPrice.Text);

            if (pp.Insert())
            {
                MessageBox.Show("Data Saved");
                MyControls.Helper.clear(this);
                cmbProduct.Focus();
            }
            else
            {
                MessageBox.Show(pp.Error);
            }
        }
    }
}
