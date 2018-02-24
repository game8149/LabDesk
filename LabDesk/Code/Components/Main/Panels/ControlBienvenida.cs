using LabDesk.Code.ControlSistemaInterno.GestorSonido;
using LabDesk.Code.PresentationLayer.Controles.ComponentesBienvenida;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;


namespace LabDesk.Code.Components.Main.Panels
{

    public partial class ControlBienvenida : UserControl
    {

        public ControlBienvenida()
        {
            this.InitializeComponent();
            base.SizeChanged += new EventHandler(this.ControlBienvenida_SizeChanged);
        }

        private void ActualizarVistaCuenta()
        {
            Cuenta cuentaLogin = new LogicaControlSistema().GetCuentaLogin();
            string[] textArray1 = new string[] { cuentaLogin.Nombre, " ", cuentaLogin.PrimerApellido, " ", cuentaLogin.SegundoApellido };
            this.CampNombre.Text = string.Concat(textArray1);
            this.CampNivel.Text = cuentaLogin.Nivel.ToString();
        }

        private void ControlBienvenida_Load(object sender, EventArgs e)
        {
            this.ActualizarVistaCuenta();
        }

        private void ControlBienvenida_SizeChanged(object sender, EventArgs e)
        {
            this.PanelLateral.Location = new Point(base.Size.Width - this.PanelLateral.Size.Width, 0);
            this.ImagenBienvenida.Location = new Point(base.Size.Width - ((this.ImagenBienvenida.Width + this.PanelLateral.Size.Width) + Decorator.EspacioBorde), Decorator.EspacioTitulo);
            this.ImagenBienvenida.Height = base.Size.Height - (Decorator.EspacioTitulo + Decorator.EspacioBorde);
            this.TextoBienvenida.Width = base.Size.Width - ((this.PanelLateral.Size.Width + this.ImagenBienvenida.Width) + (2 * Decorator.EspacioBorde));
            this.TextoBienvenida.Height = base.Size.Height - (Decorator.EspacioTitulo + Decorator.EspacioBorde);
            this.LinkCerrarSesion.Location = new Point(this.LinkCerrarSesion.Location.X, this.PanelLateral.Height - (this.LinkCerrarSesion.Height + Decorator.EspacioBorde));
        }

  
       
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LogicaControlSistema sistema = new LogicaControlSistema();
            new FormModificarCuenta { Cuenta = sistema.GetCuentaLogin() }.ShowDialog();
            this.ActualizarVistaCuenta();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LogicaControlSistema sistema = new LogicaControlSistema();
            new FormModificarClave { Cuenta = sistema.GetCuentaLogin() }.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\Docs\Manual.pdf");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Reinstale el Programa: " + exception.Message, "Advertencia");
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ReproductorSonido.Instance().RequestPlaySound(ReproductorSonido.TipoSonido.FinalSesion);
            LogicaControlSistema.FormPrincipal.FinalizarSesion();
        }
    }
}
