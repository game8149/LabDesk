using System.Collections.Generic;

namespace Entity.Code.Analysis.Templates
{
    public class TemplateRow
    {
        public int Id { get; set; }
        public int IdAnalysisTemplate { get; set; }
        public string Code { get; set; }
        public int Index { get; set; }
        public TemplateRowType Type { get; set; }
        public string Name { get; set; }
        public IEnumerable<TemplateRow> Rows { get; set; }
        public TemplateAsk Ask { get; set; }

        public enum TemplateRowType
        {
            Singled,
            Section
        }
    }
}
