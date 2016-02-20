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
    public partial class ProfessorACD : Form
    {
        public ProfessorACD()
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
                    var prof = new Professor
                    {
                        // Podesi input, automatski increase ID
                        Id = 2,
                        Name = textBox2.Text.ToString(),
                    };

                    // MISSING : Addaj odabrane restrikcije !!!!
                    ctx.Professors.Add(prof);
                    ctx.SaveChanges();
                    var len = ctx.Professors.ToArray().Length;
                    this.Close();
                }
            }
        }

        private void ProfessorACD_Load(object sender, EventArgs e)
        {
            //MISSING : Popuni combobox za restrikcije sa svim mogućim timeslotovima !!!!
        }
    }
}
