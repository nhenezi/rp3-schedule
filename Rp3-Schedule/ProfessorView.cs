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
        void RefreshGrid(object sender, FormClosedEventArgs e)
        {
            _context.Professors.Load();
            this.professorBindingSource.DataSource =
                _context.Professors.Local.ToBindingList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var ACDform = new ProfessorACD();
            ACDform.FormClosed += new FormClosedEventHandler(RefreshGrid);
            ACDform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ACDform = new ProfessorACD();
            ACDform.Show();
        }

        private void ProfessorView_Load(object sender, EventArgs e)
        {
            professorDataGridView.MultiSelect = false;
            professorDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _context = new ScheduleContext();
            _context.Professors.Load();
            this.professorBindingSource.DataSource =
                _context.Professors.Local.ToBindingList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in professorDataGridView.SelectedRows)
            {
                Professor sch = row.DataBoundItem as Professor;
                if (sch != null)
                {
                    _context.Professors.Remove(sch);
                    _context.SaveChanges();

                }
            }
        }
    }
}
