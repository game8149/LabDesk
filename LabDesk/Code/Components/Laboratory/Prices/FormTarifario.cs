using LabDesk.Code.PresentationLayer.ComponenteGeneral;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace LabDesk.Code.Components.Laboratory.Prices
{
    public partial class FormTarifario : Form
    {
        
        private bool changeState;       
        private int IdTarifarioSelected;
        private bool isLoading;      
        private DataTable tablaDataTarifario;
        private Dictionary<int, Tarifario> tarifarios = new Dictionary<int, Tarifario>();
        private string valorPrecioSelectedTemp;

        public FormTarifario()
        {
            this.InitializeComponent();
            this.InicializarTablaTarifario();
            this.CargarDatos();
            this.DGVTar.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.DGVTar_CellBeginEdit);
            this.DGVTar.CellEndEdit += new DataGridViewCellEventHandler(this.DGVTar_CellEndEdit);
            this.DGVTar.DataError += new DataGridViewDataErrorEventHandler(this.DGVTar_DataError);
            this.DGVTar.CellValidating += new DataGridViewCellValidatingEventHandler(this.DGVTar_CellValidating);
            Decorator.Instance().FormatStyle(base.Controls);
            this.InicializarToolTip();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            if (this.changeState)
            {
                if (FormMensaje.DecisionAdvertencia(RecursosUIMensajes.MsgTarifarioCloseAsk) == DialogResult.Yes)
                {
                    this.changeState = false;
                    this.CargarDatos();
                }
            }
            else
            {
                this.ModeEditar(this.changeState);
                this.CargarDatos();
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            this.ModeEditar(true);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BLTarifario tarifario = new BLTarifario();
                Tarifario tar = new Tarifario {
                    Año = this.tarifarios[this.IdTarifarioSelected].Año,
                    FechaRegistro = this.tarifarios[this.IdTarifarioSelected].FechaRegistro,
                    IdData = this.tarifarios[this.IdTarifarioSelected].IdData,
                    Vigente = this.CheckBoxTarifarioVigente.Checked
                };
                Dictionary<int, TarifarioDetalle> dictionary = new Dictionary<int, TarifarioDetalle>();
                NumberFormatInfo provider = new NumberFormatInfo {
                    NumberDecimalSeparator = "."
                };
                foreach (DataRow row in this.tablaDataTarifario.Rows)
                {
                    TarifarioDetalle detalle = new TarifarioDetalle {
                        IdData = (int) row[0]
                    };
                    detalle.IdPaquete = this.tarifarios[this.IdTarifarioSelected].Listado[detalle.IdData].IdPaquete;
                    detalle.IdTarifarioCab = this.tarifarios[this.IdTarifarioSelected].Listado[detalle.IdData].IdTarifarioCab;
                    double num = double.Parse(row[2].ToString(), provider);
                    detalle.Precio = num;
                    dictionary.Add(detalle.IdData, detalle);
                }
                tar.Listado = dictionary;
                tarifario.ActualizarTarifario(tar);
                this.changeState = false;
                this.CargarDatos();
                this.ModeEditar(true);
            }
            catch (DataException exception1)
            {
                FormMensaje.Error(exception1.Message);
            }
        }

        private void CargarDatos()
        {
            this.isLoading = true;
            try
            {
                BLTarifario tarifario = new BLTarifario();
                this.tarifarios = tarifario.ObtenerTarifarios();
                this.tablaDataTarifario.Clear();
                if (this.tarifarios.Count != 0)
                {
                    this.ComboBoxAno.DataSource = new BindingSource(tarifario.ObtenerListadoAno(this.tarifarios), null);
                    this.ComboBoxAno.DisplayMember = "Value";
                    this.ComboBoxAno.ValueMember = "Key";
                    this.HabilBoton(true);
                    this.ModeEditar(this.changeState);
                    this.CargarDatosEnDGVTar();
                }
                else
                {
                    this.CheckBoxTarifarioVigente.Visible = false;
                    this.DGVTar.Enabled = false;
                    this.ComboBoxAno.Enabled = false;
                    this.HabilBoton(false);
                }
                this.isLoading = false;
            }
            catch (DataException exception1)
            {
                FormMensaje.Error(exception1.Message);
                base.Close();
            }
        }

        private void CargarDatosEnDGVTar()
        {
            try
            {
                this.tablaDataTarifario.Clear();
                BLTarifario tarifario = new BLTarifario();
                this.IdTarifarioSelected = (int) this.ComboBoxAno.SelectedValue;
                this.CampRegistro.Text = this.tarifarios[this.IdTarifarioSelected].FechaRegistro.ToShortDateString();
                this.CheckBoxTarifarioVigente.Checked = this.tarifarios[this.IdTarifarioSelected].Vigente;
                foreach (TarifarioDetalle detalle in this.tarifarios[this.IdTarifarioSelected].Listado.Values)
                {
                    DataRow row = this.tablaDataTarifario.NewRow();
                    row[0] = detalle.IdData;
                    row[1] = tarifario.ObtenerAnalisis(detalle.IdPaquete).Nombre.ToUpper();
                    row[2] = detalle.Precio.ToString();
                    this.tablaDataTarifario.Rows.Add(row);
                }
            }
            catch (DataException exception1)
            {
                FormMensaje.Error(exception1.Message);
            }
        }

        private void ComboBoxAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.isLoading)
            {
                this.CargarDatosEnDGVTar();
            }
        }

        private void DGVTar_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (this.DGVTar.SelectedCells.Count > 0)
                {
                    this.valorPrecioSelectedTemp = this.DGVTar.Rows[e.RowIndex].Cells[2].Value.ToString();
                    this.changeState = true;
                }
            }
            catch (DataException exception1)
            {
                FormMensaje.Error(exception1.Message);
            }
        }

        private void DGVTar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!Regex.IsMatch(this.DGVTar.Rows[e.RowIndex].Cells[2].Value.ToString(), @"^[\d]+([.][\d])?$"))
            {
                this.DGVTar.Rows[e.RowIndex].Cells[2].Value = this.valorPrecioSelectedTemp;
            }
        }

        private void DGVTar_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (((e.ColumnIndex == 2) && this.DGVTar.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode) && !Regex.IsMatch(e.FormattedValue.ToString(), @"^[\d]+([.][\d])?$"))
            {
                FormMensaje.Advertencia(RecursosUIMensajes.MsgTarifarioEditError);
            }
        }

        private void DGVTar_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

       

        private void HabilBoton(bool valor)
        {
            this.BtnCerrar.Visible = valor;
            this.BtnTarifarioModificar.Visible = valor;
            this.BtnTarifarioSave.Visible = valor;
            this.CheckBoxTarifarioVigente.Enabled = valor;
        }

        private void InicializarTablaTarifario()
        {
            base.SuspendLayout();
            this.ModeEditar(false);
            this.tablaDataTarifario = new DataTable();
            this.tablaDataTarifario.Columns.Add("id", typeof(int));
            this.tablaDataTarifario.Columns.Add("nombre", typeof(string));
            this.tablaDataTarifario.Columns.Add("precio", typeof(string));
            this.DGVTar.Columns[0].DataPropertyName = "id";
            this.DGVTar.Columns[0].ReadOnly = true;
            this.DGVTar.Columns[1].DataPropertyName = "nombre";
            this.DGVTar.Columns[1].ReadOnly = true;
            this.DGVTar.Columns[2].DataPropertyName = "precio";
            this.DGVTar.Columns[2].ReadOnly = true;
            BindingSource source = new BindingSource();
            this.DGVTar.DataSource = source;
            source.DataSource = this.tablaDataTarifario;
            this.DGVTar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVTar.MultiSelect = false;
            base.ResumeLayout();
        }

        public void InicializarToolTip()
        {
            ToolTip tip1 = new ToolTip {
                ShowAlways = true
            };
            tip1.SetToolTip(this.CheckBoxTarifarioVigente, RecursosUIToolkit.CheckBoxTarifarioVigente);
            tip1.SetToolTip(this.BtnTarifarioModificar, RecursosUIToolkit.BtnTarifarioModificar);
            tip1.SetToolTip(this.BtnTarifarioSave, RecursosUIToolkit.BtnTarifarioSave);
        }

        
        private void ModeEditar(bool valor)
        {
            this.BtnTarifarioSave.Visible = valor;
            this.BtnCerrar.Visible = valor;
            this.BtnTarifarioModificar.Visible = !valor;
            if (valor)
            {
                this.CheckBoxTarifarioVigente.Visible = !this.CheckBoxTarifarioVigente.Checked;
            }
            else
            {
                this.CheckBoxTarifarioVigente.Visible = valor;
            }
            this.ComboBoxAno.Enabled = !valor;
            this.DGVTar.Columns[2].ReadOnly = !valor;
        }

        private void nuevoTarifarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTarifarioNuevo nuevo1 = new FormTarifarioNuevo();
            nuevo1.CargarDatos();
            nuevo1.MostarForm();
            this.CargarDatos();
        }

        private void transferirTarifarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTarifarioTransferencia transferencia1 = new FormTarifarioTransferencia {
                Tarifarios = this.tarifarios
            };
            transferencia1.CargarDatos();
            transferencia1.MostarForm();
            this.CargarDatos();
        }
    }
}
