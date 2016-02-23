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
    public partial class ScheduleACD : Form
    {
        public ScheduleACD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new ScheduleContext())
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Missing required input.", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var schedule = new Schedule
                    {
                        // Podesi input, automatski increase ID
                        Id = 2,
                        Name = textBox2.Text.ToString(),
                    };

                    ctx.Schedules.Add(schedule);
                    ctx.SaveChanges();

                    this.Close();
                }
            }
        }
    }
}
