using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmProductManualNew : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public frmProductManualNew()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "";
            ofd.ShowDialog();
            if (ofd.FileName == null || ofd.FileName == " ")
                return;
            txtManual.Text = ofd.FileName;
        }

        private void frmProductManualNew_Load(object sender, EventArgs e)
        {
            cmbProduct.Source(new DAL.Product().Select());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();
            int er = 0;
            if(cmbProduct.SelectedValue == null || cmbProduct.SelectedValue.ToString() == " ")

            {
                er++;
                ep.SetError(cmbProduct, "Select One");
            }
            if(txtManual.Text == "")
            {
                er++;
                ep.SetError(txtManual, "Required");
            }
            if (er > 0)
                return;

            DAL.ProductManual pm = new DAL.ProductManual();
            pm.ProductId = Convert.ToInt32(cmbProduct.SelectedValue);
            pm.Manual = MyControls.FileImage.FileToByte(txtManual.Text);
            pm.FileName = System.IO.Path.GetFileName(txtManual.Text);
            if(pm.Insert())
            {
                MessageBox.Show("Data Saved");
                MyControls.Helper.clear(this);
                cmbProduct.Focus();

            }
            else
            {
                MessageBox.Show(pm.Error);
            }
        }
    }
}
