namespace LabDesk.Code.Components.Laboratory.Orden
{
    using Entity.Code.Hospital;
    using Entity.Code.Hospital.Analisis;
    using Entity.Code.Static;
    using LabDesk.Code.Base;
    using LabDesk.Code.StyleManager;
    using MinLab.Code.LogicLayer.LogicaPaciente;
    using MinLab.Code.LogicLayer.LogicaTarifario;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;

    public partial class FormOrdenBuscar : Form
    {
        private BindingSource bindingSourceOrden;
        private BindingSource bindingSourcePaciente;
       
        private Dictionary<int, ExamOrder> diccionarioOrden;
        private Dictionary<int, Patient> diccionarioPaciente;
       
        private DataTable tablaOrden;
        private DataTable tablaPaciente;
        private bool isLoading = true;

        public FormOrdenBuscar()
        {
            this.InitializeComponent();
            this.InicializarTablaPaciente();
            this.InicializarTablaOrden();
            this.PickerEnd.Enabled = false;
            this.PickerInit.Enabled = false;
            this.ComboEstado.Enabled = false;
            this.isLoading = false;
            base.FormClosing += new FormClosingEventHandler(this.FormBuscarOrden_FormClosing);
            this.BtnUIOrdenBuscar1.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click);
            this.BtnUIOrdenBuscar2.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click1);
            this.BtnUIOrdenBuscar1.Tipo = ButtonUI.ButtonTipo.Ok;
            this.BtnUIOrdenBuscar2.Tipo = ButtonUI.ButtonTipo.Ok;
            base.SuspendLayout();
            Decorator.Instance().FormatStyle(base.Controls);
            base.ResumeLayout();
        }

        private void ComboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.isLoading)
            {
                this.LlenarTablaOrdenes();
            }
        }

        private void ComponenteUI_Click(object sender, EventArgs e)
        {
            LogicaPaciente paciente = new  LogicaPaciente();
            this.tablaPaciente.Clear();
            this.diccionarioPaciente = paciente.ObtenerPerfilPorFiltro(this.CampDni.Text, this.CampHistoria.Text, this.CampNombre.Text, this.Campapellido1erno.Text, this.Campapellido2erno.Text);
            base.SuspendLayout();
            foreach (int num in this.diccionarioPaciente.Keys)
            {
                Patient paciente2 = this.diccionarioPaciente[num];
                DataRow row = this.tablaPaciente.NewRow();
                row[0] = paciente2.Id;
                row[1] = paciente2.DocumentNumber;
                string[] textArray1 = new string[] { paciente2.Names, " ", paciente2.FirstSurname, " ", paciente2.LastSurname };
                row[2] = string.Concat(textArray1);
                this.tablaPaciente.Rows.Add(row);
            }
            base.ResumeLayout(false);
        }

        private void ComponenteUI_Click1(object sender, EventArgs e)
        {
            if ((this.DGVOrden.SelectedRows.Count > 0) && !this.isLoading)
            {
                int num = Convert.ToInt32(this.DGVOrden.SelectedRows[0].Cells[0].Value);
                this.ExamOrder = this.diccionarioOrden[num];
            }
            base.Visible = false;
        }

        private void DGVOrden_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void DGVPaciente_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.DGVPaciente.SelectedRows.Count > 0) && !this.isLoading)
            {
                int num = Convert.ToInt32(this.DGVPaciente.SelectedRows[0].Cells[0].Value);
                this.Perfil = this.diccionarioPaciente[num];
                this.LlenarTablaOrdenes();
                this.ComboEstado.Enabled = true;
                this.PickerEnd.Enabled = true;
                this.PickerInit.Enabled = true;
            }
            else
            {
                this.ComboEstado.Enabled = false;
                this.PickerEnd.Enabled = false;
                this.PickerInit.Enabled = false;
            }
        }
         
        private void FormBuscarOrden_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            base.Visible = false;
        }

        private void FormBuscarPaciente_Load(object sender, EventArgs e)
        {
        }

        private void InicializarTablaOrden()
        {
            this.bindingSourceOrden = new BindingSource();
            this.DGVOrden.DataSource = this.bindingSourceOrden;
            this.ComboEstado.DataSource = new BindingSource(DataEstaticaGeneral.OrdenEstados, null);
            this.ComboEstado.DisplayMember = "Value";
            this.ComboEstado.ValueMember = "Key";
            this.tablaOrden = new DataTable("Ordenes");
            this.tablaOrden.Columns.Add("Id", typeof(int));
            this.tablaOrden.Columns.Add("Dni", typeof(string));
            this.tablaOrden.Columns.Add("Fecha", typeof(string));
            this.DGVOrden.Columns[0].Visible = false;
            this.DGVOrden.Columns[0].ReadOnly = true;
            this.DGVOrden.Columns[0].DataPropertyName = "Id";
            this.DGVOrden.Columns[1].ReadOnly = true;
            this.DGVOrden.Columns[1].Resizable = DataGridViewTriState.False;
            this.DGVOrden.Columns[1].DataPropertyName = "Dni";
            this.DGVOrden.Columns[2].ReadOnly = true;
            this.DGVOrden.Columns[2].Resizable = DataGridViewTriState.False;
            this.DGVOrden.Columns[2].DataPropertyName = "Fecha";
            this.bindingSourceOrden.DataSource = this.tablaOrden;
            this.DGVOrden.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVOrden.SelectionChanged += new EventHandler(this.DGVOrden_SelectionChanged);
        }

        private void InicializarTablaPaciente()
        {
            this.bindingSourcePaciente = new BindingSource();
            this.DGVPaciente.DataSource = this.bindingSourcePaciente;
            this.tablaPaciente = new DataTable("Examenes");
            this.tablaPaciente.Columns.Add("Id", typeof(int));
            this.tablaPaciente.Columns.Add("Dni", typeof(string));
            this.tablaPaciente.Columns.Add("Nombre", typeof(string));
            this.DGVPaciente.Columns[0].Visible = false;
            this.DGVPaciente.Columns[0].ReadOnly = true;
            this.DGVPaciente.Columns[0].DataPropertyName = "Id";
            this.DGVPaciente.Columns[1].ReadOnly = true;
            this.DGVPaciente.Columns[1].Resizable = DataGridViewTriState.False;
            this.DGVPaciente.Columns[1].DataPropertyName = "Dni";
            this.DGVPaciente.Columns[2].ReadOnly = true;
            this.DGVPaciente.Columns[2].Resizable = DataGridViewTriState.False;
            this.DGVPaciente.Columns[2].DataPropertyName = "Nombre";
            this.bindingSourcePaciente.DataSource = this.tablaPaciente;
            this.DGVPaciente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVPaciente.SelectionChanged += new EventHandler(this.DGVPaciente_SelectionChanged);
        }

      
        private void LlenarTablaOrdenes()
        {
            ExamOrderBL orden = new ExamOrderBL();
            this.tablaOrden.Clear();
            this.diccionarioOrden = orden.ObtenerOrdenesByPacienteByFechaByEstado(this.Perfil, this.PickerInit.Value, this.PickerEnd.Value, (LabDesk.Code.EntityLayer.EOrden.ExamOrder.EstadoOrden)this.ComboEstado.SelectedIndex);
            base.SuspendLayout();
            foreach (ExamOrder orden2 in this.diccionarioOrden.Values)
            {
                DataRow row = this.tablaOrden.NewRow();
                row[0] = orden2.Id;
                row[1] = orden2.Id;
                row[2] = orden2.DateInsert.ToShortDateString();
                this.tablaOrden.Rows.Add(row);
            }
            base.ResumeLayout(false);
        }

        private void PickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if (!this.isLoading)
            {
                this.LlenarTablaOrdenes();
            }
        }

        private void PickerInit_ValueChanged(object sender, EventArgs e)
        {
            if (!this.isLoading)
            {
                this.LlenarTablaOrdenes();
            }
        }

        public  ExamOrder ExamOrder { get; set; }

        public Patient Perfil { get; set; }
    }
}
