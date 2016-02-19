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
    }
}
