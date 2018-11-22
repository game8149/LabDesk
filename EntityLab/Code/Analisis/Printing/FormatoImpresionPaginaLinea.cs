namespace EntityLab.Code.Printing
{
    public class FormatoImpresionPaginaLinea
    {
        private string nombre;
        private string resultado;
        private TipoPaginaLinea tipo;

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

        public TipoPaginaLinea TipoLinea
        {
            get => 
                this.tipo;
            set
            {
                this.tipo = value;
            }
        }

        public enum TipoPaginaLinea
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
