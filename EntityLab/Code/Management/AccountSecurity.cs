using System.ComponentModel.DataAnnotations;

namespace EntityLab.Code.Management
{
    public class AccountSecurity
    {
        [Key]
        public int Id { get; set; }
        public int IdAccount { get; set; }
        public int Level { get; set; }
        public string Code { get; set; }


        public enum AccountSecurityLevel
        {
            Basic=0,
            Administrator=1
        }
    }
}
