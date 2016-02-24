using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rp3_Schedule
{
    public partial class GCP : Form
    {
        ScheduleContext _context;
        public GCP()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new ScheduleContext())
            {
                if (comboBox1.SelectedItem.ToString() == "" || comboBox2.SelectedItem.ToString() == "" || comboBox3.SelectedItem.ToString() == "")
                {
                    MessageBox.Show("Missing required input from dropdown menu.", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int groupId = Convert.ToInt32(comboBox1.SelectedValue);
                    int courseId = Convert.ToInt32(comboBox2.SelectedValue);
                    int professorId = Convert.ToInt32(comboBox3.SelectedValue);
                    if (ctx.GroupCourseProfessors.Any(gcp => gcp.GroupId == groupId && gcp.CourseId == courseId && gcp.ProfessorId == professorId))
                    {
                        this.Close();
                        return;
                    }
                    
                    var g = new GroupCourseProfessor
                    {
                        GroupId = groupId,
                        CourseId = courseId,
                        ProfessorId = professorId,
                        Timeslots = Convert.ToInt32(textBox1.Text)
                    };

                    ctx.GroupCourseProfessors.Add(g);
                    ctx.SaveChanges();
                    this.Close();
                }
            }
        }

        private void GCP_Load(object sender, EventArgs e)
        {
            _context = new ScheduleContext();
            _context.Groups.Load();
            comboBox1.DataSource = _context.Groups.ToList();
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";

            _context.Courses.Load();
            comboBox2.DataSource = _context.Courses.ToList();
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "name";

            _context.Professors.Load();
            comboBox3.DataSource = _context.Professors.ToList();
            comboBox3.ValueMember = "id";
            comboBox3.DisplayMember = "name";
        }
    }
}
