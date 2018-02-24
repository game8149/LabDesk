
using System.Collections.Generic;
using System.Drawing;

namespace EntityLab.Code.Printing
{
    public class FormatoImpresion
    {
        private FormatoImpresionCabecera cabecera;
        private List<FormatoImpresionPagina> paginas = new List<FormatoImpresionPagina>();
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

        public FormatoImpresionCabecera Cabecera
        {
            get => 
                this.cabecera;
            set
            {
                this.cabecera = value;
            }
        }

        public List<FormatoImpresionPagina> Paginas
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
