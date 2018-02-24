
using LabDesk.Code.PresentationLayer.ComponenteGeneral;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabDesk.Code.PresentationLayer.GUISistema
{
    public partial class Test : Form
    {

        public Test()
        {
            this.InitializeComponent();
            this.BtnUI1.Tipo = ButtonUI.ButtonTipo.Ok;
            this.LblUI1.Tipo = LabelUI.LabelTipo.Item;
            this.LblUI2.Tipo = LabelUI.LabelTipo.Item;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel1.Width = 0x134;
            this.CampEdad.Text = this.trackBar1.Value + "--" + this.trackBar2.Value;
        }


        private void labelUI1_Load(object sender, EventArgs e)
        {
        }

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            double num = ((double) maxHeight) / ((double) image.Height);
            double num2 = Math.Min(((double) maxWidth) / ((double) image.Width), num);
            int width = (int) (image.Width * num2);
            int height = (int) (image.Height * num2);
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return bitmap;
        }

        private void TB_Scroll(object sender, EventArgs e)
        {
            this.CampEdad.Text = this.TB.Value.ToString();
        }
    }
}
