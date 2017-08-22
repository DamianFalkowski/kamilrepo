using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDataModel.Model
{
    public class StudentGroup
    {
        public string Name { get; set; }
        public List<Subject> Subjects { get; set; }

        public StudentGroup()
        {
            Subjects = new List<Subject>() { };
        }
    }
}
