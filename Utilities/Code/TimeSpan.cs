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
            return new TimeElapse 
            {
                Years = num,
                Months = num2,
                Days = num3
            };
        }

        public static string FormatoEdad(TimeElapse edad)
        {
            bool flag = false;
            bool flag2 = false;
            StringBuilder builder = new StringBuilder();
            if (edad.Years > 1)
            {
                builder.Append(edad.Years + " a\x00f1os ");
            }
            else
            {
                if (flag = edad.Years == 1)
                {
                    builder.Append(edad.Years + " a\x00f1o ");
                }
                if (edad.Months > 1)
                {
                    builder.Append(edad.Months + " meses ");
                }
                else
                {
                    if (flag2 = edad.Months == 1)
                    {
                        builder.Append(edad.Months + " mes ");
                    }
                    if ((edad.Days > 1) || (!flag2 && !flag))
                    {
                        builder.Append(edad.Days + " d\x00edas");
                    }
                    else if (edad.Days == 1)
                    {
                        builder.Append(edad.Days + " d\x00eda");
                    }
                }
            }
            return builder.ToString();
        }
    }
}
