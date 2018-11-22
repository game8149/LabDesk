using Entity.Code.Base.Documentary;
using System.Collections.Generic;

namespace Entity.Code.Analisis
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

        public IDictionary<int, ExamOrderDetail> Items { get; set; }
    }
}
