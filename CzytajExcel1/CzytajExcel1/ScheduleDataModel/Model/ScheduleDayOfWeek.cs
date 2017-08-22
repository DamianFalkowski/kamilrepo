using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDataModel.Model
{
    public class ScheduleDayOfWeek
    {
        public System.DayOfWeek Day { get; set; }
        public List<StudentGroup> StudentGroups { get; set; }

        public ScheduleDayOfWeek()
        {
            StudentGroups = new List<StudentGroup>() { };
        }
    }
}
