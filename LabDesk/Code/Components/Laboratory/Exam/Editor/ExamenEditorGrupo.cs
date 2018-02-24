
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.Components.Laboratory.Exam.Editor
{ 
    public class ExamenEditorGrupo : GroupBox
    {
        private List<ExamenEditorItem> items;

        public ExamenEditorGrupo(int Ancho, int Alto)
        {
            base.Height = Alto;
            base.Width = Ancho;
            this.DoubleBuffered = true;
            this.BackColor = Color.LemonChiffon;
        }

        private void addList(List<ExamenEditorItem> items)
        {
            int y = 20;
            base.SuspendLayout();
            foreach (ExamenEditorItem item in this.Items)
            {
                base.Controls.Add(item);
                item.Location = new Point(item.Location.X, y);
                y += item.Height + 2;
            }
            base.Height = y + 0x19;
            base.ResumeLayout(false);
        }

        public void redimensionarWidth(int Alto)
        {
            base.SuspendLayout();
            base.Width = Alto;
            using (List<ExamenEditorItem>.Enumerator enumerator = this.items.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    enumerator.Current.redimensionarWidth(base.Width - 10);
                }
            }
            base.ResumeLayout(false);
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

        public List<ExamenEditorItem> Items
        {
            get => 
                this.items;
            set
            {
                this.items = value;
                this.addList(value);
            }
        }

        public string Nombre
        {
            get => 
                this.Text;
            set
            {
                this.Text = value;
            }
        }
    }
}
