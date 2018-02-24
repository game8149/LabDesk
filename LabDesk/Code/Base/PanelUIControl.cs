
using System;
using System.Windows.Forms;

namespace LabDesk.Code.Base
{

    public partial class PanelUIControl : UserControl
    {

        public PanelUIControl()
        {
            this.InitializeComponent();
            this.panel4.BackColorChanged += new EventHandler(this.Panel1_BackColorChanged);
        }
        

        private void Panel1_BackColorChanged(object sender, EventArgs e)
        {
            this.label1.BackColor = this.panel4.BackColor;
        }

        public Panel ComponenteUI =>
            this.panel4;

        public Label ComponenteUIText =>
            this.label1;

        public PanelUITipo Tipo { get; set; }

        public enum PanelUITipo
        {
            Default
        }
    }
}
