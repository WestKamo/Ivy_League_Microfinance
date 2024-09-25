using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ivy_League_Microfinance
{
    public partial class Status_Page : Form
    {
        public Status_Page()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IdnumberTb.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Contact_Page contact = new Contact_Page();
            contact.Show();
        }
    }
}
