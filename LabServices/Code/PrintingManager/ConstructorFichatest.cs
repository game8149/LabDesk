using MinLab.Code.EntityLayer.ArchivoCaja;
using MinLab.Code.EntityLayer.ArchivoHistoria;
using MinLab.Code.EntityLayer.DatosEstaticos;
using MinLab.Code.EntityLayer.EntidadExamen;
using MinLab.Code.EntityLayer.EntidadExamen.EntidadPlantilla;
using MinLab.Code.PresentationLayer.GUIExamen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MinLab.Code.EntityLayer.ArchivoCaja.Orden;

namespace MinLab.Code.PresentationLayer.GUIHistorial.ComponenteImpresion
{
    public class ConstructorFicha
    {
        private static ConstructorFicha clasificador=null;
        private StringBuilder cadena = new StringBuilder();

        public static ConstructorFicha GetInstance()
        {
            if (clasificador == null)
                clasificador = new ConstructorFicha();
            return clasificador;
        }

        private enum EtapaHumano
        {
            RecienNacido,
            Niño,
        }

        public FormatoImpresion CrearDocumento(Orden orden, Paciente paciente,Dictionary<int,Examen> examenPorOrden)
        {
            List<Examen> examenSelectedTemp;
            FormatoImpresion pagina = new FormatoImpresion();
            pagina.Orden = "O"+orden.IdData;
            pagina.Nombre = paciente.Nombre +" "+ paciente.ApellidoPaterno +" "+ paciente.ApellidoMaterno;
            pagina.Historia = paciente.Historia;
            pagina.Edad = this.GetAge(paciente);
            FormatoImpresion.PaginaLinea lineaTemp;
            foreach (OrdenDetalle detalle in orden.Detalle.Values)
            {
                examenSelectedTemp = GetExamenes(examenPorOrden, detalle);
                string nombreTar = Tarifario.GetInstance().Paquetes[detalle.IdDataTarifa].Nombre;
                string nombreEx = null;
                lineaTemp = new FormatoImpresion.PaginaLinea();
                lineaTemp.TipoLinea = FormatoImpresion.PaginaLinea.TipoPaginaLinea.TituloInicio;
                lineaTemp.Nombre = nombreTar;
                pagina.Detalles.Add(lineaTemp);
                foreach (Examen ex in examenSelectedTemp)
                {
                    nombreEx = Plantillas.GetInstance().GetPlantilla(ex.IdPlantilla).Nombre;
                    if (!nombreEx.Equals(nombreTar))
                    {
                        lineaTemp = new FormatoImpresion.PaginaLinea();
                        lineaTemp.TipoLinea = FormatoImpresion.PaginaLinea.TipoPaginaLinea.SubTitulo;
                        lineaTemp.Nombre = nombreEx;
                        pagina.Detalles.Add(lineaTemp);
                    }
                    Dictionary<int, PlantillaDetalle> detalles = Plantillas.GetInstance().GetPlantilla(ex.IdPlantilla).Detalle;
                    for(int i=0;i<detalles.Count;i++)
                    {
                        switch (detalles[i].Tipo)
                        {
                            case PlantillaDetalle.TipoDetalle.Grupo:
                                lineaTemp = new FormatoImpresion.PaginaLinea();
                                lineaTemp.TipoLinea = FormatoImpresion.PaginaLinea.TipoPaginaLinea.GrupoInicio;
                                lineaTemp.Nombre = detalles[i].Grupo.Nombre;
                                pagina.Detalles.Add(lineaTemp);
                                if (detalles[i].Grupo.IdData == 4)//Para el grupo especial Medicina // Luego se puede mejorar Agregando un elemento deseado incorporandolo 
                                {
                                    foreach (Item itemG in detalles[i].Grupo.Items.Values)
                                    {
                                        lineaTemp = new FormatoImpresion.PaginaLinea();
                                        lineaTemp.TipoLinea = FormatoImpresion.PaginaLinea.TipoPaginaLinea.ItemSimple;
                                        lineaTemp.Nombre = " * "+itemG.Nombre;
                                        int indice = Convert.ToInt32(ex.DetallesByItem[itemG.IdData].Campo);
                                        if (indice != 0)
                                        {
                                            lineaTemp.Resultado = itemG.OpcionesByIndice[indice];
                                            pagina.Detalles.Add(lineaTemp);
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (Item itemG in detalles[i].Grupo.Items.Values)
                                    {
                                        lineaTemp = new FormatoImpresion.PaginaLinea();
                                        lineaTemp.TipoLinea = FormatoImpresion.PaginaLinea.TipoPaginaLinea.ItemSimple;
                                        lineaTemp.Nombre = " * "+itemG.Nombre;
                                        switch (itemG.TipoCampo)
                                        {
                                            case TipoCampo.Input:
                                                lineaTemp.Resultado = ex.DetallesByItem[itemG.IdData].Campo.ToString();
                                                if (itemG.TieneUnidad)
                                                    lineaTemp.Resultado += itemG.Unidad;
                                                lineaTemp.Resultado += ClasificarItem(paciente, ex.DetallesByItem[itemG.IdData]);
                                                break;
                                            case TipoCampo.Lista:
                                                lineaTemp.Resultado = itemG.OpcionesByIndice[Convert.ToInt32(ex.DetallesByItem[itemG.IdData].Campo)];
                                                break;
                                            case TipoCampo.Texto:
                                                lineaTemp.TipoLinea = FormatoImpresion.PaginaLinea.TipoPaginaLinea.ItemTexto;
                                                lineaTemp.Resultado = ex.DetallesByItem[itemG.IdData].Campo.ToString();
                                                break;
                                        }
                                        pagina.Detalles.Add(lineaTemp);
                                    }
                                }
                                lineaTemp = new FormatoImpresion.PaginaLinea();
                                lineaTemp.TipoLinea = FormatoImpresion.PaginaLinea.TipoPaginaLinea.GrupoFin;
                                break;
                            case PlantillaDetalle.TipoDetalle.Item:
                                Item item = detalles[i].Item;
                                lineaTemp = new FormatoImpresion.PaginaLinea();
                                lineaTemp.TipoLinea = FormatoImpresion.PaginaLinea.TipoPaginaLinea.ItemSimple;
                                if (!nombreEx.Equals(item.Nombre))
                                    lineaTemp.Nombre = item.Nombre;
                                else
                                    lineaTemp.Nombre = "RESULTADO";
                                switch (item.TipoCampo)
                                {
                                    case TipoCampo.Input:
                                        lineaTemp.Resultado = ex.DetallesByItem[item.IdData].Campo.ToString();
                                        if (item.TieneUnidad)
                                            lineaTemp.Resultado += "  "+item.Unidad;
                                        switch (item.TipoDato)
                                        {
                                            case TipoDato.Entero:
                                                lineaTemp.Resultado += ClasificarItem(paciente, ex.DetallesByItem[item.IdData]);
                                                break;
                                            case TipoDato.Decimal:
                                                lineaTemp.Resultado += ClasificarItem(paciente, ex.DetallesByItem[item.IdData]);
                                                break;
                                        }
                                        break;
                                    case TipoCampo.Lista:
                                        lineaTemp.Resultado = item.OpcionesByIndice[Convert.ToInt32(ex.DetallesByItem[item.IdData].Campo)];
                                        break;
                                    case TipoCampo.Texto:
                                        lineaTemp.TipoLinea = FormatoImpresion.PaginaLinea.TipoPaginaLinea.ItemTexto;
                                        lineaTemp.Resultado = ex.DetallesByItem[item.IdData].Campo.ToString();
                                        break;
                                }
                                pagina.Detalles.Add(lineaTemp);
                                break;
                        }
                    }
                }
            }
            return pagina;
        }

        private List<Examen> GetExamenes(Dictionary<int, Examen> examenesOrden, OrdenDetalle ordenDetalle)
        {
            
            List<int> indices = new List<int>();
            foreach (int key in examenesOrden.Keys)
                if (examenesOrden[key].IdOrdenDetalle == ordenDetalle.IdData)
                    indices.Add(key);
            List<Examen> examenes = new List<Examen>(); 
            foreach(int keySelected in indices)
            {
                examenes.Add(examenesOrden[keySelected]);
                examenesOrden.Remove(keySelected);
            }
            return examenes;
        }


        public String ClasificarItem(Paciente paciente, ExamenDetalle detalle)
        {
            DateTime actual = DateTime.Now;
            DateTime nacim = paciente.FechaNacimiento;
            int daysForYear, years;

            TimeSpan tiempo = actual - nacim;
            years = tiempo.Days / 365;
            daysForYear = tiempo.Days % 365;

            int dayCount = 1;
            int monthCount = 1;
            for (int i = 1; i < daysForYear + 1; i++)
            {
                if (DateTime.DaysInMonth(actual.Year, monthCount) == dayCount)
                {
                    dayCount = 1;
                    monthCount++;
                }
                else
                    dayCount++;
            }
            monthCount--;
            string valorString = detalle.Campo.ToString() ;
            decimal value = Convert.ToDecimal(valorString);
            StringBuilder cad=new StringBuilder();
            switch (detalle.IdItem)
            {
                case 1:
                    if (dayCount == 1 && monthCount == 0 && years == 0)
                    {
                        if (value <15.0m)
                            cad.Append(" (Bajo)");
                        else if (value >23.0m)
                            cad.Append(" (Alto)");
                        else
                            cad.Append(" (Normal)");
                    }
                    else if (monthCount >= 2 && monthCount <= 3 && years == 0)
                    {
                        if (value < 9.5m)
                            cad.Append(" (Bajo)");
                        else if (value > 213m)
                            cad.Append(" (Alto)");
                        else
                            cad.Append(" (Normal)");
                    }
                    else if (years >= 1 && years<= 5)
                    {
                        if (value < 11m)
                            cad.Append(" (Bajo)");
                        else if (value > 14.6m)
                            cad.Append(" (Alto)");
                        else
                            cad.Append(" (Normal)");
                    }
                    else if (years >= 6 && years <= 10)
                    {
                        if (value < 12m)
                            cad.Append(" (Bajo)");
                        else if (value > 16m)
                            cad.Append(" (Alto)");
                        else
                            cad.Append(" (Normal)");
                    }
                    else if (years >= 14)
                    {
                        switch (paciente.Genero) {
                            case 0:
                                if (value < 13m)
                                    cad.Append(" (Bajo)");
                                else if (value > 17.5m)
                                    cad.Append(" (Alto)");
                                else
                                    cad.Append(" (Normal)");
                                break;
                            case 1:
                                    if (value < 12m)
                                        cad.Append(" (Bajo)");
                                    else if (value > 16m)
                                        cad.Append(" (Alto)");
                                    else
                                        cad.Append(" (Normal)");
                                    break;
                        }                        
                    }
                    break;//HEMOGLOBINA
                case 2:
                    if (dayCount == 1 && monthCount == 0 && years == 0)
                    {
                        if (value < 44m)
                            cad.Append(" (Bajo)");
                        else if (value > 64m)
                            cad.Append(" (Alto)");
                        else
                            cad.Append(" (Normal)");
                    }
                    else if (years < 10)
                    {
                        if (value < 33m)
                            cad.Append(" (Bajo)");
                        else if (value > 43m)
                            cad.Append(" (Alto)");
                        else
                            cad.Append(" (Normal)");
                    }
                    else if (years >= 14)
                    {
                        switch (paciente.Genero)
                        {
                            case 0:
                                if (value < 40m)
                                    cad.Append(" (Bajo)");
                                else if (value > 50m)
                                    cad.Append(" (Alto)");
                                else
                                    cad.Append(" (Normal)");
                                break;
                            case 1:
                                if (value < 37m)
                                    cad.Append(" (Bajo)");
                                else if (value > 47m)
                                    cad.Append(" (Alto)");
                                else
                                    cad.Append(" (Normal)");
                                break;
                        }
                    }
                    break;//HEMATOCRITO
                case 3:
                    if (dayCount == 1 && monthCount == 0 && years == 0)
                    {
                        if (value < 10000)
                            cad.Append(" (Bajo)");
                        else if (value > 25000)
                            cad.Append(" (Alto)");
                        else
                            cad.Append(" (Normal)");
                    }
                    else
                    {
                        if (value < 5000)
                            cad.Append(" (Bajo)");
                        else if (value > 10000)
                            cad.Append(" (Alto)");
                        else
                            cad.Append(" (Normal)");
                    }
                    break;//LEUCOCITO (HMG)
                case 4:
                    if (value < 2)
                        cad.Append(" (Bajo)");
                    else if (value > 4)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//ABASTONADOS
                case 5:
                    if (value < 55)
                        cad.Append(" (Bajo)");
                    else if (value > 65)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//SEGMENTADOS
                case 6:
                    if (value < 40)
                        cad.Append(" (Bajo)");
                    else if (value > 75)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//NEUTROFILOS
                case 7:
                    if (value < 5)
                        cad.Append(" (Bajo)");
                    else if (value > 8)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//MONOCITOS
                case 8:
                    if (value < 0)
                        cad.Append(" (Bajo)");
                    else if (value > 3)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//EOSINOFILOS
                case 9:
                    if (value < 21)
                        cad.Append(" (Bajo)");
                    else if (value > 47)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//LINFOCITOS
                case 10:
                    if (value < 0)
                        cad.Append(" (Bajo)");
                    else if (value > 1)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//BASOFILOS
                case 11:
                    if (value < 150)
                        cad.Append(" (Bajo)");
                    else if (value > 450)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//RECUENTO DE PLAQUETAS (HMG)
                case 14:
                    if (value < 1)
                        cad.Append(" (Bajo)");
                    else if (value > 5)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//TIEMPO DE SANGRIA
                case 15:
                    if (value < 1)
                        cad.Append(" (Bajo)");
                    else if ( value > 10)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//TIEMPO DE COAGULACION
                case 16:
                    switch (paciente.Genero)
                    {
                        case 0:
                            if (value >10m)
                                cad.Append(" (Alto)");
                            else
                                cad.Append(" (Normal)");
                            break;
                        case 1:
                            if (value > 15m)
                                cad.Append(" (Alto)");
                            else
                                cad.Append(" (Normal)");
                            break;
                    }
                    break;//CONSTANTES CORPUSCULARES
                case 17:
                    if (value >= 80 && value <= 90)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Patologico)");
                    break;//VELOCIDAD DE SEDIMENTACION GLOBULAR
                case 19:
                    if (value < 2)
                        cad.Append(" (Bajo)");
                    else if (value > 7.5m)
                        cad.Append(" (Patologico)");
                    else
                        cad.Append(" (Normal)");
                    break;//ACIDO URICO
                case 20:
                    if (value < 3.5m)
                        cad.Append(" (Bajo)");
                    else if (value > 4.8m)
                        cad.Append(" (Patologico)");
                    else
                        cad.Append(" (Normal)");
                    break;//ALBUMINA
                case 21:
                    switch (paciente.Genero)
                    {
                        case 0:
                            if (value < 14)
                                cad.Append(" (Bajo)");
                            else if (value > 26)
                                cad.Append(" (Patologico)");
                            else
                                cad.Append(" (Normal)");
                            break;
                        case 1:
                            if (value < 11)
                                cad.Append(" (Bajo)");
                            else if (value > 20m)
                                cad.Append(" (Patologico)");
                            else
                                cad.Append(" (Normal)");
                            break;
                    }

                    break;//CREATININA EN ORINA
                case 22:
                    switch (paciente.Genero)
                    {
                        case 0:
                            if (value < 0.2m)
                                cad.Append(" (Bajo)");
                            else if (value > 1.3m)
                                cad.Append(" (Alto)");
                            else
                                cad.Append(" (Normal)");
                            break;
                        case 1:
                            if (value < 0.2m)
                                cad.Append(" (Bajo)");
                            else if (value > 0.96m)
                                cad.Append(" (Alto)");
                            else
                                cad.Append(" (Normal)");
                            break;
                    }
                    break; //CREATININA SERICA
                case 23:
                    switch (paciente.Genero)
                    {
                        case 0:
                            if (value >= 94 && value <= 140)
                                cad.Append(" (Normal)");
                            else
                                cad.Append(" (Patologico)");
                            break;
                        case 1:
                            if (value >= 72 && value <= 110)
                                cad.Append(" (Normal)");
                            else
                                cad.Append(" (Patologico)");
                            break;
                    }
                    break;//DEPURACION DE CREATININA
                case 24:
                    switch (paciente.Genero)
                    {
                        case 0:
                            if (value >= 8 && value <= 46)
                                cad.Append(" (Normal)");
                            else
                                cad.Append(" (Patologico)");
                            break;
                        case 1:
                            if (value >= 7 && value <= 29)
                                cad.Append(" (Normal)");
                            else
                                cad.Append(" (Patologico)");
                            break;
                    }
                    break;//GAMMAGLUTAMILTRANSEPTIDASA
                case 25:
                    if (value < 70)
                        cad.Append(" (Bajo)");
                    else if (value > 140)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//GLUCOSA (POSTPRANDIAL)
                case 26:
                    if (value < 70)
                        cad.Append(" (Bajo)");
                    else if (value > 110)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//GLUCOSA (BASAL)
                case 27:
                    if (value < 2.5m)
                        cad.Append(" (Bajo)");
                    else if (value > 2.9m)
                        cad.Append(" (Patologico)");
                    else
                        cad.Append(" (Normal)");
                    break;//GLOBULINA
                case 28:
                    if (value < 6.1m)
                        cad.Append(" (Bajo)");
                    else if (value > 7.9m)
                        cad.Append(" (Patologico)");
                    else
                        cad.Append(" (Normal)");
                    break;//PROTEINA TOTAL
                case 30:
                    if (value >= 150m)
                        cad.Append(" (Patologico)");
                    else
                        cad.Append(" (Normal)");
                    break;//PROTEINA EN ORINA DE 24 HORAS
                case 31:
                    if (value <= 200)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Patologico)");

                    break;//COLESTEROL TOTAL
                case 32:
                    if (value <= 150)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Patologico)");

                    break;//TRIGLICERIDOS
                case 33:
                    if (value > 35)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Patologico)");
                    break;//COLESTEROL HDL
                case 34:
                    if (value <= 130)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Patologico)");
                    break;//COLESTEROL LDL
                case 35:
                    if (value <= 50)
                        cad.Append(" (Normal)");
                    else
                        cad.Append(" (Patologico)");

