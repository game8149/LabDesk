using EntityLab.Code.Hospital;
using EntityLab.Code.Hospital.Analisis;
using EntityLab.Code.Hospital.Analisis.Result;
using EntityLab.Code.Management;
using EntityLab.Code.Static;
using LabDesk.Code.Base;
using LabDesk.Code.Components.Laboratory.Exam.Editor;
using LabDesk.Code.PresentationLayer.Controles.ComponentesExamen.ComponentesExamenEditor;
using LabDesk.Code.StyleManager;
using MinLab.Code.LogicLayer.LogicaExamen;
using MinLab.Code.LogicLayer.LogicaTarifario;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Laboratory.Exam
{
    public partial class FormExamenEditor : Form
    {
        private BindingSource bindingSource;

        private DataTable tabla;
        private ExamenEditorContenedor panelActual;
        private ExamOrder orden;
        private Paciente paciente;
        private Dictionary<int, ExamResult> examenes;
        private int idExamenSelected = -1;
        private int indexRowSelected = -1;

        public FormExamenEditor()
        {
            ConfiguracionExamen.GetInstance().Loading = true;
            this.InitializeComponent();
            base.SuspendLayout();
            this.bindingSource = new BindingSource();
            this.InicializarComponentesTablaDGVExamen();
            this.LimpiarFormulario();
            this.DoubleBuffered = true;
            base.FormClosing += new FormClosingEventHandler(this.FormExamenGeneral_FormClosing);
            base.ResumeLayout();
            ConfiguracionExamen.GetInstance().Loading = false;
            this.BtnUIExamenEditor1.Tipo = ButtonUI.ButtonTipo.Next;
            this.BtnUIExamenEditor2.Tipo = ButtonUI.ButtonTipo.Ok;
            this.BtnUIExamenEditor1.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click);
            this.BtnUIExamenEditor2.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click1);
            base.SuspendLayout();
            Decorator.Instance().FormatStyle(base.Controls);
            base.ResumeLayout();
        }

        private void ActualizarDGVEstadoExamen()
        {
            this.DGVExamen.SuspendLayout();
            this.DGVExamen.Rows[this.indexRowSelected].Cells[1].Value = DataEstaticaGeneral.ExamenEstados[(int)this.examenes[this.idExamenSelected].State];
            this.DGVExamen.ResumeLayout(false);
        }

        public void BlockPanelExamen()
        {
            this.panelActual.Visible = false;
            this.PanelCerrado.Visible = true;
            this.LabelModif.Visible = false;
            this.LabelUsuarioLast.Visible = false;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (ConfiguracionExamen.GetInstance().Changed)
            {
                if (MessageBox.Show("Has realizardo cambios. \x00bfDesea guardarlos?", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    new LogicaExamen().GuardarExamen(this.examenes[this.idExamenSelected]);
                    this.ActualizarDGVEstadoExamen();
                }
                ConfiguracionExamen.GetInstance().Changed = false;
            }
            this.DehabilitarBarTitle();
            this.DeshabilitarTools();
            this.UnblockPanelExamen();
            this.LabelModif.Visible = false;
            this.LabelUsuarioLast.Visible = false;
            this.PanelExamen.Controls.Remove(this.panelActual);
            this.DGVExamen.Enabled = true;
            this.LabelExamen.Text = "";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            LogicaExamen examen = new LogicaExamen.LogicaExamen();
            try
            {
                this.GetTabRespuestas(this.examenes[this.idExamenSelected]);
                //examen.ValidarExamenes(this.examenes[this.idExamenSelected]);
                //examen.GuardarExamen(this.examenes[this.idExamenSelected]);
                Account cuenta = new LogicaCuenta().ObtenerCuenta(this.examenes[this.idExamenSelected].IdAccountBegun);
                this.LabelUsuarioLast.Text = (cuenta.Name + " " + cuenta.Surnames).ToUpper() + " (" + cuenta.Tag + ")";
                ConfiguracionExamen.GetInstance().Changed = false;
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message, "Advertencia");
            }
        }

        private void CargarDatosEnDGVExamen(ExamOrder orden)
        { 
           LogicaExamen examen = new LogicaExamen();
            this.DGVExamen.SuspendLayout();
            this.tabla.Clear();
            this.examenes = examen.RecuperarExamenes(orden);
            foreach (ExamResult examen2 in this.examenes.Values)
            {
                DataRow row = this.tabla.NewRow();
                string str = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CultureInfo.CurrentCulture.TextInfo.ToLower(ListaAnalisis.GetInstance().GetAnalisisById(orden.Detalle[examen2.Id].IdDataPaquete).Nombre));
                string str2 = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CultureInfo.CurrentCulture.TextInfo.ToLower(Plantillas.GetInstance().GetPlantilla(examen2.Id).Nombre));
                row[0] = (str == str2) ? str : (str + ":" + str2);
                row[1] = DataEstaticaGeneral.ExamenEstados[(int)examen2.State];
                row[2] = examen2.Id;
                this.tabla.Rows.Add(row);
            }
            this.DGVExamen.ResumeLayout(false);
        }

        private void CargarExamen(int fila)
        {
            if (fila > -1)
            {
                ExamResult examen = this.examenes[Convert.ToInt32(this.DGVExamen.Rows[fila].Cells[2].Value)];
                this.idExamenSelected = examen.IdData;
                this.indexRowSelected = fila;
                ConfiguracionExamen.GetInstance().Loading = true;
                this.DGVExamen.Enabled = false;
                this.PanelExamen.SuspendLayout();
                this.CargarPlantillaEnPanel(examen);
                this.SetTabRespuestas(this.examenes[this.idExamenSelected]);
                this.HabilitarBarTitle();
                if (examen.Estado == ExamResult.EstadoExamen.Terminado)
                {
                    this.BlockPanelExamen();
                    this.DeshabilitarTools();
                }
                else
                {
                    this.UnblockPanelExamen();
                    this.HabilitarTools();
                }
                ConfiguracionExamen.GetInstance().Loading = false;
                this.PanelExamen.ResumeLayout(false);
            }
        }

        private void CargarPlantillaEnPanel(ExamResult examen)
        {
            Template plantilla = Plantillas.GetInstance().GetPlantilla(examen.IdPlantilla);
            this.CheckEstado.Checked = Convert.ToBoolean((int)examen.Estado);
            this.LabelExamen.Text = Plantillas.GetInstance().Coleccion()[examen.IdPlantilla].Nombre;
            Account cuenta = new LogicaCuenta().ObtenerCuenta(examen.IdCuenta);
            this.LabelUsuarioLast.Text = (cuenta.Nombre + cuenta.PrimerApellido).ToUpper() + " (" + cuenta.Dni + ")";
            base.SuspendLayout();
            List<ExamenEditorFila> list = new List<ExamenEditorFila>();
            this.panelActual = new ExamenEditorContenedor(this.PanelExamen.Width - 10, this.PanelExamen.Height - 10);
            this.PanelExamen.SuspendLayout();
            ExamenEditorFila fila = null;
            ExamenEditorItem item = null;
            ExamenEditorGrupo grupo = null;
            int num = 0;
            for (int i = 0; i < plantilla.Filas.Count; i++)
            {
                PlantillaItem item2;
                if (PlantillaFila.PlantillaFilaTipo.Agrupada == plantilla.Filas[i].Tipo)
                {
                    PlantillaFilaGrupo grupo2 = (PlantillaFilaGrupo)plantilla.Filas[i];
                    fila = new ExamenEditorFila(this.panelActual.Width - 10, 0x19);
                    fila.SuspendLayout();
                    fila.Tipo = ExamenEditorFila.TipoForm.Grupo;
                    grupo = new ExamenEditorGrupo(fila.Width - 5, 0);
                    grupo.SuspendLayout();
                    grupo.Location = new Point(0, 0);
                    grupo.Nombre = grupo2.Nombre;
                    List<ExamenEditorItem> list2 = new List<ExamenEditorItem>();
                    for (int j = 0; j < grupo2.Items.Count; j++)
                    {
                        item2 = grupo2.Items[j];
                        item = new ExamenEditorItem(grupo.Width - 20, 0x19, item2.TieneUnidad);
                        item.SuspendLayout();
                        item.TabIndex = num;
                        num++;
                        item.IdItem = item2.IdData;
                        item.Nombre = item2.Nombre;
                        item.TipoDato = item2.TipoDato;
                        item.TipoCampo = item2.TipoCampo;
                        if (item2.TipoCampo == TipoCampo.Lista)
                        {
                            item.Opciones = item2.OpcionesByIndice;
                        }
                        else if (item2.TipoCampo == TipoCampo.Texto)
                        {
                            fila.Height = 80;
                            item.Height = 80;
                        }
                        if ((item2.TipoDato == TipoDato.Entero) || (item2.TipoDato == TipoDato.Bool))
                        {
                            item.RegEx = DataEstaticaGeneral.Expressions[(int)item2.TipoDato];
                        }
                        if (item2.TieneUnidad)
                        {
                            item.Unidad = item2.Unidad;
                        }
                        item.Location = new Point(10, 20);
                        list2.Add(item);
                        item.ResumeLayout(false);
                    }
                    grupo.Items = list2;
                    fila.Grupo = grupo;
                    list.Add(fila);
                    grupo.ResumeLayout(false);
                    fila.ResumeLayout(false);
                }
                else
                {
                    item2 = ((PlantillaFilaSimple)plantilla.Filas[i]).Item;
                    fila = new ExamenEditorFila(this.panelActual.Width - 10, 0x19);
                    fila.SuspendLayout();
                    fila.Location = new Point(10, 10);
                    fila.Tipo = ExamenEditorFila.TipoForm.Item;
                    item = new ExamenEditorItem(fila.Width - 5, 0x19, item2.TieneUnidad);
                    item.SuspendLayout();
                    item.Location = new Point(0, 0);
                    item.IdItem = item2.IdData;
                    item.Nombre = item2.Nombre;
                    item.TabIndex = num;
                    num++;
                    item.TipoCampo = item2.TipoCampo;
                    item.TipoDato = item2.TipoDato;
                    if (item2.TipoCampo == TipoCampo.Lista)
                    {
                        item.Opciones = item2.OpcionesByIndice;
                    }
                    else if (item2.TipoCampo == TipoCampo.Texto)
                    {
                        fila.Height = 80;
                        item.Height = 80;
                    }
                    if (item2.TieneUnidad)
                    {
                        item.Unidad = item2.Unidad;
                    }
                    fila.Item = item;
                    list.Add(fila);
                    item.ResumeLayout(false);
                    fila.ResumeLayout(false);
                }
            }
            this.panelActual.Filas = list;
            this.PanelExamen.Controls.Add(this.panelActual);
            this.PanelExamen.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void CheckEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (!ConfiguracionExamen.GetInstance().Loading && this.CheckEstado.Checked)
            {
                if (MessageBox.Show("\x00bfEst\x00e1 seguro que desea dar por finalizado el examen?", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.examenes[this.idExamenSelected].Estado = ExamResult.EstadoExamen.Terminado;
                    new LabDesk.Code.LogicLayer.LogicaExamen.LogicaExamen().GuardarExamen(this.examenes[this.idExamenSelected]);
                    this.ActualizarDGVEstadoExamen();
                    this.DeshabilitarTools();
                    this.BlockPanelExamen();
                }
                else
                {
                    this.CheckEstado.Checked = false;
                }
            }
        }

        private void ComponenteUI_Click(object sender, EventArgs e)
        {
            LabDesk.Code.LogicLayer.LogicaExamen.LogicaExamen examen = new LabDesk.Code.LogicLayer.LogicaExamen.LogicaExamen();
            LogicaOrden orden = new LogicaOrden();
            ConfiguracionExamen.GetInstance().Loading = true;
            LogicaControlSistema sistema1 = new LogicaControlSistema();
            if (!sistema1.GetPase())
            {
                this.ValidarAutorizacion();
                this.CheckEstado.Checked = false;
            }
            if (sistema1.GetPase())
            {
                this.examenes[this.idExamenSelected].Estado = ExamResult.EstadoExamen.EnProceso;
                this.CheckEstado.Checked = false;
                examen.GuardarExamen(this.examenes[this.idExamenSelected]);
                orden.ActualizarOrden(this.examenes, this.orden);
                this.ActualizarDGVEstadoExamen();
                this.HabilitarTools();
                this.UnblockPanelExamen();
            }
            ConfiguracionExamen.GetInstance().Loading = false;
        }

        private void ComponenteUI_Click1(object sender, EventArgs e)
        {
            if (this.DGVExamen.SelectedCells.Count > 0)
            {
                this.CargarExamen(this.DGVExamen.SelectedCells[0].RowIndex);
            }
        }

        private void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.CargarExamen(e.RowIndex);
        }

        private void DataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex > -1) && this.DGVExamen.Rows[e.RowIndex].Selected)
            {
                this.DGVExamen.Cursor = Cursors.Hand;
            }
        }

        private void DataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex > -1) && this.DGVExamen.Rows[e.RowIndex].Selected)
            {
                this.DGVExamen.Cursor = Cursors.Arrow;
            }
        }

        private void DataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.RowIndex > -1) && this.DGVExamen.Rows[e.RowIndex].Selected)
            {
                this.DGVExamen.Cursor = Cursors.Hand;
            }
        }

        public void DehabilitarBarTitle()
        {
            this.BtnExamenEditarCerrar.Visible = false;
            this.LabelExamen.Visible = false;
        }

        public void DeshabilitarTools()
        {
            this.CheckEstado.Visible = false;
            this.BtnExamenEditarGuardar.Visible = false;
        }



        private void FormExamenGeneral_FormClosing(object sender, FormClosingEventArgs e)
        {
            new LogicaOrden().ActualizarOrden(this.examenes, this.orden);
        }

        private void formExamenGeneral_Load(object sender, EventArgs e)
        {
            this.DGVExamen.Columns["idExamen"].Visible = false;
        }

        private void GetTabRespuestas(ExamResult examen)
        {
            foreach (ExamenEditorFila fila in this.panelActual.Filas)
            {
                if (fila.Tipo == ExamenEditorFila.TipoForm.Item)
                {
                    examen.DetallesByItem[fila.Item.IdItem].Campo = fila.Item.Value;
                }
                else
                {
                    foreach (ExamenEditorItem item in fila.Grupo.Items)
                    {
                        examen.DetallesByItem[item.IdItem].Campo = item.Value;
                    }
                }
            }
        }

        public void HabilitarBarTitle()
        {
            this.BtnExamenEditarCerrar.Visible = true;
            this.LabelExamen.Visible = true;
        }

        public void HabilitarTools()
        {
            this.CheckEstado.Visible = true;
            this.BtnExamenEditarGuardar.Visible = true;
        }

        private void InicializarComponentesTablaDGVExamen()
        {
            this.DGVExamen.SuspendLayout();
            this.tabla = new DataTable("Examenes");
            this.tabla.Columns.Add("Nombre", typeof(string));
            this.tabla.Columns.Add("Estado", typeof(string));
            this.tabla.Columns.Add("IdExamen", typeof(int));
            this.DGVExamen.Columns[0].DataPropertyName = "Nombre";
            this.DGVExamen.Columns[0].HeaderText = "Nombre";
            this.DGVExamen.Columns[0].ReadOnly = true;
            this.DGVExamen.Columns[1].DataPropertyName = "Estado";
            this.DGVExamen.Columns[1].HeaderText = "Estado";
            this.DGVExamen.Columns[1].ReadOnly = true;
            this.DGVExamen.Columns[2].DataPropertyName = "IdExamen";
            this.DGVExamen.Columns[2].HeaderText = "IdExamen";
            this.DGVExamen.Columns[2].Visible = false;
            this.DGVExamen.Columns[2].ReadOnly = true;
            this.DGVExamen.DataSource = this.bindingSource;
            this.bindingSource.DataSource = this.tabla;
            this.DGVExamen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVExamen.CellMouseEnter += new DataGridViewCellEventHandler(this.DataGridView_CellMouseEnter);
            this.DGVExamen.CellMouseLeave += new DataGridViewCellEventHandler(this.DataGridView_CellMouseLeave);
            this.DGVExamen.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.DataGridView_CellMouseDoubleClick);
            this.DGVExamen.CellMouseUp += new DataGridViewCellMouseEventHandler(this.DataGridView_CellMouseUp);
            this.DGVExamen.MultiSelect = false;
            this.DGVExamen.ResumeLayout(true);
        }


        private void LimpiarFormulario()
        {
            this.CampOrden.Text = "";
            this.CampDni.Text = "";
            this.CampEdad.Text = "";
            this.CampHistoria.Text = "";
            this.CampNombre.Text = "";
            this.CampRegistro.Text = "";
            this.CampSexo.Text = "";
            this.LabelExamen.Text = "";
            this.LabelModif.Visible = false;
            this.LabelUsuarioLast.Visible = false;
        }

        private void ResetComboEstadoTabla()
        {
            IEnumerator enumerator = tabla.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ((DataRow)enumerator.Current)[1] = 0;
            }

        }

        private void SetTabRespuestas(ExamResult examen)
        {
            foreach (ExamenEditorFila fila in this.panelActual.Filas)
            {
                if (fila.Tipo == ExamenEditorFila.TipoForm.Item)
                {
                    fila.Item.Value = examen.DetallesByItem[fila.Item.IdItem].Campo.ToString();
                }
                else
                {
                    foreach (ExamenEditorItem item in fila.Grupo.Items)
                    {
                        item.Value = examen.DetallesByItem[item.IdItem].Campo.ToString();
                    }
                }
            }
        }

        public void UnblockPanelExamen()
        {
            this.panelActual.Visible = true;
            this.PanelCerrado.Visible = false;
            this.LabelModif.Visible = true;
            this.LabelUsuarioLast.Visible = true;
        }

        private void ValidarAutorizacion()
        {
            new FormAutorizacion().ShowDialog();
        }

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x2000000;
                return createParams;
            }
        }

        public LabDesk.Code.EntityLayer.EOrden.ExamOrder ExamOrder
        {
            get =>
                this.orden;
            set
            {
                this.orden = value;
                object[] objArray1 = new object[] { "ExamOrder ", this.orden.IdData, " - ", this.orden.Boleta };
                this.CampOrden.Text = string.Concat(objArray1);
                this.CampRegistro.Text = this.orden.FechaRegistro.ToShortDateString();
                this.CargarDatosEnDGVExamen(this.orden);
            }
        }

        public LabDesk.Code.EntityLayer.EFicha.Paciente Paciente
        {
            get =>
                this.paciente;
            set
            {
                this.paciente = value;
                string[] textArray1 = new string[] { this.paciente.Nombre, " ", this.paciente.PrimerApellido, " ", this.paciente.SegundoApellido };
                this.CampNombre.Text = string.Concat(textArray1);
                this.CampDni.Text = this.paciente.Dni;
                this.CampHistoria.Text = this.paciente.Historia;
                this.CampSexo.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CultureInfo.CurrentCulture.TextInfo.ToLower(DataEstaticaGeneral.SexoTipos[(int)this.paciente.Sexo]));
                DataEstaticaGeneral.Tiempo edad = Utilidad.CalcularEdad(this.paciente.FechaNacimiento);
                this.CampEdad.Text = Utilidad.FormatoEdad(edad);
            }
        }
    }
}
