﻿using System;
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
    public partial class ClassroomACD : Form
    {
        public List<int> restrictions = new List<int>();
        public ClassroomACD()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (var ctx = new ScheduleContext())
            {
                if (textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Missing required input.", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var classroom = new Classroom
                    {
                        Name = textBox2.Text.ToString(),
                        Capacity = Convert.ToInt32(textBox3.Text)
                    };
                    ctx.Classrooms.Add(classroom);
                    ctx.SaveChanges();
                    var len = ctx.Classrooms.ToArray().Length;
                    this.Close();

                    //Adding ClassroomTimeRestriction

                    foreach (var r in restrictions)
                    {
                        var restriction = new ClassroomTimeRestriction
                        {
                            TimeslotId = r,
                        };
                        ctx.ClassroomTimeRestrictions.Add(restriction);
                        ctx.SaveChanges();
                    }
                }
            }
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
