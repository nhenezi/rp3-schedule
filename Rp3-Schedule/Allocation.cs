using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rp3_Schedule
{
	[Table("allocation")]
    class Allocation
    {
		[Column("gcp_id", Order=1), Key]
        public int GroupCourseProfessorId { get; set; }
		[Column("classroom_id", Order=2), Key]
        public int ClassroomId { get; set; }
		[Column("schedule_id", Order=3), Key]
        public int ScheduleId { get; set; }
		[Column("timeslot_id", Order=4), Key]
        public int TimeslotId { get; set; }

        public virtual GroupCourseProfessor GroupCourseProfessor { get; set; }
        public virtual Classroom Classroom { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual Timeslot Timeslot { get; set; }

    }
}
