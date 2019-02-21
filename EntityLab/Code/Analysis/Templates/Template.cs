using Entity.Code.Base.Documentary;
using System.Collections.Generic;

namespace Entity.Code.Analysis.Templates
{
    public class Template : EntityDocument
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public IEnumerable<TemplateRow> Rows { get; set; }

    }
}
