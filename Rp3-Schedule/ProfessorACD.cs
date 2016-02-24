﻿using System;
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
        public List<int> restrictions = new List<int>();
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
                        Name = textBox2.Text.ToString(),
                    };
                    
                    ctx.Professors.Add(prof);
                    ctx.SaveChanges();

                    //Adding ProfessorTimeRestriction

                    foreach (var r in restrictions)
                    {
                        var restriction = new ProfessorTimeRestriction
                        {
                            ProfessorId = prof.Id,
                            TimeslotId = r,
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
                var result = ACDRestriction.ShowDialog();
                if (result == DialogResult.OK)
                {
                    restrictions = ACDRestriction.restrictions;
                }
            }
        }
    }
}
