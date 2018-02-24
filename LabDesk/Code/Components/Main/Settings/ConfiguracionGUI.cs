using LabDesk.Code.Base;
using LabDesk.Code.ControlSistemaInterno.GestorSonido;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace LabDesk.Code.Components.Main.Settings
{
    public partial class ConfiguracionGUI : Form
    {
        private Dictionary<VistaConfig, ButtonUI> botones = new Dictionary<VistaConfig, ButtonUI>();

        public CheckBox CheckBoxSoundEnabled;
        public CheckBox CheckBoxSoundMouse;
        public CheckBox CheckBoxSoundSesion;

        private VistaConfig VistaActual;

        public ConfiguracionGUI()
        {
            this.InitializeComponent();
            this.IniciarInterfaz();
        }

        private void CheckBoxSoundEnabled_CheckedChanged(object sender, EventArgs e)
        {
            this.SonidoOpciones.Enabled = this.CheckBoxSoundEnabled.Checked;
        }

        private void ComponenteUI_Click(object sender, EventArgs e)
        {
            this.MostrarVista(VistaConfig.General);
            ReproductorSonido.Instance().RequestPlaySound(ReproductorSonido.TipoSonido.ClickBtnUI);
        }

        private void ComponenteUI_Click1(object sender, EventArgs e)
        {
            this.MostrarVista(VistaConfig.Sonido);
            ReproductorSonido.Instance().RequestPlaySound(ReproductorSonido.TipoSonido.ClickBtnUI);
        }

        private void ComponenteUI_Click2(object sender, EventArgs e)
        {
            this.MostrarVista(VistaConfig.Accesibilidad);
            ReproductorSonido.Instance().RequestPlaySound(ReproductorSonido.TipoSonido.ClickBtnUI);
        }

        private void ComponenteUI_Click3(object sender, EventArgs e)
        {
            this.LlenarDatosDefault(this.VistaActual);
            ReproductorSonido.Instance().InitVolume();
        }

        private void ComponenteUI_Click4(object sender, EventArgs e)
        {
            ReproductorSonido.Instance().InitVolume();
            base.Close();
        }

        private void ComponenteUI_Click5(object sender, EventArgs e)
        {
            this.RecolectarDatos(this.VistaActual);
            LogicaControlSistema.FormPrincipal.ActualizarVista();
            base.Close();
        }

   
        public void IniciarInterfaz()
        {
            this.ComboApariencia.DataSource = new BindingSource(ConfiguracionSystem.Estilos, null);
            this.ComboApariencia.DisplayMember = "Value";
            this.ComboApariencia.ValueMember = "Key";
            //this.BtnUIConfig1.ComponenteUI.Image = Resources.icon_pantalla;
            //this.BtnUIConfig2.ComponenteUI.Image = Resources.icon_volumen;
            //this.BtnUIConfig3.ComponenteUI.Image = Resources.icon_ojo;
            this.BtnUIConfig1.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click);
            this.BtnUIConfig2.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click1);
            this.BtnUIConfig3.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click2);
            this.BtnUIConfig4.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click3);
            this.BtnUIConfig5.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click4);
            this.BtnUIConfig6.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click5);
            this.botones.Add(VistaConfig.General, this.BtnUIConfig1);
            this.botones.Add(VistaConfig.Sonido, this.BtnUIConfig2);
            this.botones.Add(VistaConfig.Accesibilidad, this.BtnUIConfig3);
            this.BtnUIConfig1.Tipo = ButtonUI.ButtonTipo.ItemLight;
            this.BtnUIConfig2.Tipo = ButtonUI.ButtonTipo.ItemLight;
            this.BtnUIConfig3.Tipo = ButtonUI.ButtonTipo.ItemLight;
            this.BtnUIConfig4.Tipo = ButtonUI.ButtonTipo.Next;
            this.BtnUIConfig5.Tipo = ButtonUI.ButtonTipo.Cancel;
            this.BtnUIConfig6.Tipo = ButtonUI.ButtonTipo.Ok;
            base.SuspendLayout();
            Decorator.Instance().FormatStyle(base.Controls);
            this.PanelGeneral.Visible = false;
            this.PanelAccesibilidad.Visible = false;
            this.PanelSonido.Visible = false;
            this.VistaActual = VistaConfig.NoDefinido;
            this.MostrarVista(VistaConfig.General);
            base.ResumeLayout();
        }

       
        public void LlenarDatos(VistaConfig vista)
        {
            switch (this.VistaActual)
            {
                case VistaConfig.General:
                    this.ComboApariencia.SelectedValue = ConfiguracionSystem.Style;
                    return;

                case VistaConfig.Sonido:
                    this.CheckBoxSoundMouse.Checked = ConfiguracionSystem.SoundMouseEnabled;
                    this.CheckBoxSoundSesion.Checked = ConfiguracionSystem.SoundSesionEnabled;
                    this.TrackBarSound.Value = ConfiguracionSystem.Volumen;
                    this.LabelVol.Text = ConfiguracionSystem.Volumen + " %";
                    this.CheckBoxSoundEnabled.Checked = ConfiguracionSystem.SoundEnabled;
                    return;

                case VistaConfig.Accesibilidad:
                    this.CheckBoxDaltonic.Checked = ConfiguracionSystem.Daltonic;
                    return;
            }
        }

        public void LlenarDatosDefault(VistaConfig vista)
        {
            switch (this.VistaActual)
            {
                case VistaConfig.General:
                    ConfiguracionSystem.ResetDefaultGeneral();
                    return;

                case VistaConfig.Sonido:
                    ConfiguracionSystem.ResetDefaultSonido();
                    return;

                case VistaConfig.Accesibilidad:
                    ConfiguracionSystem.ResetDefaultAccesibilidad();
                    return;
            }
        }

        private void MostrarVista(VistaConfig vista)
        {
            if (this.VistaActual != vista)
            {
                if (VistaConfig.NoDefinido != this.VistaActual)
                {
                    this.PanelActual.Visible = false;
                    this.setBotonColorOriginal(this.botones[this.VistaActual]);
                }
                this.VistaActual = vista;
                switch (this.VistaActual)
                {
                    case VistaConfig.General:
                        this.PanelActual = this.PanelGeneral;
                        break;

                    case VistaConfig.Sonido:
                        this.PanelActual = this.PanelSonido;
                        break;

                    case VistaConfig.Accesibilidad:
                        this.PanelActual = this.PanelAccesibilidad;
                        break;
                }
                this.setBotonColorSelect(this.botones[this.VistaActual]);
                this.LlenarDatos(this.VistaActual);
                this.PanelActual.Location = new Point(0x16, 12);
                this.PanelActual.Visible = true;
            }
        }

        public void RecolectarDatos(VistaConfig vista)
        {
            switch (this.VistaActual)
            {
                case VistaConfig.General:
                    ConfiguracionSystem.Style = (int) this.ComboApariencia.SelectedValue;
                    return;

                case VistaConfig.Sonido:
                    ConfiguracionSystem.SoundMouseEnabled = this.CheckBoxSoundMouse.Checked;
                    ConfiguracionSystem.SoundSesionEnabled = this.CheckBoxSoundSesion.Checked;
                    ConfiguracionSystem.Volumen = this.TrackBarSound.Value;
                    ConfiguracionSystem.SoundEnabled = this.CheckBoxSoundEnabled.Checked;
                    return;

                case VistaConfig.Accesibilidad:
                    ConfiguracionSystem.Daltonic = this.CheckBoxDaltonic.Checked;
                    return;
            }
        }

        public void setBotonColorOriginal(ButtonUI boton)
        {
            boton.ComponenteUI.BackColor = Decorator.Instance().ActualStyle.ButtonItemLight.BackGroundBack;
            boton.ComponenteUI.FlatAppearance.BorderColor = Decorator.Instance().ActualStyle.ButtonItemLight.BordeColor;
            boton.ComponenteUI.FlatAppearance.MouseOverBackColor = Decorator.Instance().ActualStyle.ButtonItemLight.BackGroundOver;
            boton.ComponenteUI.FlatAppearance.MouseDownBackColor = Decorator.Instance().ActualStyle.ButtonItemLight.BackGroundDown;
        }

        public void setBotonColorSelect(ButtonUI boton)
        {
            boton.ComponenteUI.BackColor = Decorator.Instance().ActualStyle.ButtonItemLight.BackGroundSelect;
            boton.ComponenteUI.FlatAppearance.BorderColor = Decorator.Instance().ActualStyle.ButtonItemLight.BordeColor;
            boton.ComponenteUI.FlatAppearance.MouseDownBackColor = Decorator.Instance().ActualStyle.ButtonItemLight.BackGroundSelect;
            boton.ComponenteUI.FlatAppearance.MouseOverBackColor = Decorator.Instance().ActualStyle.ButtonItemLight.BackGroundSelect;
        }

        private void TrackBarSound_Scroll(object sender, EventArgs e)
        {
            ReproductorSonido.Instance().TestSound(this.TrackBarSound.Value);
            this.LabelVol.Text = this.TrackBarSound.Value + " %";
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

        public enum VistaConfig
        {
            General,
            Sonido,
            Accesibilidad,
            NoDefinido
        }
    }
}
