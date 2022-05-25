using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projERPMercearia.Controller
{
    class DateFormatter
    {
        public static string DateTimeFormat(string date)
        {
            string Day, Month, Year;
            string Second, Minute, Hour;

            string tempDate = ReturnData(0, date);
            string tempHour = ReturnData(1, date);

            Day = GetDate(tempDate, 2, false);
            Month = GetDate(tempDate, 1, false);
            Year = GetDate(tempDate, 0, false);

            Second = GetHour(tempHour, 2);
            Minute = GetHour(tempHour, 1);
            Hour = GetHour(tempHour, 0);

            return $"{Day}/{Month}/{Year} às {Hour}:{Minute}:{Second}";
        }

        public static string DateFormat(string date, bool trace)
        {
            string Day, Month, Year;
            if (trace)
            {
                Day = GetDate(date, 0, trace);
                Month = GetDate(date, 1, trace);
                Year = GetDate(date, 2, trace).Split(' ')[0];
                return $"{Day}-{Month}-{Year}";
            }
            else
            {
                Day = int.Parse(GetDate(date, 2, trace)).ToString("D2");
                Month = int.Parse(GetDate(date, 1, trace)).ToString("D2");
                Year = GetDate(date, 0, trace);
                return $"{Day}/{Month}/{Year}";
            }
        }

        static string ReturnData(int data, string date)
        {
            return date.Split(' ')[data];
        }

        static string GetDate(string date, int data, bool trace)
        {
            if(!trace) return date.Split('-')[data];
            else return date.Split('/')[data];
        }

        static string GetHour(string hour, int data)
        {
            return hour.Split(':')[data];
        }
    }
}
