using LabDesk.Code.Base;
using LabDesk.Code.ControlSistemaInterno.GestorSonido;
using LabDesk.Code.PresentationLayer.ComponenteGeneral;
using LabDesk.Code.PresentationLayer.Controles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main
{
    public partial class Principal : Form
    {


        private static UserControl ControlActual;
        private FormAcerca formaAcerca = new FormAcerca();
        private Timer Temporizador;
        private Vista VistaActual;
        public bool ModeExit;
        private bool modeLogout;
        private Dictionary<Vista, ButtonUI> botones = new Dictionary<Vista, ButtonUI>();
     

        public Principal()
        {
            this.InitializeComponent();
            base.FormClosing += new FormClosingEventHandler(this.Principal_FormClosing);
            this.DoubleBuffered = true;
            this.IniciarInterfaz();
            base.KeyPress += new KeyPressEventHandler(this.Principal_KeyPress);
            base.Focus();
        }

        public void ActualizarControlCabecera()
        {
            this.panelUIControl1.ComponenteUIText.Text = LogicaControlSistema.CadenaNavegacion;
        }

        public void ActualizarVista()
        {
            Decorator.Instance().FormatStyle(base.Controls);
            this.setBotonColorSelect(this.botones[this.VistaActual]);
        }

        public PanelUIControl CabeceraUI() =>
            this.panelUIControl1;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ReproductorSonido.Instance().RequestPlaySound(ReproductorSonido.TipoSonido.ClickBtnUI);
            if (this.CheckBoxMenu.Checked)
            {
                SliderPanel.Instance().SlidePanel(this.PanelOpcion, 0xa6, SliderPanel.TypeSlide.Left);
            }
            else
            {
                SliderPanel.Instance().SlidePanel(this.PanelOpcion, 0x37, SliderPanel.TypeSlide.Left);
            }
        }

        private void ComponenteUI_Click(object sender, EventArgs e)
        {
            ReproductorSonido.Instance().RequestPlaySound(ReproductorSonido.TipoSonido.ClickBtnUI);
            this.MostrarVista(Vista.Inicio);
        }

        private void ComponenteUI_Click1(object sender, EventArgs e)
        {
            ReproductorSonido.Instance().RequestPlaySound(ReproductorSonido.TipoSonido.ClickBtnUI);
            this.MostrarVista(Vista.Paciente);
        }

        private void ComponenteUI_Click2(object sender, EventArgs e)
        {
            ReproductorSonido.Instance().RequestPlaySound(ReproductorSonido.TipoSonido.ClickBtnUI);
            this.MostrarVista(Vista.Medico);
        }

        private void ComponenteUI_Click3(object sender, EventArgs e)
        {
            ReproductorSonido.Instance().RequestPlaySound(ReproductorSonido.TipoSonido.ClickBtnUI);
            this.MostrarVista(Vista.Orden);
        }

        private void ComponenteUI_Click4(object sender, EventArgs e)
        {
            ReproductorSonido.Instance().RequestPlaySound(ReproductorSonido.TipoSonido.ClickBtnUI);
            this.MostrarVista(Vista.Examen);
        }

        private void ComponenteUI_Click5(object sender, EventArgs e)
        {
            ReproductorSonido.Instance().RequestPlaySound(ReproductorSonido.TipoSonido.ClickBtnUI);
            this.MostrarVista(Vista.Reporte);
        }

        private void ComponenteUI_Click6(object sender, EventArgs e)
        {
            ReproductorSonido.Instance().RequestPlaySound(ReproductorSonido.TipoSonido.ClickBtnUI);
            new ConfiguracionGUI().ShowDialog();
        }

        private void ComponenteUI_Click7(object sender, EventArgs e)
        {
            ReproductorSonido.Instance().RequestPlaySound(ReproductorSonido.TipoSonido.ClickBtnUI);
            this.formaAcerca.ShowDialog();
        }
        
        public void FinalizarSesion()
        {
            this.modeLogout = true;
            base.Close();
        }

        public void InicializarToolTip()
        {
            ToolTip tip1 = new ToolTip
            {
                ShowAlways = true
            };
            tip1.SetToolTip(this.BtnUIMain1.ComponenteUI, RecursosUI.BtnUIMain1);
            tip1.SetToolTip(this.BtnUIMain2.ComponenteUI, RecursosUI.BtnUIMain2);
            tip1.SetToolTip(this.BtnUIMain3.ComponenteUI, RecursosUI.BtnUIMain3);
            tip1.SetToolTip(this.BtnUIMain4.ComponenteUI, RecursosUI.BtnUIMain4);
            tip1.SetToolTip(this.BtnUIMain5.ComponenteUI, RecursosUI.BtnUIMain5);
            tip1.SetToolTip(this.BtnUIMain6.ComponenteUI, RecursosUI.BtnUIMain6);
            tip1.SetToolTip(this.BtnUIMain7.ComponenteUI, RecursosUI.BtnUIMain7);
            tip1.SetToolTip(this.BtnUIMain8.ComponenteUI, RecursosUI.BtnUIMain8);
        }

        public void IniciarInterfaz()
        {
            this.botones.Add(Vista.Inicio, this.BtnUIMain1);
            this.botones.Add(Vista.Paciente, this.BtnUIMain2);
            this.botones.Add(Vista.Medico, this.BtnUIMain3);
            this.botones.Add(Vista.Orden, this.BtnUIMain4);
            this.botones.Add(Vista.Examen, this.BtnUIMain5);
            this.botones.Add(Vista.Reporte, this.BtnUIMain6);
            //this.BtnUIMain1.ComponenteUI.Image = Resources.icon_usuario;
            //this.BtnUIMain2.ComponenteUI.Image = Resources.icon_paciente;
            //this.BtnUIMain3.ComponenteUI.Image = Resources.icon_nurse;
            //this.BtnUIMain4.ComponenteUI.Image = Resources.icon_orden;
            //this.BtnUIMain5.ComponenteUI.Image = Resources.icon_examen;
            //this.BtnUIMain6.ComponenteUI.Image = Resources.icon_report;
            //this.BtnUIMain7.ComponenteUI.Image = Resources.icon_configuracion;
            //this.BtnUIMain8.ComponenteUI.Image = Resources.icon_acerca;
            this.BtnUIMain1.Tipo = ButtonUI.ButtonTipo.ItemLow;
            this.BtnUIMain2.Tipo = ButtonUI.ButtonTipo.ItemLow;
            this.BtnUIMain3.Tipo = ButtonUI.ButtonTipo.ItemLow;
            this.BtnUIMain4.Tipo = ButtonUI.ButtonTipo.ItemLow;
            this.BtnUIMain5.Tipo = ButtonUI.ButtonTipo.ItemLow;
            this.BtnUIMain6.Tipo = ButtonUI.ButtonTipo.ItemLow;
            this.BtnUIMain7.Tipo = ButtonUI.ButtonTipo.ItemLow;
            this.BtnUIMain8.Tipo = ButtonUI.ButtonTipo.ItemLow;
            base.SuspendLayout();
            Decorator.Instance().FormatStyle(base.Controls);
            base.ResumeLayout();
            this.VistaActual = Vista.NoDefinido;
            this.MostrarVista(Vista.Inicio);
            this.BtnUIMain1.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click);
            this.BtnUIMain2.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click1);
            this.BtnUIMain3.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click2);
            this.BtnUIMain4.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click3);
            this.BtnUIMain5.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click4);
            this.BtnUIMain6.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click5);
            this.BtnUIMain7.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click6);
            this.BtnUIMain8.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click7);
            this.RelocalizarUI();
            this.InicializarToolTip();
            base.Show();
        }

      
        private void MostrarVista(Vista vista)
        {
            if (this.VistaActual != vista)
            {
                if (Vista.NoDefinido != this.VistaActual)
                {
                    this.setBotonColorOriginal(this.botones[this.VistaActual]);
                    this.PanelPrincipal.Controls.Remove(ControlActual);
                    ControlActual.Dispose();
                }
                this.VistaActual = vista;
                switch (this.VistaActual)
                {
                    case Vista.Inicio:
                        ControlActual = new ControlBienvenida();
                        break;

                    case Vista.Paciente:
                        ControlActual = new ControlPaciente();
                        break;

                    case Vista.Medico:
                        ControlActual = new ControlMedico();
                        break;

                    case Vista.Orden:
                        ControlActual = new ControlOrden();
                        break;

                    case Vista.Examen:
                        ControlActual = new ControlExamen();
                        break;

                    case Vista.Reporte:
                        ControlActual = new ControlContabilidad();
                        break;
                }
                LogicaControlSistema.ReiniciarNavegacion();
                LogicaControlSistema.AumentarNivel(RecursosUI.ResourceManager.GetString(ControlActual.Name, RecursosUI.Culture));
                this.ActualizarControlCabecera();
                ControlActual.Dock = DockStyle.Fill;
                this.PanelPrincipal.Controls.Add(ControlActual);
                Decorator.Instance().FormatStyle(ControlActual.Controls);
                this.setBotonColorSelect(this.botones[this.VistaActual]);
            }
        }

        private void panelPrincipal_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.modeLogout)
            {
                if (FormMensaje.DecisionAdvertencia(RecursosUIMensajes.MsgPrincipalClose) == DialogResult.Yes)
                {
                    ReproductorSonido.Instance().RequestPlaySound(ReproductorSonido.TipoSonido.FinalSesion);
                    this.ModeExit = true;
                    e.Cancel = false;
                }
                else
                {
                    this.ModeExit = false;
                    e.Cancel = true;
                }
            }
        }

        private void Principal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x001b')
            {
                e.Handled = true;
            }
        }

        private void RelocalizarUI()
        {
            base.SuspendLayout();
            this.PanelOpcion.Location = new Point(0, 0);
            this.PanelOpcion.Height = base.Height;
            base.ResumeLayout();
        }

        public void setBotonColorOriginal(ButtonUI boton)
        {
            boton.ComponenteUI.BackColor = Decorator.Instance().ActualStyle.ButtonItemLow.BackGroundBack;
            boton.ComponenteUI.FlatAppearance.BorderColor = Decorator.Instance().ActualStyle.ButtonItemLow.BordeColor;
            boton.ComponenteUI.FlatAppearance.MouseOverBackColor = Decorator.Instance().ActualStyle.ButtonItemLow.BackGroundOver;
            boton.ComponenteUI.FlatAppearance.MouseDownBackColor = Decorator.Instance().ActualStyle.ButtonItemLow.BackGroundDown;
        }

        public void setBotonColorSelect(ButtonUI boton)
        {
            boton.ComponenteUI.BackColor = Decorator.Instance().ActualStyle.ButtonDefault.BackGroundBack;
            boton.ComponenteUI.FlatAppearance.BorderColor = Decorator.Instance().ActualStyle.ButtonItemLow.BordeColor;
            boton.ComponenteUI.FlatAppearance.MouseDownBackColor = Decorator.Instance().ActualStyle.ButtonDefault.BackGroundBack;
            boton.ComponenteUI.FlatAppearance.MouseOverBackColor = Decorator.Instance().ActualStyle.ButtonDefault.BackGroundBack;
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

        public enum Vista
        {
            Inicio,
            Paciente,
            Medico,
            Orden,
            Examen,
            Reporte,
            NoDefinido
        }
    }
}
