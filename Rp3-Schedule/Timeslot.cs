using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rp3_Schedule
{
    class Timeslot
    {
        [Key]
        public int Id { get; set; }
        public int From { get; set; }
        public int To { get; set; }
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
