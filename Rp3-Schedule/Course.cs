using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rp3_Schedule
{
	[Table("course")]
    class Course
    {
		[Key, Column("id")]
        public int Id { get; set; }
		[Column("name")]
        public String Name { get; set; }

        private readonly ObservableListSource<ViableClassroom> _ViableClassrooms =
                new ObservableListSource<ViableClassroom>();
        public virtual ObservableListSource<ViableClassroom> ViableClassrooms { get { return _ViableClassrooms; } }

        private readonly ObservableListSource<GroupCourseProfessor> _ProfessorGroups =
        new ObservableListSource<GroupCourseProfessor>();
        public virtual ObservableListSource<GroupCourseProfessor> ProfessorGroups { get { return _ProfessorGroups; } }
    }
}
