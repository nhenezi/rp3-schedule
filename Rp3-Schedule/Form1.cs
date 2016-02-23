﻿using System;
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

            _context = new ScheduleContext();
            _context.Schedules.Load();
            this.scheduleBindingSource.DataSource =
                _context.Classrooms.Local.ToBindingList();
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

        private void button8_Click(object sender, EventArgs e)
        {
            //Add schedule
            var ACDform = new ScheduleACD();
            ACDform.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Change schedule
            var ACDform = new ProfessorACD();
            ACDform.Show();
        }
    }
}
