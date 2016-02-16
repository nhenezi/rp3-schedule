using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rp3_Schedule
{
    class Professor
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }

        private readonly ObservableListSource<ProfessorTimeRestriction> _TimeRestrictions =
              new ObservableListSource<ProfessorTimeRestriction>();
        public virtual ObservableListSource<ProfessorTimeRestriction> TimeRestrictions { get { return _TimeRestrictions; } }
        private readonly ObservableListSource<GroupCourseProfessor> _GroupCourses =
        new ObservableListSource<GroupCourseProfessor>();
        public virtual ObservableListSource<GroupCourseProfessor> GroupCourses { get { return _GroupCourses; } }
    }
}
