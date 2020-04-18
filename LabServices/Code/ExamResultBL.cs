using DataManager.Repositories.Analysis;
using Entity.Code.Analysis;
using Entity.Code.Analysis.Templates;
using System;
using System.Collections.Generic;

namespace LabServices.Code
{
    public class ExamResultBL
    {
        private ExamResultRepository ExamenResultRepo = new ExamResultRepository();
        private PriceListBL PriceListLogi = new PriceListBL();

        public void GenerarExamenes(ExamOrder orden)
        {
            Dictionary<int, ExamResult> examenes = new Dictionary<int, ExamResult>();
            int key = 0;
            foreach (ExamOrderDetail detalle2 in orden.Items.Values)
            {
                if (!ExamenResultRepo.Check(detalle2))
                {
                    foreach (int num2 in PriceListLogi.ObtenerPriceListDetalle(detalle2.IdPackage).PlantillasId)
                    {
                        ExamResult examen = new ExamResult
                        {
                            Id = 0,
                            State = Entity.Code.Base.Documentary.EntityDocumentState.DocumentState.OnProgress,
                            IdOrder = detalle2.Id,
                            IdTemplate = num2,
                            AccountBegun = string.Empty,
                            Items = new Dictionary<int, ExamResultDetail>()
                        };
                        int num3 = 0;
                        foreach (TemplateAsk item in TemplateBL.GetAllItemsByPlantilla(num2).Values)
                        {
                            ExamResultDetail detalle = new ExamResultDetail
                            {
                                Id = item.Id,
                                Value = item.DefaultValue
                            };
                            examen.Items.Add(num3, detalle);
                            num3++;
                        }
                        examenes.Add(key, examen);
                        key++;
                    }
                }
            }
            foreach (var exam in examenes.Values)
                ExamenResultRepo.Save(exam);
        }

        public bool GuardarExamen(ExamResult ex)
        {
            //ex.IdCuenta = SistemaControl.Instance().Sesion.Cuenta.IdData;
            ExamenResultRepo.Save(ex);
            return true;
        }

        public Dictionary<int, ExamResult> RecuperarExamenes(ExamOrder orden)
        {
            Dictionary<int, ExamResult> examenesByOrdenDetalle = null;
            foreach (ExamOrderDetail detalle in orden.Items.Values)
            {
                if (examenesByOrdenDetalle == null)
                {
                    examenesByOrdenDetalle = (Dictionary<int,ExamResult>)ExamenResultRepo.Index();
                }
                else
                {
                    foreach (ExamResult examen in ExamenResultRepo.Index().Values)
                    {
                        examenesByOrdenDetalle.Add(examen.Id, examen);
                    }
                }
            }
            return examenesByOrdenDetalle;
        }

        public bool ValidarExamenes(ExamResult examen)
        {
            //new Clasificador().Controlar(examen);
            return true;
        }
    }
}
