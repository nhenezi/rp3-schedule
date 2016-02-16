using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Rp3_Schedule
{

    class ScheduleContext : DbContext
    {

        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public ScheduleContext() : base() { }


    }
}