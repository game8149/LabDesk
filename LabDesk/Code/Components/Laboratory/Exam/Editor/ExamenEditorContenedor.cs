using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace LabDesk.Code.Components.Laboratory.Exam.Editor
{

    public class ExamenEditorContenedor : Panel
    {
        private List<ExamenEditorFila> filas = new List<ExamenEditorFila>();

        public ExamenEditorContenedor(int Ancho, int Alto)
        {
            base.Width = Ancho;
            base.Height = Alto;
            this.BackColor = Color.LemonChiffon;
            this.DoubleBuffered = true;
        }

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x2000000;
                return createParams;
            }
        }

        public List<ExamenEditorFila> Filas
        {
            get => 
                this.filas;
            set
            {
                int y = 20;
                this.filas = value;
                base.SuspendLayout();
                foreach (ExamenEditorFila fila in this.filas)
                {
                    fila.Location = new Point(10, y);
                    y += fila.Height + 5;
                    base.Controls.Add(fila);
                }
                this.AutoScroll = true;
                if (y > base.Height)
                {
                    using (List<ExamenEditorFila>.Enumerator enumerator = this.filas.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            enumerator.Current.redimensionarWidth(0x19);
                        }
                    }
                }
                base.HScroll = false;
                base.ResumeLayout(false);
                base.PerformLayout();
            }
        }

        public int IdExamen { get; set; }
    }
}
