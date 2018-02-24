using System;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main.ManagementAccount
{

    public partial class FormAutorizacion : Form
    {
        public FormAutorizacion()
        {
            this.InitializeComponent();
            base.FormClosing += new FormClosingEventHandler(this.FormAutorizacion_FormClosing);
        }

        private void BtnInicia_Click(object sender, EventArgs e)
        {
            LogicaControlSistema sistema = new LogicaControlSistema();
            try
            {
                sistema.AperturaAutorizacion(this.CampDni.Text, this.CampClave.Text);
                base.Visible = false;
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message, "Acceso Denegado");
            }
        }

       

        private void FormAutorizacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.Visible = true;
            e.Cancel = false;
        }

        private void FormAutorizacion_Load(object sender, EventArgs e)
        {
        }

       
    }
}
