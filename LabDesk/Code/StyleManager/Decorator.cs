
using LabDesk.Code.Base;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.StyleManager
{
    public class Decorator
    {
        public static int EspacioBorde = 0x19;
        public static int EspacioTitulo = 50;
        private static Decorator obj;

        private Decorator()
        {
        }

        private void FormatButton(ButtonUI but)
        {
            StyleUIParameters buttonNext = null;
            switch (but.Tipo)
            {
                case ButtonUI.ButtonTipo.Next:
                    buttonNext = this.ActualStyle.ButtonNext;
                    break;

                case ButtonUI.ButtonTipo.Ok:
                    buttonNext = this.ActualStyle.ButtonOK;
                    break;

                case ButtonUI.ButtonTipo.Cancel:
                    buttonNext = this.ActualStyle.ButtonCancel;
                    break;

                case ButtonUI.ButtonTipo.Item:
                    buttonNext = this.ActualStyle.ButtonItem;
                    break;

                case ButtonUI.ButtonTipo.ItemLight:
                    buttonNext = this.ActualStyle.ButtonItemLight;
                    break;

                case ButtonUI.ButtonTipo.ItemLow:
                    buttonNext = this.ActualStyle.ButtonItemLow;
                    break;

                case ButtonUI.ButtonTipo.Delete:
                    buttonNext = this.ActualStyle.ButtonDelete;
                    break;

                default:
                    buttonNext = this.ActualStyle.ButtonDefault;
                    break;
            }
            but.ComponenteUI.SuspendLayout();
            but.ComponenteUI.Size = buttonNext.Size;
            but.ComponenteUI.FlatAppearance.BorderColor = buttonNext.BordeColor;
            but.ComponenteUI.FlatAppearance.BorderSize = buttonNext.BordeSize;
            but.ComponenteUI.ForeColor = buttonNext.FontColor;
            but.ComponenteUI.Font = new Font("Futura Bk BT", (float) buttonNext.FontSize);
            but.ComponenteUI.BackColor = buttonNext.BackGroundBack;
            but.ComponenteUI.FlatAppearance.MouseDownBackColor = buttonNext.BackGroundDown;
            but.ComponenteUI.FlatAppearance.MouseOverBackColor = buttonNext.BackGroundOver;
            but.ComponenteUI.TextAlign = buttonNext.TextAlign;
            but.ComponenteUI.Cursor = buttonNext.Cursor;
            but.ComponenteUI.ResumeLayout(true);
        }

        private void FormatComponentUI(Control c)
        {
            if (c.Name == "PanelLateral")
            {
                this.FormatPanelGeneric((Panel) c);
            }
            else if (c.Name == "PanelBarTable")
            {
                this.FormatPanelTable((Panel) c);
            }
            else if (c is ButtonUI)
            {
                this.FormatButton((ButtonUI) c);
                string str = RecursosUI.ResourceManager.GetString(c.Name, RecursosUI.Culture);
                if (str != string.Empty)
                {
                    ((ButtonUI) c).ComponenteUI.Text = str;
                }
            }
            else if (c is PanelUIControl)
            {
                this.FormatPanelControl((PanelUIControl) c);
                string str2 = RecursosUI.ResourceManager.GetString(c.Name, RecursosUI.Culture);
                if (str2 != string.Empty)
                {
                    ((PanelUIControl) c).ComponenteUIText.Text = str2;
                }
            }
            else if (c is PanelSesionUI)
            {
                this.FormatPanelSesion((PanelSesionUI) c);
            }
            else
            {
                foreach (Control control in c.Controls)
                {
                    this.FormatComponentUI(control);
                }
            }
        }

        private void FormatPanelControl(PanelUIControl but)
        {
            StyleUIParameters panelNavegationControl = this.ActualStyle.PanelNavegationControl;
            but.ComponenteUI.BackColor = panelNavegationControl.BackGroundBack;
        }

        private void FormatPanelGeneric(Panel but)
        {
            StyleUIParameters panelLateralControl = this.ActualStyle.PanelLateralControl;
            but.BackColor = panelLateralControl.BackGroundBack;
        }

        private void FormatPanelSesion(PanelSesionUI but)
        {
            StyleUIParameters buttonItem = this.ActualStyle.ButtonItem;
            but.ComponenteUI.BackColor = buttonItem.BackGroundBack;
        }

        private void FormatPanelTable(Panel but)
        {
            StyleUIParameters panelBarTable = this.ActualStyle.PanelBarTable;
            but.BackColor = panelBarTable.BackGroundBack;
        }

        public void FormatStyle(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                this.FormatComponentUI(control);
            }
        }

        public static Decorator Instance()
        {
            if (obj == null)
            {
                obj = new Decorator();
            }
            return obj;
        }

        public StyleUI ActualStyle
        {
            get
            {
                StyleUI style = StyleUIPalette.Instance().GetStyle((StyleUI.StyleTipe) ConfiguracionSystem.Style);
                if (ConfiguracionSystem.Daltonic)
                {
                    if (ConfiguracionSystem.Style == 0)
                    {
                        style = StyleUIPalette.Instance().GetStyle(StyleUI.StyleTipe.DefaultDaltonic);
                    }
                    if (1 == ConfiguracionSystem.Style)
                    {
                        style = StyleUIPalette.Instance().GetStyle(StyleUI.StyleTipe.MoradoDaltonic);
                    }
                }
                return style;
            }
        }
    }
}
