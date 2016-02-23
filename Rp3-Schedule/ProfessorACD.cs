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
        public List<string> restrictions = new List<string>();
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
                    
                    ctx.Professors.Add(prof);
                    ctx.SaveChanges();

                    //Adding ProfessorTimeRestriction

                    foreach (var r in restrictions)
                    {
                        var restriction = new ProfessorTimeRestriction
                        {
                            TimeslotId = Int32.Parse(r),
                            ProfessorId = 2,  //popraviti, AUTOMATSKI INCREASE POSTAVLJEN IZNAD
                        };
                        ctx.ProfessorTimeRestrictions.Add(restriction);
                        ctx.SaveChanges();
                    }

                    this.Close();
                }
            }
        }

        private void ProfessorACD_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var ACDRestriction = new TimeslotsView(true))
            {
                this.Hide();
                ACDRestriction.ShowDialog();
                restrictions = ACDRestriction.GetRestrictions();
                this.Show();
            }
        }
    }
}
