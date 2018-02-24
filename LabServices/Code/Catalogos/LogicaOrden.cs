using DataManager.Repositories;
using EntityLab.Code.Hospital.Analisis;
using EntityLab.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static EntityLab.Code.Base.EntityDocumentState;

namespace MinLab.Code.LogicLayer.LogicaTarifario
{
    public class LogicaOrden
    {
        private IRepositoryDetailedRecord<ExamOrder, ExamOrderDetailed, int> repoExamOrder = new ExamOrderRepository();

        public void ActualizarOrden(ExamOrder orden)
        {
            repoExamOrder.Update(orden);
        }

        //public bool ActualizarOrden(Dictionary<int, Examen> examenes, ExamOrder orden)
        //{
        //    int num = 0;
        //    using (Dictionary<int, Examen>.ValueCollection.Enumerator enumerator = examenes.Values.GetEnumerator())
        //    {
        //        while (enumerator.MoveNext())
        //        {
        //            if (enumerator.Current.Estado == Examen.EstadoExamen.Terminado)
        //            {
        //                num++;
        //            }
        //        }
        //    }
        //    if (num == examenes.Count)
        //    {
        //        orden.Estado = ExamOrder.EstadoOrden.Finalizado;
        //    }
        //    else
        //    {
        //        orden.Estado = ExamOrder.EstadoOrden.EnProceso;
        //    }
        //    this.ActualizarOrden(orden);
        //    return true;
        //}

       
        public void AgregarOrden(ExamOrder orden)
        {
            MinLab.Code.LogicLayer.LogicaExamen.LogicaExamen examen = new MinLab.Code.LogicLayer.LogicaExamen.LogicaExamen();
            orden.Estado = ExamOrder.EstadoOrden.EnProceso;
            int id = new DataOrden().CrearOrdenToBD(orden);
            orden = this.ObtenerOrden(id);
            examen.GenerarExamenes(orden);
            Dictionary<int, Examen> examenes = examen.RecuperarExamenes(orden);
            this.ActualizarOrden(examenes, orden);
        }

        public void AgregarOrdenDetalle(ExamOrder orden)
        {
            if (orden.Detalle.Count > 0)
            {
                MinLab.Code.LogicLayer.LogicaExamen.LogicaExamen examen = new MinLab.Code.LogicLayer.LogicaExamen.LogicaExamen();
                DataOrden orden1 = new DataOrden();
                orden1.AgregarOrdenDetalleFromBD(orden);
                orden = orden1.ObtenerOrdenFromBD(orden.IdData);
                examen.GenerarExamenes(orden);
                Dictionary<int, Examen> examenes = examen.RecuperarExamenes(orden);
                this.ActualizarOrden(examenes, orden);
            }
        }

        public void EliminarOrden(ExamOrder orden)
        {
            new DataOrden().EliminarOrdenFromBD(orden);
        }

        public void EliminarOrdenDetalle(ExamOrder orden)
        {
            if (orden.Detalle.Count > 0)
            {
                new DataOrden().EliminarOrdenDetalleFromBD(orden);
            }
        }

        public string ObtenerDescripcion(ExamOrder orden)
        {
            StringBuilder builder = new StringBuilder();
            foreach (OrdenDetalle detalle in orden.Detalle.Values)
            {
                builder.Append("- ").Append(ListaAnalisis.GetInstance().Analisis[detalle.IdDataPaquete].Nombre).Append("\n ");
            }
            return builder.ToString();
        }

        public ExamOrder ObtenerOrden(int Id) => 
            new DataOrden().ObtenerOrdenFromBD(Id);

        public Dictionary<int, ExamOrder> ObtenerOrdenesByFechaByEstado(DateTime init, DateTime end, DocumentState estado) => 
            new DataOrden().GetAllOrdenByFechaByEstado(init, end, estado);

        public Dictionary<int, ExamOrder> ObtenerOrdenesByPacienteByFechaByEstado(Paciente paciente, DateTime init, DateTime end, ExamOrder.EstadoOrden estado) => 
            new DataOrden().GetAllOrdenByPacienteByFechaByEstado(paciente, init, end, estado);

        public Dictionary<int, Dictionary<int, int>> ObtenerReporteAcumuladoMensual(int año, int mes)
        {
            DataOrden orden = new DataOrden();
            Dictionary<int, Dictionary<int, int>> dictionary = new Dictionary<int, Dictionary<int, int>>();
            foreach (int num in DataEstaticaGeneral.CoberturaTipos.Keys)
            {
                dictionary.Add(num, orden.GetReporteAcumuladoFromDB(num, año, mes));
            }
            return dictionary;
        }

        public Dictionary<int, Dictionary<int, int>> ObtenerReporteAcumuladoMensual(int año, int mes, int idMedico)
        {
            DataOrden orden = new DataOrden();
            Dictionary<int, Dictionary<int, int>> dictionary = new Dictionary<int, Dictionary<int, int>>();
            foreach (int num in DataEstaticaGeneral.CoberturaTipos.Keys)
            {
                dictionary.Add(num, orden.GetReporteAcumuladoFromDB(num, año, mes, idMedico));
            }
            return dictionary;
        }

        public Dictionary<int, Dictionary<int, int>> ObtenerReporteCantidadMensual(int año, int mes)
        {
            DataOrden orden = new DataOrden();
            Dictionary<int, Dictionary<int, int>> dictionary = new Dictionary<int, Dictionary<int, int>>();
            foreach (int num in DataEstaticaGeneral.CoberturaTipos.Keys)
            {
                dictionary.Add(num, orden.GetReporteCantidadFromDB(num, año, mes));
            }
            return dictionary;
        }

        public Dictionary<int, Dictionary<int, int>> ObtenerReporteCantidadMensual(int año, int mes, int idMedico)
        {
            DataOrden orden = new DataOrden();
            Dictionary<int, Dictionary<int, int>> dictionary = new Dictionary<int, Dictionary<int, int>>();
            foreach (int num in DataEstaticaGeneral.CoberturaTipos.Keys)
            {
                dictionary.Add(num, orden.GetReporteCantidadFromDB(num, año, mes, idMedico));
            }
            return dictionary;
        }

        public List<int[]> ObtenerReporteEdad(int cobertura, int año, int mes) => 
            new DataOrden().GetReporteEdadFromDB(cobertura, año, mes);

        public List<object[]> ObtenerReporteResultado(int año, int mes) => 
            new DataOrden().GetReporteResultadoFromDB(año, mes);
    }
}
