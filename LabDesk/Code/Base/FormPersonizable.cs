
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Base
{
    public class FormPersonalizable : Form
    {
        public void CambiarFuente(Control c)
        {
            if (c.Controls.Count == 0)
            {
                c.Font = new Font("Futura Bk BT", c.Font.Size);
            }
            else
            {
                foreach (Control control in c.Controls)
                {
                    this.CambiarFuente(control);
                }
            }
        }
    }
}
