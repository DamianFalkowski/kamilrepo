using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDataModel.Model
{
    public class Subject
    {
        public string Name { get; set; }
        public int TimeStarts { get; set; }
        public int TimeEnds { get; set; }

        public string TimeStarts_Hour { get { return TimeStarts / 60 + ":" + TimeStarts % 60; } }
        public string TimeEnds_Hour { get { return TimeEnds / 60 + ":" + TimeEnds % 60; } }

    }
}
