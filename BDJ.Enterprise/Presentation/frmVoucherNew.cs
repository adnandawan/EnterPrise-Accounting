using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmVoucherNew : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public frmVoucherNew()
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
            if (txtDescription.Text == "")
            {
                er++;
                ep.SetError(txtDescription, "Required");

            }
            if (txtCurrentNumber.Text == "")
            {
                er++;
                ep.SetError(txtCurrentNumber, "Required");

            }
            if (txtPrefix.Text == "")
            {
                er++;
                ep.SetError(txtPrefix, "Required");

            }
            if (txtPostfix.Text == "")
            {
                er++;
                ep.SetError(txtPostfix, "Required");

            }
            if (er > 0)
                return;
            DAL.Voucher voucher = new DAL.Voucher();
            voucher.Name = txtName.Text;
            voucher.Description = txtDescription.Text;
            voucher.AutoNumber = chkAutoNumber.Checked;
            voucher.CurrentNumber = Convert.ToInt32(txtCurrentNumber.Text);
            voucher.Prefix = txtPrefix.Text;
            voucher.Postfix = txtPostfix.Text;
            voucher.Length = Convert.ToInt32(txtLength.Text);
            voucher.AutoPrint = chkAutoPrint.Checked;

            if(voucher.Insert())
            {
                MessageBox.Show("Data Saved");
                MyControls.Helper.clear(this);
                txtName.Focus();
            }
            else
            {
                MessageBox.Show(voucher.Error);
            }
        }

        private void frmVoucherNew_Load(object sender, EventArgs e)
        {

        }
    }
}
