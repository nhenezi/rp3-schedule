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
    public partial class CourseView : Form
    {
        ScheduleContext _context;
        public CourseView()
        {
            InitializeComponent();
        }

        private void courseDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ACDform = new CourseACD();
            ACDform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ACDform = new CourseACD();
            ACDform.Show();
        }

        private void CourseView_Load(object sender, EventArgs e)
        {
            _context = new ScheduleContext();
            _context.Courses.Load();
            this.courseBindingSource.DataSource =
                _context.Courses.Local.ToBindingList();
        }
    }
}
