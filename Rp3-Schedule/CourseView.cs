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
        void RefreshGrid(object sender, FormClosedEventArgs e)
        {
            _context.Courses.Load();
            this.courseBindingSource.DataSource =
                _context.Courses.Local.ToBindingList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var ACDform = new CourseACD();
            ACDform.FormClosed += new FormClosedEventHandler(RefreshGrid);
            ACDform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ACDform = new CourseACD();
            ACDform.Show();
        }

        private void CourseView_Load(object sender, EventArgs e)
        {
            courseDataGridView.MultiSelect = false;
            courseDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _context = new ScheduleContext();
            _context.Courses.Load();
            this.courseBindingSource.DataSource =
                _context.Courses.Local.ToBindingList();
        }

        private void courseBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in courseDataGridView.SelectedRows)
            {
                Course sch = row.DataBoundItem as Course;
                if (sch != null)
                {
                    _context.Courses.Remove(sch);
                    _context.SaveChanges();

                }
            }
        }
    }
}
