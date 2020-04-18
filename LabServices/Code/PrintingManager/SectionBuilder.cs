using Entity.Code.Analysis;
using Entity.Code.Analysis.Templates;
using Entity.Code.Analysis.Templates.Print;
using Entity.Code.Business;
using Entity.Code.Management;
using Entity.Code.Static;
using LabServices.Code.Code.Catalog; 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using Utilities.Code;
using static Entity.Code.Static.DataEstaticaGeneral;

namespace LabServices.Code.PrintingManager
{
    public class SectionBuilder
    {
        private StringBuilder cadena = new StringBuilder();
        private static SectionBuilder clasificador;
        private Dictionary<Area, List<int>> repositorio;

        private SectionBuilder()
        {
            this.Inicializar();
        }

        public static List<string> AcoplarTexto(string text, string fontFamily, float emSize, double pixels)
        {
            string[] separator = new string[] { " " };
            List<string> list = new List<string>();
            StringBuilder builder = new StringBuilder();
            double num = 0.0;
            foreach (string str in text.Split(separator, StringSplitOptions.None))
            {
                FormattedText text2 = new FormattedText(str, CultureInfo.CurrentCulture, System.Windows.FlowDirection.LeftToRight, new Typeface(fontFamily), (double)emSize, System.Windows.Media.Brushes.Black);
                builder.Append(str + " ");
                num += text2.Width;
                if (num > pixels)
                {
                    list.Add(builder.ToString());
                    builder.Clear();
                    num = 0.0;
                }
            }
            if (builder.Length > 0)
            {
                list.Add(builder.ToString());
            }
            return list;
        }

