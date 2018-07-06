using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmCity : frmDashboard
    {
        public frmCity()
        {
            InitializeComponent();
        }

        private void frmCity_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.City city = new DAL.City();
            dgvData.DataSource = city.Select().Tables[0];
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmCityNew().ShowDialog();
            btnSearch.PerformClick();
        }
    }
}
