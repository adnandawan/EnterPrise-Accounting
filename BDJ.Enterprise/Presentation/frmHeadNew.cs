using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmHeadNew : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public frmHeadNew()
        {
            InitializeComponent();
        }

        private void frmHeadNew_Load(object sender, EventArgs e)
        {
            DAL.Head head = new DAL.Head();
            cmbHead.Source(head.Select());
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
            DAL.Head head = new DAL.Head();
            head.Name = txtName.Text;
            head.Description = txtDescription.Text;
            if (cmbHead.SelectedValue != null && cmbHead.SelectedValue.ToString() != "") 
            head.HeadId = Convert.ToInt32(cmbHead.SelectedValue); 
            if(head.Insert())
            {
                MessageBox.Show("Data Saved");
                txtName.Text = "";
                txtDescription.Text = "";
                cmbHead.SelectedValue = -1;
                txtName.Focus();
            }
            else
            {
                MessageBox.Show(head.Error);
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DAL.Head head = new DAL.Head();
            cmbHead.Source(head.Select());
        }
    }
}
