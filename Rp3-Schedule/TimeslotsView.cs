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
        public List<string> restrictions { get; set; }
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
                
                button4.Visible = true;
                timeslotDataGridView.MultiSelect = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ACDform = new TimeslotACD();
            ACDform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ACDform = new TimeslotACD();
            ACDform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            foreach (DataRowView rowView in timeslotDataGridView.SelectedRows)
            {
                if (rowView != null)
                {
                    DataRow row = rowView.Row;
                    restrictions.Add(row.ItemArray[0].ToString());
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TimeslotsView_Load(object sender, EventArgs e)
        {
            _context = new ScheduleContext();
            _context.Timeslots.Load();
            this.timeslotBindingSource.DataSource =
                _context.Timeslots.Local.ToBindingList();
        }
    }
}
