using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmProductManual : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmProductManual()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmProductManualNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.ProductManual pm = new DAL.ProductManual();
            myGrid1.DataSource = pm.Select().Tables[0];
        }

        private void myGrid1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show(e.RowIndex.ToString() + "," + e.ColumnIndex.ToString());
           if(e.ColumnIndex == 2)
            {
                DAL.ProductManual pm = new DAL.ProductManual();
                pm.ProductId = Convert.ToInt32(myGrid1.Rows[e.RowIndex].Cells["colproductid"].Value);
                if(pm.SelectById())
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    fbd.ShowDialog();
                    if (fbd.SelectedPath == null || fbd.SelectedPath == "")
                        return;
                    MyControls.FileImage.FileFromByte(pm.Manual, fbd.SelectedPath + "/" + pm.FileName);
                    MessageBox.Show("Downloaded");
                }
                
            }
        }
    }
}
