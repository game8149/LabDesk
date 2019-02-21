using Entity.Code.Analysis.Templates.Print;
using System.Collections.Generic;

namespace LabServices.Code.PrintingManager
{
    public class BufferImpresion
    {
        private List<TemplatePrint> formatos = new List<TemplatePrint>();
        private int indexFormatoActual;
        private int indexLineaActual;
        private int indexPagActual;

        public BufferImpresion(List<TemplatePrint> Formatos)
        {
            this.formatos = Formatos;
            this.indexFormatoActual = -1;
            this.indexPagActual = -1;
            this.indexLineaActual = -1;
            this.IsModeRead = false;
        }

        public bool EmptyListFormato() => 
            (this.indexFormatoActual >= this.formatos.Count);

        public bool EmptyListLinea() => 
            (this.indexLineaActual >= this.formatos[this.indexFormatoActual].Paginas[this.indexPagActual].Detalles.Count);

        public bool EmptyListPagina() => 
            (this.indexPagActual >= this.formatos[this.indexFormatoActual].Paginas.Count);

        public TemplatePrint GetFormato()
        {
            if (!this.EmptyListFormato())
            {
                return this.formatos[this.indexFormatoActual];
            }
            return null;
        }

        public TemplatePrintPageLine GetLinea()
        {
            if ((!this.EmptyListFormato() && !this.EmptyListPagina()) && !this.EmptyListLinea())
            {
                return this.formatos[this.indexFormatoActual].Paginas[this.indexPagActual].Detalles[this.indexLineaActual];
            }
            return null;
        }

        public TemplatePrintPage GetPagina()
        {
            if (!this.EmptyListFormato() && !this.EmptyListPagina())
            {
                return this.formatos[this.indexFormatoActual].Paginas[this.indexPagActual];
            }
            return null;
        }

        public bool SiguienteFormato()
        {
            this.indexFormatoActual++;
            this.indexPagActual = -1;
            this.indexLineaActual = -1;
            return !this.EmptyListFormato();
        }

        public bool SiguienteLinea()
        {
            this.indexLineaActual++;
            return !this.EmptyListLinea();
        }

        public bool SiguientePagina()
        {
            this.indexPagActual++;
            this.indexLineaActual = -1;
            return !this.EmptyListPagina();
        }

        public bool IsModeRead { get; set; }
    }
}
