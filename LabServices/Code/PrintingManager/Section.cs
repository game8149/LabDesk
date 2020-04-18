using System.Drawing;
using System.Windows.Forms;

namespace LabServices.Code.PrintingManager
{
    public class Section
    {
        public int Header { get; set; }
        public SectorSetting Setting { get; }
        public Point InitPosition { get; set; }
        public Point FinalPosition { get; set; }

        public Section()
        {
            Setting = new SectorSetting();
            Setting.Sangria = 3;
            Setting.PaperSize = new Size();
            Setting.Margin = new Padding();
            Header = 0;
            InitPosition = new Point(0, 0);
            FinalPosition = new Point(0, 0);
        }

        public void UpdatePosition(int numberSection)
        {
            Header = 0;
            switch (numberSection)
            {
                case 1:
                    InitPosition.X = 0;
                    InitPosition.Y = 0;
                    FinalPosition.X = Setting.PaperSize.Width / 2;
                    FinalPosition.Y = Setting.PaperSize.Height / 2;
                    return;

                case 2:
                    InitPosition.X = Setting.PaperSize.Width / 2;
                    InitPosition.Y = 0;
                    FinalPosition.X = Setting.PaperSize.Width;
                    FinalPosition.Y = Setting.PaperSize.Height / 2;
                    return;

                case 3:
                    InitPosition.X = 0;
                    InitPosition.Y = Setting.PaperSize.Height / 2;
                    FinalPosition.X = Setting.PaperSize.Width / 2;
                    FinalPosition.Y = Setting.PaperSize.Height;
                    return;

                case 4:
                    InitPosition.X = Setting.PaperSize.Width / 2;
                    InitPosition.Y = Setting.PaperSize.Height / 2;
                    FinalPosition.X = Setting.PaperSize.Width;
                    FinalPosition.Y = Setting.PaperSize.Height;
                    return;
            }
        }

        public bool FillableSector() =>
            (Header <= (FinalPosition.Y - Setting.Margin.Bottom));
    }

    public class SectorSetting
    {
        public Padding Margin;
        public int Sangria;
        public Size PaperSize;
    }
}
