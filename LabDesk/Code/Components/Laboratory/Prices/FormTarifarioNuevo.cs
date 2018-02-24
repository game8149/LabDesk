using LabDesk.Code.PresentationLayer.ComponenteGeneral;
using System;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Laboratory.Prices
{
    public partial class FormTarifarioNuevo : Form
    {

        public FormTarifarioNuevo()
        {
            this.InitializeComponent();
            this.CargarDatos();
            this.BtnUITarifarioNuevo1.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click);
            this.BtnUITarifarioNuevo1.Tipo = ButtonUI.ButtonTipo.Ok;
            Decorator.Instance().FormatStyle(base.Controls);
        }

        public void CargarDatos()
        {
            BLTarifario tarifario = new BLTarifario();
            this.OK = tarifario.ObtenerListadoAnalisis().Count > 0;
            this.NumericUDAño.Enabled = this.OK;
        }

        private void ComponenteUI_Click(object sender, EventArgs e)
        {
            try
            {
                if (new BLTarifario().CrearTarifario((int) this.NumericUDAño.Value, this.CheckBoxVigente.Checked))
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
                FormMensaje.Error(RecursosUIMensajes.MsgAnalisisError);
                base.Dispose();
            }
        }

        public bool OK { get; set; }
    }
}
