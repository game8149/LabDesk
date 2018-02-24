using EntityLab.Code.Hospital;
using LabDesk.Code.Components.Actors.Paciente;
using LabDesk.Code.Forms;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main.Panels
{
    public partial class ControlPaciente : UserControl
    {
        private UserControl ControlActual;
        
        public ControlPaciente()
        {
            this.InitializeComponent();
            this.ModeBtnFuncion(true);
            this.InicializarToolTip();
        }


        public void InicializarToolTip()
        {
            ToolTip tip1 = new ToolTip
            {
                ShowAlways = true
            };
            tip1.SetToolTip(this.LinkAbrirPerfil, RecursosUIToolkit.BtnPerfilAbrir);
            tip1.SetToolTip(this.LinkNuevoPerfil, RecursosUIToolkit.BtnPerfilNuevo);
        }


        private void LinkAbrirPerfil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Paciente perfil = null;
            FormBuscarPaciente paciente1 = new FormBuscarPaciente();
            paciente1.ShowDialog();
            perfil = paciente1.Perfil;
            if (perfil != null)
            {
                this.ControlActual = new PanelPacientePerfil();
                this.ControlActual.Dock = DockStyle.Fill;
                this.ControlActual.Parent = this;
                ((PanelPacientePerfil)this.ControlActual).Perfil = perfil;
                this.ModeBtnFuncion(false);
                this.PanelTrabajo.Controls.Add(this.ControlActual);
                //LogicaControlSistema.AumentarNivel(RecursosUI.ResourceManager.GetString(this.ControlActual.Name, RecursosUI.Culture));
                //LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
                this.ControlActual.Show();
            }
            paciente1.Dispose();
        }

        private void LinkNuevoPerfil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ControlActual = new PanelPacienteNuevo();
            this.ControlActual.Dock = DockStyle.Fill;
            this.ModeBtnFuncion(false);
            this.PanelTrabajo.Controls.Add(this.ControlActual);
            //LogicaControlSistema.AumentarNivel(RecursosUI.ResourceManager.GetString(this.ControlActual.Name, RecursosUI.Culture));
            //LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
            this.ControlActual.Show();
        }

        public void ModeBtnFuncion(bool mode)
        {
            this.PanelLateral.Visible = mode;
        }
    }
}
