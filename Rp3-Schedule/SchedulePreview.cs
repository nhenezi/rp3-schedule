using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rp3_Schedule
{
    public class Helper
    {
        public string Time { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
    
    }
    public partial class SchedulePreview : Form
    {
        ScheduleContext ctx;

        public SchedulePreview()
        {
            InitializeComponent();
        }

        private void SchedulePreview_Load(object sender, EventArgs e)
        {
            ctx = new ScheduleContext();
            ctx.Allocations.Load();
            List<Helper> h = new List<Helper>();
            foreach(var a in ctx.Allocations)
            {

                h.Add(new Helper {
                    
                });


            }
        }
    }
}
