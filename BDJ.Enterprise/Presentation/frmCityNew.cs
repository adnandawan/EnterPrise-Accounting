using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmCityNew : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public frmCityNew()
        {
            InitializeComponent();
        }

        private void frmCityNew_Load(object sender, EventArgs e)
        {
            DAL.Country country = new DAL.Country();
            cmbCountry.Source(country.Select());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            if(txtName.Text == "")
            {
                er++;
                ep.SetError(txtName, "Required");
            }
            if(cmbCountry.SelectedValue == null || cmbCountry.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbCountry, "Required");
            }
            if (er > 0)
                return;

            DAL.City city = new DAL.City();
            city.Name = txtName.Text;
            city.CountryId = Convert.ToInt32(cmbCountry.SelectedValue);
            if(city.Insert())
            {
                MessageBox.Show("Data Saved");
                txtName.Text = "";
                cmbCountry.SelectedValue = -1;
                txtName.Focus();
            }
            else
            {
                MessageBox.Show(city.Error);
            }
        }
    }
}
