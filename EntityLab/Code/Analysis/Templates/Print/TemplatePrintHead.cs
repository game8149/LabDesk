using System;

namespace Entity.Code.Analysis.Templates.Print
{
    public class TemplatePrintHead
    {
        private string area = "Laboratorio:    ";
        private string codigoOrden = "Orden:   ";
        private string direccion = "Mz. 33 - Lote 2 - Sector 2 - Tel. 270307";
        private string doctor = "Solicita:   ";
        private string edadPaciente = "Edad:   ";
        private string estado = "Ult. Rev:   ";
        private string fechaEmite = ("Emision:  " + DateTime.Now.ToShortDateString());
        private string hcPaciente = "Historia: ";
        private string institucion = "CENTRO DE SALUD WICHANZAO";
        private string nombrePaciente = "Paciente: ";
        private int numero;
        private string responsable = "Responsable: ";

        public string Area
        {
            get =>
                this.area;
            set
            {
                this.area = value;
            }
        }

        public string Direccion
        {
            get =>
                this.direccion;
            set
            {
                this.direccion = value;
            }
        }

        public string Doctor
        {
            get =>
                this.doctor;
            set
            {
                this.doctor = this.doctor + value;
            }
        }

        public string Edad
        {
            get =>
                this.edadPaciente;
            set
            {
                this.edadPaciente = this.edadPaciente + value;
            }
        }

        public string Fecha =>
            this.fechaEmite;

        public string Historia
        {
            get =>
                this.hcPaciente;
            set
            {
                this.hcPaciente = this.hcPaciente + value;
            }
        }

        public string Institucion
        {
            get =>
                this.institucion;
            set
            {
                this.institucion = value;
            }
        }

        public string Nombre
        {
            get =>
                this.nombrePaciente;
            set
            {
                this.nombrePaciente = this.nombrePaciente + value;
            }
        }

        public int Numero
        {
            get =>
                this.numero;
            set
            {
                this.numero = value;
            }
        }

        public string Orden
        {
            get =>
                this.codigoOrden;
            set
            {
                this.codigoOrden = this.codigoOrden + value;
            }
        }

        public string Responsable
        {
            get =>
                this.responsable;
            set
            {
                this.responsable = this.responsable + value;
            }
        }

        public string UltimaRev
        {
            get =>
                this.estado;
            set
            {
                this.estado = this.estado + value;
            }
        }
    }
}
