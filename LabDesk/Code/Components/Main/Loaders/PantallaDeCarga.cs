using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace LabDesk.Code.Components.Main.Loaders
{
    public partial class PantallaDeCarga : Form
    {
        private Thread _subProceso;
       
        private System.Windows.Forms.Timer timer1;
        private StringBuilder loading = new StringBuilder();

        public PantallaDeCarga(int time, Thread hilo)
        {
            this._subProceso = hilo;
            this.InitializeComponent();
            this.timer1.Interval = time * 0x3e8;
            if (!this.timer1.Enabled)
            {
                this.timer1.Enabled = true;
            }
            this.timer1.Tick += new EventHandler(this.Timer1_Tick);
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            this.LabelVersion.Text = versionInfo.FileVersion;
            this.LabelPropietario.Text = RecursosUI.Propietario;
            this.LabelPrograma.Text = RecursosUI.SistemaName;
        }


       
        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            if (this._subProceso.IsAlive)
            {
                if (this.timer1.Interval != 0x3e8)
                {
                    this.timer1.Interval = 0x3e8;
                }
                else
                {
                    if (this.loading.Length >= 4)
                    {
                        this.loading.Clear();
                    }
                    this.loading.Append(".");
                    this.campPoint.Text = this.loading.ToString();
                }
                this.timer1.Start();
            }
            else
            {
                base.Close();
            }
        }
    }
}
