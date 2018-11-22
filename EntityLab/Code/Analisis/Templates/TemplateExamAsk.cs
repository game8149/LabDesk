using System.Collections.Generic;

namespace Entity.Code.Analisis.Templates
{
    public class TemplateExamAsk
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string DefaultValue { get; set; }
        public TemplateAskType TypeAsk { get; set; }
        public TemplateAskDataType TypeAskResult { get; set; }
        public IEnumerable<TemplateExamAskData> DataList { get; set; }
        public bool TieneUnidad { get; set; }
        public string Unidad { get; set; }
        


        public enum TemplateAskDataType
        {
            Bool,
            Integer,
            String,
            Decimal,
            Date
        }

        public enum TemplateAskType
        {
            Input,
            List,
            Text
        }
         
    }
}
