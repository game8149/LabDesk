using Entity.Code.Hospital;
using LabDesk.Code.Base;
using LabDesk.Code.Forms;
using LabDesk.Code.PresentationLayer.ComponenteGeneral;
using LabDesk.Code.StyleManager;
using MinLab.Code.LogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LabDesk.Code.PresentationLayer.Controles.ComponentesMedico
{
    public partial class FormMedicoBuscar : Form
    {
        private BindingSource bindingSource;
       
        private DataTable tabla;
        private Dictionary<int, Medic> diccionario;

        public FormMedicoBuscar()
        {
            this.InitializeComponent();
            this.InicializarTablaOrdenDetalle();
            this.BtnUIMedicoBuscar1.Tipo = ButtonUI.ButtonTipo.Ok;
            this.BtnUIMedicoBuscar2.Tipo = ButtonUI.ButtonTipo.Ok;
            this.BtnUIMedicoBuscar1.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click);
            this.BtnUIMedicoBuscar2.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click1);
            base.FormClosing += new FormClosingEventHandler(this.FormBuscarMedico_FormClosing);
            base.SuspendLayout();
            Decorator.Instance().FormatStyle(base.Controls);
            base.ResumeLayout();
        }

        private void ComponenteUI_Click(object sender, EventArgs e)
        {
            try
            {
                BLMedico medico = new BLMedico();
                this.tabla.Clear();
                this.diccionario = medico.ObtenerMedico(this.CampNombre.Text, this.Campapellido1erno.Text, this.Campapellido2erno.Text, this.CheckBoxHabil.Checked);
                base.SuspendLayout();
                if (this.diccionario.Count > 0)
                {
                    foreach (int num in this.diccionario.Keys)
                    {
                        Medic medico2 = this.diccionario[num];
                        DataRow row = this.tabla.NewRow();
                        row[0] = medico2.Id;
                        row[1] = medico2.CodigoColegiatura;
                        row[2] = FormatString.FormatName(medico2);
                        row[3] = medico2.IdEspecialidad;
                        this.tabla.Rows.Add(row);
                    }
                    base.ResumeLayout(false);
                }
                else
                {
                    FormMensaje.Advertencia(RecursosUIMensajes.MsgMedicoNoEncontrados);
                }
            }
            catch (Exception exception)
            {
                FormMensaje.Error(RecursosUIMensajes.MsgNone + exception.Message);
            }
        }

        private void ComponenteUI_Click1(object sender, EventArgs e)
        {
            if (this.DGVMedico.SelectedRows.Count > 0)
            {
                int num = Convert.ToInt32(this.DGVMedico.SelectedRows[0].Cells[0].Value);
                this.Perfil = this.diccionario[num];
                base.Visible = false;
            }
            else
            {
                FormMensaje.Advertencia(RecursosUIMensajes.MsgMedicoNoSeleccionado);
            }
        }

       
        private void FormBuscarMedico_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            base.Visible = false;
        }

        private void InicializarTablaOrdenDetalle()
        {
            this.bindingSource = new BindingSource();
            this.DGVMedico.DataSource = this.bindingSource;
            this.tabla = new DataTable("Examenes");
            this.tabla.Columns.Add("Id", typeof(int));
            this.tabla.Columns.Add("Colegiatura", typeof(string));
            this.tabla.Columns.Add("Nombre", typeof(string));
            this.tabla.Columns.Add("Especialidad", typeof(string));
            this.DGVMedico.Columns[0].Visible = false;
            this.DGVMedico.Columns[0].ReadOnly = true;
            this.DGVMedico.Columns[0].DataPropertyName = "Id";
            this.DGVMedico.Columns[1].ReadOnly = true;
            this.DGVMedico.Columns[1].Resizable = DataGridViewTriState.False;
            this.DGVMedico.Columns[1].DataPropertyName = "Colegiatura";
            this.DGVMedico.Columns[2].ReadOnly = true;
            this.DGVMedico.Columns[2].Resizable = DataGridViewTriState.False;
            this.DGVMedico.Columns[2].DataPropertyName = "Nombre";
            this.DGVMedico.Columns[3].ReadOnly = true;
            this.DGVMedico.Columns[3].Resizable = DataGridViewTriState.False;
            this.DGVMedico.Columns[3].DataPropertyName = "Especialidad";
            this.bindingSource.DataSource = this.tabla;
            this.DGVMedico.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        
        public Medic Perfil { get; set; }
    }
}
