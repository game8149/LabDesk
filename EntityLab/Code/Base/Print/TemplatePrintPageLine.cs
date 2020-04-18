namespace Entity.Code.Base.Print
{
    public class TemplatePrintPageLine
    {
        private string _nombre;
        private string _result;
        private PageLineType _type;

        public string Nombre
        {
            get { return _nombre; } 
            set { _nombre = _nombre + value; }
        }

        public string Resultado
        {
            get =>
                _result;
            set
            {
                _result = value;
            }
        }

        public PageLineType TipoLinea
        {
            get =>
                _type;
            set
            {
                _type = value;
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
