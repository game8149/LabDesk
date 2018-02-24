namespace EntityLab.Code.Hospital.Analisis.Templates
{
    public abstract class TemplateRow
    {
        public int Id { get; set; }
        public int IdTemplate { get; set; }
        public int Index { get; set; }
        public TemplateRowType TypeRow { get; set; }

        public enum TemplateRowType
        {
            Singled,
            Section
        }
    }
}
