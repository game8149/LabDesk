using System.ComponentModel.DataAnnotations;

namespace EntityLab.Code.Hospital
{
    public class Office
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
