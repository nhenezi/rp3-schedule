﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Rp3_Schedule
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
			//testProfessor ();
        }

		private void testProfessor() {
		using (var ctx = new ScheduleContext ()) {
			var prof = new Professor {
				Id = 1,
				Name = "adsd"
			};
			ctx.Professors.Add (prof);
			ctx.SaveChanges ();
			var len = ctx.Professors.ToArray ().Length;
		  }
		}

    }
}
