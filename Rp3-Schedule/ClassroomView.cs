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

        private void button1_Click(object sender, EventArgs e)
        {
            var ACDform = new ClassroomACD();
            ACDform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ACDform = new ClassroomACD();
            ACDform.Show();
        }

        private void ClassroomView_Load(object sender, EventArgs e)
        {
            _context = new ScheduleContext();
            _context.Classrooms.Load();
            this.classroomBindingSource.DataSource =
                _context.Classrooms.Local.ToBindingList();
        }

        private void classroomBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}
