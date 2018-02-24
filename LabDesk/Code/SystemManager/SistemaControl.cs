namespace LogicLab.Code
{
    public class SistemaControl
    {
        private readonly Sesion sesion  = new Sesion();
        private static SistemaControl control;

        private SistemaControl()
        {
            this.Estado = SistemaEstado.Operando;
        }

        public static SistemaControl Instance()
        {
            if (control == null)
            {
                control = new SistemaControl();
            }
            return control;
        }

        public SistemaEstado Estado { get; set; }
        
        public Sesion Sesion {
            get { return this.sesion; }
        }

        public enum SistemaEstado
        {
            Operando = 0,
            SinOperar = 0
        }
    }
}
