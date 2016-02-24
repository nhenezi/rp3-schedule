using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Rp3_Schedule
{
	class ScheduleContext : DbContext
    {

        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<ProfessorTimeRestriction> ProfessorTimeRestrictions { get; set; }
        public DbSet<ClassroomTimeRestriction> ClassroomTimeRestrictions { get; set; }
        public DbSet<GroupCourseProfessor> GroupCourseProfessors { get; set; }
        public DbSet<Allocation> Allocations { get; set; }
        public ScheduleContext() : base("Schedule") { }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// PostgreSQL uses the public schema by default - not dbo.
			modelBuilder.HasDefaultSchema("public");
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention> ();
			base.OnModelCreating(modelBuilder);
		}
	}
}