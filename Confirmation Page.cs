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
    public partial class Confirmation_Page : Form
    {
        
        public Confirmation_Page()
        {
            InitializeComponent();
           
           
        }
       

        private void Confirmation_Page_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Contact_Page contact = new Contact_Page();
            contact.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Status_Page status = new Status_Page();
            status.Show();
            this.Hide();
        }
    }
}
