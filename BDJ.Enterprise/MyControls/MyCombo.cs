using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyControls
{
    public class MyCombo:System.Windows.Forms.ComboBox
    {
        public MyCombo():base()
        {
            this.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        }
        public bool Source(DataSet ds, string Display = "name", string Value = "id")
        {
            this.DataSource = ds.Tables[0];
            this.DisplayMember = Display;
            this.ValueMember = Value;
            this.SelectedValue = -1;
            return true;
        }
    } 
}
