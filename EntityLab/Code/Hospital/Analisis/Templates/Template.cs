using EntityLab.Code.Base;
using System.Collections.Generic;

namespace EntityLab.Code.Hospital.Analisis.Templates
{
    public class Template : EntityDocument
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public IEnumerable<TemplateRow> Rows { get; set; }


    }
}
