using LabDesk.Code.Base;
using LabDesk.Code.PresentationLayer.ComponenteGeneral;
using System;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Actors.Paciente
{
    public partial class PanelPacienteEditar : UserControl
    {
        public PanelPacienteEditar()
        {
            this.InitializeComponent();
            this.ComboSexo.DataSource = new BindingSource(DataEstaticaGeneral.SexoTipos, null);
            this.ComboSexo.DisplayMember = "Value";
            this.ComboSexo.ValueMember = "Key";
            this.ComboBoxDistrito.DataSource = new BindingSource(BLUbicacion.ObtenerListaDistritos(), null);
            this.ComboBoxDistrito.DisplayMember = "Value";
            this.ComboBoxDistrito.ValueMember = "Key";
            this.ComboBoxDistrito.SelectionChangeCommitted += new EventHandler(this.ComboBoxDistrito_SelectionChangeCommitted);
            this.CampDNI.KeyPress += new KeyPressEventHandler(this.CampDNI_KeyPress);
            this.CampNombre.KeyUp += new KeyEventHandler(this.CampNombre_KeyUp);
            this.Campapellido1erno.KeyUp += new KeyEventHandler(this.CampPrimerApellido_KeyUp);
            this.Campapellido2erno.KeyUp += new KeyEventHandler(this.CampSegundoApellido_KeyUp);
            this.CampHistoria.KeyUp += new KeyEventHandler(this.CampHistoria_KeyUp);
            this.CampDireccion.KeyUp += new KeyEventHandler(this.CampDireccion_KeyUp);
            this.BtnUIPacienteEditar3.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click2);
            this.BtnUIPacienteEditar3.Tipo = ButtonUI.ButtonTipo.Delete;
            Decorator.Instance().FormatStyle(base.Controls);
            this.InicializarToolTip();
        }

        private void BtnPerfilEditarCerrar_Click(object sender, EventArgs e)
        {
            if (FormMensaje.DecisionAdvertencia(RecursosUIMensajes.MsgPerfilUnsave) == DialogResult.Yes)
            {
                LogicaControlSistema.DisminuirNivel();
                LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
                base.Visible = false;
                base.Dispose();
            }
        }

        private void BtnPerfilEditarGuardar_Click(object sender, EventArgs e)
        {
            Paciente pac = new Paciente
            {
                IdData = ((PanelPacientePerfil)base.Parent).Perfil.IdData,
                Dni = this.CampDNI.Text,
                Direccion = this.CampDireccion.Text,
                Sexo = (Sexo)this.ComboSexo.SelectedValue,
                Historia = this.CampHistoria.Text,
                Nombre = this.CampNombre.Text,
                PrimerApellido = this.Campapellido1erno.Text,
                SegundoApellido = this.Campapellido2erno.Text,
                FechaNacimiento = this.CampFecha.Value,
                IdDistrito = (int)this.ComboBoxDistrito.SelectedValue,
                IdSector = (int)this.ComboBoxSector.SelectedValue
            };
            try
            {
                new LogicaPaciente.LogicaPaciente().ActualizarPaciente(pac);
                ((PanelPacientePerfil)base.Parent).Perfil = pac;
                ((PanelPacientePerfil)base.Parent).CargarDatos();
                FormMensaje.Confirmacion(RecursosUIMensajes.MsgPerfilSave);
                base.Dispose();
            }
            catch (Exception exception)
            {
                FormMensaje.Error(RecursosUIMensajes.MsgPeligro + exception.Message);
            }
        }

        private void CampDireccion_KeyUp(object sender, KeyEventArgs e)
        {
            this.CampDireccion.Text = this.CampDireccion.Text.ToUpper();
            this.CampDireccion.SelectionStart = this.CampDireccion.TextLength;
        }

        private void CampDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((!char.IsNumber(e.KeyChar) && (e.KeyChar != '\b')) && ((e.KeyChar != '\x0002') && (e.KeyChar != '\x0003'))) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
        }

        private void CampHistoria_KeyUp(object sender, KeyEventArgs e)
        {
            this.CampHistoria.Text = this.CampHistoria.Text.ToUpper();
            this.CampHistoria.SelectionStart = this.CampHistoria.TextLength;
        }

        private void CampHistoria_TextChanged(object sender, EventArgs e)
        {
        }

        private void CampNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (char.IsLetter((char)e.KeyValue) || char.IsWhiteSpace((char)e.KeyValue))
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
            if (char.IsLetter((char)e.KeyValue) || char.IsWhiteSpace((char)e.KeyValue))
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
            if (char.IsLetter((char)e.KeyValue) || char.IsWhiteSpace((char)e.KeyValue))
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
            this.CampNombre.Text = ((PanelPacientePerfil)base.Parent).Perfil.Nombre;
            this.Campapellido1erno.Text = ((PanelPacientePerfil)base.Parent).Perfil.PrimerApellido;
            this.Campapellido2erno.Text = ((PanelPacientePerfil)base.Parent).Perfil.SegundoApellido;
            this.CampDNI.Text = ((PanelPacientePerfil)base.Parent).Perfil.Dni;
            this.CampHistoria.Text = ((PanelPacientePerfil)base.Parent).Perfil.Historia;
            this.ComboSexo.SelectedValue = (int)((PanelPacientePerfil)base.Parent).Perfil.Sexo;
            this.CampFecha.Value = ((PanelPacientePerfil)base.Parent).Perfil.FechaNacimiento;
            this.CampDireccion.Text = ((PanelPacientePerfil)base.Parent).Perfil.Direccion;
            this.ComboBoxDistrito.SelectedValue = ((PanelPacientePerfil)base.Parent).Perfil.IdDistrito;
            this.ComboBoxSector.DataSource = new BindingSource(BLUbicacion.ObtenerListaSectores((int)this.ComboBoxDistrito.SelectedValue), null);
            this.ComboBoxSector.DisplayMember = "Value";
            this.ComboBoxSector.ValueMember = "Key";
            this.ComboBoxSector.SelectedValue = ((PanelPacientePerfil)base.Parent).Perfil.IdSector;
        }

        private void ComboBoxDistrito_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.ComboBoxSector.DataSource = new BindingSource(BLUbicacion.ObtenerListaSectores((int)this.ComboBoxDistrito.SelectedValue), null);
            this.ComboBoxSector.DisplayMember = "Value";
            this.ComboBoxSector.ValueMember = "Key";
        }

        private void ComponenteUI_Click2(object sender, EventArgs e)
        {
            try
            {
                if (FormMensaje.DecisionAdvertencia(RecursosUIMensajes.MsgPerfilDeleteDesicion) == DialogResult.Yes)
                {
                    new LogicaPaciente.LogicaPaciente().EliminarPaciente(((PanelPacientePerfil)base.Parent).Perfil);
                    FormMensaje.Confirmacion(RecursosUIMensajes.MsgPerfilDelete);
                    ((ControlPaciente)base.Parent.Parent.Parent).ModeBtnFuncion(true);
                    LogicaControlSistema.DisminuirNivel();
                    LogicaControlSistema.DisminuirNivel();
                    LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
                    base.Visible = false;
                    ((PanelPacientePerfil)base.Parent).Dispose();
                }
            }
            catch (Exception exception)
            {
                FormMensaje.Error(RecursosUIMensajes.MsgNone + exception.Message);
            }
        }
        
        public void InicializarToolTip()
        {
            ToolTip tip1 = new ToolTip
            {
                ShowAlways = true
            };
            tip1.SetToolTip(this.BtnPerfilEditarCerrar, RecursosUIToolkit.BtnPerfilEditarCerrar);
            tip1.SetToolTip(this.BtnPerfilEditarGuardar, RecursosUIToolkit.BtnPerfilEditarGuardar);
        }

      
        private void PanelPacienteEditar_Load(object sender, EventArgs e)
        {
        }
    }
}
