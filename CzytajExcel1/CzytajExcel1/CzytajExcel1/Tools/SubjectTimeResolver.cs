using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CzytajExcel1.Tools
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
    }
}
