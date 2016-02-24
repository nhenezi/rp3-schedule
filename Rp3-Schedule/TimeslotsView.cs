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
    public partial class TimeslotsView : Form
    {
        ScheduleContext _context;
        public List<int> restrictions { get; set; }
        public TimeslotsView(Boolean option)
        {
            InitializeComponent();
            if (option == false)
            {
                button4.Visible = false;
                timeslotDataGridView.MultiSelect = false;
            }
            else
            {
                restrictions = new List<int>();
                button4.Visible = true;
                timeslotDataGridView.MultiSelect = true;
                timeslotDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }
        void RefreshGrid(object sender, FormClosedEventArgs e)
        {
            _context.Timeslots.Load();
            this.timeslotBindingSource.DataSource =
                _context.Timeslots.Local.ToBindingList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var ACDform = new TimeslotACD();
            ACDform.FormClosed += new FormClosedEventHandler(RefreshGrid);
            ACDform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ACDform = new TimeslotACD();
            ACDform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in timeslotDataGridView.SelectedRows)
            {
                Timeslot slot = row.DataBoundItem as Timeslot;
                if (slot != null)
                {
                    Console.Write(slot.ToString());
                    restrictions.Add(slot.Id);

                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TimeslotsView_Load(object sender, EventArgs e)
        {
            timeslotDataGridView.MultiSelect = false;
            timeslotDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _context = new ScheduleContext();
            _context.Timeslots.Load();
            this.timeslotBindingSource.DataSource =
                _context.Timeslots.Local.ToBindingList();
        }

        private void timeslotBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in timeslotDataGridView.SelectedRows)
            {
                Timeslot sch = row.DataBoundItem as Timeslot;
                if (sch != null)
                {
                    _context.Timeslots.Remove(sch);
                    _context.SaveChanges();

                }
            }
        }
    }
}
