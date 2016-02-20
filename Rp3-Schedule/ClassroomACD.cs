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
        public ClassroomACD()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (var ctx = new ScheduleContext())
            {
                bool isNumber = Regex.IsMatch(textBox3.ToString(), @"^\d+$");
                if (textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Missing required input.", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!isNumber)
                {
                    MessageBox.Show("Capacity should be a number.", "Type error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var classroom = new Classroom
                    {
                        //Podesi ID na automatski increase
                        Id = 2,
                        Name = textBox2.Text.ToString(),
                        Capacity = Convert.ToInt32(textBox3.Text.ToString())
                    };

                    // MISSING : Addaj odabrane restrikcije !!!!
                    ctx.Classrooms.Add(classroom);
                    ctx.SaveChanges();
                    var len = ctx.Classrooms.ToArray().Length;
                    this.Close();
                }
            }
        }
    }
}
