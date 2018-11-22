using System.Collections.Generic;

namespace Entity.Code.Analisis.Templates
{
    public abstract class TemplateExamRow
    {        
        public string CodeExam { get; set; } 
        public int Indexed { get; set; }
        public TemplateRowType TypeRow { get; set; }
        public string Name { get; set; }
        public IEnumerable<TemplateExamRow> Rows { get; set; }
        public TemplateExamAsk Ask { get; set; } 

        public enum TemplateRowType
        {
            Singled,
            Section
        }
    }
}