                    break;//COLESTEROL VLDL
                case 36:
                    if (value < 0)
                        cad.Append(" (Bajo)");
                    else if (value > 125)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//FOSFATA ALCALINA
                case 37:
                    if (years <=10)
                    {
                        if (value < 5)
                            cad.Append(" (Bajo)");
                        else if (value > 18)
                            cad.Append(" (Alto)");
                        else
                            cad.Append(" (Normal)");
                    }
                    else
                    {
                        if (value < 7)
                            cad.Append(" (Bajo)");
                        else if (value > 20)
                            cad.Append(" (Alto)");
                        else
                            cad.Append(" (Normal)");
                    }
                    
                    break;//UREA
                case 38:
                    if (value < 0)
                        cad.Append(" (Bajo)");
                    else if (value > 40)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//TRANSAMINASAS TGP
                case 39:
                    if (value < 0)
                        cad.Append(" (Bajo)");
                    else if (value > 37)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//TRANSAMINASAS TGO
                case 40:
                    if (value < 0)
                        cad.Append(" (Bajo)");
                    else if (value > 1.2m)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//BILIRRUBINA TOTAL
                case 41:
                    if (value < 0)
                        cad.Append(" (Bajo)");
                    else if (value > 0.23m)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//BILIRRUBINA DIRECTA
                case 42:
                    if (value < 0)
                        cad.Append(" (Bajo)");
                    else if (value > 0.37m)
                        cad.Append(" (Alto)");
                    else
                        cad.Append(" (Normal)");
                    break;//BILIRRUBINA INDIRECTA
                case 73:
                    if (value < 7)
                        cad.Append(" (Acido)");
                    else if (value > 7)
                        cad.Append(" (Basico)");
                    else
                        cad.Append(" (Neutro)");
                    break;//PH
                case 77:
                    if (value < 10)
                        cad.Append(" (Normal)");
                    else if (value > 20)
                        cad.Append(" (Patologico)");
                    else
                        cad.Append(" (Regular Alto)");

