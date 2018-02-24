using LabDesk.Code.PresentationLayer.ComponenteGeneral;
using LabDesk.Code.PresentationLayer.Controles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Laboratory.Orden
{
    

    public partial class PanelOrdenEditar : UserControl
    {
        private BindingSource bindingSource;
        
        private Dictionary<int, OrdenDetalle> detalleDeleted = new Dictionary<int, OrdenDetalle>();
        private Dictionary<int, OrdenDetalle> detalleInsert = new Dictionary<int, OrdenDetalle>();
        private Dictionary<int, OrdenDetalle> detalleUpdate = new Dictionary<int, OrdenDetalle>();
        private Orden orden;
        private int idUniqueRowCount;
        private Paciente perfil;
        private DataTable tabla;
        private List<int> IndexDelete = new List<int>();
        private List<int> IndexExist = new List<int>();
        private List<int> IndexInsert = new List<int>();

        public PanelOrdenEditar()
        {
            this.InitializeComponent();
            base.SuspendLayout();
            BLConsultorio consultorio = new BLConsultorio();
            BLMedico medico = new BLMedico();
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
            this.tabla = new DataTable("Lista");
            if (ListaAnalisis.GetInstance().Coleccion.Count > 0)
            {
                this.InicializarTablaOrdenDetalle();
            }
            this.DeshabilitarFormulario();
            base.ResumeLayout(false);
            this.BtnUIOrdenEditar3.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click2);
            this.BtnUIOrdenEditar3.Tipo = ButtonUI.ButtonTipo.Delete;
            base.SuspendLayout();
            Decorator.Instance().FormatStyle(base.Controls);
            this.InicializarToolTip();
            base.ResumeLayout();
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
                this.tabla.Rows.Add(row);
                this.IndexInsert.Add(this.idUniqueRowCount);
                this.ComboExamen.SelectedIndex = 0;
                this.idUniqueRowCount++;
                base.ResumeLayout(false);
            }
            catch (Exception exception1)
            {
                FormMensaje.Advertencia(exception1.Message);
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
                        int id = (int)((DataGridViewRow)enumerator.Current).Cells[4].Value;
                        foreach (DataRow row in this.tabla.Rows)
                        {
                            if (((int)row[4]) == id)
                            {
                                if (this.existInOrdenActual(id))
                                {
                                    OrdenDetalle detalle = new OrdenDetalle
                                    {
                                        IdData = (int)row[4],
                                        IdDataPaquete = (int)row[0],
                                        Cobertura = (int)row[3]
                                    };
                                    this.detalleDeleted.Add(detalle.IdData, detalle);
                                    this.IndexDelete.Add(id);
                                    this.IndexExist.Remove(id);
                                }
                                row.Delete();
                                continue;
                            }
                        }
                    }
                
            }
        }

        private void BtnOrdenEditarGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tabla.Rows.Count == 0)
                {
                    throw new Exception(RecursosUIMensajes.MsgOrdenError1);
                }
                LabDesk.Code.EntityLayer.EOrden.Orden orden = new LabDesk.Code.EntityLayer.EOrden.Orden
                {
                    IdData = this.orden.IdData,
                    Estado = this.orden.Estado,
                    Boleta = this.CampBoleta.Text,
                    FechaRegistro = this.PickerTime.Value,
                    IdPaciente = this.Perfil.IdData,
                    UltimaModificacion = DateTime.Now,
                    IdConsultorio = (int)this.ComboBoxConsultorio.SelectedValue,
                    IdMedico = (int)this.ComboBoxMedico.SelectedValue
                };
                if (this.Perfil.Sexo == Sexo.Mujer)
                {
                    orden.EnGestacion = this.CheckBoxGestante.Checked;
                }
                OrdenDetalle detalle = null;
                foreach (int num in this.IndexExist)
                {
                    foreach (DataRow row in this.tabla.Rows)
                    {
                        if (((int)row[4]) == num)
                        {
                            detalle = new OrdenDetalle
                            {
                                IdData = (int)row[4],
                                IdDataPaquete = (int)row[0],
                                Cobertura = (int)row[3]
                            };
                            this.detalleUpdate.Add(detalle.IdData, detalle);
                        }
                    }
                }
                foreach (int num2 in this.IndexInsert)
                {
                    foreach (DataRow row2 in this.tabla.Rows)
                    {
                        if (((int)row2[4]) == num2)
                        {
                            detalle = new OrdenDetalle
                            {
                                IdData = (int)row2[4],
                                IdDataPaquete = (int)row2[0],
                                Cobertura = (int)row2[3]
                            };
                            this.detalleInsert.Add(detalle.IdData, detalle);
                        }
                    }
                }
                LogicaOrden orden1 = new LogicaOrden();
                orden1.ActualizarOrden(orden);
                orden.Detalle = this.detalleUpdate;
                orden1.ActualizarOrdenDetalle(orden);
                orden.Detalle = this.detalleInsert;
                orden1.AgregarOrdenDetalle(orden);
                orden.Detalle = this.detalleDeleted;
                orden1.EliminarOrdenDetalle(orden);
                FormMensaje.Confirmacion(RecursosUIMensajes.MsgOrdenSave);
            }
            catch (Exception exception1)
            {
                FormMensaje.Error(exception1.Message);
            }
        }

        private void BtnOrdenNuevoCerrar_Click(object sender, EventArgs e)
        {
            if (FormMensaje.DecisionAdvertencia(RecursosUIMensajes.MsgOrdenUnsave) == DialogResult.Yes)
            {
                base.Visible = false;
                ((PanelOrdenPerfil)base.Parent).Orden = new LogicaOrden().ObtenerOrden(this.orden.IdData);
                ((PanelOrdenPerfil)base.Parent).CargarDatos();
                LogicaControlSistema.DisminuirNivel();
                LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
                base.Dispose();
            }
        }

        public void CargarDatos()
        {
            try
            {
                base.SuspendLayout();
                this.orden = ((PanelOrdenPerfil)base.Parent).Orden;
                this.perfil = ((PanelOrdenPerfil)base.Parent).Perfil;
                this.CampDireccion.Text = this.perfil.Direccion;
                this.CampDni.Text = this.perfil.Dni;
                this.CampHistoria.Text = this.perfil.Historia;
                this.CampSexo.Text = DataEstaticaGeneral.SexoTipos[(int)this.Perfil.Sexo];
                string[] textArray1 = new string[] { this.perfil.Nombre, " ", this.perfil.PrimerApellido, " ", this.perfil.SegundoApellido };
                this.CampNombre.Text = string.Concat(textArray1);
                this.CampBoleta.Text = this.orden.Boleta;
                this.ComboBoxConsultorio.SelectedValue = this.orden.IdConsultorio;
                this.ComboBoxMedico.SelectedValue = this.orden.IdMedico;
                this.CheckBoxGestante.Visible = false;
                if (this.Perfil.Sexo == Sexo.Mujer)
                {
                    this.CheckBoxGestante.Visible = true;
                    this.CheckBoxGestante.Checked = this.orden.EnGestacion;
                }
                this.PickerTime.Value = this.orden.FechaRegistro;
                this.tabla.Clear();
                foreach (OrdenDetalle detalle in this.Orden.Detalle.Values)
                {
                    Analisis analisisById = ListaAnalisis.GetInstance().GetAnalisisById(detalle.IdDataPaquete);
                    DataRow row = this.tabla.NewRow();
                    row[0] = detalle.IdDataPaquete;
                    row[1] = analisisById.Codigo;
                    row[2] = analisisById.Nombre;
                    row[3] = detalle.Cobertura;
                    row[4] = detalle.IdData;
                    if (this.idUniqueRowCount < detalle.IdData)
                    {
                        this.idUniqueRowCount = detalle.IdData;
                    }
                    this.IndexExist.Add(detalle.IdData);
                    this.tabla.Rows.Add(row);
                }
                this.idUniqueRowCount++;
                base.ResumeLayout();
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message, "Advertencia");
                this.ComboExamen.Focus();
                this.ComboExamen.SelectedIndex = 0;
            }
        }

        private void ComponenteUI_Click2(object sender, EventArgs e)
        {
            try
            {
                if (FormMensaje.DecisionAdvertencia(RecursosUIMensajes.MsgOrdenDeleteDesicion) == DialogResult.Yes)
                {
                    base.Visible = false;
                    new LogicaOrden().EliminarOrden(this.orden);
                    FormMensaje.Confirmacion(RecursosUIMensajes.MsgPerfilDelete);
                    LogicaControlSistema.DisminuirNivel();
                    LogicaControlSistema.DisminuirNivel();
                    LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
                    ((ControlOrden)base.Parent.Parent.Parent).ModeBtnFuncion(true);
                    ((PanelOrdenPerfil)base.Parent).Dispose();
                }
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
            this.CampHistoria.Text = "";
            this.CampNombre.Text = "";
            this.CampDni.Text = "";
            this.CampBoleta.Text = "";
            this.CampSexo.Text = "";
            this.CheckBoxGestante.Checked = false;
            this.CheckBoxGestante.Visible = false;
            this.CheckBoxGestante.Visible = false;
        }
        
        private bool existInOrdenActual(int id)
        {
            using (List<int>.Enumerator enumerator = this.IndexExist.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current == id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void HabilitarFormulario()
        {
            this.BtnOrdenNuevoAgregarExamen.Visible = true;
            this.ComboExamen.Visible = true;
            this.LabelNombreExamen.Visible = true;
        }

        private void InicializarTablaOrdenDetalle()
        {
            base.SuspendLayout();
            this.BtnOrdenNuevoEliminarExamen.Visible = false;
            this.ComboExamen.Enabled = true;
            this.BtnOrdenNuevoAgregarExamen.Enabled = true;
            this.ComboExamen.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.ComboExamen.DataSource = new BindingSource(ListaAnalisis.GetInstance().Coleccion, null);
            this.ComboExamen.DisplayMember = "Value";
            this.ComboExamen.ValueMember = "Key";
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
            this.tip.SetToolTip(this.BtnOrdenNuevoAgregarExamen, RecursosUIToolkit.BtnOrdenNuevoAgregarExamen);
            this.tip.SetToolTip(this.BtnOrdenNuevoEliminarExamen, RecursosUIToolkit.BtnOrdenNuevoEliminarExamen);
            this.tip.SetToolTip(this.BtnOrdenEditarGuardar, RecursosUIToolkit.BtnOrdenEditarGuardar);
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
