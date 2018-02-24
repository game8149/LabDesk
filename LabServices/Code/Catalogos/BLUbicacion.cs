namespace MinLab.Code.LogicLayer
{
    using MinLab.Code.ControlSistemaInterno;
    using MinLab.Code.EntityLayer.EUbicacion;
    using System;
    using System.Collections.Generic;

    public class BLUbicacion
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
