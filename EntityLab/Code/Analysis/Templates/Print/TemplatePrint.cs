using System.Collections.Generic;
using System.Drawing;

namespace Entity.Code.Analysis.Templates.Print
{
    public class TemplatePrint
    {
        private TemplatePrintHead cabecera;
        private List<TemplatePrintPage> paginas = new List<TemplatePrintPage>();
        private Size tamaño;

        public int Alto
        {
            get =>
                this.tamaño.Height;
            set
            {
                this.tamaño.Height = value;
            }
        }

        public int Ancho
        {
            get =>
                this.tamaño.Width;
            set
            {
                this.tamaño.Width = value;
            }
        }

        public TemplatePrintHead Cabecera
        {
            get =>
                this.cabecera;
            set
            {
                this.cabecera = value;
            }
        }

        public List<TemplatePrintPage> Paginas
        {
            get =>
                this.paginas;
            set
            {
                this.paginas = value;
            }
        }

        public Size Tamaño { get; set; }
    }
}
