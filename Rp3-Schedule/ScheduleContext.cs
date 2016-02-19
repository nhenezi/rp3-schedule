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