namespace Rp3_Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GroupCourseProfessors",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        ProfessorId = c.Int(nullable: false),
                        Timeslots = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.CourseId, t.ProfessorId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Professors", t => t.ProfessorId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.CourseId)
                .Index(t => t.ProfessorId);
            
            CreateTable(
                "dbo.Allocations",
                c => new
                    {
                        GCPId = c.Int(nullable: false),
                        ClassroomId = c.Int(nullable: false),
                        ScheduleId = c.Int(nullable: false),
                        TimeslotId = c.Int(nullable: false),
                        GroupCourseProfessor_GroupId = c.Int(),
                        GroupCourseProfessor_CourseId = c.Int(),
                        GroupCourseProfessor_ProfessorId = c.Int(),
                    })
                .PrimaryKey(t => new { t.GCPId, t.ClassroomId, t.ScheduleId })
                .ForeignKey("dbo.Classrooms", t => t.ClassroomId, cascadeDelete: true)
                .ForeignKey("dbo.Timeslots", t => t.TimeslotId, cascadeDelete: true)
                .ForeignKey("dbo.GroupCourseProfessors", t => new { t.GroupCourseProfessor_GroupId, t.GroupCourseProfessor_CourseId, t.GroupCourseProfessor_ProfessorId })
                .ForeignKey("dbo.Schedules", t => t.ScheduleId, cascadeDelete: true)
                .Index(t => t.ClassroomId)
                .Index(t => t.ScheduleId)
                .Index(t => t.TimeslotId)
                .Index(t => new { t.GroupCourseProfessor_GroupId, t.GroupCourseProfessor_CourseId, t.GroupCourseProfessor_ProfessorId });
            
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClassroomTimeRestrictions",
                c => new
                    {
                        TimeslotId = c.Int(nullable: false),
                        ClassroomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TimeslotId, t.ClassroomId })
                .ForeignKey("dbo.Classrooms", t => t.ClassroomId, cascadeDelete: true)
                .ForeignKey("dbo.Timeslots", t => t.TimeslotId, cascadeDelete: true)
                .Index(t => t.TimeslotId)
                .Index(t => t.ClassroomId);
            
            CreateTable(
                "dbo.Timeslots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        From = c.Int(nullable: false),
                        To = c.Int(nullable: false),
                        Day = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfessorTimeRestrictions",
                c => new
                    {
                        TimeslotId = c.Int(nullable: false),
                        ProfessorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TimeslotId, t.ProfessorId })
                .ForeignKey("dbo.Professors", t => t.ProfessorId, cascadeDelete: true)
                .ForeignKey("dbo.Timeslots", t => t.TimeslotId, cascadeDelete: true)
                .Index(t => t.TimeslotId)
                .Index(t => t.ProfessorId);
            
            CreateTable(
                "dbo.ViableClassrooms",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        ClassroomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseId, t.ClassroomId })
                .ForeignKey("dbo.Classrooms", t => t.ClassroomId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.ClassroomId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Members = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupCourseProfessors", "ProfessorId", "dbo.Professors");
            DropForeignKey("dbo.GroupCourseProfessors", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Allocations", "ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.Allocations", new[] { "GroupCourseProfessor_GroupId", "GroupCourseProfessor_CourseId", "GroupCourseProfessor_ProfessorId" }, "dbo.GroupCourseProfessors");
            DropForeignKey("dbo.ViableClassrooms", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.GroupCourseProfessors", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.ViableClassrooms", "ClassroomId", "dbo.Classrooms");
            DropForeignKey("dbo.ProfessorTimeRestrictions", "TimeslotId", "dbo.Timeslots");
            DropForeignKey("dbo.ProfessorTimeRestrictions", "ProfessorId", "dbo.Professors");
            DropForeignKey("dbo.ClassroomTimeRestrictions", "TimeslotId", "dbo.Timeslots");
            DropForeignKey("dbo.Allocations", "TimeslotId", "dbo.Timeslots");
            DropForeignKey("dbo.ClassroomTimeRestrictions", "ClassroomId", "dbo.Classrooms");
            DropForeignKey("dbo.Allocations", "ClassroomId", "dbo.Classrooms");
            DropIndex("dbo.ViableClassrooms", new[] { "ClassroomId" });
            DropIndex("dbo.ViableClassrooms", new[] { "CourseId" });
            DropIndex("dbo.ProfessorTimeRestrictions", new[] { "ProfessorId" });
            DropIndex("dbo.ProfessorTimeRestrictions", new[] { "TimeslotId" });
            DropIndex("dbo.ClassroomTimeRestrictions", new[] { "ClassroomId" });
            DropIndex("dbo.ClassroomTimeRestrictions", new[] { "TimeslotId" });
            DropIndex("dbo.Allocations", new[] { "GroupCourseProfessor_GroupId", "GroupCourseProfessor_CourseId", "GroupCourseProfessor_ProfessorId" });
            DropIndex("dbo.Allocations", new[] { "TimeslotId" });
            DropIndex("dbo.Allocations", new[] { "ScheduleId" });
            DropIndex("dbo.Allocations", new[] { "ClassroomId" });
            DropIndex("dbo.GroupCourseProfessors", new[] { "ProfessorId" });
            DropIndex("dbo.GroupCourseProfessors", new[] { "CourseId" });
            DropIndex("dbo.GroupCourseProfessors", new[] { "GroupId" });
            DropTable("dbo.Groups");
            DropTable("dbo.Schedules");
            DropTable("dbo.Courses");
            DropTable("dbo.ViableClassrooms");
            DropTable("dbo.ProfessorTimeRestrictions");
            DropTable("dbo.Timeslots");
            DropTable("dbo.ClassroomTimeRestrictions");
            DropTable("dbo.Classrooms");
            DropTable("dbo.Allocations");
            DropTable("dbo.GroupCourseProfessors");
            DropTable("dbo.Professors");
        }
    }
}
