
using System.Collections.Generic;

namespace Entity.Code.Base.Print
{
    public class TemplatePrintPage
    {
        private Dictionary<int, TemplatePrintPageLine> detalle = new Dictionary<int, TemplatePrintPageLine>();

        public Dictionary<int, TemplatePrintPageLine> Detail
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
