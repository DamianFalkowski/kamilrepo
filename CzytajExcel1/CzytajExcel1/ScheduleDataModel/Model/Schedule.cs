using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDataModel.Model
{
    public class Schedule
    {
        public string Name { get; set; }
        public List<ScheduleDayOfWeek> DaysOfWeek { get; set; }

        public Schedule()
        {
            DaysOfWeek = new List<ScheduleDayOfWeek>() { };
        }
    }
}
