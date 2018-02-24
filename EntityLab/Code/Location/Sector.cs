using System.ComponentModel.DataAnnotations;

namespace EntityLab.Code.Location
{
    public class Sector
    {
        [Key]
        public int Id { get; set; }
        public string IdUbigeo { get; set; }
        public string Description { get; set; }
    }
}
