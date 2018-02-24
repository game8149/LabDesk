namespace MinLab.Code.LogicLayer.LogicaTarifario
{
    using MinLab.Code.ControlSistemaInterno;
    using MinLab.Code.DataLayer;
    using MinLab.Code.EntityLayer;
    using MinLab.Code.EntityLayer.ETarifario;
    using MinLab.Code.PresentationLayer;
    using MinLab.Code.PresentationLayer.ComponenteGeneral;
    using System;
    using System.Collections.Generic;

    public class BLTarifario
    {
        public void ActualizarTarifario(Tarifario tar)
        {
            if (tar.Vigente)
            {
                DataAnalisis.UpdTarifarioVigente(tar);
            }
            DataAnalisis.UpdTarifario(tar);
            FormMensaje.Confirmacion(RecursosUIMensajes.MsgTarifarioSave);
        }

        public bool CopiarTarifario(Tarifario tar, int Año, bool Vigente)
        {
            new DataAnalisis();
            if (!DataAnalisis.GetCheckTarifarioByAño(Año))
            {
                Tarifario tarifario = new Tarifario {
                    FechaRegistro = DateTime.Now,
                    Año = Año,
                    Vigente = Vigente
                };
                Dictionary<int, TarifarioDetalle> dictionary = new Dictionary<int, TarifarioDetalle>();
                int key = 0;
                foreach (TarifarioDetalle detalle2 in tar.Listado.Values)
                {
                    TarifarioDetalle detalle = new TarifarioDetalle {
                        IdPaquete = detalle2.IdPaquete,
                        Precio = detalle2.Precio
                    };
                    dictionary.Add(key, detalle);
                    key++;
                }
                tarifario.Listado = dictionary;
                DataAnalisis.AddTarifario(tarifario);
                FormMensaje.Confirmacion(RecursosUIMensajes.MsgTarifarioCopy);
                return true;
            }
            FormMensaje.Advertencia(RecursosUIMensajes.MsgTarifarioNuevoError + tar.Año);
            return false;
        }

        public bool CrearTarifario(int Año, bool Vigente)
        {
            Tarifario tar = null;
            new DataAnalisis();
            if (!DataAnalisis.GetCheckTarifarioByAño(Año))
            {
                tar = new Tarifario {
                    FechaRegistro = DateTime.Now,
                    Año = Año,
                    Vigente = Vigente
                };
                Dictionary<int, TarifarioDetalle> dictionary = new Dictionary<int, TarifarioDetalle>();
                int key = 0;
                foreach (Analisis analisis in ListaAnalisis.GetInstance().Analisis.Values)
                {
                    TarifarioDetalle detalle = new TarifarioDetalle {
                        IdPaquete = analisis.IdData,
                        Precio = 0.0
                    };
                    dictionary.Add(key, detalle);
                    key++;
                }
                tar.Listado = dictionary;
                DataAnalisis.AddTarifario(tar);
                FormMensaje.Confirmacion(RecursosUIMensajes.MsgTarifarioNuevoOk);
                return true;
            }
            FormMensaje.Advertencia(RecursosUIMensajes.MsgTarifarioNuevoError + Año);
            return false;
        }

        public Analisis ObtenerAnalisis(int idAnalisis) => 
            ListaAnalisis.GetInstance().GetAnalisisById(idAnalisis);

        public Dictionary<int, Analisis> ObtenerListadoAnalisis() => 
            ListaAnalisis.GetInstance().Analisis;

        public Dictionary<int, string> ObtenerListadoAno(Dictionary<int, Tarifario> tarifarios)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (Tarifario tarifario in tarifarios.Values)
            {
                dictionary.Add(tarifario.IdData, tarifario.Año.ToString());
            }
            return dictionary;
        }

        public Tarifario ObtenerTarifario() => 
            DataAnalisis.GetTarifarioVigente();

        public TarifarioDetalle ObtenerTarifarioDetalle(Tarifario tar, int idAnalisis)
        {
            foreach (TarifarioDetalle detalle in tar.Listado.Values)
            {
                if (detalle.IdPaquete == idAnalisis)
                {
                    return detalle;
                }
            }
            return null;
        }

        public Tarifario ObtenerTarifarioPorAno(int ano) => 
            DataAnalisis.GetTarifarioAno(ano);

        public Dictionary<int, Tarifario> ObtenerTarifarios() => 
            DataAnalisis.GetTarifarioAll();
    }
}
