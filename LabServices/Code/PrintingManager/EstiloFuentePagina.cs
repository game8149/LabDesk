using System.Drawing;

namespace LabServices.Code.PrintingManager
{
    public class PageStyleFontResource
    {
        private static Font fontFechaSub = new Font("Calibri", 7.25f, FontStyle.Regular);
        private static Font fontGrupo = new Font("Calibri", 7.45f, FontStyle.Regular);
        private static Font fontItem = new Font("Calibri", 7.35f, FontStyle.Regular);
        private static Font fontRespuesta = new Font("Calibri", 7.35f, FontStyle.Regular);
        private static Font fontSubTitulo = new Font("Calibri", 7.5f, FontStyle.Bold);
        private static Font fontTitulo = new Font("Calibri", 8f, FontStyle.Bold);
        private static Font tituloCabecera = new Font("Calibri", 12f, FontStyle.Bold);

        public static Font Fecha =>
            fontFechaSub;

        public static Font Item =>
            fontItem;

        public static Font Respuesta =>
            fontRespuesta;

        public static Font TituloArea =>
            fontTitulo;

        public static Font TituloExamen =>
            fontSubTitulo;

        public static Font TituloFormato =>
            tituloCabecera;

        public static Font TituloGrupo =>
            fontGrupo;
    }
}
