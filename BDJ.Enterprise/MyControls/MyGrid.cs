using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyControls
{
    public class MyGrid:System.Windows.Forms.DataGridView
    {
        public MyGrid():base()
        {
            this.BackgroundColor = System.Drawing.Color.White;
            this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadOnly = true;

        }
    }
}
