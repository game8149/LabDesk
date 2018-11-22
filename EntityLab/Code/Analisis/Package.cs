using Entity.Code.Base.Documentary;
using System.Collections.Generic;

namespace Entity.Code.Analisis
{
    public class Package : EntityDocument
    {        
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public PackageType Type { get; set; }
        public IEnumerable<int> TemplatesCode { get; set; }
        
        public enum PackageType
        {
            Simple,
            Compuesto,
            Perfil
        }

    }
}
