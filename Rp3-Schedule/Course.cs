using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rp3_Schedule
{
    class Course
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }

        private readonly ObservableListSource<ViableClassroom> _ViableClassrooms =
                new ObservableListSource<ViableClassroom>();
        public virtual ObservableListSource<ViableClassroom> ViableClassrooms { get { return _ViableClassrooms; } }

        private readonly ObservableListSource<GroupCourseProfessor> _ProfessorGroups =
        new ObservableListSource<GroupCourseProfessor>();
        public virtual ObservableListSource<GroupCourseProfessor> ProfessorGroups { get { return _ProfessorGroups; } }
    }
}
