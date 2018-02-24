using LabDesk.Code.PresentationLayer.ComponenteGeneral;
using System;
using System.Windows.Forms;


namespace LabDesk.Code.Components.Actors.Medico
{
    public partial class PanelMedicoNuevo : UserControl
    {
       

        public PanelMedicoNuevo()
        {
            this.InitializeComponent();
            this.CampColegiatura.KeyPress += new KeyPressEventHandler(this.CampColegiatura_KeyPress);
            this.campNombre.KeyUp += new KeyEventHandler(this.CampNombre_KeyUp);
            this.CampPrimerApellido.KeyUp += new KeyEventHandler(this.CampPrimerApellido_KeyUp);
            this.CampSegundoApellido.KeyUp += new KeyEventHandler(this.CampSegundoApellido_KeyUp);
            this.CampEspecialidad.KeyUp += new KeyEventHandler(this.CampEspecialidad_KeyUp);
            this.BtnUIMedicoNuevo1.Tipo = ButtonUI.ButtonTipo.Ok;
            this.BtnUIMedicoNuevo1.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click);
            Decorator.Instance().FormatStyle(base.Controls);
        }

        private void BtnPerfilCrearCerrar_Click(object sender, EventArgs e)
        {
            base.Visible = false;
            LogicaControlSistema.DisminuirNivel();
            LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
            ((ControlMedico) base.Parent.Parent).ModeBtnFuncion(true);
            ((ControlMedico) base.Parent.Parent).Actualcontrol.Dispose();
        }

        private void CampColegiatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((!char.IsNumber(e.KeyChar) && (e.KeyChar != '\b')) && ((e.KeyChar != '\x0002') && (e.KeyChar != '\x0003'))) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
        }

        private void CampColegiatura_TextChanged(object sender, EventArgs e)
        {
        }

        private void CampEspecialidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (char.IsLetter((char) e.KeyValue) || char.IsWhiteSpace((char) e.KeyValue))
            {
                this.CampEspecialidad.Text = this.CampEspecialidad.Text.ToUpper();
                this.CampEspecialidad.SelectionStart = this.CampEspecialidad.TextLength;
            }
            else if ((e.KeyValue != 2) && (e.KeyValue != 3))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void CampNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (char.IsLetter((char) e.KeyValue) || char.IsWhiteSpace((char) e.KeyValue))
            {
                this.campNombre.Text = this.campNombre.Text.ToUpper();
                this.campNombre.SelectionStart = this.campNombre.TextLength;
            }
            else if ((e.KeyValue != 2) && (e.KeyValue != 3))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void CampPrimerApellido_KeyUp(object sender, KeyEventArgs e)
        {
            if (char.IsLetter((char) e.KeyValue) || char.IsWhiteSpace((char) e.KeyValue))
            {
                this.CampPrimerApellido.Text = this.CampPrimerApellido.Text.ToUpper();
                this.CampPrimerApellido.SelectionStart = this.CampPrimerApellido.TextLength;
            }
            else if ((e.KeyValue != 2) && (e.KeyValue != 3))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void CampSegundoApellido_KeyUp(object sender, KeyEventArgs e)
        {
            if (char.IsLetter((char) e.KeyValue) || char.IsWhiteSpace((char) e.KeyValue))
            {
                this.CampSegundoApellido.Text = this.CampSegundoApellido.Text.ToUpper();
                this.CampSegundoApellido.SelectionStart = this.CampSegundoApellido.TextLength;
            }
            else if ((e.KeyValue != 2) && (e.KeyValue != 3))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void ComponenteUI_Click(object sender, EventArgs e)
        {
            BLMedico medico = new BLMedico();
            try
            {
                Medico medico2 = new Medico {
                    Nombre = this.campNombre.Text,
                    SegundoApellido = this.CampSegundoApellido.Text,
                    PrimerApellido = this.CampPrimerApellido.Text,
                    Colegiatura = this.CampColegiatura.Text,
                    Especialidad = this.CampEspecialidad.Text,
                    Habil = this.CheckBoxHabil.Checked
                };
                medico.CrearMedico(medico2);
                FormMensaje.Confirmacion(RecursosUIMensajes.MsgPerfilOk);
                this.limpiarCampos();
            }
            catch (Exception exception)
            {
                FormMensaje.Error(RecursosUIMensajes.MsgNone + exception.Message);
            }
        }
        

        

        public void limpiarCampos()
        {
            this.campNombre.Text = "";
            this.CampSegundoApellido.Text = "";
            this.CampPrimerApellido.Text = "";
            this.CampColegiatura.Text = "";
            this.CampEspecialidad.Text = "";
            this.CheckBoxHabil.Checked = false;
        }
    }
}
