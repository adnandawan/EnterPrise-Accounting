using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmTransactionNew : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public int VoucherId { get; set; }

        private DAL.Voucher voucher = new DAL.Voucher();
        public frmTransactionNew()
        {
            InitializeComponent();
        }

        private void frmTransactionNew_Load(object sender, EventArgs e)
        {
                DAL.Ledger lgr = new DAL.Ledger();
            cmbEmployee.Source(lgr.Select());
            cmbLedger.Source(lgr.Select());
            cmbVoucher.Source(new DAL.Voucher().Select());
            cmbVoucher.SelectedValue = VoucherId;
            cmbVoucher.Enabled = false;

            colLedger.DataSource = lgr.Select().Tables[0];
            colLedger.DisplayMember = "name";
            colLedger.ValueMember = "id";

            voucher.Id = VoucherId;
            voucher.SelectById();
            this.Text = voucher.Name;


            loadNumber();
        }

        private void loadNumber()
        {
            if (voucher.AutoNumber)
            {
                txtNumber.ReadOnly = true;
                string s = voucher.Prefix;
                for (int i = 0; i < voucher.Length - voucher.Prefix.Length - voucher.Postfix.Length - voucher.CurrentNumber.ToString().Length; i++)
                {
                    s += "0";
                }
                s += voucher.CurrentNumber.ToString() + voucher.Postfix;
                txtNumber.Text = s;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();
            int er = 0;

            if(txtNumber.Text == "")
            {
                er++;
                ep.SetError(txtNumber, "Required");
            }
            if(cmbLedger.SelectedValue == null || cmbLedger.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbLedger, "Select" );
            }
            if(dgvDetails.Rows.Count < 2)
            {
                er++;
                ep.SetError(dgvDetails, "Enter Details");
            }
            if (er > 0)
                return;
            DAL.Journal jr = new DAL.Journal();
            jr.Date = dtpDate.Value;
            jr.EmployeeId = Convert.ToInt32(cmbEmployee.SelectedValue);
            jr.LedgerId = Convert.ToInt32(cmbLedger.SelectedValue);
            jr.Number = txtNumber.Text;
            jr.Remarks = txtRemarks.Text;
            jr.VoucherId = Convert.ToInt32(cmbVoucher.SelectedValue);
            

            if(voucher.Nature == "Debit")
            {
                jr.Debit = 0;
                jr.Credit = 100;
            }
            else
            {
                jr.Credit = 0;
                jr.Debit = 100;
            }
            if(jr.Insert())
            {
               for(int i = 0; i< dgvDetails.Rows.Count; i++)
                {
                    try
                    {
                        DAL.JournalDetails jrd = new DAL.JournalDetails();
                        jrd.JournalId = jr.LastId;
                        jrd.LedgerId = Convert.ToInt32(dgvDetails.Rows[i].Cells["colLedger"].Value);
                        jrd.Remarks = dgvDetails.Rows[i].Cells["colRemarks"].Value.ToString();
                        if (voucher.Nature == "Debit")
                        {
                            jrd.Credit = 0;
                            jrd.Debit = Convert.ToDecimal(dgvDetails.Rows[i].Cells["colamount"].Value);
                        }
                        else
                        {
                            jrd.Credit = 100;
                            jrd.Debit = 0;
                        }
                        jrd.Insert();
                    }
                    catch { }
                }
                MessageBox.Show(voucher.Name + "Journal Inserted");
                voucher.CurrentNumber += 1;
                voucher.Update();
             
                MyControls.Helper.clear(this);
                loadNumber();
            }
            else
            {
                MessageBox.Show(jr.Error);
            }
        }
    }
}
