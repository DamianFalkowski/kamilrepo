using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleReader.Tools
{
    public class SubjectTimeResolver
    {
        private static SubjectTimeResolver instance = null;

        public static SubjectTimeResolver Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SubjectTimeResolver();
                }
                return instance;
            }
        }

        private SubjectTimeResolver() { }

        private const int startHour = 8;
        private const int minutesInHour = 60;
        private const int minutesInOneCell = 15;
        private const int startCell = 2;

        public int GetMinutesFromCell(int cell_column)
        {
            return startHour * minutesInHour + ((cell_column - startCell) * minutesInOneCell);
        }

        public DateTime GetTimeFromMinutes(int minutes_count)
        {
            int hours = minutes_count / minutesInHour;
            int minutes = minutes_count % minutesInHour;
            return new DateTime(0, 0, 0, hours, minutes, 0);
        }

        public bool IsValidDay(string dayofweekinstring)
        {
            List<string> days = new List<string>() { "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota", "Niedziela" };
            return days.Contains(dayofweekinstring);
        }

        public System.DayOfWeek GetDayOfWeekFromString(string dayofweekinstring)
        {
            switch (dayofweekinstring)
            {
                case "Poniedziałek":
                    return System.DayOfWeek.Monday;
                case "Wtorek":
                    return System.DayOfWeek.Tuesday;
                case "Środa":
                    return System.DayOfWeek.Wednesday;
                case "Czwartek":
                    return System.DayOfWeek.Thursday;
                case "Piątek":
                    return System.DayOfWeek.Friday;
                case "Sobota":
                    return System.DayOfWeek.Saturday;
                case "Niedziela":
                    return System.DayOfWeek.Sunday;
                default:
                    throw new NotImplementedException("taki dzień nie istnieje");
            }
        }
    }
}
