using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Entity.Code.Business
{
    public class Medic : Person
    {

        [Key]
        public int Id { get; set; }

        public string CodigoColegiatura { get; set; }

        public string IdEspecialidad { get; set; }
        public bool Habil { get; set; }
        public DateTime FechaIngreso{ get; set; }
        
        public bool ValidarDatos(Medic medico)
        {
            char[] trimChars = new char[] { ' ' };
            if (medico.CodigoColegiatura.Trim(trimChars) == string.Empty)
            {
                throw new Exception("Colegiatura: Es un campo obligatorio");
            }
            char[] chArray2 = new char[] { ' ' };
            if (medico.Names.Trim(chArray2) == string.Empty)
            {
                throw new Exception("Nombre: Es un campo obligatorio");
            }
            char[] chArray3 = new char[] { ' ' };
            if (medico.FirstSurname.Trim(chArray3) == string.Empty)
            {
                throw new Exception("Primer Apellido: Es un campo obligatorio");
            }
            char[] chArray4 = new char[] { ' ' };
            if (medico.LastSurname.Trim(chArray4) == string.Empty)
            {
                throw new Exception("Segundo Apellido: Es un campo obligatorio");
            }
            char[] chArray5 = new char[] { ' ' };
            if (medico.IdEspecialidad.Trim(chArray5) == string.Empty)
            {
                throw new Exception("Especialidad: Es un campo obligatorio");
            }
            if (!Regex.IsMatch(medico.Names + medico.FirstSurname + medico.LastSurname, "([A-Za-z]|' ')+"))
            {
                throw new Exception("Nombre y Apellidos: Solo caracteres alfabeticos");
            }
            return true;
        }
    }
}
