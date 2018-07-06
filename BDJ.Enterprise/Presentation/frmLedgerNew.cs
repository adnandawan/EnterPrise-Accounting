using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmLedgerNew : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public frmLedgerNew()
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
            if (txtContact.Text == "")
            {
                er++;
                ep.SetError(txtContact, "Required");
            }
            if (txtContactPerson.Text == "")
            {
                er++;
                ep.SetError(txtContactPerson, "Required");
            }
            if (txtPassword.Text == "")
            {
                er++;
                ep.SetError(txtPassword, "Required");
            }
           if(cmbCity.SelectedValue == null || cmbCity.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbCity, "Required");
            }
            if (cmbHead.SelectedValue == null || cmbHead.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbHead, "Required");
            }
            if(txtEmployee.Text == "")
            {
                er++;
                ep.SetError(txtEmployee, "Required");
            }
            if (er > 0)
                return;
            DAL.Ledger ledger = new DAL.Ledger();
            ledger.Name = txtName.Text;
            ledger.Contact = txtContact.Text;
            ledger.ContactPerson = txtContactPerson.Text;
            ledger.Address = txtAddress.Text;
            ledger.Description = txtDescription.Text;
            ledger.Email = txtEmail.Text;
            ledger.EmployeeId = Convert.ToInt32(txtEmployee.Text);
            ledger.Password = txtPassword.Text;
            ledger.HeadId = Convert.ToInt32(cmbHead.SelectedValue);
            ledger.CityId = Convert.ToInt32(cmbCity.SelectedValue);
            ledger.CreateDate = dateTime.Value;

            if(ledger.Insert())
            {
                MessageBox.Show("Data Saved");
                MyControls.Helper.clear(this);
                txtName.Focus();
            }
            else
            {
                MessageBox.Show(ledger.Error); 
            }











        }

        private void frmLedgerNew_Load(object sender, EventArgs e)
        {
            DAL.City ct = new DAL.City();
            DAL.Head h = new DAL.Head(); 
            cmbCity.Source(ct.Select());
            cmbHead.Source(h.Select());
        }
    }
}
