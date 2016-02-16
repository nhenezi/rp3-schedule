using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rp3_Schedule
{
    class Allocation
    {

        [Column(Order = 0), Key]
        public int GCPId { get; set; }
        [Column(Order = 1), Key]
        public int ClassroomId { get; set; }
        [Column(Order = 2), Key]
        public int ScheduleId { get; set; }
        public int TimeslotId { get; set; }

        public virtual GroupCourseProfessor GroupCourseProfessor { get; set; }
        public virtual Classroom Classroom { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual Timeslot Timeslot { get; set; }

    }
}
