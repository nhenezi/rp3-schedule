using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rp3_Schedule
{
    public partial class GroupACD : Form
    {
        ScheduleContext _context;

        public GroupACD()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new ScheduleContext())
            {
                if (textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Missing required input.", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var group = new Group
                    {
                        Name = textBox2.Text.ToString(),
                        Members = Convert.ToInt32(textBox3.Text.ToString()),
                        ParentId = Convert.ToInt32(comboBox1.SelectedValue),
                    };

                    ctx.Groups.Add(group);
                    ctx.SaveChanges();
                    var len = ctx.Groups.ToArray().Length;
                    this.Close();
                }
            }
        }

        private void GroupACD_Load(object sender, EventArgs e)
        {
            _context = new ScheduleContext();
            _context.Groups.Load();
            comboBox1.DataSource = _context.Groups.ToList();
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
