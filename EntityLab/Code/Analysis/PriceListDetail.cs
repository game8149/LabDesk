using Entity.Code.Base.Documentary;
using System.ComponentModel.DataAnnotations;

namespace Entity.Code.Analysis
{
    public class PriceListDetail : EntityDocument
    {
        [Key]
        public int Id { get; set; }

        public int IdPriceList { get; set; }
        public int IdPackage { get; set; }
        public decimal Price { get; set; }
        
    }
}
