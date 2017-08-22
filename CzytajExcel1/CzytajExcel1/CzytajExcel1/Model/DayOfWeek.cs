using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CzytajExcel1.Model
{
    public class DayOfWeek
    {
        public System.DayOfWeek Day { get; set; }
        public List<StudentGroup> StudentGroups { get; set; }

        public DayOfWeek()
        {
            StudentGroups = new List<StudentGroup>() { };
        }
    }
}
