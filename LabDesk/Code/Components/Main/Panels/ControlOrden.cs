using EntityLab.Code.Hospital;
using EntityLab.Code.Hospital.Analisis;
using LabDesk.Code.Components.Laboratory.Orden;
using LabDesk.Code.Forms;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main.Panels
{


    public partial class ControlOrden : UserControl
    {
        private UserControl ControlActual;
    

        public ControlOrden()
        {
            this.InitializeComponent();
            base.KeyPress += new KeyPressEventHandler(this.ControlOrden_KeyPress);
            this.InicializarToolTip();
            this.ModeBtnFuncion(true);
        }

        private void ControlOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                MessageBox.Show("Form.KeyPress: '" + e.KeyChar.ToString() + "' pressed.");
                switch (e.KeyChar)
                {
                    case '1':
                    case '4':
                    case '7':
                        MessageBox.Show("Form.KeyPress: '" + e.KeyChar.ToString() + "' consumed.");
                        e.Handled = true;
                        break;
                }
            }
        }
        

        public void InicializarToolTip()
        {
            ToolTip tip1 = new ToolTip {
                ShowAlways = true
            };
            tip1.SetToolTip(this.LinkAbrirPerfil, RecursosUIToolkit.BtnOrdenAbrir);
            tip1.SetToolTip(this.LinkNuevoPerfil, RecursosUIToolkit.BtnOrdenNuevo);
        }

       
        private void LinkAbrirPerfil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExamOrder orden = null;
            Paciente perfil = null;
            FormOrdenBuscar buscar1 = new FormOrdenBuscar();
            buscar1.ShowDialog();
            orden = buscar1.ExamOrder;
            perfil = buscar1.Perfil;
            if ((orden != null) && (perfil != null))
            {
                this.ControlActual = new PanelOrdenPerfil();
                this.ControlActual.Dock = DockStyle.Fill;
                ((PanelOrdenPerfil) this.ControlActual).Perfil = perfil;
                ((PanelOrdenPerfil) this.ControlActual).ExamOrder = orden;
                this.ModeBtnFuncion(false);
                this.PanelTrabajo.Controls.Add(this.ControlActual);
                ((PanelOrdenPerfil) this.ControlActual).CargarDatos();
                this.ControlActual.Show();
                //LogicaControlSistema.AumentarNivel(RecursosUI.ResourceManager.GetString(this.ControlActual.Name));
                //LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
            }
            buscar1.Dispose();
        }

        private void LinkNuevoPerfil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ControlActual = new PanelOrdenNuevo();
            this.ControlActual.Dock = DockStyle.Fill;
            this.ModeBtnFuncion(false);
            this.ControlActual.Parent = this;
            this.PanelTrabajo.Controls.Add(this.ControlActual);
            this.ControlActual.Show();
            //LogicaControlSistema.AumentarNivel(RecursosUI.ResourceManager.GetString(this.ControlActual.Name));
            //LogicaControlSistema.FormPrincipal.ActualizarControlCabecera();
        }

        public void ModeBtnFuncion(bool mode)
        {
            this.PanelLateral.Visible = mode;
        }
    }
}
