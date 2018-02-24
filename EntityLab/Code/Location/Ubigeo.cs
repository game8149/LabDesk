using System.ComponentModel.DataAnnotations;

namespace EntityLab.Code.Location
{
    public class Ubigeo
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
