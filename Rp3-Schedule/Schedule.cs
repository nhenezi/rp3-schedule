using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Rp3_Schedule
{
    [Table("schedule")]
    class Schedule
    {
        [Key, Column("id")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
		[Column("name")]
        public String Name { get; set; }

        private readonly ObservableListSource<Allocation> _Allocations =
               new ObservableListSource<Allocation>();
        public virtual ObservableListSource<Allocation> Allocations { get { return _Allocations; } }
        public void GenerateSchedule()
        {
            var ctx = new ScheduleContext();
            ctx.GroupCourseProfessors.Load();
            ctx.Timeslots.Load();

            List<int> timeslots = new List<int>();
            foreach (Timeslot t in ctx.Timeslots)
            {
                timeslots.Add(t.Id);
            }



        }
    }
}
