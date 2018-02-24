using EntityLab.Code.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLab.Code.Actors
{
    public class Person : EntityDocument
    {
        [Key]
        public int Id { get; set; }

        public string IdDocumentType { get; set; }
        
        public string DocumentNumber { get; set; }

        public string Names { get; set; }

        public string FirstSurname { get; set; }

        public string LastSurname { get; set; }

        public DateTime BirthDate { get; set; }

        public string IdOriginalUbigeo { get; set; }

        public string IdCurrentUbigeo { get; set; }

        public string IdSector { get; set; }

        public SexType Sex { get; set; }

        public enum SexType
        {
            Men,
            Women
        }
    }
}