        public TemplatePrint CrearAllDocumento(Dictionary<int, ExamResult> examenes, ExamOrder orden, float tamañoFuente, Size tamañoPag)
        {
            Clasificador clasificador = new Clasificador();
            tamañoPag.Height /= 2;
            tamañoPag.Width /= 2;
            Patient pac = new MinLab.Code.LogicLayer.LogicaPaciente.PatientBL().ObtenerPerfilPorId(orden.IdPaciente);
            int id = 0;
            DateTime minValue = DateTime.MinValue;
            foreach (ExamResult examen in examenes.Values)
            {
                Area area = (Area)Plantillas.GetInstance().GetPlantilla(examen.IdPlantilla).Area;
                this.repositorio[area].Add(examen.IdData);
                if (examen.LastUpdatedTime >= minValue)
                {
                    minValue = examen.LastUpdatedTime;
                    id = examen.AccountUpdate;
                }
            }
            TemplatePrint impresion = new TemplatePrint();
            TemplatePrintHead cabecera = new TemplatePrintHead();
            new Dictionary<int, TemplatePrintPage>();
            Medic medico = new MedicBL().GetMedic(orden.IdMedic);
            Account cuenta = new AccountBL().GetAccount(id);
            TimeElapse edad = Utilities.Code.TimeSpan.CalcularEdad(pac.BirthDate);
            cabecera.Edad = Utilities.Code.TimeSpan.FormatoEdad(edad);
            cabecera.Orden = "No " + orden.Id;
            string[] textArray1 = new string[] { pac.Names, " ", pac.FirstSurname, " ", pac.LastSurname };
            cabecera.Nombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(string.Concat(textArray1));
            cabecera.Historia = pac.HistoryCode;
            string[] textArray2 = new string[] { cuenta.Nombre, " ", cuenta.PrimerApellido, " ", cuenta.SegundoApellido, " - ", cuenta.Especialidad };
            cabecera.Responsable = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(string.Concat(textArray2));
            string[] textArray3 = new string[] { medico.Nombre, " ", medico.PrimerApellido, " ", medico.SegundoApellido };
            cabecera.Doctor = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(string.Concat(textArray3));
            cabecera.UltimaRev = minValue.ToShortDateString();
            impresion.Cabecera = cabecera;
            Dictionary<int, TemplatePrintPageLine> dictionary = null;
            TemplatePrintPage pagina = null;
            TemplatePrintPageLine linea = null;
            int key = 0;
            foreach (Area area2 in this.repositorio.Keys)
            {
                if (this.repositorio[area2].Count > 0)
                {
                    pagina = new TemplatePrintPage();
                    dictionary = new Dictionary<int, TemplatePrintPageLine>();
                    pagina.Detail = dictionary;
                    key = 0;
                    linea = new TemplatePrintPageLine
                    {
                        Nombre = "LABORATORIO DE " + DataEstaticaGeneral.Areas[(int)area2],
                        TipoLinea = TemplatePrintPageLine.PageLineType.TituloArea
                    };
                    dictionary.Add(key, linea);
                    key++;
                    foreach (int num3 in this.repositorio[area2])
                    {
                        ExamResult examen2 = examenes[num3];
                        linea = new TemplatePrintPageLine
                        {
                            Nombre = TemplateBL.GetInstance().GetPlantilla(examen2.IdPlantilla).Nombre,
                            TipoLinea = TemplatePrintPageLine.PageLineType.TituloExamen
                        };
                        dictionary.Add(key, linea);
                        key++;
                        Dictionary<int, TemplateRow> filas = Plantillas.GetInstance().GetPlantilla(examen2.IdTemplate).Filas;
                        for (int i = 0; i < filas.Count; i++)
                        {
                            TemplateAsk item;
                            string str2;
                            List<string> list2;
                            int num7;
                            TemplateRow.TemplateRowType tipo = filas[i].Type;
                            if (tipo == TemplateRow.TemplateRowType.Singled)
                            {
                                item = ((PlantillaFilaSimple)filas[i]).Item;
                                switch (item.TipoCampo)
                                {
                                    case TipoCampo.Input:
                                        linea = new TemplatePrintPageLine
                                        {
                                            Nombre = item.Nombre,
                                            TipoLinea = TemplatePrintPageLine.TipoPaginaLinea.ItemSimple,
                                            Resultado = examen2.DetallesByItem[item.IdData].Campo.ToString()
                                        };
                                        if (item.TieneUnidad)
                                        {
                                            linea.Resultado = linea.Resultado + "  " + item.Unidad;
                                        }
                                        switch (item.TipoDato)
                                        {
                                            case TipoDato.Entero:
                                                linea.Resultado = linea.Resultado + clasificador.Clasificar(pac, examen2.IdData, examen2.DetallesByItem[item.IdData]);
                                                break;

                                            case TipoDato.Decimal:
                                                goto Label_07FA;
                                        }
                                        goto Label_082D;

                                    case TipoCampo.Lista:
                                        linea = new TemplatePrintPageLine
                                        {
                                            Nombre = item.Nombre,
                                            TipoLinea = TemplatePrintPageLine.TipoPaginaLinea.ItemSimple,
                                            Resultado = item.OpcionesByIndice[Convert.ToInt32(examen2.DetallesByItem[item.IdData].Campo)]
                                        };
                                        dictionary.Add(key, linea);
                                        key++;
                                        break;

                                    case TipoCampo.Texto:
                                        if (examen2.DetallesByItem[item.IdData].Campo.Equals(""))
                                        {
                                            break;
                                        }
                                        linea = new TemplatePrintPageLine
                                        {
                                            Nombre = item.Nombre
                                        };
                                        str2 = "";
                                        list2 = AcoplarTexto(linea.Nombre + ": " + examen2.DetallesByItem[item.IdData].Campo, "Futura Bk BT", 7.5f, (double)tamañoPag.Width);
                                        num7 = 0;
                                        goto Label_098C;
                                }
                            }
                            else if (tipo == PlantillaFila.PlantillaFilaTipo.Agrupada)
                            {
                                PlantillaFilaGrupo grupo = (PlantillaFilaGrupo)filas[i];
                                linea = new TemplatePrintPageLine
                                {
                                    TipoLinea = TemplatePrintPageLine.TipoPaginaLinea.TituloGrupo,
                                    Nombre = grupo.Nombre
                                };
                                dictionary.Add(key, linea);
                                key++;
                                if (grupo.IdData == 4)
                                {
                                    foreach (PlantillaItem item2 in grupo.Items.Values)
                                    {
                                        linea = new TemplatePrintPageLine
                                        {
                                            TipoLinea = TemplatePrintPageLine.TipoPaginaLinea.ItemSimple,
                                            Nombre = " * " + item2.Nombre
                                        };
                                        int num5 = Convert.ToInt32(examen2.DetallesByItem[item2.IdData].Campo);
                                        if (num5 != 0)
                                        {
                                            linea.Resultado = item2.OpcionesByIndice[num5];
                                            dictionary.Add(key, linea);
                                            key++;
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (PlantillaItem item3 in grupo.Items.Values)
                                    {
                                        string str;
                                        List<string> list;
                                        int num6;
                                        switch (item3.TipoCampo)
                                        {
                                            case TipoCampo.Input:
                                                {
                                                    linea = new TemplatePrintPageLine
                                                    {
                                                        TipoLinea = TemplatePrintPageLine.TipoPaginaLinea.ItemSimple,
                                                        Nombre = " * " + item3.Nombre,
                                                        Resultado = examen2.DetallesByItem[item3.IdData].Campo.ToString()
                                                    };
                                                    if (item3.TieneUnidad)
                                                    {
                                                        linea.Resultado = linea.Resultado + item3.Unidad;
                                                    }
                                                    linea.Resultado = linea.Resultado + clasificador.Clasificar(pac, examen2.IdData, examen2.DetallesByItem[item3.IdData]);
                                                    dictionary.Add(key, linea);
                                                    key++;
                                                    continue;
                                                }
                                            case TipoCampo.Lista:
                                                {
                                                    linea = new TemplatePrintPageLine
                                                    {
                                                        TipoLinea = TemplatePrintPageLine.TipoPaginaLinea.ItemSimple,
                                                        Nombre = " * " + item3.Nombre,
                                                        Resultado = item3.OpcionesByIndice[Convert.ToInt32(examen2.DetallesByItem[item3.IdData].Campo)]
                                                    };
                                                    dictionary.Add(key, linea);
                                                    key++;
                                                    continue;
                                                }
                                            case TipoCampo.Texto:
                                                if (examen2.DetallesByItem[item3.IdData].Campo.Equals(""))
                                                {
                                                    continue;
                                                }
                                                linea = new TemplatePrintPageLine
                                                {
                                                    TipoLinea = TemplatePrintPageLine.TipoPaginaLinea.ItemSimple,
                                                    Nombre = " * " + item3.Nombre
                                                };
                                                str = "";
                                                list = AcoplarTexto(linea.Nombre + ": " + examen2.DetallesByItem[item3.IdData].Campo.ToString(), "Futura Bk BT", 7.5f, (double)tamañoPag.Width);
                                                num6 = 0;
                                                goto Label_06E8;

                                            default:
                                                {
                                                    continue;
                                                }
                                        }
                                    Label_068C:
                                        linea = new TemplatePrintPageLine();
                                        linea.TipoLinea = TemplatePrintPageLine.TipoPaginaLinea.ItemTexto;
                                        if (item3.TieneUnidad && ((key + 1) == list.Count))
                                        {
                                            str = str + item3.Unidad;
                                        }
                                        linea.Resultado = list[num6];
                                        dictionary.Add(key, linea);
                                        key++;
                                        num6++;
                                    Label_06E8:
                                        if (num6 < list.Count)
                                        {
                                            goto Label_068C;
                                        }
                                    }
                                }
                            }
                            continue;
                        Label_07FA:
                            linea.Resultado = linea.Resultado + clasificador.Clasificar(pac, examen2.Id, examen2.DetallesByItem[item.IdData]);
                        Label_082D:
                            dictionary.Add(key, linea);
                            key++;
                            continue;
                        Label_0930:
                            linea = new TemplatePrintPageLine();
                            linea.TipoLinea = TemplatePrintPageLine.PageLineType.ItemTexto;
                            if (item.HasUnit && ((num7 + 1) == list2.Count))
                            {
                                str2 = str2 + item.Unit;
                            }
                            linea.Resultado = list2[num7];
                            dictionary.Add(key, linea);
                            key++;
                            num7++;
                        Label_098C:
                            if (num7 < list2.Count)
                            {
                                goto Label_0930;
                            }
                        }
                    }
                    impresion.Pages.Add(pagina);
                }
            }
            return impresion;
        }

        public static SectionBuilder GetInstance()
        {
            if (clasificador == null)
            {
                clasificador = new SectionBuilder();
            }
            clasificador.LimpiarRepositorio();
            return clasificador;
        }

        public void Inicializar()
        {
            this.repositorio = new Dictionary<Area, List<int>>();
            this.repositorio.Add(Area.BIOQUIMICA, new List<int>());
            this.repositorio.Add(Area.ESTUDIODESECRECIONES, new List<int>());
            this.repositorio.Add(Area.HEMATOLOGIA, new List<int>());
            this.repositorio.Add(Area.INMUNOLOGIA, new List<int>());
            this.repositorio.Add(Area.MICROBIOLOGIA, new List<int>());
            this.repositorio.Add(Area.PARASITOLOGIA, new List<int>());
            this.repositorio.Add(Area.UROANALISIS, new List<int>());
        }

        public void LimpiarRepositorio()
        {
            this.repositorio[Area.BIOQUIMICA].Clear();
            this.repositorio[Area.ESTUDIODESECRECIONES].Clear();
            this.repositorio[Area.HEMATOLOGIA].Clear();
            this.repositorio[Area.INMUNOLOGIA].Clear();
            this.repositorio[Area.MICROBIOLOGIA].Clear();
            this.repositorio[Area.PARASITOLOGIA].Clear();
            this.repositorio[Area.UROANALISIS].Clear();
        }
    }
}
