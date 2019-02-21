using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Entity.Code.Business
{
    public class Patient : Person
    {
        [Key]
        public int Id { get; set; }

        public string HistoryCode { get; set; }
        public PatientState State { get; set; }

        public enum PatientState
        {
            Normal = 0,
            Gestante = 3,
            Enfermo = 1,
            Terminal = 2
        }

        public bool Validate()
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
            if ((this.Address.Replace(" ", string.Empty) != string.Empty) && !Regex.IsMatch(this.Address, "[A-Za-z0-9]+"))
            {
                throw new Exception("Direcci\x00f3n: Formato incorrecto.");
            }
            return true;
        }
    }
}
