using System.Drawing;
using System.Windows.Forms;

namespace LogicLab.Code.PrintingManager
{
    public class Sector
    {
        public int Cabezal;
        public SectorConfiguracion Configuracion = new SectorConfiguracion();
        public Point Inicio;
        public Point Limite;

        public Sector()
        {
            this.Configuracion.Sangria = 3;
            this.Configuracion.TamañoPapel = new Size();
            this.Configuracion.Margen = new Padding();
            this.Cabezal = 0;
            this.Inicio = new Point(0, 0);
            this.Limite = new Point(0, 0);
        }

        public void ActualizarPosicion(int sector)
        {
            this.Cabezal = 0;
            switch (sector)
            {
                case 1:
                    this.Inicio.X = 0;
                    this.Inicio.Y = 0;
                    this.Limite.X = this.Configuracion.TamañoPapel.Width / 2;
                    this.Limite.Y = this.Configuracion.TamañoPapel.Height / 2;
                    return;

                case 2:
                    this.Inicio.X = this.Configuracion.TamañoPapel.Width / 2;
                    this.Inicio.Y = 0;
                    this.Limite.X = this.Configuracion.TamañoPapel.Width;
                    this.Limite.Y = this.Configuracion.TamañoPapel.Height / 2;
                    return;

                case 3:
                    this.Inicio.X = 0;
                    this.Inicio.Y = this.Configuracion.TamañoPapel.Height / 2;
                    this.Limite.X = this.Configuracion.TamañoPapel.Width / 2;
                    this.Limite.Y = this.Configuracion.TamañoPapel.Height;
                    return;

                case 4:
                    this.Inicio.X = this.Configuracion.TamañoPapel.Width / 2;
                    this.Inicio.Y = this.Configuracion.TamañoPapel.Height / 2;
                    this.Limite.X = this.Configuracion.TamañoPapel.Width;
                    this.Limite.Y = this.Configuracion.TamañoPapel.Height;
                    return;
            }
        }

        public bool SectorLlenable() =>
            (this.Cabezal <= (this.Limite.Y - this.Configuracion.Margen.Bottom));
    }
}
