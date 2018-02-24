using MinLab.Code.EntityLayer.ArchivoCaja;
using MinLab.Code.LogicLayer.LogicaExamen;
using MinLab.Code.LogicLayer.LogicaPaciente;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MinLab.Code.PresentationLayer.GUIHistorial.ComponenteImpresion.FormatoImpresion;

namespace MinLab.Code.PresentationLayer.GUIHistorial.ComponenteImpresion
{
    public class Impresora
    {
        List<FormatoImpresion> ficheros = new List<FormatoImpresion>();

        int indexFichero = 0;
        int indexFicheroFila = 0;

        // ATRIBUTOS DEL PUNTERO DE IMPRESION
        Point pActual = new Point();
        Point pLimite = new Point();
        int margen = 4;
        int lineaPagina = 0;


        Size hojaSize = new Size();
        int spaceV = 5;

        //ATRIBUTOS DE STILO DE HOJA
        Font fontTituloCabecera = new Font("Segoe UI", 10, FontStyle.Bold);//Para cabecera Titulo 
        Font fontTitulo = new Font("Segoe UI", 9, FontStyle.Bold);//Para cabecera Titulo 
        Font fontSubTitulo = new Font("Segoe UI", 9, FontStyle.Regular);//Para cabecera Titulo 
        Font fontItem = new Font("Segoe UI Light", 10, FontStyle.Regular);//Para cabecera Titulo 
        Font fontRespuesta = new Font("Segoe UI", 10, FontStyle.Regular);//Para cabecera Titulo 
        SizeF stringSize = new SizeF();


        PrintPreviewDialog printPreviewDialog;

