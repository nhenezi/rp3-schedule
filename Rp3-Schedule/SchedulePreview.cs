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
        string filterType;
        int filterValue;
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
;
            ctx.Timeslots.Load();
            ctx.GroupCourseProfessors.Load();
            ctx.Professors.Load();
            ctx.Courses.Load();
            ctx.Groups.Load();
            comboBox1.DataSource = ctx.Professors.ToList();
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";
            comboBox2.DataSource = ctx.Groups.ToList();
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "name";
            comboBox3.DataSource = ctx.Classrooms.ToList();
            comboBox3.ValueMember = "id";
            comboBox3.DisplayMember = "name";
            filterType = "Group";
            filterValue = 1;
            refreshView();
        }

        private void refreshView()
        {
            Hashtable map = new Hashtable();
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
            IEnumerable<Allocation> allocations = null;
            if (filterType == "Group")
            {
                allocations = s.Allocations.Where(a => a.GroupCourseProfessor.GroupId == filterValue);
            }
            if (filterType == "Professor")
            {
                allocations = s.Allocations.Where(a => a.GroupCourseProfessor.ProfessorId == filterValue);
            }
            if (filterType == "Course")
            {
                allocations = s.Allocations.Where(a => a.GroupCourseProfessor.CourseId == filterValue);
            }

            foreach (var a in allocations)
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void combobox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void combobox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filterType = "Professor";
            var p = Convert.ToInt32(comboBox1.SelectedValue);
            filterValue = p;
            refreshView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filterType = "Group";
            var p = Convert.ToInt32(comboBox2.SelectedValue);
            filterValue = p;
            refreshView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            filterType = "Classroom";
            var p = Convert.ToInt32(comboBox3.SelectedValue);
            filterValue = p;
            refreshView();
        }
    }
}
