
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Base
{
    public partial class TextBoxUI : UserControl
    {

        public TextBoxUI()
        {
            this.InitializeComponent();
            this.textBox1.SizeChanged += new EventHandler(this.TextBox1_SizeChanged);
        }

      
        private void TextBox1_SizeChanged(object sender, EventArgs e)
        {
            base.Size = this.textBox1.Size;
            this.textBox1.Location = new Point(0, 0);
        }
    }
}
