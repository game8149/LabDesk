using System.ComponentModel.DataAnnotations;

namespace EntityLab.Code.Management
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string Tag { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public AccountSecurity Security { get; set; }

    }
}
