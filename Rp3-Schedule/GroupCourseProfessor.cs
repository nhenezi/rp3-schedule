using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rp3_Schedule
{
	[Table("group_course_professor")]
    class GroupCourseProfessor
    {

		[Column("id"), Key]
		public int Id { get; set; }
        [Column("group_id")]
        public int GroupId { get; set; }
        [Column("course_id")]
        public int CourseId { get; set; }
        [Column("professor_id")]
        public int ProfessorId { get; set; }
		[Column("timeslots")]
        public int Timeslots { get; set; }

        public virtual Group Group { get; set; }
        public virtual Course Course { get; set; }
        public virtual Professor Professor { get; set; }

        private readonly ObservableListSource<Allocation> _Allocations =
               new ObservableListSource<Allocation>();
        public virtual ObservableListSource<Allocation> Allocations { get { return _Allocations; } }
    }
}
