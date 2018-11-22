using Entity.Code.Hospital;
using Entity.Code.Hospital.Analisis;
using Entity.Code.Static;
using LabDesk.Code.Base;
using LabDesk.Code.Components.Laboratory.Exam;
using LabDesk.Code.StyleManager;
using LogicLab.Code.PrintingManager;
using MinLab.Code.LogicLayer.LogicaPaciente;
using MinLab.Code.LogicLayer.LogicaTarifario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main.Panels
{
    
    public partial class ControlExamen : UserControl
    {
        private BindingSource bindingSource;
        private bool isLoadingUI = true;
        private Dictionary<int, ExamOrder> ordenes;
        private DataTable tabla;

        public ControlExamen()
        {
            this.InitializeComponent();
            base.SizeChanged += new EventHandler(this.ControlExamen_SizeChanged);
            this.tabla = new DataTable("Examenes");
            this.bindingSource = new BindingSource();
            this.ComboEstado.DataSource = new BindingSource(DataEstaticaGeneral.OrdenEstados, null);
            this.ComboEstado.DisplayMember = "Value";
            this.ComboEstado.ValueMember = "Key";
            this.InicializarComponenteTablaDGVOrden();
            this.DGVOrden.KeyPress += new KeyPressEventHandler(this.DGVOrden_KeyPress);
            this.DGVOrden.DoubleClick += new EventHandler(this.DGVOrden_DoubleClick);
            this.PickerInit.Value = DateTime.Now;
            this.isLoadingUI = false;
            this.BtnUIExamen1.Tipo = ButtonUI.ButtonTipo.Ok;
            this.BtnUIExamen1.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click);
            Decorator.Instance().FormatStyle(base.Controls);
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            Dictionary<int, ExamOrder> ordenes = new Dictionary<int, ExamOrder>();
            foreach (DataGridViewRow row in this.DGVOrden.SelectedRows)
            {
                ordenes.Add((int) row.Cells[0].Value, this.ordenes[(int) row.Cells[0].Value]);
            }
            new Impresora().ContruirVistaPrevia(ordenes);
        }

        private void CargarDatosEnDGVOrden()
        {
            LogicaOrden orden = new LogicaOrden();
            LogicaPaciente paciente = new LogicaPaciente();
            this.ordenes = orden.ObtenerOrdenesByFechaByEstado(this.PickerInit.Value, this.PickerEnd.Value, (ExamOrder.DocumentState) this.ComboEstado.SelectedIndex);
            this.tabla.Clear();
            base.SuspendLayout();
            this.DGVOrden.SuspendLayout();
            foreach (ExamOrder orden2 in this.ordenes.Values)
            {
                DataRow row = this.tabla.NewRow();
                Patient paciente2 = paciente.ObtenerPerfilPorId(orden2.IdPaciente);
                row[0] = orden2.Id;
                row[1] = paciente2.DocumentNumber;
                string[] textArray1 = new string[] { paciente2.Names, " ", paciente2.FirstSurname, " ", paciente2.LastSurname };
                row[2] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(string.Concat(textArray1));
                row[3] = orden.ObtenerDescripcion(orden2);
                row[4] = orden2.DateInsert;
                row[5] = orden2.DocumentNumberAssociated;
                row[6] = DataEstaticaGeneral.OrdenEstados[Convert.ToInt32(orden2.State)];
                this.tabla.Rows.Add(row);
            }
            this.DGVOrden.ClearSelection();
            this.DGVOrden.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void ComboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.isLoadingUI)
            {
                this.CargarDatosEnDGVOrden();
            }
        }

        private void ComponenteUI_Click(object sender, EventArgs e)
        {
            this.IniciarEditorExamen();
        }

        private void ControlExamen_Load(object sender, EventArgs e)
        {
            this.PickerEnd.MaxDate = DateTime.Now;
            this.PickerInit.MaxDate = DateTime.Now;
            this.CargarDatosEnDGVOrden();
        }

        private void ControlExamen_SizeChanged(object sender, EventArgs e)
        {
            this.PanelBarTable.Width = base.Size.Width - (2 * Decorator.EspacioBorde);
            this.DGVOrden.Width = base.Size.Width - (2 * Decorator.EspacioBorde);
            this.DGVOrden.Height = base.Size.Height - (((this.PanelBarTable.Height + Decorator.EspacioTitulo) + (2 * Decorator.EspacioBorde)) + this.BtnUIExamen1.Height);
            this.BtnUIExamen1.Location = new Point(base.Size.Width - (this.BtnUIExamen1.Width + Decorator.EspacioBorde), base.Height - (this.BtnUIExamen1.Height + Decorator.EspacioBorde));
        }

        private void DGVOrden_DoubleClick(object sender, EventArgs e)
        {
            this.IniciarEditorExamen();
        }

        private void DGVOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.IniciarEditorExamen();
            }
            else if (e.KeyChar == 'P')
            {
                this.BtnPrint.PerformClick();
            }
        }

        private void DGVOrden_SelectionChanged(object sender, EventArgs e)
        {
            if (this.ComboEstado.SelectedIndex == 1)
            {
                this.BtnPrint.Visible = this.DGVOrden.SelectedRows.Count > 0;
            }
            else
            {
                this.BtnPrint.Visible = false;
            }
        }
        
        private void IniciarEditorExamen()
        {
            if (this.DGVOrden.SelectedRows.Count > 0)
            {
                int index = this.DGVOrden.SelectedRows[0].Index;
                this.DGVOrden.ClearSelection();
                this.DGVOrden.Rows[index].Selected = true;
                 LogicaPaciente paciente = new  LogicaPaciente();
                FormExamenEditor editor1 = new FormExamenEditor {
                    ExamOrder = this.ordenes[Convert.ToInt32(this.DGVOrden.SelectedRows[0].Cells[0].Value)],
                    Paciente = paciente.ObtenerPerfilPorId(this.ordenes[Convert.ToInt32(this.DGVOrden.SelectedRows[0].Cells[0].Value)].IdPaciente)
                };
                editor1.ShowDialog();
                editor1.Dispose();
                this.CargarDatosEnDGVOrden();
            }
        }

        private void InicializarComponenteTablaDGVOrden()
        {
            this.DGVOrden.DataSource = this.bindingSource;
            this.tabla.Columns.Add("Id", typeof(int));
            this.tabla.Columns.Add("Dni", typeof(string));
            this.tabla.Columns.Add("Paciente", typeof(string));
            this.tabla.Columns.Add("Descripcion", typeof(string));
            this.tabla.Columns.Add("Registro", typeof(string));
            this.tabla.Columns.Add("Comprobante", typeof(string));
            this.tabla.Columns.Add("Estado", typeof(string));
            this.DGVOrden.Columns[0].Visible = true;
            this.DGVOrden.Columns[0].ReadOnly = true;
            this.DGVOrden.Columns[0].DataPropertyName = "Id";
            this.DGVOrden.Columns[1].ReadOnly = true;
            this.DGVOrden.Columns[1].Resizable = DataGridViewTriState.False;
            this.DGVOrden.Columns[1].DataPropertyName = "Dni";
            this.DGVOrden.Columns[2].ReadOnly = true;
            this.DGVOrden.Columns[2].Resizable = DataGridViewTriState.False;
            this.DGVOrden.Columns[2].DataPropertyName = "Paciente";
            this.DGVOrden.Columns[3].ReadOnly = true;
            this.DGVOrden.Columns[3].Resizable = DataGridViewTriState.False;
            this.DGVOrden.Columns[3].DataPropertyName = "Descripcion";
            this.DGVOrden.Columns[4].ReadOnly = true;
            this.DGVOrden.Columns[4].Resizable = DataGridViewTriState.False;
            this.DGVOrden.Columns[4].DataPropertyName = "Registro";
            this.DGVOrden.Columns[5].ReadOnly = true;
            this.DGVOrden.Columns[5].Resizable = DataGridViewTriState.False;
            this.DGVOrden.Columns[5].DataPropertyName = "Comprobante";
            this.DGVOrden.Columns[6].ReadOnly = true;
            this.DGVOrden.Columns[6].Resizable = DataGridViewTriState.False;
            this.DGVOrden.Columns[6].DataPropertyName = "Estado";
            this.bindingSource.DataSource = this.tabla;
            this.DGVOrden.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVOrden.SelectionChanged += new EventHandler(this.DGVOrden_SelectionChanged);
        }
        private void LabelExamen_Click(object sender, EventArgs e)
        {
        }

        private void PickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if (!this.isLoadingUI)
            {
                this.CargarDatosEnDGVOrden();
            }
        }

        private void PickerInit_ValueChanged(object sender, EventArgs e)
        {
            if (!this.isLoadingUI)
            {
                this.CargarDatosEnDGVOrden();
            }
        }
    }
}
