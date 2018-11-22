using Entity.Code.Base.Documentary;

namespace Entity.Code.Analisis
{
    public class ExamResultDetail : EntityDocument
    {
        public int Id { get; set; }
        public int IdTemplateExamAsk { get; set; }
        public string Value { get; set; }
    }
}
