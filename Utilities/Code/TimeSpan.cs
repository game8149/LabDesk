using System;
using System.Text;


namespace Utilities.Code
{
    public class TimeSpan
    {
        public static TimeElapse CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime now = DateTime.Now;
            int num = now.Year - fechaNacimiento.Year;
            int num2 = now.Month - fechaNacimiento.Month;
            int num3 = now.Day - fechaNacimiento.Day;
            if (num2 < 0)
            {
                num--;
                num2 += 12;
            }
            if (num3 < 0)
            {
                num2--;
                int year = now.Year;
                int month = now.Month;
                if ((now.Month - 1) == 0)
                {
                    year--;
                    month = 12;
                }
                else
                {
                    month--;
                }
                num3 += DateTime.DaysInMonth(year, month);
            }
            return new DataEstaticaGeneral.Tiempo { 
                Año = num,
                Dias = num3,
                Mes = num2
            };
        }

        public static string FormatoEdad(Tiempo edad)
        {
            bool flag = false;
            bool flag2 = false;
            StringBuilder builder = new StringBuilder();
            if (edad.Año > 1)
            {
                builder.Append(edad.Año + " a\x00f1os ");
            }
            else
            {
                if (flag = edad.Año == 1)
                {
                    builder.Append(edad.Año + " a\x00f1o ");
                }
                if (edad.Mes > 1)
                {
                    builder.Append(edad.Mes + " meses ");
                }
                else
                {
                    if (flag2 = edad.Mes == 1)
                    {
                        builder.Append(edad.Mes + " mes ");
                    }
                    if ((edad.Dias > 1) || (!flag2 && !flag))
                    {
                        builder.Append(edad.Dias + " d\x00edas");
                    }
                    else if (edad.Dias == 1)
                    {
                        builder.Append(edad.Dias + " d\x00eda");
                    }
                }
            }
            return builder.ToString();
        }
    }
}
