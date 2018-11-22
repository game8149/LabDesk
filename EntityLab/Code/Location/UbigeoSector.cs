using Entity.Code.Base.Documentary;
using System.ComponentModel.DataAnnotations;

namespace Entity.Code.Location
{
    public class UbigeoSector : EntityDocument
    {
        [Key]
        public int Id { get; set; }
        public string IdUbigeo { get; set; }
        public string Description { get; set; }
    }
}
