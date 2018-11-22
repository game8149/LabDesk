using Entity.Code.Hospital;
using LabDesk.Code.Base;
using LabDesk.Code.Forms;
using LabDesk.Code.PresentationLayer.ComponenteGeneral;
using LabDesk.Code.StyleManager;
using System;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Actors.Medico
{
    public partial class PanelMedicoEditar : UserControl
    {
        

        public PanelMedicoEditar()
        {
            this.InitializeComponent();
            this.CampColegiatura.KeyPress += new KeyPressEventHandler(this.CampColegiatura_KeyPress);
            this.CampNombre.KeyUp += new KeyEventHandler(this.CampNombre_KeyUp);
            this.Campapellido1erno.KeyUp += new KeyEventHandler(this.CampPrimerApellido_KeyUp);
            this.Campapellido2erno.KeyUp += new KeyEventHandler(this.CampSegundoApellido_KeyUp);
            this.CampEspecialidad.KeyUp += new KeyEventHandler(this.CampEspecialidad_KeyUp);
            this.BtnUIMedicoEditar3.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click2);
            this.BtnUIMedicoEditar3.Tipo = ButtonUI.ButtonTipo.Delete;
            base.SuspendLayout();
            Decorator.Instance().FormatStyle(base.Controls);
            this.InicializarToolTip();
            base.ResumeLayout();
        }

        private void BtnPerfilEdicionCerrar_Click(object sender, EventArgs e)
        {
            if (FormMensaje.DecisionAdvertencia(RecursosUIMensajes.MsgPerfilUnsave) == DialogResult.Yes)
            {
                base.Visible = false;
                ((PanelMedicoPerfil) base.Parent).CargarDatos();
                //LogicaControlSistema.DisminuirNivel();
                //LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
                base.Dispose();
            }
        }

        private void BtnPerfilEditarGuardar_Click(object sender, EventArgs e)
        {
            Medic medico = new Medic {
                Id = ((PanelMedicoPerfil) base.Parent).Perfil.IdData,
                Names = this.CampNombre.Text,
                FirstSurname = this.Campapellido1erno.Text,
                LastSurname = this.Campapellido2erno.Text,
                CodigoColegiatura = this.CampColegiatura.Text,
                IdEspecialidad = this.CampEspecialidad.Text,
                Habil = this.CheckBoxHabil.Checked
            };
            try
            {
                //new BLMedico().ActualizarMedico(medico);
                ((PanelMedicoPerfil) base.Parent).Perfil = medico;
                FormMensaje.Confirmacion(RecursosUIMensajes.MsgPerfilSave);
            }
            catch (Exception exception)
            {
                FormMensaje.Error(RecursosUIMensajes.MsgNone + exception.Message);
            }
        }

        private void CampColegiatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((!char.IsNumber(e.KeyChar) && (e.KeyChar != '\b')) && ((e.KeyChar != '\x0002') && (e.KeyChar != '\x0003'))) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
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
                this.CampNombre.Text = this.CampNombre.Text.ToUpper();
                this.CampNombre.SelectionStart = this.CampNombre.TextLength;
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
                this.Campapellido1erno.Text = this.Campapellido1erno.Text.ToUpper();
                this.Campapellido1erno.SelectionStart = this.Campapellido1erno.TextLength;
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
                this.Campapellido2erno.Text = this.Campapellido2erno.Text.ToUpper();
                this.Campapellido2erno.SelectionStart = this.Campapellido2erno.TextLength;
            }
            else if ((e.KeyValue != 2) && (e.KeyValue != 3))
            {
                e.SuppressKeyPress = true;
            }
        }

        public void CargarDatos()
        {
            this.CampNombre.Text = ((PanelMedicoPerfil) base.Parent).Perfil.Nombre;
            this.Campapellido1erno.Text = ((PanelMedicoPerfil) base.Parent).Perfil.PrimerApellido;
            this.Campapellido2erno.Text = ((PanelMedicoPerfil) base.Parent).Perfil.SegundoApellido;
            this.CampColegiatura.Text = ((PanelMedicoPerfil) base.Parent).Perfil.Colegiatura;
            this.CampEspecialidad.Text = ((PanelMedicoPerfil) base.Parent).Perfil.Especialidad;
            this.CheckBoxHabil.Checked = ((PanelMedicoPerfil) base.Parent).Perfil.Habil;
        }

        private void ComponenteUI_Click2(object sender, EventArgs e)
        {
            try
            {
                if (FormMensaje.DecisionAdvertencia(RecursosUIMensajes.MsgPerfilDeleteDesicion) == DialogResult.Yes)
                {
                    base.Visible = false;
                    //new BLMedico().EliminarMedico(((PanelMedicoPerfil) base.Parent).Perfil.IdData);
                    FormMensaje.Confirmacion(RecursosUIMensajes.MsgPerfilDelete);
                    ((ControlMedico) base.Parent.Parent.Parent).ModeBtnFuncion(true);
                    //LogicaControlSistema.DisminuirNivel();
                    //LogicaControlSistema.DisminuirNivel();
                    //LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
                    ((PanelMedicoPerfil) base.Parent).Dispose();
                    base.Dispose();
                }
            }
            catch (Exception exception)
            {
                FormMensaje.Error(RecursosUIMensajes.MsgNone + exception.Message);
            }
        }
        

        public void InicializarToolTip()
        {
            ToolTip tip1 = new ToolTip {
                ShowAlways = true
            };
            tip1.SetToolTip(this.BtnPerfilEditarCerrar, RecursosUIToolkit.BtnPerfilEditarCerrar);
            tip1.SetToolTip(this.BtnPerfilEditarGuardar, RecursosUIToolkit.BtnPerfilEditarGuardar);
        }

        
    }
}
