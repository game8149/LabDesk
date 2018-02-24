namespace EntityLab.Code.Hospital.Analisis.Templates
{
    public class TemplateAsk: TemplateRow
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string DefaultValue { get; set; }
        public TemplateAskType TypeAsk { get; set; }
        public TemplateAskTypeResult TypeAskResult { get; set; }
        public bool TieneUnidad { get; set; }
        public string Unidad { get; set; }
        


        public enum TemplateAskTypeResult
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
