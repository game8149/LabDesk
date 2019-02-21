
using System.Collections.Generic;

namespace Entity.Code.Analysis.Templates.Print
{
    public class TemplatePrintPage
    {
        private Dictionary<int, TemplatePrintPageLine> detalle = new Dictionary<int, TemplatePrintPageLine>();

        public Dictionary<int, TemplatePrintPageLine> Detalles
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
