using DataManager.Code.Repositories;
using Entity.Code.Analysis;
using System.Collections.Generic;

namespace LabServices.Code
{
    public class PriceListBL
    {
        private PriceListRepository PriceList = new PriceListRepository();

        public void ActualizarPriceList(PriceList tar)
        {
            //if (tar.Active)
            //{
            //    PriceList.UpdPriceListVigente(tar);
            //}
            //DataAnalisis.UpdPriceList(tar);
            //FormMensaje.Confirmacion(RecursosUIMensajes.MsgPriceListSave);
        }

        public bool CopiarPriceList(PriceList tar, int Año, bool Vigente)
        {
            //    new DataAnalisis();
            //    if (!DataAnalisis.GetCheckPriceListByAño(Año))
            //    {
            //        PriceList PriceList = new PriceList
            //        {
            //            FechaRegistro = DateTime.Now,
            //            Año = Año,
            //            Vigente = Vigente
            //        };
            //        Dictionary<int, PriceListDetalle> dictionary = new Dictionary<int, PriceListDetalle>();
            //        int key = 0;
            //        foreach (PriceListDetalle detalle2 in tar.Listado.Values)
            //        {
            //            PriceListDetalle detalle = new PriceListDetalle
            //            {
            //                IdPaquete = detalle2.IdPaquete,
            //                Precio = detalle2.Precio
            //            };
            //            dictionary.Add(key, detalle);
            //            key++;
            //        }
            //        PriceList.Listado = dictionary;
            //        DataAnalisis.AddPriceList(PriceList);
            //        FormMensaje.Confirmacion(RecursosUIMensajes.MsgPriceListCopy);
            //        return true;
            //    }
            //    FormMensaje.Advertencia(RecursosUIMensajes.MsgPriceListNuevoError + tar.Año);
            return false;
        }

        public bool CrearPriceList(int Año, bool Vigente)
        {
            PriceList tar = null; 
            //if (!DataAnalisis.GetCheckPriceListByAño(Año))
            //{
            //    tar = new PriceList
            //    {
            //        FechaRegistro = DateTime.Now,
            //        Año = Año,
            //        Vigente = Vigente
            //    };
            //    Dictionary<int, PriceListDetalle> dictionary = new Dictionary<int, PriceListDetalle>();
            //    int key = 0;
            //    foreach (Analisis analisis in ListaAnalisis.GetInstance().Analisis.Values)
            //    {
            //        PriceListDetalle detalle = new PriceListDetalle
            //        {
            //            IdPaquete = analisis.IdData,
            //            Precio = 0.0
            //        };
            //        dictionary.Add(key, detalle);
            //        key++;
            //    }
            //    tar.Listado = dictionary;
            //    DataAnalisis.AddPriceList(tar);
            //    FormMensaje.Confirmacion(RecursosUIMensajes.MsgPriceListNuevoOk);
            //    return true;
            //}
            //FormMensaje.Advertencia(RecursosUIMensajes.MsgPriceListNuevoError + Año);
            return false;
        }

        //public Analisis ObtenerAnalisis(int idAnalisis) =>
        //    ListaAnalisis.GetInstance().GetAnalisisById(idAnalisis);

        //public Dictionary<int, Analisis> ObtenerListadoAnalisis() =>
        //    ListaAnalisis.GetInstance().Analisis;

        public Dictionary<int, string> ObtenerListadoAno(Dictionary<int, PriceList> PriceLists)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (PriceList PriceList in PriceLists.Values)
            {
                dictionary.Add(PriceList.Id, PriceList.Year.ToString());
            }
            return dictionary;
        }

        //public PriceList ObtenerPriceList() =>
        //    DataAnalisis.GetPriceListVigente();

        public PriceListDetail ObtenerPriceListDetalle(PriceList tar, int idAnalisis)
        {
            foreach (PriceListDetail detalle in tar.Items)
            {
                if (detalle.IdPackage == idAnalisis)
                {
                    return detalle;
                }
            }
            return null;
        }

        //public PriceList ObtenerPriceListPorAno(int ano) =>
        //    DataAnalisis.GetPriceListAno(ano);

        //public Dictionary<int, PriceList> ObtenerPriceLists() =>
        //    DataAnalisis.GetPriceListAll();
    }
}
