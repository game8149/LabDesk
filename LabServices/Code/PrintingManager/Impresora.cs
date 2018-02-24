using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;


namespace LogicLab.Code.PrintingManager
{
    public class Impresora
    {
        private BufferImpresion buffer;
        private PrintPreviewDialog printPreviewDialog;
        private Sector sector;

        public void ContruirVistaPrevia(Dictionary<int, Orden> ordenes)
        {
            MinLab.Code.LogicLayer.LogicaExamen.LogicaExamen examen = new MinLab.Code.LogicLayer.LogicaExamen.LogicaExamen();
            this.sector = new Sector();
            PrintDocument document = new PrintDocument {
                DefaultPageSettings = { PaperSize = new PaperSize("A4", 0x33b, 0x491) }
            };
            this.sector.Configuracion.TamañoPapel.Width = document.DefaultPageSettings.PaperSize.Width;
            this.sector.Configuracion.TamañoPapel.Height = document.DefaultPageSettings.PaperSize.Height;
            this.sector.Configuracion.Margen = new Padding(5, 5, 5, 40);
            List<FormatoImpresion> formatos = new List<FormatoImpresion>();
            foreach (Orden orden in ordenes.Values)
            {
                FormatoImpresion item = ConstructorFicha.GetInstance().CrearAllDocumento(examen.RecuperarExamenes(orden), orden, 7.5f, this.sector.Configuracion.TamañoPapel);
                formatos.Add(item);
            }
            this.buffer = new BufferImpresion(formatos);
            PrintDialog dialog1 = new PrintDialog {
                Document = document
            };
            if (dialog1.ShowDialog() == DialogResult.OK)
            {
                document.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                document.Print();
            }
        }

        public void ContruirVistaPreviaExamenPaciente(Orden orden, Dictionary<int, Examen> examenes)
        {
            this.sector = new Sector();
            PrintDocument document = new PrintDocument {
                DefaultPageSettings = { PaperSize = new PaperSize("A4", 0x33b, 0x491) }
            };
            this.sector.Configuracion.TamañoPapel.Width = document.DefaultPageSettings.PaperSize.Width;
            this.sector.Configuracion.TamañoPapel.Height = document.DefaultPageSettings.PaperSize.Height;
            document.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
            List<FormatoImpresion> formatos = new List<FormatoImpresion>();
            FormatoImpresion item = ConstructorFicha.GetInstance().CrearAllDocumento(examenes, orden, 7.5f, this.sector.Configuracion.TamañoPapel);
            formatos.Add(item);
            this.buffer = new BufferImpresion(formatos);
        }

