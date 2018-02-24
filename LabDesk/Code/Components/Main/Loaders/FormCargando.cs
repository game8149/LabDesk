using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Main.Loaders
{

    public partial class FormCargando : Form
    {
        private Thread _subProceso;
       
        private StringBuilder loading = new StringBuilder();
      
        private System.Windows.Forms.Timer timer1;

        public FormCargando(int time, Thread hilo)
        {
            this._subProceso = hilo;
            this.InitializeComponent();
            Decorator.Instance().FormatStyle(base.Controls);
            this.timer1.Interval = time * 600;
            if (!this.timer1.Enabled)
            {
                this.timer1.Enabled = true;
            }
            this.timer1.Tick += new EventHandler(this.Timer1_Tick);
        }

        

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            if (this._subProceso.IsAlive)
            {
                if (this.timer1.Interval != 20)
                {
                    this.timer1.Interval = 20;
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
