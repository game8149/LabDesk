
using System;
using System.Drawing;
using System.Windows.Forms;


namespace LabDesk.Code.Base
{
    public partial class LabelUI : UserControl
    {
        public LabelTipo Tipo;

        public LabelUI()
        {
            this.InitializeComponent();
            this.label1.SizeChanged += new EventHandler(this.LabelUI_SizeChanged);
        }


        private void LabelUI_SizeChanged(object sender, EventArgs e)
        {
            base.Size = this.label1.Size;
            this.label1.Location = new Point(0, 0);
        }

        public Label ComponenteUI =>
            this.label1;

        public enum LabelTipo
        {
            Titulo,
            Subtitulo,
            Item
        }
    }
}
