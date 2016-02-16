using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rp3_Schedule
{
    class Group
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public int Members { get; set; }
        public int ParentId { get; set; }

        private readonly ObservableListSource<GroupCourseProfessor> _ProfessorCourses =
                new ObservableListSource<GroupCourseProfessor>();
        public virtual ObservableListSource<GroupCourseProfessor> ProfessorCourses { get { return _ProfessorCourses; } }
    }
}
