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
    public partial class ClassroomView : Form
    {
        ScheduleContext _context;
        public ClassroomView()
        {
            InitializeComponent();
        }

        void RefreshGrid(object sender, FormClosedEventArgs e)
        {
            _context.Classrooms.Load();
            this.classroomBindingSource.DataSource =
                _context.Classrooms.Local.ToBindingList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ACDform = new ClassroomACD();
            ACDform.FormClosed += new FormClosedEventHandler(RefreshGrid);
            ACDform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ACDform = new ClassroomACD();
            ACDform.Show();
        }

        private void ClassroomView_Load(object sender, EventArgs e)
        {
            classroomDataGridView.MultiSelect = false;
            classroomDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _context = new ScheduleContext();
            _context.Classrooms.Load();
            this.classroomBindingSource.DataSource =
                _context.Classrooms.Local.ToBindingList();
        }

        private void classroomBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in classroomDataGridView.SelectedRows)
            {
                Classroom sch = row.DataBoundItem as Classroom;
                if (sch != null)
                {
                    _context.Classrooms.Remove(sch);
                    _context.SaveChanges();

                }
            }
        }
    }
}
