using System;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main.ManagementAccount
{
    public partial class FormModificarCuenta : Form
    {
     

        public FormModificarCuenta()
        {
            this.InitializeComponent();
            this.CampDni.KeyPress += new KeyPressEventHandler(this.CampDNI_KeyPress);
            this.CampNombre.KeyUp += new KeyEventHandler(this.CampNombre_KeyUp);
            this.CampPrimerApellido.KeyUp += new KeyEventHandler(this.CampPrimerApellido_KeyUp);
            this.CampSegundoApellido.KeyUp += new KeyEventHandler(this.CampSegundoApellido_KeyUp);
            this.CampCodigo.KeyPress += new KeyPressEventHandler(this.CampCodigo_KeyPress);
            this.CampEspecialidad.KeyUp += new KeyEventHandler(this.CampEspecialidad_KeyUp);
            this.BtnUIUsuarioDatos1.Tipo = ButtonUI.ButtonTipo.Ok;
            this.BtnUIUsuarioDatos2.Tipo = ButtonUI.ButtonTipo.Cancel;
            this.BtnUIUsuarioDatos1.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click);
            this.BtnUIUsuarioDatos2.ComponenteUI.Click += new EventHandler(this.ComponenteUI_Click1);
            base.SuspendLayout();
            Decorator.Instance().FormatStyle(base.Controls);
            base.ResumeLayout();
        }

        private void BtnUIUsuarioDatos1_Load(object sender, EventArgs e)
        {
        }

        private void CampCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((!char.IsNumber(e.KeyChar) && (e.KeyChar != '\b')) && ((e.KeyChar != '\x0002') && (e.KeyChar != '\x0003'))) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
        }

        private void CampDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((!char.IsNumber(e.KeyChar) && (e.KeyChar != '\b')) && ((e.KeyChar != '\x0002') && (e.KeyChar != '\x0003'))) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
        }

        private void CampEspecialidad_KeyUp(object sender, KeyEventArgs e)
        {
            this.CampEspecialidad.Text = this.CampEspecialidad.Text.ToUpper();
            this.CampEspecialidad.SelectionStart = this.CampEspecialidad.TextLength;
        }

        private void CampNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (char.IsLetter((char) e.KeyValue) || char.IsWhiteSpace((char) e.KeyValue))
            {
                this.CampNombre.Text = this.CampNombre.Text.ToUpper();
                this.CampNombre.SelectionStart = this.CampNombre.TextLength;
            }
            else if ((e.KeyValue != 2) && (e.KeyValue != 3))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void CampPrimerApellido_KeyUp(object sender, KeyEventArgs e)
        {
            if (char.IsLetter((char) e.KeyValue) || char.IsWhiteSpace((char) e.KeyValue))
            {
                this.CampPrimerApellido.Text = this.CampPrimerApellido.Text.ToUpper();
                this.CampPrimerApellido.SelectionStart = this.CampPrimerApellido.TextLength;
            }
            else if ((e.KeyValue != 2) && (e.KeyValue != 3))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void CampSegundoApellido_KeyUp(object sender, KeyEventArgs e)
        {
            if (char.IsLetter((char) e.KeyValue) || char.IsWhiteSpace((char) e.KeyValue))
            {
                this.CampSegundoApellido.Text = this.CampSegundoApellido.Text.ToUpper();
                this.CampSegundoApellido.SelectionStart = this.CampSegundoApellido.TextLength;
            }
            else if ((e.KeyValue != 2) && (e.KeyValue != 3))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void ComponenteUI_Click(object sender, EventArgs e)
        {
            LogicaCuenta cuenta = new LogicaCuenta();
            LabDesk.Code.EntityLayer.EFicha.Cuenta cuenta2 = new LabDesk.Code.EntityLayer.EFicha.Cuenta {
                IdData = this.Cuenta.IdData,
                Nombre = this.CampNombre.Text,
                PrimerApellido = this.CampPrimerApellido.Text,
                SegundoApellido = this.CampSegundoApellido.Text,
                Dni = this.CampDni.Text,
                Especialidad = this.CampEspecialidad.Text,
                CodigoPro = this.CampCodigo.Text,
                Clave = this.Cuenta.Clave
            };
            try
            {
                cuenta.ActualizarCuenta(cuenta2);
                base.Close();
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message, "Advertencia");
            }
        }

        private void ComponenteUI_Click1(object sender, EventArgs e)
        {
            base.Close();
        }
        

        private void FormModificarCuenta_Load(object sender, EventArgs e)
        {
            this.CampDni.Text = this.Cuenta.Dni;
            this.CampNombre.Text = this.Cuenta.Nombre;
            this.CampPrimerApellido.Text = this.Cuenta.PrimerApellido;
            this.CampSegundoApellido.Text = this.Cuenta.SegundoApellido;
            this.CampEspecialidad.Text = this.Cuenta.Especialidad;
            this.CampCodigo.Text = this.Cuenta.CodigoPro;
        }

        
        public LabDesk.Code.EntityLayer.EFicha.Cuenta Cuenta { get; set; }
    }
}
