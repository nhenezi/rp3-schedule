using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rp3_Schedule
{
    public partial class CourseACD : Form
    {
        public CourseACD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new ScheduleContext())
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Missing required input.", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    var course = new Course
                    {
                        //Podesi ID na automatski increase
                        Id = 2,
                        Name = textBox2.Text.ToString(),      
                    };
 
                    ctx.Courses.Add(course);
                    ctx.SaveChanges();
                    var len = ctx.Classrooms.ToArray().Length;
                    this.Close();
                }
            }
        }
    }
}
