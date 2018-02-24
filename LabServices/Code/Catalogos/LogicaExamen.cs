namespace MinLab.Code.LogicLayer.LogicaExamen
{
    using MinLab.Code.ControlSistemaInterno;
    using MinLab.Code.DataLayer;
    using MinLab.Code.EntityLayer.EExamen;
    using MinLab.Code.EntityLayer.EOrden;
    using MinLab.Code.EntityLayer.EPlantilla;
    using MinLab.Code.LogicLayer.BLPrueba;
    using System;
    using System.Collections.Generic;

    public class LogicaExamen
    {
        public void GenerarExamenes(Orden orden)
        {
            Dictionary<int, Examen> examenes = new Dictionary<int, Examen>();
            int key = 0;
            foreach (OrdenDetalle detalle2 in orden.Detalle.Values)
            {
                if (!DataExamen.ExistenExamenes(detalle2))
                {
                    foreach (int num2 in ListaAnalisis.GetInstance().GetAnalisisById(detalle2.IdDataPaquete).PlantillasId)
                    {
                        Examen examen = new Examen {
                            Estado = Examen.EstadoExamen.EnProceso,
                            FechaFinalizado = DateTime.Now,
                            FechaRegistro = DateTime.Now,
                            UltimaModificacion = DateTime.Now,
                            IdOrdenDetalle = detalle2.IdData,
                            IdPlantilla = num2,
                            IdCuenta = SistemaControl.Instance().Sesion.Cuenta.IdData,
                            IdData = 0,
                            DetallesByItem = new Dictionary<int, ExamenDetalle>()
                        };
                        int num3 = 0;
                        foreach (PlantillaItem item in BLPlantilla.GetAllItemsByPlantilla(num2).Values)
                        {
                            ExamenDetalle detalle = new ExamenDetalle {
                                IdItem = item.IdData,
                                Campo = item.PorDefault
                            };
                            examen.DetallesByItem.Add(num3, detalle);
                            num3++;
                        }
                        examenes.Add(key, examen);
                        key++;
                    }
                }
            }
            DataExamen.AddExamen(examenes);
        }

        public bool GuardarExamen(Examen ex)
        {
            ex.IdCuenta = SistemaControl.Instance().Sesion.Cuenta.IdData;
            if (ex.Estado == Examen.EstadoExamen.Terminado)
            {
                ex.FechaFinalizado = DateTime.Now;
            }
            DataExamen.GuardarExamen(ex);
            return true;
        }

        public Dictionary<int, Examen> RecuperarExamenes(Orden orden)
        {
            Dictionary<int, Examen> examenesByOrdenDetalle = null;
            foreach (OrdenDetalle detalle in orden.Detalle.Values)
            {
                if (examenesByOrdenDetalle == null)
                {
                    examenesByOrdenDetalle = DataExamen.GetExamenesByOrdenDetalle(detalle);
                }
                else
                {
                    foreach (Examen examen in DataExamen.GetExamenesByOrdenDetalle(detalle).Values)
                    {
                        examenesByOrdenDetalle.Add(examen.IdData, examen);
                    }
                }
            }
            return examenesByOrdenDetalle;
        }

        public bool ValidarExamenes(Examen examen)
        {
            new Clasificador().Controlar(examen);
            return true;
        }
    }
}
