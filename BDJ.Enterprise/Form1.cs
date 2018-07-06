using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BDJ.Enterprise.Presentation;

namespace BDJ.Enterprise
{
    public partial class Form1 : Form
    {
        frmCity city = new frmCity();
        frmHead head = new frmHead();


        frmProduct product = new frmProduct();
        frmLedger ledger = new frmLedger();
        frmProductPrice productPrice = new frmProductPrice();
        frmProductImage productImage = new frmProductImage();
        frmBrand brand = new frmBrand();
        frmUnit unit = new frmUnit();
        frmVoucher voucher = new frmVoucher();
        frmFormula formula = new frmFormula();
        frmProductManual productManual = new frmProductManual();


        frmCashFlow cashFlow = new frmCashFlow();
        
       
        public Form1()
        {
            InitializeComponent();
        }

        private void cityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (city.IsDisposed)
                city = new frmCity();
            city.MdiParent = this;
            city.Show();
            city.BringToFront();
        }

        private void headToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (head.IsDisposed)
                head = new frmHead();
            head.MdiParent = this;
            head.Show();
            head.BringToFront();
        }

        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (product.IsDisposed)
                product = new Presentation.frmProduct();
            product.MdiParent = this;
            product.Show();
            product.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DAL.Voucher vcr = new DAL.Voucher();
            DataTable dt = vcr.Select().Tables[0];
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                ToolStripMenuItem mnu = new ToolStripMenuItem();
                mnu.Text = dt.Rows[i].ItemArray[1].ToString();
                mnu.Tag = dt.Rows[i].ItemArray[0].ToString();
                mnu.Click += Mnu_Click;
                mnuVoucher.DropDownItems.Add(mnu);
            }
        }

        private void Mnu_Click(object sender, EventArgs e)
        {
            frmTransaction transaction = new frmTransaction();
            transaction.VoucherId = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
            transaction.MdiParent = this;
            transaction.Text = ((ToolStripMenuItem)sender).Text;
            transaction.Show();
            transaction.BringToFront();
        }

        private void priceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productPrice.IsDisposed)
                productPrice = new frmProductPrice();
            productPrice.MdiParent = this;
            productPrice.Show();
            productPrice.BringToFront();
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productImage.IsDisposed)
                productImage = new frmProductImage();
            productImage.MdiParent = this;
            productImage.Show();
            productImage.BringToFront();
        }

        private void ledgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ledger.IsDisposed)
                ledger = new Presentation.frmLedger();
            ledger.MdiParent = this;
            ledger.Show();
            ledger.BringToFront();
        }

        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (brand.IsDisposed)
                brand = new frmBrand();
            brand.MdiParent = this;
            brand.Show();
            brand.BringToFront();
        }

        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (unit.IsDisposed)
                unit = new frmUnit();
            unit.MdiParent = this;
            unit.Show();
            unit.BringToFront();
        }

        private void voucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (voucher.IsDisposed)
                voucher = new frmVoucher();
            voucher.MdiParent = this;
            voucher.Show();
            voucher.BringToFront();
        }

        private void productionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (formula.IsDisposed)
                formula = new Presentation.frmFormula();
            formula.MdiParent = this;
            formula.Show();
            formula.BringToFront();
        }

        private void manualToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (productManual.IsDisposed)
                productManual = new Presentation.frmProductManual();
            productManual.MdiParent = this;
            productManual.Show();
            productManual.BringToFront();
        }

        private void mnuVoucher_Click(object sender, EventArgs e)
        {

        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cashFlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cashFlow.IsDisposed)
                cashFlow = new Presentation.frmCashFlow();
            cashFlow.MdiParent = this;
            cashFlow.Show();
            cashFlow.BringToFront();

        }

        private void referencesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
