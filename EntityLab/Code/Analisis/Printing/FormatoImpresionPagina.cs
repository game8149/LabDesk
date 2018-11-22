
using System.Collections.Generic;

namespace EntityLab.Code.Printing
{
    public class FormatoImpresionPagina
    {
        private Dictionary<int, FormatoImpresionPaginaLinea> detalle = new Dictionary<int, FormatoImpresionPaginaLinea>();

        public Dictionary<int, FormatoImpresionPaginaLinea> Detalles
        {
            get => 
                this.detalle;
            set
            {
                this.detalle = value;
            }
        }
    }
}
