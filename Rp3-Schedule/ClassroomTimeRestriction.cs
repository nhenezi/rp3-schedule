using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rp3_Schedule
{
	[Table("classroom_timeslot")]
    class ClassroomTimeRestriction
    {
		[Column("timeslot_id", Order=1), Key]
        public int TimeslotId { get; set; }
		[Column("classroom_id", Order=2), Key]
        public int ClassroomId { get; set; }

        public virtual Timeslot Timeslot { get; set; }
        public virtual Classroom Classroom { get; set; }
    }
}
