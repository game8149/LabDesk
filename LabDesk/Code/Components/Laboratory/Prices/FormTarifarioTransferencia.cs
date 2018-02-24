using LabDesk.Code.PresentationLayer.ComponenteGeneral;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Laboratory.Prices
{
    public partial  class FormTarifarioTransferencia : Form
    {
     
        public FormTarifarioTransferencia()
        {
            this.InitializeComponent();
            base.SuspendLayout();
            this.BtnUITarifarioTransferencia1.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click);
            this.BtnUITarifarioTransferencia1.Tipo = ButtonUI.ButtonTipo.Ok;
            Decorator.Instance().FormatStyle(base.Controls);
            base.ResumeLayout();
        }

        public void CargarDatos()
        {
            BLTarifario tarifario = new BLTarifario();
            this.OK = (tarifario.ObtenerListadoAnalisis().Count > 0) && (this.Tarifarios.Count > 0);
            if (this.OK)
            {
                this.ComboBoxAno.DataSource = new BindingSource(tarifario.ObtenerListadoAno(this.Tarifarios), null);
                this.ComboBoxAno.DisplayMember = "Value";
                this.ComboBoxAno.ValueMember = "Key";
            }
        }

        private void ComponenteUI_Click(object sender, EventArgs e)
        {
            try
            {
                if (new BLTarifario().CopiarTarifario(this.Tarifarios[(int) this.ComboBoxAno.SelectedValue], (int) this.NumericUDAño.Value, this.CheckBoxVigente.Checked))
                {
                    base.Close();
                }
            }
            catch (Exception exception1)
            {
                FormMensaje.Advertencia(exception1.Message);
            }
        }

  

        public void MostarForm()
        {
            if (this.OK)
            {
                base.ShowDialog();
            }
            else
            {
                FormMensaje.Advertencia(RecursosUIMensajes.MsgTarifarioCopyError);
                base.Dispose();
            }
        }

        private bool OK { get; set; }

        public Dictionary<int, Tarifario> Tarifarios { get; set; }
    }
}
