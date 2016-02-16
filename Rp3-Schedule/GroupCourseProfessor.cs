using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rp3_Schedule
{
    class GroupCourseProfessor
    {

        [Column(Order = 0), Key]
        public int GroupId { get; set; }
        [Column(Order = 1), Key]
        public int CourseId { get; set; }
        [Column(Order = 2), Key]
        public int ProfessorId { get; set; }
        public int Timeslots { get; set; }

        public virtual Group Group { get; set; }
        public virtual Course Course { get; set; }
        public virtual Professor Professor { get; set; }

        private readonly ObservableListSource<Allocation> _Allocations =
               new ObservableListSource<Allocation>();
        public virtual ObservableListSource<Allocation> Allocations { get { return _Allocations; } }
    }
}
