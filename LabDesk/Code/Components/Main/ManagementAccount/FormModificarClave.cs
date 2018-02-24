using LabDesk.Code.Base;
using LabDesk.Code.PresentationLayer.ComponenteGeneral;
using System;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main.ManagementAccount
{
    public partial class FormModificarClave : Form
    {

        public FormModificarClave()
        {
            this.InitializeComponent();
            base.SuspendLayout();
            this.BtnUIUsuarioClave1.Tipo = ButtonUI.ButtonTipo.Ok;
            this.BtnUIUsuarioClave2.Tipo = ButtonUI.ButtonTipo.Cancel;
            this.BtnUIUsuarioClave1.ComponenteUI.Click += new EventHandler(this.BtnUIUsuarioClave1_Click);
            this.BtnUIUsuarioClave2.ComponenteUI.Click += new EventHandler(this.BtnUIUsuarioClave2_Click);
            Decorator.Instance().FormatStyle(base.Controls);
            base.ResumeLayout();
        }

        private void BtnUIUsuarioClave1_Click(object sender, EventArgs e)
        {
            LogicaCuenta cuenta = new LogicaCuenta();
            try
            {
                if (cuenta.ActualizarClave(this.Cuenta, this.CampNueva.Text, this.CampAntigua.Text))
                {
                    base.Close();
                }
            }
            catch (Exception exception1)
            {
                FormMensaje.Error(exception1.Message);
            }
        }

        private void BtnUIUsuarioClave2_Click(object sender, EventArgs e)
        {
            base.Close();
        }


        public LabDesk.Code.EntityLayer.EFicha.Cuenta Cuenta { get; set; }
    }
}
