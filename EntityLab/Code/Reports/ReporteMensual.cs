
using System;
using System.Collections.Generic;
using System.Data;

namespace EntityLab.Code.Reports
{
    public class ReporteMensual
    {
        private Dictionary<int, ReporteMensualDetalle> detalles;

        public bool ExisteId(int id)
        {
            foreach (ReporteMensualDetalle detalle in this.detalles.Values)
            {
                if (id == detalle.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public int Area { get; set; }

        public Dictionary<int, ReporteMensualDetalle> Detalle
        {
            get => 
                this.detalles;
            set
            {
                this.detalles = value;
            }
        }


        private bool existDataInDictionary(int id, Dictionary<int, int> dict)
        {
            using (Dictionary<int, int>.KeyCollection.Enumerator enumerator = dict.Keys.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current == id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool ExportarReporteEconomicoEdad(int year, int month, string direccion)
        {
            ExcelPackage package = null;
            string path = null;
            if (direccion != null)
            {
                DateTime now = DateTime.Now;
                object[] objArray1 = new object[] { direccion, @"\ReporteMensualGrupoEtareo-", DataEstaticaGeneral.Meses[month - 1], "-", year, ".xlsx" };
                path = string.Concat(objArray1);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                package = new ExcelPackage(new FileInfo(path));
                ExcelWorksheet worksheet = null;
                try
                {
                    Cuenta cuenta = SistemaControl.Instance().Sesion.Cuenta;
                    foreach (int num in DataEstaticaGeneral.CoberturaTipos.Keys)
                    {
                        worksheet = package.Workbook.Worksheets.Add(DataEstaticaGeneral.CoberturaTipos[num]);
                        worksheet.PrinterSettings.PaperSize = ePaperSize.A4;
                        worksheet.PrinterSettings.Orientation = eOrientation.Landscape;
                        worksheet.Cells["A3"].Value = "Responsable:";
                        worksheet.Cells["A4"].Value = "A\x00f1o:";
                        worksheet.Cells["A5"].Value = "Mes:";
                        worksheet.Cells["A6"].Value = "Cobertura:";
                        worksheet.Cells["A3:A6"].Style.Font.Bold = true;
                        worksheet.Cells["B3:E6"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        worksheet.Cells["B3:E6"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        worksheet.Cells["B3:E3"].Merge = true;
                        worksheet.Cells["B4:E4"].Merge = true;
                        worksheet.Cells["B5:E5"].Merge = true;
                        worksheet.Cells["B6:E6"].Merge = true;
                        string[] textArray1 = new string[] { cuenta.Nombre, " ", cuenta.PrimerApellido, " ", cuenta.SegundoApellido };
                        worksheet.Cells["B3:E3"].Value = string.Concat(textArray1);
                        worksheet.Cells["B4:E4"].Value = year;
                        worksheet.Cells["B5:E5"].Value = DataEstaticaGeneral.Meses[month - 1];
                        worksheet.Cells["B6:E6"].Value = DataEstaticaGeneral.CoberturaTipos[num];
                        int num2 = 4;
                        worksheet.Cells["A8"].Value = "ID";
                        worksheet.Cells["B8"].Value = "Examen";
                        worksheet.Cells["C8"].Value = "< 1 a\x00f1o";
                        while (num2 <= 0x16)
                        {
                            worksheet.Cells[8, num2].Value = (num2 - 3) + " a\x00f1os";
                            num2++;
                        }
                        int num5 = 20;
                        while (num5 < 0x4c)
                        {
                            object[] objArray2 = new object[] { num5, " - ", num5 + 4, " a\x00f1os" };
                            worksheet.Cells[8, num2].Value = string.Concat(objArray2);
                            num5 += 5;
                            num2++;
                        }
                        worksheet.Cells[8, num2].Value = "> 80 a\x00f1os";
                        worksheet.Cells[8, 1, 8, num2].Style.Font.Bold = true;
                        worksheet.Cells[8, 1, 8, num2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        worksheet.Cells[8, 1, 8, num2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        int num3 = 9;
                        IEnumerator enumerator2 = this.ObtenerTablaFormatoReporteEdad(year, month, num).Rows.GetEnumerator();

                        while (enumerator2.MoveNext())
                        {
                            int num4 = 1;
                            foreach (object obj2 in ((DataRow)enumerator2.Current).ItemArray)
                            {
                                worksheet.Cells[num3, num4].Value = obj2;
                                num4++;
                            }
                            num3++;
                        }

                        ExcelRange range = worksheet.Cells[8, 1, num3 - 1, num2];
                        range.Style.Font.Bold = true;
                        range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        string name = "T" + DataEstaticaGeneral.CoberturaTipos[num].Replace(' ', '_') + DataEstaticaGeneral.CoberturaTipos[num].Replace(' ', '_');
                        worksheet.Tables.Add(range, name);
                        worksheet.Tables[name].TableStyle = TableStyles.Light9;
                    }
                    package.Save();
                    //TimeSpan time1 = DateTime.Now - now;
                    return true;
                }
                catch (Exception exception1)
                {
                    throw new Exception(exception1.Message);
                }
            }
            return false;
        }

        private bool ExportarReporteEconomicoMedico(int year, int month, string direccion)
        {
            ExcelPackage package = null;
            string path = null;
            if (direccion != null)
            {
                object[] objArray1 = new object[] { direccion, @"\ReporteMensualMedico-", DataEstaticaGeneral.Meses[month - 1], "-", year, ".xlsx" };
                path = string.Concat(objArray1);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                package = new ExcelPackage(new FileInfo(path));
                ExcelWorksheet worksheet = null;
                try
                {
                    Dictionary<int, Medico> dictionary = new BLMedico().ObtenerMedicosHabil();
                    Cuenta cuenta = SistemaControl.Instance().Sesion.Cuenta;
                    foreach (int num in dictionary.Keys)
                    {
                        worksheet = package.Workbook.Worksheets.Add(BLMedico.FormatearNombre(dictionary[num]));
                        worksheet.PrinterSettings.PaperSize = ePaperSize.A4;
                        worksheet.PrinterSettings.Orientation = eOrientation.Portrait;
                        worksheet.Cells["A2"].Value = "Profesional:";
                        worksheet.Cells["A3"].Value = "Coleg./Especial:";
                        worksheet.Cells["A4"].Value = "A\x00f1o:";
                        worksheet.Cells["A5"].Value = "Mes:";
                        worksheet.Cells["A2:A5"].Style.Font.Bold = true;
                        worksheet.Cells["B2:E5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        worksheet.Cells["B2:E5"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        worksheet.Cells["B2:E2"].Merge = true;
                        worksheet.Cells["B3:E3"].Merge = true;
                        worksheet.Cells["B4:E4"].Merge = true;
                        worksheet.Cells["B5:E5"].Merge = true;
                        worksheet.Cells["B2:E2"].Value = BLMedico.FormatearNombre(dictionary[num]);
                        worksheet.Cells["B3:E3"].Value = dictionary[num].Colegiatura + "/" + dictionary[num].Especialidad;
                        worksheet.Cells["B4:E4"].Value = year;
                        worksheet.Cells["B5:E5"].Value = DataEstaticaGeneral.Meses[month - 1];
                        worksheet.Cells["A7:I7"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        worksheet.Cells["A7:I7"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        worksheet.Cells[7, 1].Value = "Codigo";
                        worksheet.Cells[7, 2].Value = "Examen";
                        worksheet.Cells[7, 3].Value = "Paricular";
                        worksheet.Cells[7, 4].Value = "Anterior Particular";
                        worksheet.Cells[7, 5].Value = "SIS";
                        worksheet.Cells[7, 6].Value = "Anterior SIS";
                        worksheet.Cells[7, 7].Value = "Exonerado";
                        worksheet.Cells[7, 8].Value = "Anterior Exonerado";
                        worksheet.Cells[7, 9].Value = "Unit.(S/.)";
                        worksheet.Cells[7, 10].Value = "Total Mes(S/.)";
                        worksheet.Cells[7, 11].Value = "Acumulado Total";
                        int num2 = 8;
                        IEnumerator enumerator2 = this.ObtenerTablaFormatoDatosReporteEconomicoMedico(year, month, num).Rows.GetEnumerator();


                        while (enumerator2.MoveNext())
                        {
                            int num3 = 1;
                            foreach (object obj2 in ((DataRow)enumerator2.Current).ItemArray)
                            {
                                worksheet.Cells[num2, num3].Value = obj2;
                                num3++;
                            }
                            num2++;
                        }

                        ExcelRange range = worksheet.Cells[7, 1, num2 - 1, 11];
                        range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        string name = "T" + BLMedico.FormatearNombre(dictionary[num]).Replace(' ', '_');
                        worksheet.Tables.Add(range, name);
                        worksheet.Tables[name].TableStyle = TableStyles.Light9;
                        worksheet.Cells[num2 + 1, 2].Value = "Examen";
                        worksheet.Cells[num2 + 1, 3].Value = "Particular";
                        worksheet.Cells[num2 + 1, 4].Value = "Anterior Particular";
                        worksheet.Cells[num2 + 1, 5].Value = "SIS";
                        worksheet.Cells[num2 + 1, 6].Value = "Anterior SIS";
                        worksheet.Cells[num2 + 1, 7].Value = "Exonedado";
                        worksheet.Cells[num2 + 1, 8].Value = "Anterior Exonerado";
                        worksheet.Cells[num2 + 1, 9].Value = "Total Mes(S/.)";
                        worksheet.Cells[num2 + 1, 10].Value = "Acumulado Total";
                        worksheet.Cells[num2 + 2, 2].Value = "Todos";
                        worksheet.Cells[num2 + 2, 3].Formula = "=SUM(C8:C" + (num2 - 1) + ")";
                        worksheet.Cells[num2 + 2, 4].Formula = "=SUM(D8:D" + (num2 - 1) + ")";
                        worksheet.Cells[num2 + 2, 5].Formula = "=SUM(E8:E" + (num2 - 1) + ")";
                        worksheet.Cells[num2 + 2, 6].Formula = "=SUM(F8:F" + (num2 - 1) + ")";
                        worksheet.Cells[num2 + 2, 7].Formula = "=SUM(G8:G" + (num2 - 1) + ")";
                        worksheet.Cells[num2 + 2, 8].Formula = "=SUM(H8:H" + (num2 - 1) + ")";
                        worksheet.Cells[num2 + 2, 9].Formula = "=SUM(J8:J" + (num2 - 1) + ")";
                        worksheet.Cells[num2 + 2, 10].Formula = "=SUM(K8:K" + (num2 - 1) + ")";
                        ExcelRange range2 = worksheet.Cells[num2 + 1, 2, num2 + 2, 10];
                        range2.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        range2.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        string str3 = "TTotal" + BLMedico.FormatearNombre(dictionary[num]).Replace(' ', '_');
                        worksheet.Tables.Add(range2, str3);
                        worksheet.Tables[str3].TableStyle = TableStyles.Light9;
                    }
                    package.Save();
                    return true;
                }
                catch (Exception exception1)
                {
                    throw new Exception(exception1.Message);
                }
            }
            return false;
        }

        private bool ExportarReporteResultadoGeneral(int year, int month, string direccion)
        {
            ExcelPackage package = null;
            string path = null;
            if (direccion != null)
            {
                object[] objArray1 = new object[] { direccion, @"\ReporteResultadoGeneral-", DataEstaticaGeneral.Meses[month - 1], "-", year, ".xlsx" };
                path = string.Concat(objArray1);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                package = new ExcelPackage(new FileInfo(path));
                ExcelWorksheet worksheet = null;
                try
                {
                    Cuenta cuenta = SistemaControl.Instance().Sesion.Cuenta;
                    worksheet = package.Workbook.Worksheets.Add("Reporte Resultado General");
                    worksheet.PrinterSettings.PaperSize = ePaperSize.A4;
                    worksheet.PrinterSettings.Orientation = eOrientation.Portrait;
                    worksheet.Cells["A3"].Value = "Responsable:";
                    worksheet.Cells["A4"].Value = "A\x00f1o:";
                    worksheet.Cells["A5"].Value = "Mes:";
                    worksheet.Cells["A2:A5"].Style.Font.Bold = true;
                    worksheet.Cells["B2:E5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    worksheet.Cells["B2:E5"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    worksheet.Cells["B3:E3"].Merge = true;
                    worksheet.Cells["B4:E4"].Merge = true;
                    worksheet.Cells["B5:E5"].Merge = true;
                    string[] textArray1 = new string[] { cuenta.Nombre, " ", cuenta.PrimerApellido, " ", cuenta.SegundoApellido };
                    worksheet.Cells["B3:E3"].Value = string.Concat(textArray1);
                    worksheet.Cells["B4:E4"].Value = year;
                    worksheet.Cells["B5:E5"].Value = DataEstaticaGeneral.Meses[month - 1];
                    worksheet.Cells[7, 1, 7, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    worksheet.Cells[7, 1, 7, 12].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    worksheet.Cells[7, 1].Value = "DNI";
                    worksheet.Cells[7, 2].Value = "Nombre";
                    worksheet.Cells[7, 3].Value = "Prim. Apellido";
                    worksheet.Cells[7, 4].Value = "Seg. Apellido";
                    worksheet.Cells[7, 5].Value = "Edad";
                    worksheet.Cells[7, 6].Value = "Sexo";
                    worksheet.Cells[7, 7].Value = "Gestante";
                    worksheet.Cells[7, 8].Value = "Examen";
                    worksheet.Cells[7, 9].Value = "Resultado";
                    worksheet.Cells[7, 10].Value = "Unidad";
                    worksheet.Cells[7, 11].Value = "Cobertura";
                    worksheet.Cells[7, 12].Value = "Estado";
                    int num = 8;
                    IEnumerator enumerator = this.ObtenerTablaFormatoDatosReporteResultado(year, month).Rows.GetEnumerator();

                    while (enumerator.MoveNext())
                    {
                        int num2 = 1;
                        foreach (object obj2 in ((DataRow)enumerator.Current).ItemArray)
                        {
                            worksheet.Cells[num, num2].Value = obj2;
                            num2++;
                        }
                        num++;
                    }

                    ExcelRange range = worksheet.Cells[7, 1, num - 1, 12];
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    string name = "TabGeneral";
                    worksheet.Tables.Add(range, name);
                    worksheet.Tables[name].TableStyle = TableStyles.Light9;
                    package.Save();
                    return true;
                }
                catch (Exception exception1)
                {
                    throw new Exception(exception1.Message);
                }
            }
            return false;
        }

        private bool GenerarExcelReporteEconomicoGeneral(int year, int month, string direccion)
        {
            ExcelPackage package = null;
            string path = null;
            if (direccion != null)
            {
                object[] objArray1 = new object[] { direccion, @"\ReporteEconomicoGeneral-", DataEstaticaGeneral.Meses[month - 1], "-", year, ".xlsx" };
                path = string.Concat(objArray1);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                package = new ExcelPackage(new FileInfo(path));
                ExcelWorksheet worksheet = null;
                try
                {
                    Cuenta cuenta = SistemaControl.Instance().Sesion.Cuenta;
                    DataTable table = this.ObtenerTablaFormatoReporteEconomicoGeneral(year, month);
                    worksheet = package.Workbook.Worksheets.Add("Reporte General");
                    worksheet.PrinterSettings.PaperSize = ePaperSize.A4;
                    worksheet.PrinterSettings.Orientation = eOrientation.Portrait;
                    worksheet.Cells["A3"].Value = "Responsable:";
                    worksheet.Cells["A4"].Value = "A\x00f1o:";
                    worksheet.Cells["A5"].Value = "Mes:";
                    worksheet.Cells["A2:A5"].Style.Font.Bold = true;
                    worksheet.Cells["B2:E5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    worksheet.Cells["B2:E5"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    worksheet.Cells["B3:E3"].Merge = true;
                    worksheet.Cells["B4:E4"].Merge = true;
                    worksheet.Cells["B5:E5"].Merge = true;
                    string[] textArray1 = new string[] { cuenta.Nombre, " ", cuenta.PrimerApellido, " ", cuenta.SegundoApellido };
                    worksheet.Cells["B3:E3"].Value = string.Concat(textArray1);
                    worksheet.Cells["B4:E4"].Value = year;
                    worksheet.Cells["B5:E5"].Value = DataEstaticaGeneral.Meses[month - 1];
                    worksheet.Cells[7, 1, 7, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    worksheet.Cells["A7:J7"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    worksheet.Cells[7, 1].Value = "Codigo";
                    worksheet.Cells[7, 2].Value = "Examen";
                    worksheet.Cells[7, 3].Value = "Particular";
                    worksheet.Cells[7, 4].Value = "Anterior Particular";
                    worksheet.Cells[7, 5].Value = "SIS";
                    worksheet.Cells[7, 6].Value = "Anterior SIS";
                    worksheet.Cells[7, 7].Value = "Exonerado";
                    worksheet.Cells[7, 8].Value = "Anterior Exonerado";
                    worksheet.Cells[7, 9].Value = "Unit.(S/.)";
                    worksheet.Cells[7, 10].Value = "Total Mes(S/.)";
                    worksheet.Cells[7, 11].Value = "Acumulado Total";
                    int num = 8;
                    IEnumerator enumerator = table.Rows.GetEnumerator();

                    while (enumerator.MoveNext())
                    {
                        int num2 = 1;
                        foreach (object obj2 in ((DataRow)enumerator.Current).ItemArray)
                        {
                            worksheet.Cells[num, num2].Value = obj2;
                            num2++;
                        }
                        num++;
                    }

                    ExcelRange range = worksheet.Cells[7, 1, num - 1, 11];
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    string name = "TabGeneral";
                    worksheet.Tables.Add(range, name);
                    worksheet.Tables[name].TableStyle = TableStyles.Light9;
                    worksheet.Cells[num + 1, 2].Value = "Examen";
                    worksheet.Cells[num + 1, 3].Value = "Particular";
                    worksheet.Cells[num + 1, 4].Value = "Anterior Particular";
                    worksheet.Cells[num + 1, 5].Value = "SIS";
                    worksheet.Cells[num + 1, 6].Value = "Anterior SIS";
                    worksheet.Cells[num + 1, 7].Value = "Exonerado";
                    worksheet.Cells[num + 1, 8].Value = "Anterior Exonerado";
                    worksheet.Cells[num + 1, 9].Value = "Total Mes(S/.)";
                    worksheet.Cells[num + 1, 10].Value = "Acumulado Total";
                    worksheet.Cells[num + 2, 2].Value = "Todos";
                    worksheet.Cells[num + 2, 3].Formula = "=SUM(C8:C" + (num - 1) + ")";
                    worksheet.Cells[num + 2, 4].Formula = "=SUM(D8:D" + (num - 1) + ")";
                    worksheet.Cells[num + 2, 5].Formula = "=SUM(E8:E" + (num - 1) + ")";
                    worksheet.Cells[num + 2, 6].Formula = "=SUM(F8:F" + (num - 1) + ")";
                    worksheet.Cells[num + 2, 7].Formula = "=SUM(G8:G" + (num - 1) + ")";
                    worksheet.Cells[num + 2, 8].Formula = "=SUM(H8:H" + (num - 1) + ")";
                    worksheet.Cells[num + 2, 9].Formula = "=SUM(J8:J" + (num - 1) + ")";
                    worksheet.Cells[num + 2, 10].Formula = "=SUM(K8:K" + (num - 1) + ")";
                    ExcelRange range2 = worksheet.Cells[num + 1, 2, num + 2, 10];
                    range2.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range2.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    string str3 = "TTotal";
                    worksheet.Tables.Add(range2, str3);
                    worksheet.Tables[str3].TableStyle = TableStyles.Light9;
                    package.Save();
                    return true;
                }
                catch (Exception exception1)
                {
                    throw new Exception(exception1.Message);
                }
            }
            return false;
        }

        public void GenerarReporteEconomico(FiltroReporteEconomico filt, int year, int month, string direccion)
        {
            switch (filt)
            {
                case FiltroReporteEconomico.General:
                    this.GenerarExcelReporteEconomicoGeneral(year, month, direccion);
                    return;

                case FiltroReporteEconomico.Edad:
                    this.ExportarReporteEconomicoEdad(year, month, direccion);
                    return;

                case FiltroReporteEconomico.Medico:
                    this.ExportarReporteEconomicoMedico(year, month, direccion);
                    return;
            }
        }

        public void GenerarReporteResultados(FiltroReporteResultados filt, int year, int month, string direccion)
        {
            if (filt == FiltroReporteResultados.General)
            {
                this.ExportarReporteResultadoGeneral(year, month, direccion);
            }
        }

        private DataTable ObtenerTablaFormatoDatosReporteEconomicoMedico(int ano, int mes, int idMedico)
        {
            BLTarifario tarifario = new BLTarifario();
            Tarifario tar = tarifario.ObtenerTarifario();
            DataTable table = new DataTable();
            try
            {
                new List<int>();
                LogicaOrden orden1 = new LogicaOrden();
                Dictionary<int, Dictionary<int, int>> dictionary = orden1.ObtenerReporteAcumuladoMensual(ano, mes, idMedico);
                Dictionary<int, Dictionary<int, int>> dictionary2 = orden1.ObtenerReporteCantidadMensual(ano, mes, idMedico);
                table.Columns.Add("id", typeof(int));
                table.Columns.Add("nombre", typeof(string));
                table.Columns.Add("nroP", typeof(int));
                table.Columns.Add("acuP", typeof(int));
                table.Columns.Add("nroS", typeof(int));
                table.Columns.Add("acuS", typeof(int));
                table.Columns.Add("nroE", typeof(int));
                table.Columns.Add("acuE", typeof(int));
                table.Columns.Add("precioUn", typeof(double));
                table.Columns.Add("totalMes", typeof(double));
                table.Columns.Add("cob", typeof(int));
                foreach (int num in ListaAnalisis.GetInstance().Coleccion.Keys)
                {
                    DataRow row = table.NewRow();
                    row[0] = num;
                    row[1] = ListaAnalisis.GetInstance().Analisis[num].Nombre;
                    row[2] = this.existDataInDictionary(num, dictionary2[0]) ? dictionary2[0][num] : 0;
                    row[3] = this.existDataInDictionary(num, dictionary[0]) ? dictionary[0][num] : 0;
                    row[4] = this.existDataInDictionary(num, dictionary2[1]) ? dictionary2[1][num] : 0;
                    row[5] = this.existDataInDictionary(num, dictionary[1]) ? dictionary[1][num] : 0;
                    row[6] = this.existDataInDictionary(num, dictionary2[2]) ? dictionary2[2][num] : 0;
                    row[7] = this.existDataInDictionary(num, dictionary[2]) ? dictionary[2][num] : 0;
                    row[8] = tarifario.ObtenerTarifarioDetalle(tar, num).Precio;
                    row[9] = ((int)row[2]) * tarifario.ObtenerTarifarioDetalle(tar, num).Precio;
                    row[10] = ((((((int)row[2]) + ((int)row[4])) + ((int)row[6])) + ((int)row[3])) + ((int)row[5])) + ((int)row[7]);
                    table.Rows.Add(row);
                }
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return table;
        }

        private DataTable ObtenerTablaFormatoDatosReporteResultado(int ano, int mes)
        {
            new BLTarifario().ObtenerTarifario();
            DataTable table = new DataTable();
            try
            {
                table.Columns.Add("dni", typeof(string));
                table.Columns.Add("nombre", typeof(string));
                table.Columns.Add("apellido1", typeof(string));
                table.Columns.Add("apellido2", typeof(string));
                table.Columns.Add("edad", typeof(double));
                table.Columns.Add("sexo", typeof(string));
                table.Columns.Add("gestante", typeof(string));
                table.Columns.Add("Examen", typeof(string));
                table.Columns.Add("respuesta", typeof(string));
                table.Columns.Add("nota", typeof(string));
                table.Columns.Add("cobertura", typeof(string));
                table.Columns.Add("estado", typeof(string));
                foreach (object[] objArray in new LogicaOrden().ObtenerReporteResultado(ano, mes))
                {
                    DataRow row = table.NewRow();
                    row[0] = objArray[1].ToString();
                    row[1] = objArray[2].ToString();
                    row[2] = objArray[3].ToString();
                    row[3] = objArray[4].ToString();
                    row[4] = objArray[5];
                    row[5] = DataEstaticaGeneral.SexoTipos[(int)objArray[6]];
                    row[6] = Convert.ToBoolean(objArray[7]) ? "SI" : "NO";
                    row[7] = Plantillas.GetInstance().GetPlantilla((int)objArray[0]).Nombre;
                    row[8] = objArray[8].ToString().Replace('.', ',');
                    row[9] = objArray[9];
                    row[10] = DataEstaticaGeneral.CoberturaTipos[(int)objArray[10]];
                    row[11] = DataEstaticaGeneral.ExamenEstados[(int)objArray[11]];
                    table.Rows.Add(row);
                }
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return table;
        }

        private DataTable ObtenerTablaFormatoReporteEconomicoGeneral(int ano, int mes)
        {
            BLTarifario tarifario = new BLTarifario();
            Tarifario tar = tarifario.ObtenerTarifarioPorAno(ano);
            DataTable table = new DataTable();
            if (tar == null)
            {
                throw new Exception("No existe tarifario para este a\x00f1o");
            }
            try
            {
                new List<int>();
                LogicaOrden orden1 = new LogicaOrden();
                Dictionary<int, Dictionary<int, int>> dictionary = orden1.ObtenerReporteAcumuladoMensual(ano, mes);
                Dictionary<int, Dictionary<int, int>> dictionary2 = orden1.ObtenerReporteCantidadMensual(ano, mes);
                table.Columns.Add("id", typeof(int));
                table.Columns.Add("nombre", typeof(string));
                table.Columns.Add("nroP", typeof(int));
                table.Columns.Add("acuP", typeof(int));
                table.Columns.Add("nroS", typeof(int));
                table.Columns.Add("acuS", typeof(int));
                table.Columns.Add("nroE", typeof(int));
                table.Columns.Add("acuE", typeof(int));
                table.Columns.Add("precioUn", typeof(double));
                table.Columns.Add("totalMes", typeof(double));
                table.Columns.Add("cob", typeof(int));
                foreach (int num in ListaAnalisis.GetInstance().Coleccion.Keys)
                {
                    DataRow row = table.NewRow();
                    row[0] = num;
                    row[1] = ListaAnalisis.GetInstance().Analisis[num].Nombre;
                    row[2] = this.existDataInDictionary(num, dictionary2[0]) ? dictionary2[0][num] : 0;
                    row[3] = this.existDataInDictionary(num, dictionary[0]) ? dictionary[0][num] : 0;
                    row[4] = this.existDataInDictionary(num, dictionary2[1]) ? dictionary2[1][num] : 0;
                    row[5] = this.existDataInDictionary(num, dictionary[1]) ? dictionary[1][num] : 0;
                    row[6] = this.existDataInDictionary(num, dictionary2[2]) ? dictionary2[2][num] : 0;
                    row[7] = this.existDataInDictionary(num, dictionary[2]) ? dictionary[2][num] : 0;
                    row[8] = tarifario.ObtenerTarifarioDetalle(tar, num).Precio;
                    row[9] = ((int)row[2]) * tarifario.ObtenerTarifarioDetalle(tar, num).Precio;
                    row[10] = ((((((int)row[2]) + ((int)row[4])) + ((int)row[6])) + ((int)row[3])) + ((int)row[5])) + ((int)row[7]);
                    table.Rows.Add(row);
                }
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return table;
        }

        private DataTable ObtenerTablaFormatoReporteEdad(int year, int month, int cobertura)
        {
            DataTable table = new DataTable();
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("examen", typeof(string));
            for (int i = 0; i <= 0x13; i++)
            {
                table.Columns.Add("c" + i, typeof(int));
            }
            for (int j = 20; j < 0x4c; j += 5)
            {
                table.Columns.Add("c" + j, typeof(int));
            }
            table.Columns.Add("c80", typeof(int));
            try
            {
                foreach (int[] numArray in new LogicaOrden().ObtenerReporteEdad(cobertura, year, month))
                {
                    DataRow row = table.NewRow();
                    row[0] = numArray[0];
                    row[1] = ListaAnalisis.GetInstance().Analisis[numArray[0]].Nombre;
                    for (int k = 1; k < numArray.Length; k++)
                    {
                        row[k + 1] = numArray[k];
                    }
                    table.Rows.Add(row);
                }
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return table;
        }

        public enum FiltroReporteEconomico
        {
            General,
            Edad,
            Medico
        }

        public enum FiltroReporteResultados
        {
            General
        }
    }
}
