using System.Drawing;


namespace Entity.Code.Static
{
    public class PaletaColor
    {
        private static Color cBtnBackOriginal = Color.DodgerBlue;
        private static Color cBtnBackSelect = Color.DarkOrange;
        private static Color cBtnBorderOriginal = Color.SteelBlue;
        private static Color cBtnBorderSelect = Color.SandyBrown;
        private static Color cBtnDownOriginal = Color.LightSkyBlue;
        private static Color cBtnDownSelect = Color.Khaki;
        private static Color cBtnOverOriginal = Color.DeepSkyBlue;
        private static Color cBtnOverSelect = Color.Orange;

        public static Color BtnOriginalBack =>
            cBtnBackOriginal;

        public static Color BtnOriginalBorder =>
            cBtnBorderOriginal;

        public static Color BtnOriginalDown =>
            cBtnDownOriginal;

        public static Color BtnOriginalOver =>
            cBtnOverOriginal;

        public static Color BtnSelectBack =>
            cBtnBackSelect;

        public static Color BtnSelectBorder =>
            cBtnBorderSelect;

        public static Color BtnSelectDown =>
            cBtnDownSelect;

        public static Color BtnSelectOver =>
            cBtnOverSelect;
    }
}
