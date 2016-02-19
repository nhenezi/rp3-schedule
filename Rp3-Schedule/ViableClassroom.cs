using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rp3_Schedule
{
	[Table("viable_classroom")]
    class ViableClassroom
    {
		[Column("course_id", Order=1), Key]
        public int CourseId { get; set; }
		[Column("classroom_id", Order=21), Key]
        public int ClassroomId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Classroom Classroom { get; set; }

    }
}
