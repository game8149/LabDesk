using System.Collections.Generic;
using System.Windows.Forms;


namespace LabDesk.Code.Components.Laboratory.Exam.Editor
{
    public class ItemFormLista : ExamenEditorItem
    {
        private ComboBox combo;

        public ItemFormLista(int Ancho, int Alto, bool tieneUnidad) : base(Ancho, Alto, tieneUnidad)
        {
            this.combo = new ComboBox();
        }

        public void SetCollection(Dictionary<int, string> Coleccion)
        {
        }
    }
}
