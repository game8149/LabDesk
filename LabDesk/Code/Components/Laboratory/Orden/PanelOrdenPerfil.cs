using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Laboratory.Orden
{
    public partial class PanelOrdenPerfil : UserControl
    {
        private int idUniqueRowCount;
        private Orden orden;
        private Paciente perfil;
        private DataTable tabla;
        public UserControl controlSecondActive;
        private BindingSource bindingSource;



        public PanelOrdenPerfil()
        {
            this.InitializeComponent();
            base.SuspendLayout();
            this.tabla = new DataTable("Lista");
            this.InicializarTablaOrdenDetalle();
            this.CampGestacion.Visible = false;
            this.LabelGestacion.Visible = false;
            Decorator.Instance().FormatStyle(base.Controls);
            base.ResumeLayout(false);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            base.Visible = false;
            LogicaControlSistema.DisminuirNivel();
            LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
            ((ControlOrden)base.Parent.Parent).ModeBtnFuncion(true);
            base.Dispose();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            this.controlSecondActive = new PanelOrdenEditar();
            this.controlSecondActive.SuspendLayout();
            this.controlSecondActive.Parent = this;
            this.controlSecondActive.Dock = DockStyle.Fill;
            this.controlSecondActive.Location = new Point(0, 0);
            base.Controls.Add(this.controlSecondActive);
            this.controlSecondActive.Visible = false;
            ((PanelOrdenEditar)this.controlSecondActive).CargarDatos();
            this.controlSecondActive.BringToFront();
            LogicaControlSistema.AumentarNivel(RecursosUI.ResourceManager.GetString(this.controlSecondActive.Name, RecursosUI.Culture));
            LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
            this.controlSecondActive.Show();
            this.controlSecondActive.ResumeLayout();
        }

        public void CargarDatos()
        {
            Medico medico = new BLMedico().ObtenerMedico(this.orden.IdMedico);
            this.CampUbicacion.Text = LabDesk.Code.LogicLayer.LogicaPaciente.LogicaPaciente.FormatearUbicacion(this.perfil);
            this.CampDni.Text = this.perfil.Dni;
            this.CampHistoria.Text = this.perfil.Historia;
            string[] textArray1 = new string[] { this.perfil.Nombre, " ", this.perfil.PrimerApellido, " ", this.perfil.SegundoApellido };
            this.CampNombre.Text = string.Concat(textArray1);
            this.CampBoleta.Text = this.orden.Boleta;
            this.CampSexo.Text = DataEstaticaGeneral.SexoTipos[(int)this.perfil.Sexo];
            string[] textArray2 = new string[] { medico.Nombre, " ", medico.PrimerApellido, " ", medico.SegundoApellido };
            this.CampMedico.Text = string.Concat(textArray2);
            this.CampConsultorio.Text = Consultorios.GetInstance().GetConsultorio(this.orden.IdConsultorio).Nombre;
            this.LabelGestacion.Visible = false;
            this.CampGestacion.Visible = false;
            if (this.perfil.Sexo == Sexo.Mujer)
            {
                this.LabelGestacion.Visible = true;
                this.CampGestacion.Visible = true;
                this.CampGestacion.Text = this.orden.EnGestacion ? "Si" : "No";
            }
            this.PickerTime.Text = this.orden.FechaRegistro.ToShortDateString();
            this.tabla.Clear();
            foreach (OrdenDetalle detalle in this.orden.Detalle.Values)
            {
                Analisis analisisById = ListaAnalisis.GetInstance().GetAnalisisById(detalle.IdDataPaquete);
                base.SuspendLayout();
                DataRow row = this.tabla.NewRow();
                row[0] = analisisById.IdData;
                row[1] = analisisById.Codigo;
                row[2] = analisisById.Nombre;
                row[3] = detalle.Cobertura;
                row[4] = this.idUniqueRowCount;
                this.idUniqueRowCount++;
                this.tabla.Rows.Add(row);
                base.ResumeLayout(false);
            }
        }

       
        private void InicializarTablaOrdenDetalle()
        {
            base.SuspendLayout();
            this.tabla.Columns.Add("id", typeof(int));
            this.tabla.Columns.Add("codigo", typeof(string));
            this.tabla.Columns.Add("nombre", typeof(string));
            this.tabla.Columns.Add("cobertura", typeof(object));
            this.tabla.Columns.Add("idUnique", typeof(int));
            this.dataGridView.Columns[0].DataPropertyName = "id";
            this.dataGridView.Columns[0].Visible = false;
            this.dataGridView.Columns[0].ReadOnly = true;
            this.dataGridView.Columns[1].DataPropertyName = "codigo";
            this.dataGridView.Columns[1].ReadOnly = true;
            this.dataGridView.Columns[1].Resizable = DataGridViewTriState.False;
            this.dataGridView.Columns[2].DataPropertyName = "nombre";
            this.dataGridView.Columns[2].ReadOnly = true;
            this.dataGridView.Columns[2].Resizable = DataGridViewTriState.False;
            this.dataGridView.Columns[2].HeaderText = "Nombre";
            this.dataGridView.Columns[3].DataPropertyName = "cobertura";
            this.dataGridView.Columns[3].HeaderText = "Cobertura";
            ((DataGridViewComboBoxColumn)this.dataGridView.Columns[3]).DataSource = new BindingSource(DataEstaticaGeneral.CoberturaTipos, null);
            ((DataGridViewComboBoxColumn)this.dataGridView.Columns[3]).DisplayMember = "Value";
            ((DataGridViewComboBoxColumn)this.dataGridView.Columns[3]).ValueMember = "Key";
            this.dataGridView.Columns[3].Resizable = DataGridViewTriState.False;
            this.dataGridView.Columns[4].DataPropertyName = "idUnique";
            this.dataGridView.Columns[4].Visible = false;
            this.dataGridView.Columns[4].ReadOnly = true;
            this.dataGridView.Enabled = false;
            this.bindingSource = new BindingSource();
            this.dataGridView.DataSource = this.bindingSource;
            this.bindingSource.DataSource = this.tabla;
            this.dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            base.ResumeLayout(false);
        }

       
        public LabDesk.Code.EntityLayer.EOrden.Orden Orden
        {
            get =>
                this.orden;
            set
            {
                this.orden = value;
            }
        }

        public Paciente Perfil
        {
            get =>
                this.perfil;
            set
            {
                this.perfil = value;
            }
        }
    }
}
