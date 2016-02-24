using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.Entity;

namespace Rp3_Schedule
{
    public partial class SchedulePreview : Form
    {
        ScheduleContext ctx;
        Schedule s;
        public SchedulePreview(int id)
        {
            InitializeComponent();
            ctx = new ScheduleContext();
            dataGridView1.AllowUserToAddRows = false;
            ctx.Schedules.Load();
            s = ctx.Schedules.Find(id);
        }

        private void SchedulePreview_Load(object sender, EventArgs e)
        {
            
            ctx.Allocations.Load();
            Hashtable map = new Hashtable();
            ctx.Timeslots.Load();
            ctx.GroupCourseProfessors.Load();
            ctx.Professors.Load();
            ctx.Courses.Load();
            ctx.Groups.Load();
            foreach (var t in ctx.Timeslots)
            {
                if (!map.ContainsKey(t.From))
                {
                    map.Add(t.From, new Helper
                    {
                        Time = t.From.ToString() + " - " + t.To.ToString()
                    });

                }
            }
            foreach (var a in s.Allocations)
            {
                Helper h = map[a.Timeslot.From] as Helper;
                if (a.Timeslot.Day == "Ponedjeljak")
                {
                    h.Monday = a.GroupCourseProfessor.Course.Name + "\n " + a.GroupCourseProfessor.Professor.Name + "\n " + a.GroupCourseProfessor.Group.Name;
                }
                if (a.Timeslot.Day == "Utorak")
                {
                    h.Tuesday = a.GroupCourseProfessor.Course.Name + " " + a.GroupCourseProfessor.Professor.Name + " " + a.GroupCourseProfessor.Group.Name;
                }
                if (a.Timeslot.Day == "Srijeda")
                {
                    h.Wednesday = a.GroupCourseProfessor.Course.Name + " " + a.GroupCourseProfessor.Professor.Name + " " + a.GroupCourseProfessor.Group.Name;
                }
                if (a.Timeslot.Day == "Cetvrtak")
                {
                    h.Thursday = a.GroupCourseProfessor.Course.Name + " " + a.GroupCourseProfessor.Professor.Name + " " + a.GroupCourseProfessor.Group.Name;
                }
                if (a.Timeslot.Day == "Petak")
                {
                    h.Friday = a.GroupCourseProfessor.Course.Name + " " + a.GroupCourseProfessor.Professor.Name + " " + a.GroupCourseProfessor.Group.Name;
                }

                map[a.Timeslot.From] = h;
            }
            List<Helper> l = new List<Helper>();
            foreach (var key in map.Keys)
            {
                Helper k = map[key] as Helper;
                l.Add(k);
            }

            l.OrderBy(o => o.Time).ToList();
            l.Reverse();
            var source = new BindingSource();
            source.DataSource = l;
            dataGridView1.DataSource = source;
            
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }
    }
}
