using DataManager.Code.Repositories;
using Entity.Code.Business;
using System.Collections.Generic;
using System.Globalization;

namespace LabServices.Code.Code.Catalog
{
    public class MedicBL
    {
        private MedicRepository RepoMedic = new MedicRepository();

        public static string FormatearNombre(Medic medico)
        {
            string[] textArray1 = new string[] { medico.Names, " ", medico.FirstSurname, " ", medico.LastSurname };
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(string.Concat(textArray1));
        }

        public Dictionary<int, string> ObtenerListaGeneral()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (Medic medico in RepoMedic.List())
            {
                dictionary.Add(medico.Id, medico.FirstSurname + " " + medico.LastSurname + ", " + medico.Names);
            }
            return dictionary;
        }

        public Dictionary<int, string> ObtenerListaHabil()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (Medic medico in RepoMedic.List())
            {
                dictionary.Add(medico.Id, FormatearNombre(medico));
            }
            return dictionary;
        }

        public Medic GetMedic(int id)
        {
            return RepoMedic.Get(id);
        }
        //public Dictionary<int, Medic> ObtenerMedico(string name, string firstSurname, string lastSurname, bool able) =>
        //    RepoMedic.SelectList(name, firstSurname, lastSurname, able);

        //public Dictionary<int, Medico> ObtenerMedicosHabil() =>
        //    new DataMedico().GetAllMedicoHabil();

    }
}
