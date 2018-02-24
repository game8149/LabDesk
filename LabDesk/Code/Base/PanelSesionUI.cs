
using System;
using System.Windows.Forms;

namespace LabDesk.Code.Base
{
    public partial class PanelSesionUI : UserControl
    {
        public PanelSesionUI()
        {
            this.InitializeComponent();
            this.panel1.BackColorChanged += new EventHandler(this.Panel1_BackColorChanged);
        }


        private void Panel1_BackColorChanged(object sender, EventArgs e)
        {
            this.label1.BackColor = this.panel1.BackColor;
        }

        public Panel ComponenteUI =>
            this.panel1;

        public string Subtitle
        {
            set
            {
                this.label2.Text = value;
            }
        }

        public PanelUITipo Tipo { get; set; }

        public string Title
        {
            set
            {
                this.label1.Text = value;
            }
        }

        public enum PanelUITipo
        {
            Default
        }
    }
}
