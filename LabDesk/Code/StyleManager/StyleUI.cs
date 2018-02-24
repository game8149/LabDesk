
using System.Drawing;

namespace LabDesk.Code.StyleManager
{
    public class StyleUI
    {
        public StyleUI()
        {
            this.ButtonOK = new StyleUIParameters();
            this.ButtonCancel = new StyleUIParameters();
            this.ButtonDefault = new StyleUIParameters();
            this.ButtonDelete = new StyleUIParameters();
            this.ButtonItem = new StyleUIParameters();
            this.ButtonItemLow = new StyleUIParameters();
            this.ButtonNext = new StyleUIParameters();
            this.ButtonItemLight = new StyleUIParameters();
            this.PanelNavegationControl = new StyleUIParameters();
            this.PanelNavegationControl.BackGroundBack = Color.FromArgb(0x4c, 0x4a, 0x4a);
            this.PanelLateralControl = new StyleUIParameters();
            this.PanelBarTable = new StyleUIParameters();
        }

        public StyleUIParameters ButtonCancel { get; set; }

        public StyleUIParameters ButtonDefault { get; set; }

        public StyleUIParameters ButtonDelete { get; set; }

        public StyleUIParameters ButtonItem { get; set; }

        public StyleUIParameters ButtonItemLight { get; set; }

        public StyleUIParameters ButtonItemLow { get; set; }

        public StyleUIParameters ButtonNext { get; set; }

        public StyleUIParameters ButtonOK { get; set; }

        public StyleUIParameters PanelBarTable { get; set; }

        public StyleUIParameters PanelLateralControl { get; set; }

        public StyleUIParameters PanelNavegationControl { get; set; }

        public enum StyleTipe
        {
            Default,
            Morado,
            MoradoDaltonic,
            DefaultDaltonic
        }
    }
}
