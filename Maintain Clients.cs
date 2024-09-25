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
    public partial class Maintain_Clients : Form
    {
        public Maintain_Clients()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Update up = new Update();
            up.Show();
         }

        private void button2_Click(object sender, EventArgs e)
        {
            Delete del = new Delete();
            del.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Delete_From_Loans loans = new Delete_From_Loans();
            loans.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GenerateReport gen = new GenerateReport();
            gen.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