        private void PaintCabecera(FormatoImpresionCabecera cabecera, Graphics grafico, Sector hoja)
        {
           // Image image = ScaleImage(Resources.logo_regionbn, 50, 50);
            //Image image2 = ScaleImage(Resources.Tratado2, 200, 200);
            hoja.Cabezal = 0;
            Point inicio = hoja.Inicio;
            Point limite = hoja.Limite;
            //grafico.DrawImage(image, (limite.X - 0x19) - image.Width, inicio.Y);
            SizeF ef = grafico.MeasureString(cabecera.Institucion, EstiloFuentePagina.TituloFormato);
            grafico.DrawString(cabecera.Institucion, EstiloFuentePagina.TituloFormato, System.Drawing.Brushes.Black, ((inicio.X + limite.X) / 2) - (ef.Width / 2f), (float) (inicio.Y + hoja.Cabezal));
            hoja.Cabezal += (int) ef.Height;
            ef = grafico.MeasureString(cabecera.Direccion, EstiloFuentePagina.Item);
            grafico.DrawString(cabecera.Direccion, EstiloFuentePagina.Item, System.Drawing.Brushes.Black, ((inicio.X + limite.X) / 2) - (ef.Width / 2f), (float) (inicio.Y + hoja.Cabezal));
            hoja.Cabezal += (((int) ef.Height) + hoja.Configuracion.Sangria) + 3;
            grafico.DrawString(cabecera.Nombre, EstiloFuentePagina.Item, System.Drawing.Brushes.Black, (float) inicio.X, (float) (inicio.Y + hoja.Cabezal));
            ef = grafico.MeasureString(cabecera.Nombre, EstiloFuentePagina.Item);
            hoja.Cabezal += ((int) ef.Height) + hoja.Configuracion.Sangria;
            ef = grafico.MeasureString(cabecera.Orden, EstiloFuentePagina.Item);
            grafico.DrawString(cabecera.Orden, EstiloFuentePagina.Item, System.Drawing.Brushes.Black, (float) inicio.X, (float) (inicio.Y + hoja.Cabezal));
            grafico.DrawString(cabecera.Fecha, EstiloFuentePagina.Item, System.Drawing.Brushes.Black, (float) ((inicio.X + ((limite.X - inicio.X) / 3)) - 30), (float) (inicio.Y + hoja.Cabezal));
            grafico.DrawString(cabecera.UltimaRev, EstiloFuentePagina.Item, System.Drawing.Brushes.Black, (float) ((inicio.X + ((2 * (limite.X - inicio.X)) / 3)) - 0x37), (float) (inicio.Y + hoja.Cabezal));
            hoja.Cabezal += ((int) ef.Height) + hoja.Configuracion.Sangria;
            ef = grafico.MeasureString(cabecera.Edad, EstiloFuentePagina.Item);
            grafico.DrawString(cabecera.Edad, EstiloFuentePagina.Item, System.Drawing.Brushes.Black, (float) inicio.X, (float) (inicio.Y + hoja.Cabezal));
            grafico.DrawString(cabecera.Historia, EstiloFuentePagina.Item, System.Drawing.Brushes.Black, (float) ((inicio.X + ((limite.X - inicio.X) / 3)) - 30), (float) (inicio.Y + hoja.Cabezal));
            grafico.DrawString(cabecera.Doctor, EstiloFuentePagina.Item, System.Drawing.Brushes.Black, (float) ((inicio.X + ((2 * (limite.X - inicio.X)) / 3)) - 0x37), (float) (inicio.Y + hoja.Cabezal));
            hoja.Cabezal += ((int) ef.Height) + hoja.Configuracion.Sangria;
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Black) {
                Brush = System.Drawing.Brushes.Black,
                Width = 0.6f
            };
            grafico.DrawLine(pen, new Point(0, hoja.Cabezal + inicio.Y), new Point(limite.X - (hoja.Configuracion.Margen.Left * 2), inicio.Y + hoja.Cabezal));
            hoja.Cabezal += hoja.Configuracion.Sangria;
            //grafico.DrawImage(image2, (int) (((inicio.X + limite.X) - image2.Size.Width) / 2), (int) ((((inicio.Y + hoja.Cabezal) + limite.Y) - image2.Size.Height) / 2));
            grafico.DrawString(cabecera.Responsable, EstiloFuentePagina.Fecha, System.Drawing.Brushes.Black, (float) (inicio.X + 5), (float) (limite.Y - 0x21));
            grafico.DrawLine(pen, new Point(inicio.X, limite.Y - 0x23), new Point((limite.X - hoja.Configuracion.Margen.Left) - 10, limite.Y - 0x23));
            hoja.Cabezal += inicio.Y;
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            SizeF ef = new SizeF();
            Graphics grafico = ev.Graphics;
            try
            {
                if (!this.buffer.EmptyListFormato())
                {
                    if (!this.buffer.IsModeRead)
                    {
                        this.buffer.SiguienteFormato();
                        this.buffer.SiguientePagina();
                        this.buffer.IsModeRead = true;
                    }
                    for (int i = 1; i < 5; i++)
                    {
                        FormatoImpresion formato = this.buffer.GetFormato();
                        this.sector.ActualizarPosicion(i);
                        this.PaintCabecera(formato.Cabecera, grafico, this.sector);
                        this.buffer.GetPagina();
                        do
                        {
                            if (this.buffer.SiguienteLinea())
                            {
                                this.buffer.IsModeRead = true;
                                FormatoImpresionPaginaLinea linea = this.buffer.GetLinea();
                                switch (linea.TipoLinea)
                                {
                                    case FormatoImpresionPaginaLinea.TipoPaginaLinea.TituloExamen:
                                        grafico.DrawString(linea.Nombre, EstiloFuentePagina.TituloExamen, System.Drawing.Brushes.Black, (float) (this.sector.Inicio.X + this.sector.Configuracion.Margen.Left), (float) this.sector.Cabezal);
                                        ef = grafico.MeasureString(linea.Nombre, EstiloFuentePagina.TituloExamen);
                                        break;

                                    case FormatoImpresionPaginaLinea.TipoPaginaLinea.TituloArea:
                                        ef = grafico.MeasureString(linea.Nombre, EstiloFuentePagina.TituloArea);
                                        grafico.DrawString(linea.Nombre, EstiloFuentePagina.TituloArea, System.Drawing.Brushes.Black, (((this.sector.Inicio.X + this.sector.Limite.X) / 2) - (ef.Width / 2f)) + this.sector.Configuracion.Margen.Left, (float) this.sector.Cabezal);
                                        ef.Height += 5f;
                                        break;

                                    case FormatoImpresionPaginaLinea.TipoPaginaLinea.ItemSimple:
                                        grafico.DrawString(linea.Nombre + ":  " + linea.Resultado, EstiloFuentePagina.Item, System.Drawing.Brushes.Black, (float) (this.sector.Inicio.X + (this.sector.Configuracion.Margen.Left * 2)), (float) this.sector.Cabezal);
                                        ef = grafico.MeasureString(linea.Nombre, EstiloFuentePagina.Item);
                                        break;

                                    case FormatoImpresionPaginaLinea.TipoPaginaLinea.ItemTexto:
                                        grafico.DrawString(linea.Resultado, EstiloFuentePagina.Item, System.Drawing.Brushes.Black, (float) (this.sector.Inicio.X + (this.sector.Configuracion.Margen.Left * 2)), (float) this.sector.Cabezal);
                                        ef = grafico.MeasureString(linea.Resultado, EstiloFuentePagina.Item);
                                        break;

                                    case FormatoImpresionPaginaLinea.TipoPaginaLinea.TituloGrupo:
                                        grafico.DrawString(linea.Nombre + ":  ", EstiloFuentePagina.TituloGrupo, System.Drawing.Brushes.Black, (float) (this.sector.Inicio.X + this.sector.Configuracion.Margen.Left), (float) this.sector.Cabezal);
                                        ef = grafico.MeasureString(linea.Nombre, EstiloFuentePagina.TituloGrupo);
                                        break;
                                }
                                this.sector.Cabezal += ((int) ef.Height) + this.sector.Configuracion.Sangria;
                            }
                            else
                            {
                                this.buffer.IsModeRead = false;
                                if (!this.buffer.SiguientePagina())
                                {
                                    if (!this.buffer.SiguienteFormato())
                                    {
                                        i = 5;
                                    }
                                    else
                                    {
                                        this.buffer.SiguientePagina();
                                        this.buffer.IsModeRead = true;
                                    }
                                }
                                else
                                {
                                    this.buffer.IsModeRead = true;
                                }
                                continue;
                            }
                        }
                        while (this.sector.SectorLlenable());
                    }
                }
                ev.HasMorePages = this.buffer.IsModeRead;
            }
            catch (Exception)
            {
                FormMensaje.Error(RecursosUIMensajes.MsgImpresionError);
            }
        }

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            double num = ((double) maxHeight) / ((double) image.Height);
            double num2 = Math.Min(((double) maxWidth) / ((double) image.Width), num);
            int width = (int) (image.Width * num2);
            int height = (int) (image.Height * num2);
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return bitmap;
        }
    }
}
