using EntityLab.Code.Actors;
using System;
using System.Text.RegularExpressions;

namespace EntityLab.Code.Hospital
{
    public class Paciente : Person
    {
        public string CodigoHistoria { get; set; }
        public string Direccion { get; set; }
        public CurrentState Estado { get; set; }

        public enum CurrentState
        {
            Normal,
            Gestante
        }


        public bool Validar()
        {
            if (this.DocumentNumber.Replace(" ", string.Empty) == string.Empty)
            {
                throw new Exception("DNI: Es necesario especificarlo.");
            }
            if (!Regex.IsMatch(this.DocumentNumber, "[0-9]+"))
            {
                throw new Exception("DNI: Formato incorrecto.");
            }
            if (this.FirstSurname.Replace(" ", string.Empty) == string.Empty)
            {
                throw new Exception("Primer Apellido: Es necesario especificarlo.");
            }
            if (!Regex.IsMatch(this.FirstSurname, "[A-Za-z]+"))
            {
                throw new Exception("Primer Apellido: Formato incorrecto.");
            }
            if (this.FirstSurname.Replace(" ", string.Empty) == string.Empty)
            {
                throw new Exception("Primer Apellido: Es necesario especificarlo.");
            }
            if (!Regex.IsMatch(this.LastSurname, "[A-Za-z]+"))
            {
                throw new Exception("Segundo Apellido: Formato incorrecto.");
            }
            if ((this.Direccion.Replace(" ", string.Empty) != string.Empty) && !Regex.IsMatch(this.Direccion, "[A-Za-z0-9]+"))
            {
                throw new Exception("Direcci\x00f3n: Formato incorrecto.");
            }
            return true;
        }
    }
}
