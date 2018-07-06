using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmHead : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmHead()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.Head head = new DAL.Head();
            dgvHead.DataSource = head.Select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmHeadNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void frmHead_Load(object sender, EventArgs e)
        {
            DAL.Head head = new DAL.Head();
            DataTable dt = head.Select(" where h1.headId is null ").Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dt.Rows[i].ItemArray[1].ToString();
                tn.Tag = dt.Rows[i].ItemArray[0].ToString();
                addChild(Convert.ToInt32(dt.Rows[i].ItemArray[0]), tn);
                tvHead.Nodes.Add(tn);
            }
        }

        private void addChild(int pid, TreeNode tn)
        {
            DAL.Head head = new DAL.Head();
            DataTable dt = head.Select(" where h1.headId = " + pid.ToString()).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode tn2 = new TreeNode();
                tn2.Text = dt.Rows[i].ItemArray[1].ToString();
                tn2.Tag = dt.Rows[i].ItemArray[0].ToString();
                addChild(Convert.ToInt32(dt.Rows[i].ItemArray[0]), tn2);
                tn.Nodes.Add(tn2);
            }
        }
    }
}
