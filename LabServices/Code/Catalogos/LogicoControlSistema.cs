namespace MinLab.Code.LogicLayer.LogicaControl
{
    using MinLab.Code.ControlSistemaInterno;
    using MinLab.Code.DataLayer;
    using MinLab.Code.EntityLayer.EFicha;
    using MinLab.Code.PresentationLayer.GUISistema;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class LogicaControlSistema
    {
        public static Stack<string> Navegacion = new Stack<string>();
        private static string Separador = " > ";

        public void ActualizarCuentaLogin(Cuenta cuenta)
        {
            SistemaControl.Instance().Sesion.Cuenta = cuenta;
        }

        public void AperturaAutorizacion(string dni, string autorizacion)
        {
            DataCuenta cuenta = new DataCuenta();
            Cuenta cuentaByDni = null;
            if (!cuenta.CheckExistCuenta(dni))
            {
                throw new Exception("Esa cuenta no est\x00e1 registrada");
            }
            cuentaByDni = cuenta.GetCuentaByDni(dni);
            if (cuentaByDni.Nivel != Sesion.SesionNivel.Administrador)
            {
                throw new Exception("Es necesario tener una cuenta administrador");
            }
            char[] trimChars = new char[] { ' ' };
            char[] chArray2 = new char[] { ' ' };
            if (cuenta.GetSeguridad(cuentaByDni).Trim(trimChars) != autorizacion.Trim(chArray2))
            {
                throw new Exception("Codigo de autorizaci\x00f3n incorrecto.");
            }
            SistemaControl.Instance().Sesion.Pase = true;
        }

        public static void AumentarNivel(string titulo)
        {
            Navegacion.Push(titulo);
        }

        public void CerrarAutorizacion()
        {
            SistemaControl.Instance().Sesion.Pase = false;
        }

        public bool CerrarSesion()
        {
            SistemaControl.Instance().Sesion.Cuenta = null;
            SistemaControl.Instance().Sesion.Nivel = Sesion.SesionNivel.Administrador;
            SistemaControl.Instance().Sesion.Estado = Sesion.SesionEstado.NoLoggin;
            return true;
        }

        public static void DisminuirNivel()
        {
            Navegacion.Pop();
        }

        public bool EsLoggeado() => 
            (SistemaControl.Instance().Sesion.Estado == Sesion.SesionEstado.Loggin);

        public Cuenta GetCuentaLogin() => 
            SistemaControl.Instance().Sesion.Cuenta;

        public bool GetPase() => 
            SistemaControl.Instance().Sesion.Pase;

        public bool IniciarSesion(string dni, string clave)
        {
            DataCuenta cuenta = new DataCuenta();
            Cuenta cuentaByDni = null;
            if (!cuenta.CheckExistCuenta(dni))
            {
                throw new Exception("Esa cuenta no est\x00e1 registrada");
            }
            cuentaByDni = cuenta.GetCuentaByDni(dni);
            char[] trimChars = new char[] { ' ' };
            if (cuentaByDni.Clave.Trim(trimChars) != clave)
            {
                throw new Exception("Contrase\x00f1a Incorrecta");
            }
            SistemaControl.Instance().Sesion.Cuenta = cuentaByDni;
            SistemaControl.Instance().Sesion.Estado = Sesion.SesionEstado.Loggin;
            if (cuentaByDni.Nivel == Sesion.SesionNivel.Administrador)
            {
                SistemaControl.Instance().Sesion.Pase = true;
            }
            else
            {
                SistemaControl.Instance().Sesion.Pase = false;
            }
            return true;
        }

        public static void ReiniciarNavegacion()
        {
            Navegacion.Clear();
        }

        public static string CadenaNavegacion
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                string[] strArray = Navegacion.ToArray();
                for (int i = strArray.Length - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        builder.Append(strArray[i]);
                    }
                    else
                    {
                        builder.Append(strArray[i]).Append(Separador);
                    }
                }
                return builder.ToString();
            }
        }

        public static Principal FormPrincipal
        {
            get => FormPrincipal;          
            set
            {
                FormPrincipal = value;
            }
        }
    }
}
