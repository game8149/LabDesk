using LabDesk.Code.PresentationLayer.Controles;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Actors.Medico
{
    public partial class PanelMedicoPerfil : UserControl
    {
        private BindingSource bindingSource;
        
        private DataTable tabla;
        public UserControl controlSecondActive;
        private Medico perfil;
        private bool isLoadingUI;

        public PanelMedicoPerfil()
        {
            this.InitializeComponent();
            this.isLoadingUI = true;
            this.InicializarTablaOrdenDetalle();
            this.limpiarCamps();
            base.SuspendLayout();
            this.ComboEstado.DataSource = new BindingSource(DataEstaticaGeneral.OrdenEstados, null);
            this.ComboEstado.DisplayMember = "Value";
            this.ComboEstado.ValueMember = "Key";
            this.InicializarToolTip();
            base.ResumeLayout(false);
            this.isLoadingUI = false;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            base.Visible = false;
            LogicaControlSistema.DisminuirNivel();
            LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
            ((ControlMedico) base.Parent.Parent).ModeBtnFuncion(true);
            base.Dispose();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            this.controlSecondActive = new PanelMedicoEditar();
            this.controlSecondActive.Parent = this;
            this.controlSecondActive.Dock = DockStyle.Fill;
            base.Controls.Add(this.controlSecondActive);
            this.controlSecondActive.Location = new Point(0, 0);
            ((PanelMedicoEditar) this.controlSecondActive).CargarDatos();
            this.controlSecondActive.BringToFront();
            LogicaControlSistema.AumentarNivel(RecursosUI.ResourceManager.GetString(this.controlSecondActive.Name, RecursosUI.Culture));
            LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
            this.controlSecondActive.Show();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
        }

        public void CargarDatos()
        {
            this.CampNombre.Text = BLMedico.FormatearNombre(this.Perfil);
            this.CampHabil.Text = this.Perfil.Habil ? "Activo" : "Inactivo";
            this.CampColegiatura.Text = this.Perfil.Colegiatura;
            this.CampEspecialidad.Text = this.Perfil.Especialidad;
            this.RellenarExamenesEnTabla();
        }

        private void ComboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.isLoadingUI)
            {
                this.RellenarExamenesEnTabla();
            }
        }

  

        private void InicializarTablaOrdenDetalle()
        {
            this.bindingSource = new BindingSource();
            this.DGVExamen.DataSource = this.bindingSource;
            this.tabla = new DataTable("Examenes");
            this.tabla.Columns.Add("Id", typeof(int));
            this.tabla.Columns.Add("Codigo", typeof(int));
            this.tabla.Columns.Add("Examen", typeof(string));
            this.tabla.Columns.Add("Responsable", typeof(string));
            this.tabla.Columns.Add("UltimaModificacion", typeof(string));
            this.tabla.Columns.Add("IdOrden", typeof(int));
            this.DGVExamen.Columns[0].Visible = false;
            this.DGVExamen.Columns[0].ReadOnly = true;
            this.DGVExamen.Columns[0].DataPropertyName = "Id";
            this.DGVExamen.Columns[1].ReadOnly = true;
            this.DGVExamen.Columns[1].Resizable = DataGridViewTriState.False;
            this.DGVExamen.Columns[1].DataPropertyName = "Codigo";
            this.DGVExamen.Columns[2].ReadOnly = true;
            this.DGVExamen.Columns[2].Resizable = DataGridViewTriState.False;
            this.DGVExamen.Columns[2].DataPropertyName = "Examen";
            this.DGVExamen.Columns[3].ReadOnly = true;
            this.DGVExamen.Columns[3].Resizable = DataGridViewTriState.False;
            this.DGVExamen.Columns[3].DataPropertyName = "Responsable";
            this.DGVExamen.Columns[4].ReadOnly = true;
            this.DGVExamen.Columns[4].Resizable = DataGridViewTriState.False;
            this.DGVExamen.Columns[4].DataPropertyName = "UltimaModificacion";
            this.DGVExamen.Columns[5].Visible = false;
            this.DGVExamen.Columns[5].ReadOnly = true;
            this.DGVExamen.Columns[5].DataPropertyName = "IdOrden";
            this.bindingSource.DataSource = this.tabla;
            this.DGVExamen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void InicializarToolTip()
        {
            ToolTip tip1 = new ToolTip {
                ShowAlways = true
            };
            tip1.SetToolTip(this.BtnPerfilCerrar, RecursosUIToolkit.BtnPerfilCerrar);
            tip1.SetToolTip(this.BtnPerfilEditar, RecursosUIToolkit.BtnPerfilEditar);
            tip1.SetToolTip(this.BtnPerfilPrintExamen, RecursosUIToolkit.BtnPerfilPrintExamen);
        }

       
        public void limpiarCamps()
        {
            this.CampNombre.Text = "";
            this.CampColegiatura.Text = "";
            this.CampHabil.Text = "";
            this.BtnPerfilPrintExamen.Visible = false;
        }

        private void PickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if (!this.isLoadingUI)
            {
                this.RellenarExamenesEnTabla();
            }
        }

        private void PickerInit_ValueChanged(object sender, EventArgs e)
        {
            if (!this.isLoadingUI)
            {
                this.RellenarExamenesEnTabla();
            }
        }

        private void RellenarExamenesEnTabla()
        {
        }

        public Medico Perfil
        {
            get => 
                this.perfil;
            set
            {
                this.perfil = value;
                this.CargarDatos();
            }
        }
    }
}
