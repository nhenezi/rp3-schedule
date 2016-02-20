using System;
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
    public partial class GroupACD : Form
    {
        public GroupACD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Number of group members should be a number.", "Type error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var group = new Group
                    {
                        //Podesiti ID na automatski increase
                        Id = 2,
                        Name = textBox2.Text.ToString(),
                        Members = Convert.ToInt32(textBox3.Text.ToString()),
                        //Podesiti na odabir iz combo boxa:
                        ParentId = 3,
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
            //Popuniti ParentID combo box sa svim grupama !!!
        }
    }
}
