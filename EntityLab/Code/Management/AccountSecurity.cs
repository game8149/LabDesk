using Entity.Code.Base.Documentary;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.Code.Management
{
    public class AccountSecurity: EntityDocument
    {
        [Key]
        public int Id { get; set; }
        public int IdAccount { get; set; }
        public AccountSecurityLevel Level { get; set; }
        public string Code { get; set; }
        public DateTime LastUse { get; set; }

        public enum AccountSecurityLevel
        {
            Basic=0,
            Administrator=1
        }
    }
}
