using Entity.Code.Base.Documentary;
using Entity.Code.Business;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Utilities.Code;
using static Entity.Code.Business.Person;

namespace Entity.Code.Analysis
{
    public class ExamResult : EntityDocumentState
    {
        public int Id { get; set; }
        public int IdTemplate { get; set; }
        public int IdOrder { get; set; }

        public IDictionary<int, ExamResultDetail> Items;


        public string Clasificate(Patient pac, int idTarifa, ExamResultDetail exdet)
        {
            StringBuilder builder = new StringBuilder();
            NumberFormatInfo provider = new NumberFormatInfo
            {
                NumberDecimalSeparator = "."
            };
            double num = double.Parse(exdet.Value, provider);
            TimeElapse tiempo = Utilities.Code.TimeSpan.CalcularEdad(pac.BirthDate);
            switch (exdet.IdTemplateExamAsk)
            {
                case 0xb7:
                    if ((num > 90.0) || (num < 80.0))
                    {
                        builder.Append(" (Patologico)");
                        break;
                    }
                    builder.Append(" (Normal)");
                    break;

                case 0xb8:
                    if ((num < 27.0) || (num > 32.0))
                    {
                        builder.Append(" (Patologico)");
                        break;
                    }
                    builder.Append(" (Normal)");
                    break;

                case 0xb9:
                    if ((num < 32.0) || (num > 36.0))
                    {
                        builder.Append(" (Patologico)");
                        break;
                    }
                    builder.Append(" (Normal)");
                    break;

                case 0xba:
                    if (((tiempo.Days > 10) || (tiempo.Months != 0)) || (tiempo.Years != 0))
                    {
                        if (((tiempo.Days > 10) && (tiempo.Months >= 0)) && (tiempo.Years >= 0))
                        {
                            if (num < 4500.0)
                            {
                                builder.Append(" (Bajo)");
                            }
                            else if (num > 5000.0)
                            {
                                builder.Append(" (Alto)");
                            }
                            else
                            {
                                builder.Append(" (Normal)");
                            }
                        }
                        break;
                    }
                    if (num >= 4500.0)
                    {
                        if (num > 5100.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 0xaf:
                    if (num < 25.0)
                    {
                        builder.Append(" (Patologico)");
                    }
                    else if (num > 35.0)
                    {
                        builder.Append(" (Patologico)");
                    }
                    else
                    {
                        builder.Append(" (Normal)");
                    }
                    break;

                case 1:
                    if (((tiempo.Days > 0x1d) || (tiempo.Months != 0)) || (tiempo.Years != 0))
                    {
                        if ((tiempo.Days > 0x1d) && (tiempo.Years == 0))
                        {
                            if (num < 11.0)
                            {
                                builder.Append(" (Bajo)");
                            }
                            else if (num > 12.0)
                            {
                                builder.Append(" (Alto)");
                            }
                            else
                            {
                                builder.Append(" (Normal)");
                            }
                        }
                        else if ((tiempo.Years >= 1) && (tiempo.Years <= 5))
                        {
                            if (num < 11.0)
                            {
                                builder.Append(" (Bajo)");
                            }
                            else if (num > 13.0)
                            {
                                builder.Append(" (Alto)");
                            }
                            else
                            {
                                builder.Append(" (Normal)");
                            }
                        }
                        else if ((tiempo.Years >= 6) && (tiempo.Years <= 10))
                        {
                            if (num < 12.0)
                            {
                                builder.Append(" (Bajo)");
                            }
                            else if (num > 13.5)
                            {
                                builder.Append(" (Alto)");
                            }
                            else
                            {
                                builder.Append(" (Normal)");
                            }
                        }
                        else if (tiempo.Years >= 11)
                        {
                            switch (pac.Sex)
                            {
                                case SexType.Man :
                                    if (num < 13.0)
                                    {
                                        builder.Append(" (Bajo)");
                                    }
                                    else if (num > 15.5)
                                    {
                                        builder.Append(" (Alto)");
                                    }
                                    else
                                    {
                                        builder.Append(" (Normal)");
                                    }
                                    break;

                                case SexType.Woman :
                                    if (idTarifa == 70)
                                    {
                                        if (num < 11.0)
                                        {
                                            builder.Append(" (Bajo)");
                                        }
                                        else if (num > 13.0)
                                        {
                                            builder.Append(" (Alto)");
                                        }
                                        else
                                        {
                                            builder.Append(" (Normal)");
                                        }
                                    }
                                    else if (num < 12.0)
                                    {
                                        builder.Append(" (Bajo)");
                                    }
                                    else if (num > 15.0)
                                    {
                                        builder.Append(" (Alto)");
                                    }
                                    else
                                    {
                                        builder.Append(" (Normal)");
                                    }
                                    goto Label_1388;
                            }
                        }
                        break;
                    }
                    if (num >= 14.55)
                    {
                        if (num > 23.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 2:
                    if (((tiempo.Days > 10) || (tiempo.Months != 0)) || (tiempo.Years != 0))
                    {
                        if (((tiempo.Days > 10) && (tiempo.Months >= 0)) && ((tiempo.Years >= 0) && (tiempo.Years < 14)))
                        {
                            if (num < 33.0)
                            {
                                builder.Append(" (Bajo)");
                            }
                            else if (num > 43.0)
                            {
                                builder.Append(" (Alto)");
                            }
                            else
                            {
                                builder.Append(" (Normal)");
                            }
                        }
                        else if (tiempo.Years >= 14)
                        {
                            switch (pac.Sex)
                            {
                                case SexType.Man:
                                    if (num < 40.0)
                                    {
                                        builder.Append(" (Bajo)");
                                    }
                                    else if (num > 50.0)
                                    {
                                        builder.Append(" (Alto)");
                                    }
                                    else
                                    {
                                        builder.Append(" (Normal)");
                                    }
                                    break;

                                case SexType.Woman:
                                    if (idTarifa == 70)
                                    {
                                        if (num < 34.0)
                                        {
                                            builder.Append(" (Bajo)");
                                        }
                                        else if (num > 44.0)
                                        {
                                            builder.Append(" (Alto)");
                                        }
                                        else
                                        {
                                            builder.Append(" (Normal)");
                                        }
                                    }
                                    else if (num < 37.0)
                                    {
                                        builder.Append(" (Bajo)");
                                    }
                                    else if (num > 47.0)
                                    {
                                        builder.Append(" (Alto)");
                                    }
                                    else
                                    {
                                        builder.Append(" (Normal)");
                                    }
                                    goto Label_1388;
                            }
                        }
                        break;
                    }
                    if (num >= 44.0)
                    {
                        if (num > 64.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 3:
                    if ((tiempo.Years != 0) || (tiempo.Days > 0x1d))
                    {
                        if (num < 5.0)
                        {
                            builder.Append(" (Bajo)");
                        }
                        else if (num > 10.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    if (num >= 5.0)
                    {
                        if (num > 25.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 4:
                    if (num >= 2.0)
                    {
                        if (num > 4.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 5:
                    if (num >= 55.0)
                    {
                        if (num > 65.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 6:
                    if (num >= 40.0)
                    {
                        if (num > 75.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 7:
                    if (num >= 5.0)
                    {
                        if (num > 8.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 8:
                    if (num >= 0.0)
                    {
                        if (num > 3.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 9:
                    if (num >= 21.0)
                    {
                        if (num > 47.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 10:
                    if (num >= 0.0)
                    {
                        if (num > 1.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 11:
                    if (num >= 150.0)
                    {
                        if (num > 450.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 14:
                    if (num >= 1.0)
                    {
                        if (num > 3.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 15:
                    if (num >= 1.0)
                    {
                        if (num > 10.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 0x10:
                    if ((num < 80.0) || (num > 90.0))
                    {
                        builder.Append(" (Patologico)");
                        break;
                    }
                    builder.Append(" (Normal)");
                    break;

                case 0x12:
                    if (num >= 2.0)
                    {
                        if (num > 7.5)
                        {
                            builder.Append(" (Patologico)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 0x13:
                    if ((num < 3.0) || (num > 4.8))
                    {
                        builder.Append(" (Patologico)");
                        break;
                    }
                    builder.Append(" (Normal)");
                    break;

                case 20:
                    switch (pac.Sex)
                    {
                        case SexType.Man:
                            if (num < 14.0)
                            {
                                builder.Append(" (Bajo)");
                            }
                            else if (num > 26.0)
                            {
                                builder.Append(" (Patologico)");
                            }
                            else
                            {
                                builder.Append(" (Normal)");
                            }
                            goto Label_1388;

                        case SexType.Woman:
                            if (num < 11.0)
                            {
                                builder.Append(" (Bajo)");
                            }
                            else if (num > 20.0)
                            {
                                builder.Append(" (Patologico)");
                            }
                            else
                            {
                                builder.Append(" (Normal)");
                            }
                            goto Label_1388;
                    }
                    break;

                case 0x15:
                    if (num >= 0.2)
                    {
                        if (num > 1.2)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 0x16:
                    switch (pac.Sex)
                    {
                        case SexType.Man:
                            if ((num >= 94.0) && (num <= 140.0))
                            {
                                builder.Append(" (Normal)");
                            }
                            else
                            {
                                builder.Append(" (Patologico)");
                            }
                            goto Label_1388;

                        case SexType.Woman:
                            if ((num >= 72.0) && (num <= 110.0))
                            {
                                builder.Append(" (Normal)");
                            }
                            else
                            {
                                builder.Append(" (Patologico)");
                            }
                            goto Label_1388;
                    }
                    break;

                case 0x17:
                    switch (pac.Sex)
                    {
                        case SexType.Man:
                            if ((num >= 8.0) && (num <= 46.0))
                            {
                                builder.Append(" (Normal)");
                            }
                            else
                            {
                                builder.Append(" (Patologico)");
                            }
                            goto Label_1388;

                        case SexType.Woman:
                            if ((num >= 7.0) && (num <= 29.0))
                            {
                                builder.Append(" (Normal)");
                            }
                            else
                            {
                                builder.Append(" (Patologico)");
                            }
                            goto Label_1388;
                    }
                    break;

                case 0x18:
                    if (num >= 70.0)
                    {
                        if (num > 140.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 0x19:
                    if (num >= 70.0)
                    {
                        if (num > 110.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 0x1a:
                    if ((num < 2.5) || (num > 2.9))
                    {
                        builder.Append(" (Patologico)");
                        break;
                    }
                    builder.Append(" (Normal)");
                    break;

                case 0x1b:
                    if ((num < 6.1) || (num > 7.9))
                    {
                        builder.Append(" (Patologico)");
                        break;
                    }
                    builder.Append(" (Normal)");
                    break;

                case 0x1d:
                    if (num < 150.0)
                    {
                        builder.Append(" (Normal)");
                        break;
                    }
                    builder.Append(" (Patologico)");
                    break;

                case 30:
                    if (num > 200.0)
                    {
                        builder.Append(" (Patologico)");
                        break;
                    }
                    builder.Append(" (Normal)");
                    break;

                case 0x1f:
                    if (num > 150.0)
                    {
                        builder.Append(" (Patologico)");
                        break;
                    }
                    builder.Append(" (Normal)");
                    break;

                case 0x20:
                    if (num <= 35.0)
                    {
                        builder.Append(" (Patologico)");
                        break;
                    }
                    builder.Append(" (Normal)");
                    break;

                case 0x21:
                    if (num > 130.0)
                    {
                        builder.Append(" (Patologico)");
                        break;
                    }
                    builder.Append(" (Normal)");
                    break;

                case 0x22:
                    if (num > 50.0)
                    {
                        builder.Append(" (Patologico)");
                        break;
                    }
                    builder.Append(" (Normal)");
                    break;

                case 0x23:
                    if (num >= 50.0)
                    {
                        if (num > 125.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 0x24:
                    if (num >= 20.0)
                    {
                        if (num > 45.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 0x25:
                    if (num >= 8.0)
                    {
                        if (num > 37.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 0x26:
                    if (num >= 8.0)
                    {
                        if (num > 40.0)
                        {
                            builder.Append(" (Alto)");
                        }
                        else
                        {
                            builder.Append(" (Normal)");
                        }
                        break;
                    }
                    builder.Append(" (Bajo)");
                    break;

                case 0x27:
                    if (num > 1.2)
                    {
                        builder.Append(" (Alto)");
                        break;
                    }
                    builder.Append(" (Normal)");
                    break;

                case 40:
                    if (num > 0.23)
                    {
                        builder.Append(" (Alto)");
                        break;
                    }
                    builder.Append(" (Normal)");
                    break;

                case 0x29:
                    if (num > 0.37)
                    {
                        builder.Append(" (Alto)");
                        break;
                    }
                    builder.Append(" (Normal)");
                    break;

                case 0x3d:
                    if (num >= 7.0)
                    {
                        if (num > 7.0)
                        {
                            builder.Append(" (Basico)");
                        }
                        else
                        {
                            builder.Append(" (Neutro)");
                        }
                        break;
                    }
                    builder.Append(" (Acido)");
                    break;

                case 0x41:
                    if (num >= 10.0)
                    {
                        if (num > 20.0)
                        {
                            builder.Append(" (Patologico)");
                        }
                        else
                        {
                            builder.Append(" (Regular Alto)");
                        }
                        break;
                    }
                    builder.Append(" (Normal)");
                    break;

                case 0x4d:
                    if (num >= 140.0)
                    {
                        if (num > 200.0)
                        {
                            builder.Append(" (Diabetes)");
                        }
                        else
                        {
                            builder.Append(" (Intolerante)");
                        }
                        break;
                    }
                    builder.Append(" (Normal)");
                    break;

                case 0x4e:
                    if (num >= 140.0)
                    {
                        if (num > 200.0)
                        {
                            builder.Append(" (Diabetes)");
                        }
                        else
                        {
                            builder.Append(" (Intolerante)");
                        }
                        break;
                    }
                    builder.Append(" (Normal)");
                    break;

                case 0xae:
                    if (num > 13.5)
                    {
                        builder.Append(" (Patologico)");
                    }
                    else if (num < 11.0)
                    {
                        builder.Append(" (Patologico)");
                    }
                    else
                    {
                        builder.Append(" (Normal)");
                    }
                    break;
            }
            Label_1388:
            return builder.ToString();
        }

        public bool Controlar(ExamResult ex)
        {
            if (ex.IdTemplate == 6)
            {
                NumberFormatInfo provider = new NumberFormatInfo
                {
                    NumberDecimalSeparator = "."
                };
                double num2 = double.Parse(ex.Items[5].Value, provider);
                double num4 = double.Parse(ex.Items[7].Value, provider);
                double num5 = double.Parse(ex.Items[8].Value, provider);
                double num6 = double.Parse(ex.Items[9].Value, provider);
                double num7 = double.Parse(ex.Items[10].Value, provider);
                double num3 = double.Parse(ex.Items[6].Value, provider);
                if ((double.Parse(ex.Items[4].Value, provider) + num2) != num3)
                {
                    throw new Exception("Neutrofilos no tiene la cantidad Correcta.\n Neutrofilos= Abastonados + Segmentados ");
                }
                if (((((num3 + num4) + num7) + num5) + num6) != 100.0)
                {
                    throw new Exception("La suma de los 5 ultimos campos debe ser 100.");
                }
            }
            return true;
        }

    }
}
