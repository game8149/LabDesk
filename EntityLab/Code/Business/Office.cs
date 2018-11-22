using Entity.Code.Base.Documentary;
using System.ComponentModel.DataAnnotations;

namespace Entity.Code.Business
{
    public class Office : EntityDocument
    {
        [Key]
        public string Id { get; set; }
        public string Nombre { get; set; }
    }
}
