namespace LabDesk.Code.Components.Actors.Paciente
{
    using LabDesk.Code.Base;
    using LabDesk.Code.PresentationLayer.ComponenteGeneral;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;

    public partial class FormBuscarPaciente : Form
    {
       
        private BindingSource bindingSource;
       
        private Dictionary<int, Paciente> diccionario;
        private DataTable tabla;

        public FormBuscarPaciente()
        {
            this.InitializeComponent();
            this.InicializarTablaOrdenDetalle();
            this.BtnUIPacienteBuscar1.Tipo = ButtonUI.ButtonTipo.Ok;
            this.BtnUIPacienteBuscar2.Tipo = ButtonUI.ButtonTipo.Ok;
            this.BtnUIPacienteBuscar1.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click);
            this.BtnUIPacienteBuscar2.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click1);
            Decorator.Instance().FormatStyle(base.Controls);
        }

        private void ComponenteUI_Click(object sender, EventArgs e)
        {
            LabDesk.Code.LogicLayer.LogicaPaciente.LogicaPaciente paciente = new LabDesk.Code.LogicLayer.LogicaPaciente.LogicaPaciente();
            this.tabla.Clear();
            this.diccionario = paciente.ObtenerPerfilPorFiltro(this.CampDni.Text, this.CampHistoria.Text, this.CampNombre.Text, this.Campapellido1erno.Text, this.Campapellido2erno.Text);
            base.SuspendLayout();
            if (this.diccionario.Count > 0)
            {
                foreach (int num in this.diccionario.Keys)
                {
                    Paciente paciente2 = this.diccionario[num];
                    DataRow row = this.tabla.NewRow();
                    row[0] = paciente2.IdData;
                    row[1] = paciente2.Dni;
                    row[2] = paciente2.Historia;
                    row[3] = paciente2.Nombre;
                    row[4] = paciente2.PrimerApellido;
                    row[5] = paciente2.SegundoApellido;
                    this.tabla.Rows.Add(row);
                }
            }
            else
            {
                FormMensaje.Advertencia(RecursosUIMensajes.MsgMedicoNoEncontrados);
            }
            base.ResumeLayout(false);
        }

        private void ComponenteUI_Click1(object sender, EventArgs e)
        {
            if (this.DGVPaciente.SelectedRows.Count > 0)
            {
                int num = Convert.ToInt32(this.DGVPaciente.SelectedRows[0].Cells[0].Value);
                this.Perfil = this.diccionario[num];
                base.Visible = false;
            }
            else
            {
                FormMensaje.Advertencia(RecursosUIMensajes.MsgMedicoNoSeleccionado);
            }
        }

    
        private void FormBuscarPaciente_Load(object sender, EventArgs e)
        {
        }

        private void InicializarTablaOrdenDetalle()
        {
            this.bindingSource = new BindingSource();
            this.DGVPaciente.DataSource = this.bindingSource;
            this.tabla = new DataTable("Examenes");
            this.tabla.Columns.Add("Id", typeof(int));
            this.tabla.Columns.Add("Dni", typeof(string));
            this.tabla.Columns.Add("Historia", typeof(string));
            this.tabla.Columns.Add("Nombre", typeof(string));
            this.tabla.Columns.Add("ApellidoP", typeof(string));
            this.tabla.Columns.Add("ApellidoM", typeof(string));
            this.DGVPaciente.Columns[0].Visible = false;
            this.DGVPaciente.Columns[0].ReadOnly = true;
            this.DGVPaciente.Columns[0].DataPropertyName = "Id";
            this.DGVPaciente.Columns[1].ReadOnly = true;
            this.DGVPaciente.Columns[1].Resizable = DataGridViewTriState.False;
            this.DGVPaciente.Columns[1].DataPropertyName = "Dni";
            this.DGVPaciente.Columns[2].ReadOnly = true;
            this.DGVPaciente.Columns[2].Resizable = DataGridViewTriState.False;
            this.DGVPaciente.Columns[2].DataPropertyName = "Historia";
            this.DGVPaciente.Columns[3].ReadOnly = true;
            this.DGVPaciente.Columns[3].Resizable = DataGridViewTriState.False;
            this.DGVPaciente.Columns[3].DataPropertyName = "Nombre";
            this.DGVPaciente.Columns[4].ReadOnly = true;
            this.DGVPaciente.Columns[4].Resizable = DataGridViewTriState.False;
            this.DGVPaciente.Columns[4].DataPropertyName = "ApellidoP";
            this.DGVPaciente.Columns[5].ReadOnly = true;
            this.DGVPaciente.Columns[5].Resizable = DataGridViewTriState.False;
            this.DGVPaciente.Columns[5].DataPropertyName = "ApellidoM";
            this.bindingSource.DataSource = this.tabla;
            this.DGVPaciente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        
        public Paciente Perfil { get; set; }
    }
}
