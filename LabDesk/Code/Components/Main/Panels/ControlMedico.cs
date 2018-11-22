using Entity.Code.Hospital;
using LabDesk.Code.Components.Actors.Medico;
using LabDesk.Code.Forms;
using LabDesk.Code.PresentationLayer.Controles.ComponentesMedico;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main.Panels
{

    public partial class ControlMedico : UserControl
    {
        public UserControl Actualcontrol;

        public ControlMedico()
        {
            this.InitializeComponent();
            base.SizeChanged += new EventHandler(this.ControlMedico_SizeChanged);
            this.ModeBtnFuncion(true);
            this.InicializarToolTip();
        }

        private void ControlMedico_SizeChanged(object sender, EventArgs e)
        {
            this.PanelLateral.Location = new Point(base.Size.Width - this.PanelLateral.Size.Width, 0);
        }
        
        public void InicializarToolTip()
        {
            ToolTip tip1 = new ToolTip {
                ShowAlways = true
            };
            tip1.SetToolTip(this.LinkAbrirPerfil, RecursosUIToolkit.BtnPerfilAbrir);
            tip1.SetToolTip(this.LinkNuevoPerfil, RecursosUIToolkit.BtnPerfilNuevo);
        }

        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Medic perfil = null;
            FormMedicoBuscar buscar1 = new FormMedicoBuscar();
            buscar1.ShowDialog();
            perfil = buscar1.Perfil;
            if (perfil != null)
            {
                this.Actualcontrol = new PanelMedicoPerfil();
                this.Actualcontrol.Dock = DockStyle.Fill;
                this.Actualcontrol.Parent = this;
                ((PanelMedicoPerfil) this.Actualcontrol).Perfil = perfil;
                this.ModeBtnFuncion(false);
                this.PanelTrabajo.Controls.Add(this.Actualcontrol);
                this.Actualcontrol.Show();
                //LogicaControlSistema.AumentarNivel(RecursosUI.ResourceManager.GetString(this.Actualcontrol.Name, RecursosUI.Culture));
                //LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
            }
            buscar1.Dispose();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Actualcontrol = new PanelMedicoNuevo();
            this.Actualcontrol.Dock = DockStyle.Fill;
            this.ModeBtnFuncion(false);
            this.PanelTrabajo.Controls.Add(this.Actualcontrol);
            this.Actualcontrol.Show();
            //LogicaControlSistema.AumentarNivel(RecursosUI.ResourceManager.GetString(this.Actualcontrol.Name, RecursosUI.Culture));
            //LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
        }

        public void ModeBtnFuncion(bool mode)
        {
            this.PanelLateral.Visible = mode;
        }

        private void PanelTrabajo_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
