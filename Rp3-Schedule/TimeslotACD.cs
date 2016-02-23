using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isNumber1 = Regex.IsMatch(textBox2.ToString(), @"^\d+$");
            bool isNumber2 = Regex.IsMatch(textBox2.ToString(), @"^\d+$");
            if (!isNumber1 || !isNumber2)
            {
                MessageBox.Show("Fields 'From' and 'To' should be numbers.", "Type error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                using (var ctx = new ScheduleContext())
                {
                    if (comboBox1.SelectedItem.ToString() == "")
                    {
                        MessageBox.Show("Missing required input from dropdown menu.", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var timeslot = new Timeslot
                        {
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
}
