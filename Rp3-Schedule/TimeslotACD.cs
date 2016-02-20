using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rp3_Schedule
{
    public partial class TimeslotACD : Form
    {
        public TimeslotACD()
        {
            InitializeComponent();
        }

        private void TimeslotACD_Load(object sender, EventArgs e)
        {
            timePickerFrom.Format = DateTimePickerFormat.Time;
            timePickerFrom.ShowUpDown = true;

            timePickerTo.Format = DateTimePickerFormat.Time;
            timePickerTo.ShowUpDown = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new ScheduleContext())
            {
                if ( comboBox1.SelectedItem.ToString() == "" )
                {
                    MessageBox.Show("Missing required input from dropdown menu.", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var timeslot = new Timeslot
                    {
                        // Podesi input, automatski increase ID
                        Id = 2,
                        // Promijeniti u bazi da mogu popuniti dobro From i To! U bazi su int, ovdje je timePicker?
                        From = 1,
                        To = 2,
                        Day = comboBox1.SelectedItem.ToString(),
                    };

                    ctx.Timeslots.Add(timeslot);
                    ctx.SaveChanges();
                    var len = ctx.Timeslots.ToArray().Length;
                    this.Close();
                }
            }
        }
    }
}
