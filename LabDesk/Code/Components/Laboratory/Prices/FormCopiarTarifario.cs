using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Laboratory.Prices
{
    public partial class FormCopiarTarifario : Form
    {
        public Dictionary<int,Tarifario> Tarifarios{get; set;}
        private bool OK { get; set; }


        public FormCopiarTarifario()
        {
            InitializeComponent();
        }

        public void CargarDatos()
        {
            BtnSave.Visible = true;
            BLTarifario enlace = new BLTarifario();
            if (enlace.ObtenerListadoAnalisis().Count > 0 && Tarifarios.Count > 0)
            {
                ComboBoxAno.DataSource = new BindingSource(enlace.ObtenerListadoAno(Tarifarios), null);
                ComboBoxAno.DisplayMember = "Value";
                ComboBoxAno.ValueMember = "Key";
                BtnSave.Enabled = true;
                OK = true;
            }
            else
            {
                OK = false;
                BtnSave.Enabled = false;
            }
        }

        public void MostarForm()
        {
            if (OK)
                this.ShowDialog();
            else
            {
                MessageBox.Show("No existen Tarifarios Vigentes", "Mensaje");
                this.Dispose();
            }
        }



        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BLTarifario enlace = new BLTarifario();
                enlace.CopiarTarifario(Tarifarios[(int)ComboBoxAno.SelectedValue], (int)NumericUDAño.Value, CheckBoxVigente.Checked);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Advertencia");
            }
        }
    }
}
