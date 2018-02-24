using System;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main.Settings
{
    public partial class FormConfigServer : Form
    {
        public FormConfigServer()
        {
            this.InitializeComponent();
            base.FormClosing += new FormClosingEventHandler(this.FormConfigServer_FormClosing);
            this.CampConexion.Text = ConfiguracionSystem.ConexionConfig;
        }

        private void BtnInicia_Click(object sender, EventArgs e)
        {
        }

     

        private void FormAutorizacion_Load(object sender, EventArgs e)
        {
        }

        private void FormConfigServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.Visible = true;
            e.Cancel = false;
        }

       
    }
}
