namespace Entity.Code.Analysis.Templates.Print
{
    public class TemplatePrintPageLine
    {
        private string nombre;
        private string resultado;
        private PageLineType tipo;

        public string Nombre
        {
            get =>
                this.nombre;
            set
            {
                this.nombre = this.nombre + value;
            }
        }

        public string Resultado
        {
            get =>
                this.resultado;
            set
            {
                this.resultado = value;
            }
        }

        public PageLineType TipoLinea
        {
            get =>
                this.tipo;
            set
            {
                this.tipo = value;
            }
        }

        public enum PageLineType
        {
            TituloExamen,
            TituloArea,
            TituloFin,
            ItemSimple,
            ItemTexto,
            TituloGrupo,
            GrupoFin
        }
    }
}
