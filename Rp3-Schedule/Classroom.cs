using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rp3_Schedule
{
	[Table("classroom")]
    class Classroom
    {
		[Key, Column("id")]
        public int Id { get; set; }
		[Column("name")]
        public String Name { get; set; }
		[Column("capacity")]
        public int Capacity { get; set; }

        private readonly ObservableListSource<ViableClassroom> _ViableCourses =
               new ObservableListSource<ViableClassroom>();
        public virtual ObservableListSource<ViableClassroom> ViableCourses { get { return _ViableCourses; } }

        private readonly ObservableListSource<ClassroomTimeRestriction> _TimeRestrictions =
               new ObservableListSource<ClassroomTimeRestriction>();
        public virtual ObservableListSource<ClassroomTimeRestriction> TimeRestrictions { get { return _TimeRestrictions; } }

        private readonly ObservableListSource<Allocation> _Allocations =
               new ObservableListSource<Allocation>();
        public virtual ObservableListSource<Allocation> Allocations { get { return _Allocations; } }
    }
}
