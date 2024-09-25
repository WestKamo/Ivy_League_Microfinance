using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ivy_League_Microfinance
{
    public partial class Delete : Form
    {
        string connStr = @"";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adap;
        
        public Delete()
        {
            InitializeComponent();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
           
            try
            {
                SqlConnection conn = new SqlConnection(@"");

                string store = $"Delete Loan_amount,Id_Number From Loans where Id_number=@txtIDnumber)";

                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(store, conn);
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("Successfully registered");
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"");

                string store = $"Delete FName,Id_Number,LName From Clients where Id_number=@txtIDnumber)";

                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(store, conn);
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();

                conn.Close();
               
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);

            }
            MessageBox.Show("Successfully Deleted");
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
