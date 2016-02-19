using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rp3_Schedule
{
	[Table("professor_timeslot")]
    class ProfessorTimeRestriction
    {

		[Column("timeslot_id", Order=1), Key]
        public int TimeslotId { get; set; }
		[Column("professor_id", Order=2), Key]
        public int ProfessorId { get; set; }

        public virtual Timeslot Timeslot { get; set; }
        public virtual Professor Professor { get; set; }
    }
}
