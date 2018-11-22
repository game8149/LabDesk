using Entity.Code.Base.Documentary;
using System.ComponentModel.DataAnnotations;

namespace Entity.Code.Location
{
    public class Ubigeo : EntityDocument
    {
        [Key]
        public string Id { get; set; }
        public string Description { get; set; }
    }
}
