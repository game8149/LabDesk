namespace EntityLab.Code.Reports
{
    public class ReporteMensualDetalle
    {
        private int acumulado;
        private int cantidad;
        private int id;

        public int Acumulado
        {
            get => 
                this.acumulado;
            set
            {
                this.acumulado = value;
            }
        }

        public int Cantidad
        {
            get => 
                this.cantidad;
            set
            {
                this.cantidad = value;
            }
        }

        public int Id
        {
            get => 
                this.id;
            set
            {
                this.id = value;
            }
        }
    }
}
