using System.Collections.Generic;

namespace EntityLab.Code.Hospital.Analisis.Templates
{
    public class TemplateList : TemplateAsk
    {

        public IEnumerable<TemplateListOption> Items { get; set; }

       
        public class TemplateListOption
        {
            public int Index { get; set; }
            public string Name { get; set; }
        }

    }
}
