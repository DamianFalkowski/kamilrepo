using System;
using System.Collections.Generic;

namespace CzytajExcel1.Model
{
    internal class Schedule
    {
        public string Name { get; set; }
        public List<DayOfWeek> DaysOfWeek { get; set; }

        public Schedule()
        {
            DaysOfWeek = new List<DayOfWeek>() { };
        }
    }
}