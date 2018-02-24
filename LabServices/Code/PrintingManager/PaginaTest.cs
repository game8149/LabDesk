using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinLab.Code.PresentationLayer.GUIHistorial.ComponenteImpresion
{
    public class FormatoImpresion
    {
        private List<PaginaLinea> detalle;

        private string institucion;
        private string codigoOrden;
        private string nombrePaciente;
        private string edadPaciente;
        private string fechaEmite;
        private string hcPaciente;
        private string nombreDoctor;
        private int numero;
        public FormatoImpresion()
        {
            Institucion = "CENTRO DE SALUD WICHANZAO";
            codigoOrden = "Orden:   ";
            hcPaciente = "Historia:   ";
            nombreDoctor = "Solicita:   ";
            edadPaciente = "Edad:   ";
            nombrePaciente = "Paciente:   ";
            fechaEmite = "Emision:   " + DateTime.Now.ToShortDateString();
            detalle = new List<PaginaLinea>();
        }

        public List<PaginaLinea> Detalles
        {
            get { return detalle; }
        }

        public string Institucion
        {
            get { return institucion; }
            set { this.institucion = value; }
        }

        public string Nombre
        {
            get { return nombrePaciente; }
            set { this.nombrePaciente += value; }
        }
        public string Edad
        {
            get { return edadPaciente; }
            set { this.edadPaciente += value; }
        }
        public string Historia
        {
            get { return hcPaciente; }
            set { this.hcPaciente += value; }
        }
        public string Doctor
        {
            get { return nombreDoctor; }
            set { this.nombreDoctor = value; }
        }
        public int Numero
        {
            get { return numero; }
            set { this.numero = value; }
        }
        public string Fecha
        {
            get { return fechaEmite; }
        }

        public string Orden
        {
            get { return codigoOrden; }
            set { this.codigoOrden+= value; }
        }
        public class PaginaLinea
        {
            public enum TipoPaginaLinea
            {
                SubTitulo,
                TituloInicio,
                TituloFin,
                ItemSimple,
                ItemTexto,
                GrupoInicio,
                GrupoFin,
            }

            private string nombre;
            private string resultado;
            private TipoPaginaLinea tipo;

            public TipoPaginaLinea TipoLinea
            {
                get { return tipo; }
                set { this.tipo = value; }
            }

            public string Nombre
            {
                get { return nombre; }
                set { this.nombre += value; }
            }
            public string Resultado
            {
                get { return resultado; }
                set { this.resultado = value; }
            }

        }

    }
}
