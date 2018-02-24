
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Base
{
    public partial class ButtonUI : UserControl
    {
        public int Id;
        public ButtonTipo Tipo;

        public ButtonUI()
        {
            this.InitializeComponent();
            this.button1.SizeChanged += new EventHandler(this.Button1_SizeChanged);
        }

        private void Button1_SizeChanged(object sender, EventArgs e)
        {
            base.Size = this.button1.Size;
            this.button1.Location = new Point(0, 0);
        }

        private void ButtonUI_Load(object sender, EventArgs e)
        {
        }
        
        public Button ComponenteUI =>
            this.button1;

        public enum ButtonTipo
        {
            Next,
            Ok,
            Cancel,
            Modify,
            Item,
            ItemLight,
            ItemLow,
            Delete,
            Default
        }

    }
}
