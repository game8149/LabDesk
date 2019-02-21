using System.Collections.Generic;

namespace Entity.Code.Analysis.Templates
{
    public class TemplateAsk
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string DefaultValue { get; set; }
        public AnalysisTemplateAskType Type { get; set; }
        public AnalysisTemplateAskDataType DataType { get; set; }
        public IEnumerable<TemplateAskData> DataList { get; set; }
        public bool HasUnit { get; set; }
        public string Unit { get; set; }
         
        public enum AnalysisTemplateAskDataType
        {
            Bool,
            Integer,
            String,
            Decimal,
            Date
        }

        public enum AnalysisTemplateAskType
        {
            Input,
            List,
            Text
        }

    }

    public class TemplateAskData
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
    }
}
