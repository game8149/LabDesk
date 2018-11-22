namespace MinLab.Code.LogicLayer
{
    using Entity.Code.Business;
    using Entity.Code.Interfaces;
    using System.Collections.Generic;
    using System.Globalization;

    public class BLMedico
    {
        private IRepositorySimpleRecord<Medic, int> RepoMedic = new MedicRepository();


        public static string FormatearNombre(Medico medico)
        {
            string[] textArray1 = new string[] { medico.Nombre, " ", medico.PrimerApellido, " ", medico.SegundoApellido };
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(string.Concat(textArray1));
        }

        public Dictionary<int, string> ObtenerListaGeneral()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (Medic medico in new DataMedico().GetAllMedico().Values)
            {
                dictionary.Add(medico.IdData, medico.PrimerApellido + " " + medico.SegundoApellido + ", " + medico.Nombre);
            }
            return dictionary;
        }

        public Dictionary<int, string> ObtenerListaHabil()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (Medico medico in new DataMedico().GetAllMedicoHabil().Values)
            {
                dictionary.Add(medico.IdData, FormatearNombre(medico));
            }
            return dictionary;
        }

        public Medico ObtenerMedico(int id) => 
            new DataMedico().GetMedico(id);

        public Dictionary<int, Medico> ObtenerMedico(string nombre, string primerApellido, string segundoApellido, bool habil) => 
            new DataMedico().GetMedicoByFiltro(nombre, primerApellido, segundoApellido, habil);

        public Dictionary<int, Medico> ObtenerMedicosHabil() => 
            new DataMedico().GetAllMedicoHabil();

        
    }
}
