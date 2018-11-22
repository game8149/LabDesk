using Entity.Code.Base;
using System.Collections.Generic;

namespace Entity.Code.Analisis.Templates
{
    public class TemplateExam : EntityDocument
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<TemplateExamRow> Rows { get; set; }


    }
}
