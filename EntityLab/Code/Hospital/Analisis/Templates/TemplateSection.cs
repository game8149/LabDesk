using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLab.Code.Hospital.Analisis.Templates
{
    public class TemplateSection: TemplateRow
    {
        public string Name { get; set; }
        public IEnumerable<TemplateRow> Asks { get; set; }
        
    }
}
