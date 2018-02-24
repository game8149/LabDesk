using EntityLab.Code.Base;
using System.Collections.Generic;

namespace EntityLab.Code.Hospital.Analisis
{

    public class ExamOrder : EntityDocumentState
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string DocumentNumberAssociated { get; set; }
        public int IdPaciente { get; set; }                
        public bool EnGestacion { get; set; }  
        public int IdHospitalOffice { get; set; }
        public int IdMedic { get; set; }

        public IDictionary<int, ExamOrderDetailed> Items { get; set; }
    }
}
