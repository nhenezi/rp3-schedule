using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rp3_Schedule
{
	[Table("group")]
    class Group
    {
        [Key][Column("id")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
		[Column("name")]
        public String Name { get; set; }
		[Column("members")]
        public int Members { get; set; }
		[Column("parent_id")]
        public int ParentId { get; set; }

        private readonly ObservableListSource<GroupCourseProfessor> _ProfessorCourses =
                new ObservableListSource<GroupCourseProfessor>();
        public virtual ObservableListSource<GroupCourseProfessor> ProfessorCourses { get { return _ProfessorCourses; } }
    }
}
