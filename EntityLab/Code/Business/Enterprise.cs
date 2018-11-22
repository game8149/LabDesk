using Entity.Code.Base.Documentary;
using System.ComponentModel.DataAnnotations;

namespace Entity.Code.Business
{
    public class Enterprise : EntityDocument
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public byte[] Logo { get; set; }


    }
}
