using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rp3_Schedule
{
	[Table("timeslot")]
    class Timeslot
    {
        [Key][Column("id")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
		[Column("from")]
        public int From { get; set; }
		[Column("to")]
        public int To { get; set; }
		[Column("day")]
        public String Day { get; set; }

        private readonly ObservableListSource<ClassroomTimeRestriction> _ClassroomRestrictions =
              new ObservableListSource<ClassroomTimeRestriction>();
        public virtual ObservableListSource<ClassroomTimeRestriction> ClassroomRestrictions
        {
            get { return _ClassroomRestrictions; }
        }

        private readonly ObservableListSource<ProfessorTimeRestriction> _ProfessorRestrictions =
              new ObservableListSource<ProfessorTimeRestriction>();
        public virtual ObservableListSource<ProfessorTimeRestriction> ProfessorRestrictions
        {
            get { return _ProfessorRestrictions; }
        }

        private readonly ObservableListSource<Allocation> _Allocations =
               new ObservableListSource<Allocation>();
        public virtual ObservableListSource<Allocation> Allocations { get { return _Allocations; } }
    }
}
