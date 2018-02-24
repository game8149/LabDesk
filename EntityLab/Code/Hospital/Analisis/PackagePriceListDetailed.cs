using EntityLab.Code.Base;

namespace EntityLab.Code.Hospital.Analisis.Pricing
{
    public class PackagePriceListDetailed : EntityDocument
    {
        public int Id { get; set; }        
        public int IdPackage { get; set; }
        public decimal Price { get; set; }
        
    }
}
