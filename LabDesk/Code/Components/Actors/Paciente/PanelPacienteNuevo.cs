using LabDesk.Code.PresentationLayer.ComponenteGeneral;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Actors.Paciente
{

    public partial class PanelPacienteNuevo : UserControl
    {
        public PanelPacienteNuevo()
        {
            this.InitializeComponent();
            this.comboSexo.DataSource = new BindingSource(DataEstaticaGeneral.SexoTipos, null);
            this.comboSexo.DisplayMember = "Value";
            this.comboSexo.ValueMember = "Key";
            Dictionary<int, string> dataSource = BLUbicacion.ObtenerListaDistritos();
            this.ComboBoxDistrito.DataSource = new BindingSource(dataSource, null);
            this.ComboBoxDistrito.DisplayMember = "Value";
            this.ComboBoxDistrito.ValueMember = "Key";
            this.ComboBoxDistrito.SelectedValueChanged += new EventHandler(this.ComboBoxDistrito_SelectedValueChanged);
            foreach (int num in dataSource.Keys)
            {
                this.ComboBoxDistrito.SelectedValue = num;
                break;
            }
            Dictionary<int, string> dictionary2 = BLUbicacion.ObtenerListaSectores((int) this.ComboBoxDistrito.SelectedValue);
            this.ComboBoxSector.DataSource = new BindingSource(dictionary2, null);
            this.ComboBoxSector.DisplayMember = "Value";
            this.ComboBoxSector.ValueMember = "Key";
            foreach (int num2 in dictionary2.Keys)
            {
                this.ComboBoxSector.SelectedValue = num2;
                break;
            }
            this.campDNI.KeyPress += new KeyPressEventHandler(this.CampDNI_KeyPress);
            this.campNombre.KeyUp += new KeyEventHandler(this.CampNombre_KeyUp);
            this.campapellido1erno.KeyUp += new KeyEventHandler(this.CampPrimerApellido_KeyUp);
            this.campapellido2erno.KeyUp += new KeyEventHandler(this.CampSegundoApellido_KeyUp);
            this.campHistoria.KeyUp += new KeyEventHandler(this.CampHistoria_KeyUp);
            this.campDireccion.KeyUp += new KeyEventHandler(this.CampDireccion_KeyUp);
            this.BtnUIPacienteNuevo1.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click);
            this.BtnUIPacienteNuevo1.Tipo = ButtonUI.ButtonTipo.Ok;
            Decorator.Instance().FormatStyle(base.Controls);
            this.InicializarToolTip();
        }

        private void BtnPerfilNuevoCerrar_Click(object sender, EventArgs e)
        {
            LogicaControlSistema.DisminuirNivel();
            LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
            ((ControlPaciente) base.Parent.Parent).ModeBtnFuncion(true);
            base.Dispose();
        }

        private void CampDireccion_KeyUp(object sender, KeyEventArgs e)
        {
            this.campDireccion.Text = this.campDireccion.Text.ToUpper();
            this.campDireccion.SelectionStart = this.campDireccion.TextLength;
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
            this.campHistoria.Text = this.campHistoria.Text.ToUpper();
            this.campHistoria.SelectionStart = this.campHistoria.TextLength;
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
                this.campapellido1erno.Text = this.campapellido1erno.Text.ToUpper();
                this.campapellido1erno.SelectionStart = this.campapellido1erno.TextLength;
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
                this.campapellido2erno.Text = this.campapellido2erno.Text.ToUpper();
                this.campapellido2erno.SelectionStart = this.campapellido2erno.TextLength;
            }
            else if ((e.KeyValue != 2) && (e.KeyValue != 3))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void ComboBoxDistrito_SelectedValueChanged(object sender, EventArgs e)
        {
            Dictionary<int, string> dataSource = BLUbicacion.ObtenerListaSectores((int) this.ComboBoxDistrito.SelectedValue);
            this.ComboBoxSector.DataSource = new BindingSource(dataSource, null);
            this.ComboBoxSector.DisplayMember = "Value";
            this.ComboBoxSector.ValueMember = "Key";
            foreach (int num in dataSource.Keys)
            {
                this.ComboBoxSector.SelectedValue = num;
                break;
            }
        }

        private void ComponenteUI_Click(object sender, EventArgs e)
        {
            LabDesk.Code.LogicLayer.LogicaPaciente.LogicaPaciente paciente = new LabDesk.Code.LogicLayer.LogicaPaciente.LogicaPaciente();
            try
            {
                Paciente pac = new Paciente {
                    Sexo = (Sexo) this.comboSexo.SelectedIndex,
                    Nombre = this.campNombre.Text,
                    SegundoApellido = this.campapellido2erno.Text,
                    PrimerApellido = this.campapellido1erno.Text,
                    Historia = this.campHistoria.Text,
                    FechaNacimiento = this.campFecha.Value,
                    Dni = this.campDNI.Text,
                    Direccion = this.campDireccion.Text,
                    IdDistrito = (int) this.ComboBoxDistrito.SelectedValue,
                    IdSector = (int) this.ComboBoxSector.SelectedValue
                };
                paciente.CrearPaciente(pac);
                FormMensaje.Confirmacion(RecursosUIMensajes.MsgPerfilOk);
                this.limpiarCampos();
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
            tip1.SetToolTip(this.BtnPerfilEditarCerrar, RecursosUIToolkit.BtnPerfilNuevoCerrar);
            tip1.SetToolTip(this.BtnPerfilEditarGuardar, RecursosUIToolkit.BtnPerfilNuevoCerrar);
        }

        
        public void limpiarCampos()
        {
            this.comboSexo.SelectedIndex = 0;
            this.campNombre.Text = "";
            this.campapellido2erno.Text = "";
            this.campapellido1erno.Text = "";
            this.campHistoria.Text = "";
            this.campDNI.Text = "";
            this.campFecha.Value = DateTime.Now;
            this.campDireccion.Text = "";
        }
    }
}
