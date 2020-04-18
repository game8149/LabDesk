using Entity.Code.Analysis;
using Entity.Code.Analysis.Templates.Print; 
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace LabServices.Code.PrintingManager
{
    public class Printer
    {
        private PrintBuffer buffer;
        private PrintPreviewDialog printPreviewDialog;
        private Section sector;

        public void ContruirVistaPrevia(Dictionary<int, ExamOrder> ordenes)
        {
            ExamResult examen = new ExamResult();
            this.sector = new Section();
            PrintDocument document = new PrintDocument
            {
                DefaultPageSettings = { PaperSize = new PaperSize("A4", 0x33b, 0x491) }
            };
            this.sector.Setting.PaperSize.Width = document.DefaultPageSettings.PaperSize.Width;
            this.sector.Setting.PaperSize.Height = document.DefaultPageSettings.PaperSize.Height;
            this.sector.Setting.Margen = new Padding(5, 5, 5, 40);
            List<TemplatePrint> formatos = new List<TemplatePrint>();
            foreach (ExamOrder orden in ordenes.Values)
            {
                TemplatePrint item = SectionBuilder.GetInstance().CrearAllDocumento(examen(orden), orden, 7.5f, this.sector.Setting.PaperSize);
                formatos.Add(item);
            }
            this.buffer = new PrintBuffer(formatos);
            PrintDialog dialog1 = new PrintDialog
            {
                Document = document
            };
            if (dialog1.ShowDialog() == DialogResult.OK)
            {
                document.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                document.Print();
            }
        }

        public void ContruirVistaPreviaExamenPaciente(ExamOrder orden, Dictionary<int, ExamResult> examenes)
        {
            this.sector = new Section();
            PrintDocument document = new PrintDocument
            {
                DefaultPageSettings = { PaperSize = new PaperSize("A4", 0x33b, 0x491) }
            };
            this.sector.Setting.PaperSize.Width = document.DefaultPageSettings.PaperSize.Width;
            this.sector.Setting.PaperSize.Height = document.DefaultPageSettings.PaperSize.Height;
            document.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
            List<TemplatePrint> formatos = new List<TemplatePrint>();
            TemplatePrint item = SectionBuilder.GetInstance().CrearAllDocumento(examenes, orden, 7.5f, this.sector.Setting.PaperSize);
            formatos.Add(item);
            this.buffer = new PrintBuffer(formatos);
        }

        private void PaintCabecera(FormatoImpresionCabecera cabecera, Graphics grafico, Section hoja)
        {
            // Image image = ScaleImage(Resources.logo_regionbn, 50, 50);
            //Image image2 = ScaleImage(Resources.Tratado2, 200, 200);
            hoja.Header = 0;
            Point inicio = hoja.InitPosition;
            Point limite = hoja.FinalPosition;
            //grafico.DrawImage(image, (limite.X - 0x19) - image.Width, inicio.Y);
            SizeF ef = grafico.MeasureString(cabecera.Institucion, PageStyleFontResource.TituloFormato);
            grafico.DrawString(cabecera.Institucion, PageStyleFontResource.TituloFormato, System.Drawing.Brushes.Black, ((inicio.X + limite.X) / 2) - (ef.Width / 2f), (float)(inicio.Y + hoja.Header));
            hoja.Header += (int)ef.Height;
            ef = grafico.MeasureString(cabecera.Direccion, PageStyleFontResource.Item);
            grafico.DrawString(cabecera.Direccion, PageStyleFontResource.Item, System.Drawing.Brushes.Black, ((inicio.X + limite.X) / 2) - (ef.Width / 2f), (float)(inicio.Y + hoja.Header));
            hoja.Header += (((int)ef.Height) + hoja.Setting.Sangria) + 3;
            grafico.DrawString(cabecera.Nombre, PageStyleFontResource.Item, System.Drawing.Brushes.Black, (float)inicio.X, (float)(inicio.Y + hoja.Header));
            ef = grafico.MeasureString(cabecera.Nombre, PageStyleFontResource.Item);
            hoja.Header += ((int)ef.Height) + hoja.Setting.Sangria;
            ef = grafico.MeasureString(cabecera.Orden, PageStyleFontResource.Item);
            grafico.DrawString(cabecera.Orden, PageStyleFontResource.Item, System.Drawing.Brushes.Black, (float)inicio.X, (float)(inicio.Y + hoja.Header));
            grafico.DrawString(cabecera.Fecha, PageStyleFontResource.Item, System.Drawing.Brushes.Black, (float)((inicio.X + ((limite.X - inicio.X) / 3)) - 30), (float)(inicio.Y + hoja.Header));
            grafico.DrawString(cabecera.UltimaRev, PageStyleFontResource.Item, System.Drawing.Brushes.Black, (float)((inicio.X + ((2 * (limite.X - inicio.X)) / 3)) - 0x37), (float)(inicio.Y + hoja.Header));
            hoja.Header += ((int)ef.Height) + hoja.Setting.Sangria;
            ef = grafico.MeasureString(cabecera.Edad, PageStyleFontResource.Item);
            grafico.DrawString(cabecera.Edad, PageStyleFontResource.Item, System.Drawing.Brushes.Black, (float)inicio.X, (float)(inicio.Y + hoja.Header));
            grafico.DrawString(cabecera.Historia, PageStyleFontResource.Item, System.Drawing.Brushes.Black, (float)((inicio.X + ((limite.X - inicio.X) / 3)) - 30), (float)(inicio.Y + hoja.Header));
            grafico.DrawString(cabecera.Doctor, PageStyleFontResource.Item, System.Drawing.Brushes.Black, (float)((inicio.X + ((2 * (limite.X - inicio.X)) / 3)) - 0x37), (float)(inicio.Y + hoja.Header));
            hoja.Header += ((int)ef.Height) + hoja.Setting.Sangria;
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Black)
            {
                Brush = System.Drawing.Brushes.Black,
                Width = 0.6f
            };
            grafico.DrawLine(pen, new Point(0, hoja.Header + inicio.Y), new Point(limite.X - (hoja.Setting.Margen.Left * 2), inicio.Y + hoja.Header));
            hoja.Header += hoja.Setting.Sangria;
            //grafico.DrawImage(image2, (int) (((inicio.X + limite.X) - image2.Size.Width) / 2), (int) ((((inicio.Y + hoja.Cabezal) + limite.Y) - image2.Size.Height) / 2));
            grafico.DrawString(cabecera.Responsable, PageStyleFontResource.Fecha, System.Drawing.Brushes.Black, (float)(inicio.X + 5), (float)(limite.Y - 0x21));
            grafico.DrawLine(pen, new Point(inicio.X, limite.Y - 0x23), new Point((limite.X - hoja.Setting.Margen.Left) - 10, limite.Y - 0x23));
            hoja.Header += inicio.Y;
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            SizeF ef = new SizeF();
            Graphics grafico = ev.Graphics;
            try
            {
                if (!this.buffer.EmptyTemplates())
                {
                    if (!this.buffer._isReadMode)
                    {
                        this.buffer.NextTemplate();
                        this.buffer.NextPage();
                        this.buffer._isReadMode = true;
                    }
                    for (int i = 1; i < 5; i++)
                    {
                        FormatoImpresion formato = this.buffer.GetTemplate();
                        this.sector.UpdatePosition(i);
                        this.PaintCabecera(formato.Cabecera, grafico, this.sector);
                        this.buffer.GetPage();
                        do
                        {
                            if (this.buffer.NextLine())
                            {
                                this.buffer._isReadMode = true;
                                FormatoImpresionPaginaLinea linea = this.buffer.GetLine();
                                switch (linea.TipoLinea)
                                {
                                    case FormatoImpresionPaginaLinea.TipoPaginaLinea.TituloExamen:
                                        grafico.DrawString(linea.Nombre, PageStyleFontResource.TituloExamen, System.Drawing.Brushes.Black, (float)(this.sector.InitPosition.X + this.sector.Setting.Margen.Left), (float)this.sector.Header);
                                        ef = grafico.MeasureString(linea.Nombre, PageStyleFontResource.TituloExamen);
                                        break;

                                    case FormatoImpresionPaginaLinea.TipoPaginaLinea.TituloArea:
                                        ef = grafico.MeasureString(linea.Nombre, PageStyleFontResource.TituloArea);
                                        grafico.DrawString(linea.Nombre, PageStyleFontResource.TituloArea, System.Drawing.Brushes.Black, (((this.sector.InitPosition.X + this.sector.FinalPosition.X) / 2) - (ef.Width / 2f)) + this.sector.Setting.Margen.Left, (float)this.sector.Header);
                                        ef.Height += 5f;
                                        break;

                                    case FormatoImpresionPaginaLinea.TipoPaginaLinea.ItemSimple:
                                        grafico.DrawString(linea.Nombre + ":  " + linea.Resultado, PageStyleFontResource.Item, System.Drawing.Brushes.Black, (float)(this.sector.InitPosition.X + (this.sector.Setting.Margen.Left * 2)), (float)this.sector.Header);
                                        ef = grafico.MeasureString(linea.Nombre, PageStyleFontResource.Item);
                                        break;

                                    case FormatoImpresionPaginaLinea.TipoPaginaLinea.ItemTexto:
                                        grafico.DrawString(linea.Resultado, PageStyleFontResource.Item, System.Drawing.Brushes.Black, (float)(this.sector.InitPosition.X + (this.sector.Setting.Margen.Left * 2)), (float)this.sector.Header);
                                        ef = grafico.MeasureString(linea.Resultado, PageStyleFontResource.Item);
                                        break;

                                    case FormatoImpresionPaginaLinea.TipoPaginaLinea.TituloGrupo:
                                        grafico.DrawString(linea.Nombre + ":  ", PageStyleFontResource.TituloGrupo, System.Drawing.Brushes.Black, (float)(this.sector.InitPosition.X + this.sector.Setting.Margen.Left), (float)this.sector.Header);
                                        ef = grafico.MeasureString(linea.Nombre, PageStyleFontResource.TituloGrupo);
                                        break;
                                }
                                this.sector.Header += ((int)ef.Height) + this.sector.Setting.Sangria;
                            }
                            else
                            {
                                this.buffer._isReadMode = false;
                                if (!this.buffer.NextPage())
                                {
                                    if (!this.buffer.NextTemplate())
                                    {
                                        i = 5;
                                    }
                                    else
                                    {
                                        this.buffer.NextPage();
                                        this.buffer._isReadMode = true;
                                    }
                                }
                                else
                                {
                                    this.buffer._isReadMode = true;
                                }
                                continue;
                            }
                        }
                        while (this.sector.FillableSector());
                    }
                }
                ev.HasMorePages = this.buffer._isReadMode;
            }
            catch (Exception)
            {
                FormMensaje.Error(RecursosUIMensajes.MsgImpresionError);
            }
        }

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            double num = ((double)maxHeight) / ((double)image.Height);
            double num2 = Math.Min(((double)maxWidth) / ((double)image.Width), num);
            int width = (int)(image.Width * num2);
            int height = (int)(image.Height * num2);
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return bitmap;
        }
    }
}
