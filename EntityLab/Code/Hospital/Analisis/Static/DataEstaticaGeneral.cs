using System.Collections.Generic;


namespace EntityLab.Code.Static
{
    public class DataEstaticaGeneral
    {
        private static Dictionary<int, string> areas = new Dictionary<int, string>();
        private static Dictionary<int, string> coberturaTipos = new Dictionary<int, string>();
        private static Dictionary<int, string> diccionarioAño = new Dictionary<int, string>();
        private static Dictionary<int, string> docTipos = new Dictionary<int, string>();
        private static Dictionary<int, string> examenStates = new Dictionary<int, string>();
        private static Dictionary<int, string> meses = new Dictionary<int, string>();
        private static Dictionary<int, string> ordenStates = new Dictionary<int, string>();
        private static Dictionary<int, string> regexs = new Dictionary<int, string>();
        private static Dictionary<int, string> reporteFiltrosEconomico = new Dictionary<int, string>();
        private static Dictionary<int, string> reporteFiltrosResultado = new Dictionary<int, string>();
        private static Dictionary<int, string> reporteTipos = new Dictionary<int, string>();
        private static Dictionary<int, string> sexoList = new Dictionary<int, string>();
        private static Dictionary<int, Distrito> ubicaciones = new Dictionary<int, Distrito>();

        public static void Init()
        {
            reporteFiltrosEconomico.Add(0, "General");
            reporteFiltrosEconomico.Add(1, "Grupo Etareo");
            reporteFiltrosEconomico.Add(2, "M\x00e9dico");
            reporteFiltrosResultado.Add(0, "General");
            sexoList.Add(0, "HOMBRE");
            sexoList.Add(1, "MUJER");
            docTipos.Add(0, "DNI");
            docTipos.Add(1, "HC");
            coberturaTipos.Add(0, "PARTICULAR");
            coberturaTipos.Add(1, "SIS");
            coberturaTipos.Add(2, "EXONERADO");
            areas.Add(0, "BIOQUIMICA");
            areas.Add(1, "ESTUDIO DE SECRECIONES");
            areas.Add(2, "HEMATOLOGIA");
            areas.Add(3, "INMUNOLOGIA");
            areas.Add(4, "MICROBIOLOGIA");
            areas.Add(5, "PARASITOLOGIA");
            areas.Add(6, "UROANALISIS");
            ordenStates.Add(0, "EN PROCESO");
            ordenStates.Add(1, "TERMINADO");
            examenStates.Add(0, "EN PROCESO");
            examenStates.Add(1, "TERMINADO");
            meses.Add(0, "ENERO");
            meses.Add(1, "FEBRERO");
            meses.Add(2, "MARZO");
            meses.Add(3, "ABRIL");
            meses.Add(4, "MAYO");
            meses.Add(5, "JUNIO");
            meses.Add(6, "JULIO");
            meses.Add(7, "AGOSTO");
            meses.Add(8, "SEPTIEMBRE");
            meses.Add(9, "OCTUBRE");
            meses.Add(10, "NOVIEMBRE");
            meses.Add(11, "DICIEMBRE");
            reporteTipos.Add(0, "Economico");
            reporteTipos.Add(1, "Resultados");
            regexs.Add(2, @"(\b[0-9]+$)");
            regexs.Add(3, @"(\b[0-9]+$|(\b[0-9]+.[0-9]+$))");
        }

        public static Dictionary<int, string> Areas =>
            areas;

        public static Dictionary<int, string> CoberturaTipos =>
            coberturaTipos;

        public static Dictionary<int, string> ExamenEstados =>
            examenStates;

        public static Dictionary<int, string> Expressions =>
            regexs;

        public static Dictionary<int, string> Meses =>
            meses;

        public static Dictionary<int, string> OrdenEstados =>
            ordenStates;

        public static Dictionary<int, string> ReporteFiltrosEconomico =>
            reporteFiltrosEconomico;

        public static Dictionary<int, string> ReporteFiltrosResultado =>
            reporteFiltrosResultado;

        public static Dictionary<int, string> ReporteTipos =>
            reporteTipos;

        public static Dictionary<int, string> SexoTipos =>
            sexoList;

    }
}
