using LabDesk.Code.Base;
using LabDesk.Code.PresentationLayer.ComponenteGeneral;
using LabDesk.Code.PresentationLayer.GUISistema;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;


namespace LabDesk.Code.Components.Main.Panels
{


    public partial class ControlContabilidad : UserControl
    {
      

        public ControlContabilidad()
        {
            this.InitializeComponent();
            base.SizeChanged += new EventHandler(this.ControlContabilidad_SizeChanged);
            this.ComboBoxTipo.DataSource = new BindingSource(DataEstaticaGeneral.ReporteTipos, null);
            this.ComboBoxTipo.DisplayMember = "Value";
            this.ComboBoxTipo.ValueMember = "Key";
            this.ComboBoxMes.DataSource = new BindingSource(DataEstaticaGeneral.Meses, null);
            this.ComboBoxMes.DisplayMember = "Value";
            this.ComboBoxMes.ValueMember = "Key";
            this.BtnUIContabilidad1.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click);
            this.BtnUIContabilidad1.Tipo = ButtonUI.ButtonTipo.Ok;
            this.ComboBoxTipo.SelectionChangeCommitted += new EventHandler(this.ComboBoxTipo_SelectionChangeCommitted);
            this.ComboBoxTipo.SelectedValue = 0;
            this.ComboBoxMes.SelectedValue = 0;
            switch (((int) this.ComboBoxTipo.SelectedValue))
            {
                case 0:
                    this.ComboBoxFiltro.DataSource = new BindingSource(DataEstaticaGeneral.ReporteFiltrosEconomico, null);
                    this.ComboBoxFiltro.DisplayMember = "Value";
                    this.ComboBoxFiltro.ValueMember = "Key";
                    this.LabelDescEconomico.Visible = true;
                    this.LabelDescResultado.Visible = false;
                    break;

                case 1:
                    this.ComboBoxFiltro.DataSource = new BindingSource(DataEstaticaGeneral.ReporteFiltrosResultado, null);
                    this.ComboBoxFiltro.DisplayMember = "Value";
                    this.ComboBoxFiltro.ValueMember = "Key";
                    this.LabelDescEconomico.Visible = false;
                    this.LabelDescResultado.Visible = true;
                    break;
            }
            this.ComboBoxFiltro.SelectedValue = 0;
            Decorator.Instance().FormatStyle(base.Controls);
        }

        private void ComboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ComboBoxTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (((int) this.ComboBoxTipo.SelectedValue))
            {
                case 0:
                    this.ComboBoxFiltro.DataSource = new BindingSource(DataEstaticaGeneral.ReporteFiltrosEconomico, null);
                    this.ComboBoxFiltro.DisplayMember = "Value";
                    this.ComboBoxFiltro.ValueMember = "Key";
                    this.LabelDescEconomico.Visible = true;
                    this.LabelDescResultado.Visible = false;
                    break;

                case 1:
                    this.ComboBoxFiltro.DataSource = new BindingSource(DataEstaticaGeneral.ReporteFiltrosResultado, null);
                    this.ComboBoxFiltro.DisplayMember = "Value";
                    this.ComboBoxFiltro.ValueMember = "Key";
                    this.LabelDescEconomico.Visible = false;
                    this.LabelDescResultado.Visible = true;
                    break;
            }
            this.ComboBoxFiltro.SelectedValue = 0;
        }

        private void ComponenteUI_Click(object sender, EventArgs e)
        {
            try
            {
                Thread hilo = null;
                this.DialogFolderBuscar.SelectedPath = null;
                this.DialogFolderBuscar.ShowDialog();
                hilo = new Thread(new ThreadStart(this.GenerarDocumento));
                hilo.Start();
                while (!hilo.IsAlive)
                {
                }
                FormCargando cargando1 = new FormCargando(2, hilo);
                cargando1.ShowDialog();
                cargando1.Dispose();
                FormMensaje.Confirmacion(RecursosUIMensajes.MsgReporteOk);
            }
            catch (Exception exception)
            {
                FormMensaje.Error(RecursosUIMensajes.MsgNone + exception.Message);
            }
        }

        private void ControlContabilidad_Load(object sender, EventArgs e)
        {
        }

        private void ControlContabilidad_SizeChanged(object sender, EventArgs e)
        {
            this.PanelLateral.Location = new Point(base.Size.Width - this.PanelLateral.Size.Width, 0);
            this.BtnUIContabilidad1.Location = new Point(base.Size.Width - ((this.BtnUIContabilidad1.Width + this.PanelLateral.Size.Width) + Decorator.EspacioBorde), base.Height - (this.BtnUIContabilidad1.Height + Decorator.EspacioBorde));
            this.LabelDescEconomico.Width = base.Size.Width - (this.PanelLateral.Size.Width + Decorator.EspacioBorde);
            this.LabelDescEconomico.Height = base.Size.Height - (Decorator.EspacioTitulo + Decorator.EspacioBorde);
            this.LabelDescResultado.Width = base.Size.Width - (this.PanelLateral.Size.Width + Decorator.EspacioBorde);
            this.LabelDescResultado.Height = base.Size.Height - (Decorator.EspacioTitulo + Decorator.EspacioBorde);
        }

       

        private void GenerarDocumento()
        {
            BLReporte reporte = new BLReporte();
            switch (((int) this.ComboBoxTipo.SelectedValue))
            {
                case 0:
                    reporte.GenerarReporteEconomico((BLReporte.FiltroReporteEconomico) this.ComboBoxFiltro.SelectedValue, (int) this.NumericUD.Value, ((int) this.ComboBoxMes.SelectedValue) + 1, this.DialogFolderBuscar.SelectedPath);
                    return;

                case 1:
                    reporte.GenerarReporteResultados((BLReporte.FiltroReporteResultados) this.ComboBoxFiltro.SelectedValue, (int) this.NumericUD.Value, ((int) this.ComboBoxMes.SelectedValue) + 1, this.DialogFolderBuscar.SelectedPath);
                    break;
            }
        }

        
        private void LinkLabelTarifario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FormTarifario().ShowDialog();
        }
    }
}
