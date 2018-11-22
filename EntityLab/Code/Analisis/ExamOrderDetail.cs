using Entity.Code.Base.Documentary;

namespace Entity.Code.Analisis
{
    public class ExamOrderDetail : EntityDocument
    {
        public int Id { get; set; }
        public int Cobertura { get; set; }
        public int IdPackage { get; set; }
        public decimal Price { get; set; }        
    }
}
