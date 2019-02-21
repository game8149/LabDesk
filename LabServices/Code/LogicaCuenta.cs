namespace MinLab.Code.LogicLayer
{
    using MinLab.Code.ControlSistemaInterno;
    using MinLab.Code.DataLayer;
    using MinLab.Code.DataLayer.Recursos;
    using MinLab.Code.EntityLayer.EFicha;
    using MinLab.Code.LogicLayer.LogicaControl;
    using MinLab.Code.PresentationLayer;
    using MinLab.Code.PresentationLayer.ComponenteGeneral;
    using System;
    using System.Text.RegularExpressions;

    internal class LogicaCuenta
    {
        public bool ActualizarClave(Cuenta cuenta, string nuevaClave, string antiguaClave)
        {
            LogicaControlSistema sistema = new LogicaControlSistema();
            DataCuenta cuenta2 = new DataCuenta();
            if (cuenta.Clave.Trim() != antiguaClave.Trim())
            {
                FormMensaje.Advertencia(RecursosUIMensajes.MsgCuentaValidation1);
                return false;
            }
            if (!Regex.IsMatch(nuevaClave, "[A-Za-z0-9]+"))
            {
                FormMensaje.Advertencia(RecursosUIMensajes.MsgCuentaValidation1);
                return false;
            }
            if (nuevaClave.Length < 8)
            {
                FormMensaje.Advertencia(RecursosUIMensajes.MsgCuentaValidation3);
                return false;
            }
            cuenta.Clave = nuevaClave;
            cuenta2.UpdClave(cuenta);
            FormMensaje.Confirmacion(RecursosUIMensajes.MsgCuentaUpdate);
            sistema.GetCuentaLogin().Clave = nuevaClave;
            return true;
        }

        public void ActualizarCuenta(Cuenta cuenta)
        {
            DataCuenta cuenta2 = new DataCuenta();
            this.ValidarDatos(cuenta);
            LogicaControlSistema sistema1 = new LogicaControlSistema();
            if ((sistema1.GetCuentaLogin().Dni != cuenta.Dni) && cuenta2.CheckExistCuenta(cuenta.Dni))
            {
                throw new Exception("Ya existe una cuenta para ese DNI");
            }
            cuenta2.UpdCuenta(cuenta);
            FormMensaje.Confirmacion(RecursosUIMensajes.MsgCuentaUpdate);
            sistema1.GetCuentaLogin().Dni = cuenta.Dni;
            sistema1.GetCuentaLogin().Nombre = cuenta.Nombre;
            sistema1.GetCuentaLogin().PrimerApellido = cuenta.PrimerApellido;
            sistema1.GetCuentaLogin().SegundoApellido = cuenta.SegundoApellido;
            sistema1.GetCuentaLogin().Especialidad = cuenta.Especialidad;
            sistema1.GetCuentaLogin().CodigoPro = cuenta.CodigoPro;
        }

        public bool CrearCuenta(Cuenta cuenta, string autorizacion)
        {
            this.ValidarDatos(cuenta);
            if (!autorizacion.Equals(CuentaMaestra.CodigoMaestro))
            {
                throw new Exception("Codigo Maestro Incorrecto");
            }
            DataCuenta cuenta1 = new DataCuenta();
            if (cuenta1.CheckExistCuenta(cuenta.Dni))
            {
                throw new Exception("Ya existe una cuenta para ese DNI");
            }
            cuenta.Nivel = Sesion.SesionNivel.Usuario;
            cuenta1.AddCuenta(cuenta);
            return true;
        }

        public Cuenta ObtenerCuenta(int id) => 
            new DataCuenta().GetCuentaById(id);

        public Cuenta ObtenerCuenta(string dni) => 
            new DataCuenta().GetCuentaByDni(dni);

        private bool ValidarDatos(Cuenta cuenta)
        {
            if (!Regex.IsMatch(cuenta.Dni, "[0-9]+"))
            {
                throw new Exception("DNI: Formato incorrecto");
            }
            if (!Regex.IsMatch(cuenta.Clave, "[A-Za-z0-9]+"))
            {
                throw new Exception("Clave: Formato incorrecto");
            }
            if (cuenta.Clave.Length < 8)
            {
                throw new Exception("Clave: Debe tener mas de 8 caracteres.");
            }
            if (!Regex.IsMatch(cuenta.Nombre + cuenta.PrimerApellido + cuenta.SegundoApellido, "([A-Za-z]|' ')+"))
            {
                throw new Exception("Nombre y Apellidos: Formato incorrecto");
            }
            return true;
        }
    }
}
