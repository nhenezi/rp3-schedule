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

        void RefreshGrid(object sender, FormClosedEventArgs e)
        {
            _context.Groups.Load();
            this.groupBindingSource.DataSource =
                _context.Groups.Local.ToBindingList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var ACDform = new GroupACD();
            ACDform.FormClosed += new FormClosedEventHandler(RefreshGrid);
            ACDform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ACDform = new GroupACD();
            ACDform.Show();
        }

        private void GroupView_Load(object sender, EventArgs e)
        {
            groupDataGridView.MultiSelect = false;
            groupDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _context = new ScheduleContext();
            _context.Groups.Load();
            this.groupBindingSource.DataSource =
                _context.Groups.Local.ToBindingList();
        }

        private void groupDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in groupDataGridView.SelectedRows)
            {
                Group sch = row.DataBoundItem as Group;
                if (sch != null)
                {
                    _context.Groups.Remove(sch);
                    _context.SaveChanges();

                }
            }
        }
    }
}