                    break;//LEUCOCITOS (EXM)
                case 78:
                    if (value < 5)
                        cad.Append(" (Normal)");
                    else if (value > 20)
                        cad.Append(" (Patologico)");
                    else
                        cad.Append(" (Regular Alto)");
                    break;//HEMATIES (EXM)
                case 99:
                    if (value < 140)
                        cad.Append(" (Normal)");
                    else if (value > 200)
                        cad.Append(" (Diabetes)");
                    else
                        cad.Append(" (Intolerante)");

                    break;//GLUCOSA TOMA 1
                case 100:
                    if (value < 140)
                        cad.Append(" (Normal)");
                    else if (value > 200)
                        cad.Append(" (Diabetes)");
                    else
                        cad.Append(" (Intolerante)");
                    break;//GLUCOSA TOMA 2
                case 141:
                    if (value < 0)
                        cad.Append(" (Bajo)");
                    else if (value > 5)
                        cad.Append(" (Patologico)");
                    else
                        cad.Append(" (Normal)");
                    break;//LEUCOCITOS EN MOCO FECAL
                case 211:
                    if (value < 11)
                        cad.Append(" (Bajo)");
                    else if (value > 13.5m)
                        cad.Append(" (Patologico)");
                    else
                        cad.Append(" (Normal)");
                    break;//TIEMPO DE PROTOMBINA
                case 212:
                    if (value < 25)
                        cad.Append(" (Bajo)");
                    else if (value > 35)
                        cad.Append(" (Patologico)");
                    else
                        cad.Append(" (Normal)");
                    break;//TIEMPO DE TROMBOPLASTINA

            }

            return cad.ToString();
        }
        
        public string GetAge(Paciente paciente)
        {
            cadena.Clear();
            DateTime actual = DateTime.Now;
            DateTime nacim= paciente.FechaNacimiento;
            int daysForYear, years;

            TimeSpan tiempo = actual - nacim;
            years= tiempo.Days / 365;
            daysForYear = tiempo.Days%365;

            int dayCount=1;
            int monthCount = 1;
            for (int i=1;i<daysForYear+1;i++)
            {
                if (DateTime.DaysInMonth(actual.Year, monthCount) == dayCount)
                {
                    dayCount = 1;
                    monthCount++;
                }
                else
                    dayCount++;
            }
            monthCount--;
            
            if (years > 0) cadena.Append(years).Append(" Años,");
            if (monthCount > 0) cadena.Append(monthCount).Append(" Meses,");
            if (dayCount > 0) cadena.Append(dayCount).Append(" Dias");
            return cadena.ToString();

        }
    }
}
