using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmFormulaNew : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public frmFormulaNew()
        {
            InitializeComponent();
        }

        private void frmFormulaNew_Load(object sender, EventArgs e)
        {
            DAL.Product p = new DAL.Product();
            cmbProduct.Source(p.Select());

            colProduct.DataSource = p.Select().Tables[0];
            colProduct.DisplayMember = "name";
            colProduct.ValueMember = "id";


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();
            int er = 0;

            if (txtName.Text == "")
            {
                er++;
                ep.SetError(txtName, "Required");
            }
            if (cmbProduct.SelectedValue == null || cmbProduct.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbProduct, "Select Product");
            }
            if (txtQty.Text == "")
            {
                er++;
                ep.SetError(txtQty, "Required");
            }
            if (dgvDetails.Rows.Count < 2)
            {
                er++;
                ep.SetError(dgvDetails, "Enter Details");
            }
            if (er > 0)
                return;

            DAL.Formula f = new DAL.Formula();
            f.Name = txtName.Text;
            f.ProductId = Convert.ToInt32(cmbProduct.SelectedValue);
            f.Quantity = Convert.ToDecimal(txtQty.Text);
            if (f.Insert())
            {
                for (int i = 0; i < dgvDetails.Rows.Count - 1; i++)
                {
                    DAL.FormulaDetails fd = new DAL.FormulaDetails();
                    try
                    {

                        fd.FormulaId = f.LastId;
                        fd.ProductId = Convert.ToInt32(dgvDetails.Rows[i].Cells["colproduct"].Value);
                        fd.Qty = Convert.ToDouble(dgvDetails.Rows[i].Cells["colQty"].Value);
                        fd.Remarks = dgvDetails.Rows[i].Cells["colRemarks"].Value.ToString();
                        fd.Insert();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(fd.Error + "\n" + ex.Message);
                    }
                }
                MessageBox.Show("Formula Saved");
                MyControls.Helper.clear(this);
                dgvDetails.Rows.Clear();
            }
            else
            {
                MessageBox.Show(f.Error);
            }
        }
    }
}
