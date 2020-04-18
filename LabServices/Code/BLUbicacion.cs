using LogicLab.Code.PrintingManager;
using System.Collections.Generic;

namespace LabServices.Code
{

    public class LocationBL
    {
        public static Dictionary<int, string> ObtenerListaDistritos()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (Distrito distrito in Locaciones.GetInstance().Coleccion().Values)
            {
                dictionary.Add(distrito.IdData, distrito.Nombre);
            }
            return dictionary;
        }

        public static Dictionary<int, string> ObtenerListaSectores(int idDistrito)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (Sector sector in Locaciones.GetInstance().GetDistrito(idDistrito).Sectores.Values)
            {
                dictionary.Add(sector.IdData, sector.Nombre);
            }
            return dictionary;
        }
    }
}
