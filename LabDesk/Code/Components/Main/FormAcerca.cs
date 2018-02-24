using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main
{
    public partial class FormAcerca : Form
    {
        public FormAcerca()
        {
            this.InitializeComponent();
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            this.LabelPropietario.Text = RecursosUI.Propietario;
            this.LabelPrograma.Text = RecursosUI.SistemaName;
            this.LabelVersion.Text = versionInfo.FileVersion;
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\Docs\NotaVer.pdf");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Reinstale el Programa: " + exception.Message, "Advertencia");
            }
        }
    }
}
