
using Entity.Code.Management;
using System;

namespace LogicLab.Code
{
    public class Sesion
    {
        private Account cuentaActual;
        private SesionEstado estado;
        private DateTime horaInicio;
        private SesionNivel nivel;
        private bool permiso;

        public void Login(Account cuenta)
        {
            this.cuentaActual = cuenta;
            this.horaInicio = DateTime.Now;
        }

        public void Logout()
        {
            this.cuentaActual = null;
            this.horaInicio = DateTime.MinValue;
            this.permiso = false;
        }

        public MinLab.Code.EntityLayer.EFicha.Cuenta Cuenta
        {
            get => 
                this.cuentaActual;
            set
            {
                this.horaInicio = DateTime.Now;
                this.cuentaActual = value;
            }
        }

        public SesionEstado Estado
        {
            get => 
                this.estado;
            set
            {
                this.estado = value;
            }
        }

        public DateTime HoraInicio =>
            this.horaInicio;

        public SesionNivel Nivel
        {
            get => 
                this.nivel;
            set
            {
                this.nivel = value;
            }
        }

        public bool Pase
        {
            get => 
                this.permiso;
            set
            {
                this.permiso = value;
            }
        }

        public enum SesionEstado
        {
            NoLoggin,
            Loggin
        }

        public enum SesionNivel
        {
            Administrador,
            Usuario
        }
    }
}
