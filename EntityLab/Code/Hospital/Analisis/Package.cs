using EntityLab.Code.Base;
using System.Collections.Generic;

namespace EntityLab.Code.Hospital.Analisis
{
    public class Package : EntityDocument
    {        
        public string Id { get; set; }
        public string Nombre { get; set; }
        public PackageType Type { get; set; }
        public IEnumerable<int> TemplatesId { get; set; }
        
        public enum PackageType
        {
            Simple,
            Compuesto,
            Perfil
        }

    }
}
