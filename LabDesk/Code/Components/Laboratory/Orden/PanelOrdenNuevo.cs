using LabDesk.Code.PresentationLayer.ComponenteGeneral;
using LabDesk.Code.PresentationLayer.Controles.GUIBuscarPaciente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;



namespace LabDesk.Code.Components.Laboratory.Orden
{
    public partial class PanelOrdenNuevo : UserControl
    {
        private BindingSource bindingSource;
       
        private DataTable tabla;
        private Orden orden;
        private int idUniqueRowCount;

        public PanelOrdenNuevo()
        {
            this.InitializeComponent();
            base.SuspendLayout();
            this.tabla = new DataTable("Lista");
            if (ListaAnalisis.GetInstance().Coleccion.Count > 0)
            {
                this.InicializarTablaOrdenDetalle();
            }
            this.DeshabilitarFormulario();
            this.BtnUIOrdenNuevo2.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click1);
            this.BtnUIOrdenNuevo2.Tipo = ButtonUI.ButtonTipo.Ok;
            Decorator.Instance().FormatStyle(base.Controls);
            this.InicializarToolTip();
            base.ResumeLayout(false);
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ComboExamen.SelectedItem == null)
                {
                    throw new Exception("Listado de Examen: No se ha seleccionado ningun examen.");
                }
                KeyValuePair<int, string> selectedItem = (KeyValuePair<int, string>)this.ComboExamen.SelectedItem;
                int key = selectedItem.Key;
                Analisis analisisById = ListaAnalisis.GetInstance().GetAnalisisById(key);
                base.SuspendLayout();
                DataRow row = this.tabla.NewRow();
                row[0] = analisisById.IdData;
                row[1] = analisisById.Codigo;
                row[2] = analisisById.Nombre;
                row[3] = 0;
                row[4] = this.idUniqueRowCount;
                this.idUniqueRowCount++;
                this.tabla.Rows.Add(row);
                this.ComboExamen.SelectedIndex = 0;
                base.ResumeLayout(false);
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message, "Advertencia");
                this.ComboExamen.Focus();
                this.ComboExamen.SelectedIndex = 0;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dataGridView.SelectedRows.Count > 0)
            {
                IEnumerator enumerator = this.dataGridView.SelectedRows.GetEnumerator();
                
                    while (enumerator.MoveNext())
                    {
                        int num = (int)((DataGridViewRow)enumerator.Current).Cells[4].Value;
                        foreach (DataRow row in this.tabla.Rows)
                        {
                            if (((int)row[4]) == num)
                            {
                                row.Delete();
                                continue;
                            }
                        }
                    }
                
            }
        }

        private void BtnPerfilCerrar_Click(object sender, EventArgs e)
        {
            base.Visible = false;
            LogicaControlSistema.DisminuirNivel();
            LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
            ((ControlOrden)base.Parent.Parent).ModeBtnFuncion(true);
            base.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormBuscarPaciente paciente = new FormBuscarPaciente();
            paciente.ShowDialog();
            if (paciente.Perfil != null)
            {
                this.Perfil = paciente.Perfil;
                this.CampDni.Text = this.Perfil.Dni;
                this.CampHistoria.Text = this.Perfil.Historia;
                string[] textArray1 = new string[] { this.Perfil.Nombre, " ", this.Perfil.PrimerApellido, " ", this.Perfil.SegundoApellido };
                this.CampNombre.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(string.Concat(textArray1));
                this.CampSexo.Text = DataEstaticaGeneral.SexoTipos[(int)this.Perfil.Sexo];
                this.CampUbicacion.Text = LabDesk.Code.LogicLayer.LogicaPaciente.LogicaPaciente.FormatearUbicacion(this.Perfil);
                this.HabilitarFormulario();
                if (this.Perfil.Sexo == Sexo.Mujer)
                {
                    this.CheckBoxGestante.Visible = true;
                }
            }
            paciente.Dispose();
        }

        private void ComponenteUI_Click1(object sender, EventArgs e)
        {
            try
            {
                if (this.Perfil == null)
                {
                    throw new Exception("Perfil: Se necesita un perfil de paciente.");
                }
                if (this.tabla.Rows.Count == 0)
                {
                    throw new Exception("Listado de Examenes: La lista esta vacia.");
                }
                this.orden = new Orden();
                this.orden.Boleta = this.CampBoleta.Text;
                this.orden.FechaRegistro = this.PickerTime.Value;
                this.orden.IdPaciente = this.Perfil.IdData;
                this.orden.UltimaModificacion = this.PickerTime.Value;
                this.orden.IdConsultorio = (int)this.ComboBoxConsultorio.SelectedValue;
                this.orden.IdMedico = (int)this.ComboBoxMedico.SelectedValue;
                if (this.Perfil.Sexo == Sexo.Mujer)
                {
                    this.orden.EstadoPaciente = this.CheckBoxGestante.Checked ? PacienteEstado.Gestante : PacienteEstado.Normal;
                }
                else
                {
                    this.orden.EstadoPaciente = PacienteEstado.Normal;
                }
                Dictionary<int, OrdenDetalle> dictionary = new Dictionary<int, OrdenDetalle>();
                OrdenDetalle detalle = null;
                int key = 0;
                foreach (DataRow row in this.tabla.Rows)
                {
                    detalle = new OrdenDetalle
                    {
                        IdDataPaquete = (int)row[0],
                        Cobertura = (int)row[3]
                    };
                    dictionary.Add(key, detalle);
                    key++;
                }
                this.orden.Detalle = dictionary;
                new LogicaOrden().AgregarOrden(this.orden);
                MessageBox.Show("Orden: Se han registrado correctamente los datos.", "Confirmaci\x00f3n");
                this.DeshabilitarFormulario();
                ((ControlOrden)base.Parent.Parent).ModeBtnFuncion(true);
                base.Visible = false;
                FormMensaje.Confirmacion(RecursosUIMensajes.MsgOrdenOk);
            }
            catch (Exception exception)
            {
                FormMensaje.Error(RecursosUIMensajes.MsgNone + exception.Message);
            }
        }

        private void DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.BtnOrdenNuevoEliminarExamen.Visible = this.dataGridView.Rows.Count > 0;
        }

        private void DataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.BtnOrdenNuevoEliminarExamen.Visible = this.dataGridView.Rows.Count > 0;
        }

        public void DeshabilitarFormulario()
        {
            this.tabla.Clear();
            this.Perfil = null;
            this.BtnOrdenNuevoEliminarExamen.Visible = false;
            this.BtnOrdenNuevoAgregarExamen.Visible = false;
            this.LabelNombreExamen.Visible = false;
            this.ComboExamen.Visible = false;
            this.CampHistoria.Text = "";
            this.CampNombre.Text = "";
            this.CampDni.Text = "";
            this.CampBoleta.Text = "";
            this.CampUbicacion.Text = "";
            this.CampSexo.Text = "";
        }
        

        public void HabilitarFormulario()
        {
            this.BtnOrdenNuevoAgregarExamen.Visible = true;
            this.ComboExamen.Visible = true;
            this.LabelNombreExamen.Visible = true;
            this.CheckBoxGestante.Visible = false;
            this.CheckBoxGestante.Checked = false;
        }

        private void InicializarTablaOrdenDetalle()
        {
            BLMedico medico = new BLMedico();
            BLConsultorio consultorio = new BLConsultorio();
            base.SuspendLayout();
            this.BtnOrdenNuevoEliminarExamen.Visible = false;
            this.ComboExamen.Enabled = true;
            this.BtnOrdenNuevoAgregarExamen.Enabled = true;
            this.ComboExamen.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.ComboExamen.DataSource = new BindingSource(ListaAnalisis.GetInstance().Coleccion, null);
            this.ComboExamen.DisplayMember = "Value";
            this.ComboExamen.ValueMember = "Key";
            this.ComboBoxConsultorio.DataSource = new BindingSource(consultorio.ObtenerLista(), null);
            this.ComboBoxConsultorio.DisplayMember = "Value";
            this.ComboBoxConsultorio.ValueMember = "Key";
            this.ComboBoxMedico.DataSource = new BindingSource(medico.ObtenerListaHabil(), null);
            this.ComboBoxMedico.DisplayMember = "Value";
            this.ComboBoxMedico.ValueMember = "Key";
            this.tabla.TableNewRow += new DataTableNewRowEventHandler(this.Tabla_TableNewRow);
            this.tabla.RowDeleted += new DataRowChangeEventHandler(this.Tabla_RowDeleted);
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
            this.bindingSource = new BindingSource();
            this.dataGridView.DataSource = this.bindingSource;
            this.bindingSource.DataSource = this.tabla;
            this.dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.RowsAdded += new DataGridViewRowsAddedEventHandler(this.DataGridView_RowsAdded);
            this.dataGridView.RowsRemoved += new DataGridViewRowsRemovedEventHandler(this.DataGridView_RowsRemoved);
            base.ResumeLayout(false);
        }

        public void InicializarToolTip()
        {
            this.tip = new ToolTip();
            this.tip.ShowAlways = true;
            this.tip.SetToolTip(this.BtnOrdenNuevoAgregarPaciente, RecursosUIToolkit.BtnOrdenNuevoAgregarPaciente);
            this.tip.SetToolTip(this.BtnOrdenNuevoAgregarExamen, RecursosUIToolkit.BtnOrdenNuevoAgregarExamen);
            this.tip.SetToolTip(this.BtnOrdenNuevoEliminarExamen, RecursosUIToolkit.BtnOrdenNuevoEliminarExamen);
            this.tip.SetToolTip(this.BtnOrdenNuevoCerrar, RecursosUIToolkit.BtnOrdenNuevoCerrar);
        }

        
        private void Tabla_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            if (this.tabla.Rows.Count == 0)
            {
                this.BtnOrdenNuevoEliminarExamen.Visible = false;
            }
            else
            {
                this.BtnOrdenNuevoEliminarExamen.Visible = true;
            }
        }

        private void Tabla_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            if (this.tabla.Rows.Count == 0)
            {
                this.BtnOrdenNuevoEliminarExamen.Visible = false;
            }
            else
            {
                this.BtnOrdenNuevoEliminarExamen.Visible = true;
            }
        }

        public Paciente Perfil { get; set; }
    }
}
