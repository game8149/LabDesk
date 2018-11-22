using Entity.Code.Hospital;
using Entity.Code.Hospital.Analisis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Laboratory.Orden
{

    public partial class FormBuscarOrden : Form
    {
        private Dictionary<int, Patient> diccionarioPaciente;
        private Dictionary<int, ExamOrder> diccionarioOrden;
        


        public Patient Perfil { get; set; }
        public ExamOrder ExamOrder { get; set; }

        //Componentes
        private DataTable tablaPaciente;
        private BindingSource bindingSourcePaciente;

        private DataTable tablaOrden;
        private BindingSource bindingSourceOrden;

        private bool isLoading=false;

        public FormBuscarOrden()
        {
            isLoading = true;
            InitializeComponent();
            InicializarTablaPaciente();
            InicializarTablaOrden();
            BtnCargar.Enabled = false;
            PickerEnd.Enabled = false;
            PickerInit.Enabled = false;
            ComboEstado.Enabled = false;
            isLoading = false;
            this.FormClosing += FormBuscarOrden_FormClosing;
        }

        private void FormBuscarOrden_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void FormBuscarPaciente_Load(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            LogicaPaciente enlace = new LogicaPaciente();
            tablaPaciente.Clear();
            diccionarioPaciente = enlace.ObtenerPerfilPorFiltro(CampDni.Text, CampHistoria.Text, CampNombre.Text, Campapellido1erno.Text, Campapellido2erno.Text);
            this.SuspendLayout();
            foreach (int key in diccionarioPaciente.Keys)
            {
                Patient pac = diccionarioPaciente[key];
                DataRow row = tablaPaciente.NewRow();
                row[0] = pac.Id;
                row[1] = pac.Dni;
                row[2] = pac.Nombres +" "+ pac.PrimerApellido+" "+ pac.SegundoApellido;
                tablaPaciente.Rows.Add(row);
            }
            this.ResumeLayout(false);
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            if (this.DGVOrden.SelectedRows.Count > 0 && !isLoading)
            {
                int idData = Convert.ToInt32(this.DGVOrden.SelectedRows[0].Cells[0].Value);
                ExamOrder = diccionarioOrden[idData];
            }
            this.Visible=false;
        }
        
        private void InicializarTablaPaciente()
        {
            bindingSourcePaciente = new BindingSource();
            DGVPaciente.DataSource = bindingSourcePaciente;
            tablaPaciente = new DataTable("Examenes");
            // Configuracion de Tablas
            
            tablaPaciente.Columns.Add("Id", typeof(int));
            tablaPaciente.Columns.Add("Dni", typeof(string));
            tablaPaciente.Columns.Add("Nombre", typeof(string));
            
            //ID DATA
            this.DGVPaciente.Columns[0].Visible = false;
            this.DGVPaciente.Columns[0].ReadOnly = true;
            this.DGVPaciente.Columns[0].DataPropertyName = "Id";
            //DNI
            this.DGVPaciente.Columns[1].ReadOnly = true;
            this.DGVPaciente.Columns[1].Resizable = DataGridViewTriState.False;
            this.DGVPaciente.Columns[1].DataPropertyName = "Dni";
            //NOMBRE
            this.DGVPaciente.Columns[2].ReadOnly = true;
            this.DGVPaciente.Columns[2].Resizable = DataGridViewTriState.False;
            this.DGVPaciente.Columns[2].DataPropertyName = "Nombre";

            bindingSourcePaciente.DataSource = tablaPaciente;
            this.DGVPaciente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            this.DGVPaciente.SelectionChanged += DGVPaciente_SelectionChanged;
        }
        private void InicializarTablaOrden()
        {
            bindingSourceOrden = new BindingSource();
            DGVOrden.DataSource = bindingSourceOrden;

            ComboEstado.DataSource = new BindingSource(DiccionarioGeneral.GetInstance().EstadoOrden, null);
            ComboEstado.DisplayMember = "Value";
            ComboEstado.ValueMember = "Key";

            tablaOrden = new DataTable("Ordenes");
            // Configuracion de Tablas

            tablaOrden.Columns.Add("Id", typeof(int));
            tablaOrden.Columns.Add("Dni", typeof(string));
            tablaOrden.Columns.Add("Fecha", typeof(string));

            //ID DATA
            this.DGVOrden.Columns[0].Visible = false;
            this.DGVOrden.Columns[0].ReadOnly = true;
            this.DGVOrden.Columns[0].DataPropertyName = "Id";
            //DNI
            this.DGVOrden.Columns[1].ReadOnly = true;
            this.DGVOrden.Columns[1].Resizable = DataGridViewTriState.False;
            this.DGVOrden.Columns[1].DataPropertyName = "Dni";
            //NOMBRE
            this.DGVOrden.Columns[2].ReadOnly = true;
            this.DGVOrden.Columns[2].Resizable = DataGridViewTriState.False;
            this.DGVOrden.Columns[2].DataPropertyName = "Fecha";

            bindingSourceOrden.DataSource = tablaOrden;
            this.DGVOrden.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.DGVOrden.SelectionChanged += DGVOrden_SelectionChanged;
        }

        private void DGVOrden_SelectionChanged(object sender, EventArgs e)
        {
            if (this.DGVOrden.SelectedRows.Count > 0)
                BtnCargar.Enabled = true;
            else
                BtnCargar.Enabled = false;
        }

        private void DGVPaciente_SelectionChanged(object sender, EventArgs e)
        {
            if (this.DGVPaciente.SelectedRows.Count > 0 && !isLoading)
            {
                int idData = Convert.ToInt32(this.DGVPaciente.SelectedRows[0].Cells[0].Value);
                Perfil = diccionarioPaciente[idData];
                LlenarTablaOrdenes();
                ComboEstado.Enabled = true;
                PickerEnd.Enabled = true;
                PickerInit.Enabled = true;
            }
            else
            {
                ComboEstado.Enabled = false;
                PickerEnd.Enabled = false;
                PickerInit.Enabled = false;
            }
        }
        
        private void LlenarTablaOrdenes()
        {
            LogicaOrden enlaceOrden = new LogicaOrden();
            tablaOrden.Clear();
            diccionarioOrden = enlaceOrden.ObtenerOrdenesByPacienteByFechaByEstado(Perfil, PickerInit.Value, PickerEnd.Value, (EstadoOrden)ComboEstado.SelectedIndex);
            this.SuspendLayout();
            foreach(ExamOrder ord in diccionarioOrden.Values)
            {
                DataRow row = tablaOrden.NewRow();
                row[0] = ord.IdData;
                row[1] = ord.IdData;
                row[2] = ord.FechaRegistro.ToShortDateString();
                tablaOrden.Rows.Add(row);
            }
            this.ResumeLayout(false);
        }

        private void PickerInit_ValueChanged(object sender, EventArgs e)
        {
            if(!isLoading)
                LlenarTablaOrdenes();
        }

        private void PickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if(!isLoading)
                LlenarTablaOrdenes();
        }

        private void ComboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoading)
                LlenarTablaOrdenes();
        }
    }
}
