using System;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main.ManagementAccount
{
    public partial class FormRegistrarProfesional : Form
    {
        
        public FormRegistrarProfesional()
        {
            InitializeComponent();
        }
        
        private void BtnCancelar(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRegistra_Click(object sender, EventArgs e)
        {
            BLMedico logica = new BLMedico();
            Medico med = new Medico();
            med.Nombre = CampNombre.Text;
            med.PrimerApellido = CampSegundoApellido.Text;
            med.SegundoApellido = CampColegiatura.Text.Trim(' ');
            med.Especialidad = CampEspecialidad.Text;
            med.Colegiatura = CampEspecialidad.Text;
            try
            {
                if (logica.CrearMedico(med))
                {
                    MessageBox.Show("Registro Finalizado","Mensaje");
                    this.Close();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Advertencia");
            }
        }
    }
}
