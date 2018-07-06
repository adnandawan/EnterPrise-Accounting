using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyControls
{
    public static class Helper
    {
        public static bool Numeric(System.Windows.Forms.TextBox txt)
        {
            txt.KeyPress += Txt_KeyPress;
            return true;
        }
        public static bool clear(System.Windows.Forms.Form frm)

        {
               
            foreach(Control item in frm.Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
                else if(item is ComboBox)
                {
                    item.Text = "";
                    ComboBox cmb = item as ComboBox;
                    cmb.SelectedValue = -1;
                }
                else if(item is PictureBox)
                {
                    (item as PictureBox).Image = null;
                }
                else if (item is CheckBox)
                {
                    (item as CheckBox).Checked = false;
                }
               
            }
            return true;
        }
        private static void Txt_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.' || char.IsControl(e.KeyChar))
            {

            }
            else
            {
                e.Handled = true;
            }
           
        }
    }
}
