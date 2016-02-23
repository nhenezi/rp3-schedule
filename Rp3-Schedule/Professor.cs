using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rp3_Schedule
{
	[Table("professor")]
    class Professor
    {
        [Key][Column("id")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
		[Column("name")]
        public String Name { get; set; }

        private readonly ObservableListSource<ProfessorTimeRestriction> _TimeRestrictions =
              new ObservableListSource<ProfessorTimeRestriction>();
        public virtual ObservableListSource<ProfessorTimeRestriction> TimeRestrictions { get { return _TimeRestrictions; } }
        private readonly ObservableListSource<GroupCourseProfessor> _GroupCourses =
        new ObservableListSource<GroupCourseProfessor>();
        public virtual ObservableListSource<GroupCourseProfessor> GroupCourses { get { return _GroupCourses; } }
    }
}
