
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Laboratory.Exam.Editor
{
    public class ExamenEditorFila : Panel
    {
        private ExamenEditorGrupo grupo;
        private int index;
        private ExamenEditorItem item;
        private TipoForm tipo;

        public ExamenEditorFila(int Ancho, int Alto)
        {
            base.Width = Ancho;
            base.Height = Alto;
            base.Size = new Size(base.Width, base.Height);
            this.DoubleBuffered = true;
            this.BackColor = Color.LemonChiffon;
        }

        public void redimensionarWidth(int diferencia)
        {
            base.Width -= diferencia;
            TipoForm tipo = this.tipo;
            if (tipo != TipoForm.Grupo)
            {
                if (tipo != TipoForm.Item)
                {
                    return;
                }
            }
            else
            {
                this.grupo.redimensionarWidth(base.Width);
                return;
            }
            this.item.redimensionarWidth(base.Width);
        }

        public ExamenEditorGrupo Grupo
        {
            get => 
                this.grupo;
            set
            {
                base.SuspendLayout();
                this.grupo = value;
                base.Height = this.grupo.Height;
                base.Width = this.grupo.Width;
                base.Controls.Add(this.grupo);
                base.ResumeLayout(false);
            }
        }

        public int Indice
        {
            get => 
                this.index;
            set
            {
                this.index = value;
            }
        }

        public ExamenEditorItem Item
        {
            get => 
                this.item;
            set
            {
                base.SuspendLayout();
                this.item = value;
                this.item.Location = new Point(0, 0);
                base.Height = this.item.Height;
                base.Width = this.item.Width;
                base.Controls.Add(this.item);
                base.ResumeLayout(false);
            }
        }

        public TipoForm Tipo
        {
            get => 
                this.tipo;
            set
            {
                this.tipo = value;
            }
        }

        public enum TipoForm
        {
            Grupo,
            Item
        }
    }
}
