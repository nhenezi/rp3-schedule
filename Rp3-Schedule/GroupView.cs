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
    public partial class GroupView : Form
    {
        ScheduleContext _context;
        public GroupView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ACDform = new GroupACD();
            ACDform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ACDform = new GroupACD();
            ACDform.Show();
        }

        private void GroupView_Load(object sender, EventArgs e)
        {
            _context = new ScheduleContext();
            _context.Groups.Load();
            this.groupBindingSource.DataSource =
                _context.Groups.Local.ToBindingList();
        }

        private void groupDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
