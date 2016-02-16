using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rp3_Schedule
{
    class ViableClassroom
    {
        [Column(Order = 0), Key]
        public int CourseId { get; set; }
        [Column(Order = 1), Key]
        public int ClassroomId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Classroom Classroom { get; set; }

    }
}
