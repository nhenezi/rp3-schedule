using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rp3_Schedule
{
    class ProfessorTimeRestriction
    {

        [Column(Order = 0), Key]
        public int TimeslotId { get; set; }
        [Column(Order = 1), Key]
        public int ProfessorId { get; set; }

        public virtual Timeslot Timeslot { get; set; }
        public virtual Professor Professor { get; set; }
    }
}
