namespace MinLab.Code.LogicLayer
{
    using DataManager.Code.Repositories;
    using Entity.Code.Management;
    using System;
    using System.Text.RegularExpressions;

    internal class AccountBL
    {
        public bool UpdatePassword(Account cuenta, string nuevaClave, string antiguaClave)
        {
            LogicaControlSistema sistema = new LogicaControlSistema();
            DataAccount cuenta2 = new DataAccount();
            if (cuenta.Password.Trim() != antiguaClave.Trim())
            {
                //FormMensaje.Advertencia(RecursosUIMensajes.MsgAccountValidation1);
                return false;
            }
            if (!Regex.IsMatch(nuevaClave, "[A-Za-z0-9]+"))
            {
                //FormMensaje.Advertencia(RecursosUIMensajes.MsgAccountValidation1);
                return false;
            }
            if (nuevaClave.Length < 8)
            {
                //FormMensaje.Advertencia(RecursosUIMensajes.MsgAccountValidation3);
                return false;
            }
            cuenta.Password = nuevaClave;
            cuenta2.UpdClave(cuenta);
            //FormMensaje.Confirmacion(RecursosUIMensajes.MsgAccountUpdate);
            sistema.GetAccountLogin().Clave = nuevaClave;
            return true;
        }

        public void ActualizarAccount(Account cuenta)
        {
            AccountRepository cuenta2 = new AccountRepository();
            this.ValidarDatos(cuenta);
            LogicaControlSistema sistema1 = new LogicaControlSistema();
            if ((sistema1.GetAccountLogin().Id != cuenta.Id) && cuenta2.CheckExistAccount(cuenta.Id))
            {
                throw new Exception("Ya existe una cuenta para ese DNI");
            }
            cuenta2.Update(cuenta);
            FormMensaje.Confirmacion(RecursosUIMensajes.MsgAccountUpdate);
            sistema1.GetAccountLogin().Dni = cuenta.;
            sistema1.GetAccountLogin().Nombre = cuenta.Nombre;
            sistema1.GetAccountLogin().PrimerApellido = cuenta.PrimerApellido;
            sistema1.GetAccountLogin().SegundoApellido = cuenta.SegundoApellido;
            sistema1.GetAccountLogin().Especialidad = cuenta.Especialidad;
            sistema1.GetAccountLogin().CodigoPro = cuenta.CodigoPro;
        }

        public bool CrearAccount(Account cuenta, string autorizacion)
        {
            this.ValidarDatos(cuenta);
            if (!autorizacion.Equals(AccountMaestra.CodigoMaestro))
            {
                throw new Exception("Codigo Maestro Incorrecto");
            }
            DataAccount cuenta1 = new DataAccount();
            if (cuenta1.CheckExistAccount(cuenta.Dni))
            {
                throw new Exception("Ya existe una cuenta para ese DNI");
            }
            cuenta.Nivel = Sesion.SesionNivel.Usuario;
            cuenta1.AddAccount(cuenta);
            return true;
        }

        public Account GetAccount(int id) => 
            new DataAccount().GetAccountById(id);

        public Account ObtenerAccount(string dni) => 
            new DataAccount().GetAccountByDni(dni);

        private bool ValidarDatos(Account cuenta)
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
