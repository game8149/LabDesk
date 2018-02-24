
using LabDesk.Code.Base;
using LabDesk.Code.ControlSistemaInterno.GestorSonido;
using LabDesk.Code.PresentationLayer.ComponenteGeneral;
using LabDesk.Code.PresentationLayer.GUISesion;
using LabDesk.Code.PresentationLayer.GUISistema;
using System;
using System.Windows.Forms;

namespace LabDesk.Code.Forms.Main
{
    public partial class FormInicioSesion : Form
    {

        public FormInicioSesion()
        {
            this.InitializeComponent();
            this.CampDni.KeyPress += new KeyPressEventHandler(this.CampDni_KeyPress);
            this.CampClave.KeyPress += new KeyPressEventHandler(this.CampClave_KeyPress);
            this.CampDni.Focus();
            this.BtnUISesion1.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click);
            this.BtnUISesion1.Tipo = ButtonUI.ButtonTipo.Default;
            this.panelSesionUI1.Title = RecursosUI.Propietario;
            this.panelSesionUI1.Subtitle = RecursosUI.SistemaName;
            base.SuspendLayout();
            Decorator.Instance().FormatStyle(base.Controls);
            base.ResumeLayout();
        }

        private void CampClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.BtnUISesion1.ComponenteUI.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyChar == '\x001b')
            {
                base.Close();
                e.Handled = true;
            }
        }

        private void CampDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((!char.IsNumber(e.KeyChar) && (e.KeyChar != '\b')) && ((e.KeyChar != '\x0002') && (e.KeyChar != '\x0003'))) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '\r')
            {
                this.CampClave.Focus();
                e.Handled = true;
            }
            else if (e.KeyChar == '\x001b')
            {
                base.Close();
                e.Handled = true;
            }
        }

        private void ComponenteUI_Click(object sender, EventArgs e)
        {
            ReproductorSonido.Instance().RequestPlaySound(ReproductorSonido.TipoSonido.ClickBtnUI);
            LogicaControlSistema sistema = new LogicaControlSistema();
            try
            {
                char[] trimChars = new char[] { ' ' };
                if (sistema.IniciarSesion(this.CampDni.Text, this.CampClave.Text.Trim(trimChars)))
                {
                    base.Visible = false;
                    ReproductorSonido.Instance().RequestPlaySound(ReproductorSonido.TipoSonido.InicioSesion);
                }
            }
            catch (Exception exception)
            {
                this.CampClave.Text = string.Empty;
                FormMensaje.Error(RecursosUIMensajes.MsgNone + exception.Message);
            }
        }


        private void FormInicioSesion_Load(object sender, EventArgs e)
        {
        }

   

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            base.Visible = false;
            new FormCrearCuenta().ShowDialog();
            base.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        public Principal Formulario { get; set; }
    }
}
