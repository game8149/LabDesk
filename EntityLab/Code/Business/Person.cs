using Entity.Code.Base.Documentary;
using System;

namespace Entity.Code.Business
{
    public class Person : EntityDocument
    { 

        public string IdDocumentType { get; set; }
        
        public string DocumentNumber { get; set; }

        public string Names { get; set; }

        public string FirstSurname { get; set; }

        public string LastSurname { get; set; }

        public DateTime BirthDate { get; set; }

        public string IdOriginalUbigeo { get; set; }

        public string IdCurrentUbigeo { get; set; }

        public string IdSector { get; set; }

        public string Address { get; set; }

        public SexType Sex { get; set; }

        public enum SexType
        {
            Man,
            Woman
        }
    }
}
