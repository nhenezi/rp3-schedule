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
    public partial class ProfessorView : Form
    {
        ScheduleContext _context;
        public ProfessorView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ACDform = new ProfessorACD();
            ACDform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ACDform = new ProfessorACD();
            ACDform.Show();
        }

        private void ProfessorView_Load(object sender, EventArgs e)
        {
            _context = new ScheduleContext();
            _context.Professors.Load();
            this.professorBindingSource.DataSource =
                _context.Professors.Local.ToBindingList();
        }

        
    }
}
