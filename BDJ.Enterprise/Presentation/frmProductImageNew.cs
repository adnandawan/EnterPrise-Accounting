using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmProductImageNew : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public frmProductImageNew()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPEG|*.jpg|PNG|*.png|GIF|*.gif";
            ofd.ShowDialog();
            if (ofd.FileName == null || ofd.FileName == "")
                return;
            pbImage.Tag = System.IO.Path.GetFileName(ofd.FileName);
            pbImage.Image = Image.FromFile(ofd.FileName);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.Image = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();
            int er = 0;
            if(cmbProduct.SelectedValue == null || cmbProduct.SelectedValue.ToString() == "" )
            {
                er++;
                ep.SetError(cmbProduct, "Select Product");
            }
            if(pbImage.Image == null)
            {
                er++;
                ep.SetError(pbImage, "Select Image");
            }
            if (er >= 0)
                return;
            DAL.ProductImage pi = new DAL.ProductImage();
            pi.ProductId = Convert.ToInt32(cmbProduct.SelectedValue);
            pi.Title = txtTitle.Text;
            pi.FileName = pbImage.Tag.ToString();
            pi.Image = MyControls.FileImage.ImageToByte(pbImage.Image);
            if(pi.Insert())
            {
                MessageBox.Show("Data Saved");
                MyControls.Helper.clear(this);
            }
            else
            {
                MessageBox.Show(pi.Error);
            }
        }

        private void frmProductImageNew_Load(object sender, EventArgs e)
        {
            DAL.Product p = new DAL.Product();
            cmbProduct.Source(p.Select());
        }
    }
}