        public void ContruirVistaPrevia(Dictionary<int,Orden> ordenes)
        {
            BLPaciente enlace = new BLPaciente();
            FormatoImpresion fichero;
            foreach (Orden orden in ordenes.Values)
            {
                fichero = ConstructorFicha.GetInstance().CrearDocumento(orden, enlace.ObtenerPerfilPorId(orden.IdPaciente), BLExamen.RecuperarExamenes(orden));
                ficheros.Add(fichero);
            }

            this.printPreviewDialog = new PrintPreviewDialog();
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Location = new System.Drawing.Point(29, 29);
            this.printPreviewDialog.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.printPreviewDialog.Name = "Vista Previa de Impresión";
            hojaSize.Height = 1170;
            hojaSize.Width = 827;
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1170); // all sizes are converted from mm to inches & then multiplied by 100.
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
            printPreviewDialog.Document = pd;
            printPreviewDialog.ShowDialog();
            indexFichero = 0;
            ficheros.Clear();

        }


        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Graphics graphics = ev.Graphics;
            indexFicheroFila = 0;
            int pag = 0;
            for (pag = 1; pag < 5; pag++)
            {
                Console.WriteLine("En Pagina " + pag);
                CalcularPuntos(pag);
                Console.WriteLine("Pos X,Y: " + pActual.X + " - " + pActual.Y);
                lineaPagina = PaintCabecera(graphics, indexFichero, pActual, pLimite);
                while (indexFicheroFila < ficheros[indexFichero].Detalles.Count)
                {
                    PaginaLinea linea = ficheros[indexFichero].Detalles[indexFicheroFila];
                    switch (linea.TipoLinea)
                    {
                        case PaginaLinea.TipoPaginaLinea.TituloInicio:
                            graphics.DrawString(linea.Nombre, fontTitulo, Brushes.Black, pActual.X + margen, pActual.Y + lineaPagina);
                            break;
                        case PaginaLinea.TipoPaginaLinea.SubTitulo:
                            graphics.DrawString("(" + linea.Nombre + ")", fontSubTitulo, Brushes.Black, pActual.X + margen, pActual.Y + lineaPagina);
                            break;
                        case PaginaLinea.TipoPaginaLinea.ItemSimple:
                            graphics.DrawString(linea.Nombre + ":  " + linea.Resultado, fontItem, Brushes.Black, pActual.X + margen * 2, pActual.Y + lineaPagina);
                            break;
                        case PaginaLinea.TipoPaginaLinea.GrupoInicio:
                            graphics.DrawString(linea.Nombre + ":  ", fontItem, Brushes.Black, pActual.X + margen, pActual.Y + lineaPagina);
                            break;
                    }

                    stringSize = graphics.MeasureString(linea.Nombre, fontItem);
                    lineaPagina += ((int)stringSize.Height + spaceV);
                    indexFicheroFila++;
                    if (lineaPagina >= pLimite.Y - 40)
                    {
                        break;
                    }
                }

                if (indexFicheroFila >= ficheros[indexFichero].Detalles.Count)
                {
                    indexFichero++;
                    if (indexFichero < ficheros.Count())
                    {
                        indexFicheroFila = 0;
                        Console.WriteLine("Pase a " + indexFichero);
                        if (pag == 4)
                            ev.HasMorePages = true;

                    }
                    else
                    {
                        ev.HasMorePages = false;
                        indexFichero = 0;
                        break;
                    }
                }
            }
        }

        private int PaintCabecera(Graphics grafico, int indiceFichero, Point actual, Point limit)
        {
            int lineaPag = 0;

            Console.WriteLine("Cabecera de " + ficheros[indiceFichero].Historia);
            stringSize = grafico.MeasureString(ficheros[indiceFichero].Institucion, fontTituloCabecera);
            grafico.DrawString(ficheros[indiceFichero].Institucion, fontTituloCabecera, Brushes.Black, (actual.X + limit.X) / 2 - stringSize.Width / 2, actual.Y + lineaPag);
            stringSize = grafico.MeasureString(ficheros[indiceFichero].Institucion, fontTituloCabecera);
            lineaPag += ((int)stringSize.Height + spaceV);

            grafico.DrawString(ficheros[indiceFichero].Edad, fontItem, Brushes.Black, actual.X, actual.Y + lineaPag);
            grafico.DrawString(ficheros[indiceFichero].Historia, fontItem, Brushes.Black, (actual.X + limit.X) / 2, actual.Y + lineaPag);
            stringSize = grafico.MeasureString(ficheros[indiceFichero].Edad, fontItem);
            lineaPag += ((int)stringSize.Height + spaceV);

            grafico.DrawString(ficheros[indiceFichero].Nombre, fontItem, Brushes.Black, actual.X, actual.Y + lineaPag);
            stringSize = grafico.MeasureString(ficheros[indiceFichero].Nombre, fontItem);
            lineaPag += ((int)stringSize.Height + spaceV);

            grafico.DrawString(ficheros[indiceFichero].Doctor, fontItem, Brushes.Black, (actual.X + limit.X) / 2, actual.Y + lineaPag);
            grafico.DrawString(ficheros[indiceFichero].Fecha, fontItem, Brushes.Black, actual.X, actual.Y + lineaPag);
            stringSize = grafico.MeasureString(ficheros[indiceFichero].Doctor, fontItem);
            lineaPag += ((int)stringSize.Height + spaceV);

            //DIBUJA LA LINEA SEPARADORA
            Pen pen = new Pen(Color.Black);
            pen.Brush = Brushes.Black;
            pen.Width = 1.0f;
            grafico.DrawLine(pen, new Point(0, lineaPag + actual.Y), new Point(limit.X - margen * 2, actual.Y + lineaPag));
            lineaPag += spaceV;
            return lineaPag;
        }

        private void CalcularPuntos(int pag)
        {
            switch (pag)
            {
                case 1:
                    pActual.X = 0;
                    pLimite.X = hojaSize.Width / 2;
                    pActual.Y = 0;
                    pLimite.Y = hojaSize.Height / 2;
                    break;
                case 2:
                    pActual.X = hojaSize.Width / 2;
                    pLimite.X = hojaSize.Width;
                    pActual.Y = 0;
                    pLimite.Y = hojaSize.Height / 2;
                    break;
                case 3:
                    pActual.X = 0;
                    pLimite.X = hojaSize.Width / 2;
                    pActual.Y = hojaSize.Height / 2;
                    pLimite.Y = hojaSize.Height;
                    break;
                case 4:
                    pActual.X = hojaSize.Width / 2;
                    pLimite.X = hojaSize.Width;
                    pActual.Y = hojaSize.Height / 2;
                    pLimite.Y = hojaSize.Height;
                    break;
            }
        }



    }
}
