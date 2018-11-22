using Entity.Code.Base.Documentary;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.Code.Management
{
    public class Account : EntityDocument
    {
        [Key]
        public int Id { get; set; }
        public string Tag { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime LastLogin { get; set; }

        public AccountSecurity CurrentSecurity { get; set; }

    }
}
