using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.Entity;

namespace Rp3_Schedule
{
    public partial class Form1 : Form
    {
        ScheduleContext _context;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            scheduleDataGridView.MultiSelect = false;
            scheduleDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _context = new ScheduleContext();
            _context.Schedules.Load();
            this.scheduleBindingSource.DataSource =
                _context.Schedules.Local.ToBindingList();
        }

        private void scheduleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var viewForm = new ProfessorView();
            viewForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var viewForm = new CourseView();
            viewForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var viewForm = new GroupView();
            viewForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var viewForm = new ClassroomView();
            viewForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var viewForm = new TimeslotsView(false);
            viewForm.Show();
        }

        void RefreshGrid(object sender, FormClosedEventArgs e)
        {
            _context.Schedules.Load();
            this.scheduleBindingSource.DataSource =
                _context.Schedules.Local.ToBindingList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Add schedule
            var ACDform = new ScheduleACD();
            ACDform.FormClosed += new FormClosedEventHandler(RefreshGrid);
            ACDform.Show();

        }


        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in scheduleDataGridView.SelectedRows)
            {
                Schedule sch = row.DataBoundItem as Schedule;
                if (sch != null)
                {
                    _context.Schedules.Remove(sch);
                    _context.SaveChanges();

                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var ACDform = new GCP();
            ACDform.FormClosed += new FormClosedEventHandler(RefreshGrid);
            ACDform.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in scheduleDataGridView.SelectedRows)
            {
                Schedule sch = row.DataBoundItem as Schedule;
                if (sch != null)
                {
                    var prev = new SchedulePreview(sch.Id);
                    prev.Show();

                }
            }
        }
    }
}
