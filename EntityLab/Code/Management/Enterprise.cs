using System.ComponentModel.DataAnnotations;

namespace EntityLab.Code.Management
{
    public class Enterprise
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public byte[] Logo { get; set; }


    }
}
