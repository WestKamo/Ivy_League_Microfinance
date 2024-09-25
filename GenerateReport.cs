using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ivy_League_Microfinance
{
    public partial class GenerateReport : Form
    {
        public GenerateReport()
        {
            InitializeComponent();
        }

        string connStr = @"";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adap;
        DataSet ds;

        private void GenerateReport_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            adap = new SqlDataAdapter();
            ds = new DataSet();

            string sql = "SELECT * FROM ClientRecordsmdf";

            comm = new SqlCommand(sql, conn);
            adap.SelectCommand = comm;
            adap.Fill(ds, "SourceTable");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "SourceTable";

            conn.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
