using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Actors.Paciente
{


    public partial class PanelPacientePerfil : UserControl
    {
        private BindingSource bindingSource;
        
        private DataTable tabla;
        private Dictionary<int, Orden> ordenes;
        private bool isLoadingUI;
        private Dictionary<int, Examen> examenesGeneral;
        private Paciente perfil;
        public UserControl ControlSecondActive;

        public PanelPacientePerfil()
        {
            this.InitializeComponent();
            this.isLoadingUI = true;
            this.InicializarTablaOrdenDetalle();
            this.limpiarCamps();
            base.SuspendLayout();
            this.ComboEstado.DataSource = new BindingSource(DataEstaticaGeneral.OrdenEstados, null);
            this.ComboEstado.DisplayMember = "Value";
            this.ComboEstado.ValueMember = "Key";
            base.ResumeLayout(false);
            this.InicializarToolTip();
            this.isLoadingUI = false;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            LogicaControlSistema.DisminuirNivel();
            base.Visible = false;
            ((ControlPaciente) base.Parent.Parent).ModeBtnFuncion(true);
            LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
            base.Dispose();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            this.ControlSecondActive = new PanelPacienteEditar();
            this.ControlSecondActive.Parent = this;
            this.ControlSecondActive.Dock = DockStyle.Fill;
            base.Controls.Add(this.ControlSecondActive);
            this.ControlSecondActive.Location = new Point(0, 0);
            ((PanelPacienteEditar) this.ControlSecondActive).CargarDatos();
            this.ControlSecondActive.BringToFront();
            this.ControlSecondActive.Show();
            LogicaControlSistema.AumentarNivel(RecursosUI.ResourceManager.GetString(this.ControlSecondActive.Name, RecursosUI.Culture));
            LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            new LogicaOrden();
            Dictionary<int, Examen> examenes = new Dictionary<int, Examen>();
            Orden orden = this.ordenes[(int) this.ComboBoxOrden.SelectedValue];
            foreach (DataGridViewRow row in this.DGVExamen.SelectedRows)
            {
                examenes.Add((int) row.Cells[1].Value, this.examenesGeneral[(int) row.Cells[1].Value]);
            }
            new Impresora().ContruirVistaPreviaExamenPaciente(orden, examenes);
        }

        public void CargarDatos()
        {
            string[] textArray1 = new string[] { this.perfil.Nombre, " ", this.perfil.PrimerApellido, " ", this.perfil.SegundoApellido };
            this.CampNombre.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(string.Concat(textArray1));
            this.CampDni.Text = this.perfil.Dni;
            this.CampHistoria.Text = this.perfil.Historia;
            this.CampSexo.Text = DataEstaticaGeneral.SexoTipos[(int) this.perfil.Sexo];
            DataEstaticaGeneral.Tiempo edad = Utilidad.CalcularEdad(this.perfil.FechaNacimiento);
            this.CampEdad.Text = Utilidad.FormatoEdad(edad);
            this.CampDireccion.Text = this.perfil.Direccion;
            this.CampUbicacion.Text = Locaciones.GetInstance().GetDistrito(this.perfil.IdDistrito).Nombre + ", " + Locaciones.GetInstance().GetDistrito(this.perfil.IdDistrito).Sectores[this.perfil.IdSector].Nombre;
            this.RellenarOrdenes();
        }

        private void ComboBoxOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.isLoadingUI)
            {
                this.RellenarExamenesEnTabla();
            }
        }

        private void ComboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.isLoadingUI)
            {
                this.RellenarOrdenes();
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
            tip1.SetToolTip(this.BtnPacientePerfilCerrar, RecursosUIToolkit.BtnPerfilCerrar);
            tip1.SetToolTip(this.BtnPacientePerfilEdit, RecursosUIToolkit.BtnPerfilEditar);
            tip1.SetToolTip(this.BtnPacientePerfilPrint, RecursosUIToolkit.BtnPerfilPrintExamen);
        }

        

        public void limpiarCamps()
        {
            this.CampNombre.Text = "";
            this.CampDireccion.Text = "";
            this.CampEdad.Text = "";
            this.CampHistoria.Text = "";
            this.CampSexo.Text = "";
            this.CampDni.Text = "";
            this.BtnPacientePerfilPrint.Visible = false;
        }

        private void PanelPerfil_Load(object sender, EventArgs e)
        {
        }

        private void PickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if (!this.isLoadingUI)
            {
                this.RellenarOrdenes();
            }
        }

        private void PickerInit_ValueChanged(object sender, EventArgs e)
        {
            if (!this.isLoadingUI)
            {
                this.RellenarOrdenes();
            }
        }

        private void RellenarExamenesEnTabla()
        {
            LogicaCuenta cuenta = new LogicaCuenta();
            LabDesk.Code.LogicLayer.LogicaExamen.LogicaExamen examen = new LabDesk.Code.LogicLayer.LogicaExamen.LogicaExamen();
            if (this.ordenes.Count > 0)
            {
                this.tabla.Clear();
                this.examenesGeneral = new Dictionary<int, Examen>();
                Orden orden = this.ordenes[(int) this.ComboBoxOrden.SelectedValue];
                foreach (Examen examen2 in examen.RecuperarExamenes(orden).Values)
                {
                    if (examen2.Estado == Examen.EstadoExamen.Terminado)
                    {
                        base.SuspendLayout();
                        this.examenesGeneral.Add(examen2.IdData, examen2);
                        DataRow row = this.tabla.NewRow();
                        row[0] = examen2.IdOrdenDetalle;
                        row[1] = examen2.IdData;
                        string nombre = ListaAnalisis.GetInstance().GetAnalisisById(orden.Detalle[examen2.IdOrdenDetalle].IdDataPaquete).Nombre;
                        string str2 = Plantillas.GetInstance().GetPlantilla(examen2.IdPlantilla).Nombre;
                        row[2] = (nombre == str2) ? nombre : (nombre + ":" + str2);
                        Cuenta cuenta2 = cuenta.ObtenerCuenta(examen2.IdCuenta);
                        row[3] = (cuenta2.Nombre + cuenta2.PrimerApellido).ToUpper() + " (" + cuenta2.Dni + ")";
                        row[4] = examen2.UltimaModificacion;
                        row[5] = orden.IdData;
                        this.tabla.Rows.Add(row);
                        base.ResumeLayout(false);
                    }
                }
                this.BtnPacientePerfilPrint.Visible = this.examenesGeneral.Count > 0;
            }
        }

        private void RellenarOrdenes()
        {
            this.ordenes = new LogicaOrden().ObtenerOrdenesByPacienteByFechaByEstado(this.perfil, this.PickerInit.Value, this.PickerEnd.Value, (Orden.EstadoOrden) this.ComboEstado.SelectedIndex);
            if (this.ordenes.Count > 0)
            {
                Dictionary<int, string> dataSource = new Dictionary<int, string>();
                foreach (Orden orden2 in this.ordenes.Values)
                {
                    dataSource.Add(orden2.IdData, string.Concat(new object[] { orden2.IdData, "-", (orden2.Boleta == "") ? "Sin Boleta" : orden2.Boleta, " (", orden2.FechaRegistro, ")" }));
                }
                this.ComboBoxOrden.DataSource = new BindingSource(dataSource, null);
                this.ComboBoxOrden.DisplayMember = "Value";
                this.ComboBoxOrden.ValueMember = "Key";
                foreach (int num in dataSource.Keys)
                {
                    this.ComboBoxOrden.SelectedValue = num;
                }
            }
            this.ComboBoxOrden.Visible = this.ordenes.Count > 0;
            this.LabelOrden.Visible = this.ordenes.Count > 0;
        }

        public Paciente Perfil
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
