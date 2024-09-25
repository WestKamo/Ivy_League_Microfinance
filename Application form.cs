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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Ivy_League_Microfinance
{
    public partial class Application_Form : Form
    {
        SqlConnection conn;
        SqlCommand command;
        SqlDataReader dataReader;
        SqlDataAdapter adapt;
        DataSet dataS;
        public Application_Form()
        {
            InitializeComponent();
        }

        private void Application_Form_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string address=AddressTB.Text;
            string city =CityTb.Text;
            string zip_code=IDnumberTB.Text;
            string marital=MaritalTb.Text;

            //financial information
            string income=FinancialTb.Text;
            string source_income=SourceTb.Text;
            string employer=EmployerTb.Text;
            

            //Loan details
            string loan=AmountTb.Text;
            string purposeOfLoan=PurposeTb.Text;
            string repayment_term=TermTb.Text;
          
            //Reference 1
            string name=Rname1.Text;
            string relationship=RelationshipTb1.Text;
            string phone_no=PhoneTp1.Text;
           

            // Validate Address
            if (string.IsNullOrEmpty(AddressTB.Text))
            {
                errorAddress.SetError(AddressTB, "Address is required.");
                return;
            }
            try
            {
                SqlConnection conn = new SqlConnection(@"");
                conn.Open();

                string store = $"INSERT INTO Clients(Address) VALUES ('{address}')";

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


            // Validate City
            if (string.IsNullOrEmpty(CityTb.Text))
            {
                errorCity.SetError(CityTb, "City is required.");
                return;
            }

            // Validate Zip Code
            if (string.IsNullOrEmpty(IDnumberTB.Text))
            {
                errorCode.SetError(IDnumberTB, "Zip code is required.");
                return;
            }
            else if (!int.TryParse(IDnumberTB.Text, out _))
            {
                errorCode.SetError(IDnumberTB, "ID number must be a valid number.");
                return;
            }

            // Validate Marital Status
            if (string.IsNullOrEmpty(MaritalTb.Text))
            {
                errorStatus.SetError(MaritalTb, "Marital status is required.");
                return;
            }

            // Validate Financial Information
            if (string.IsNullOrEmpty(FinancialTb.Text))
            {
                errorFinancial.SetError(FinancialTb, "Income is required.");
                return;
            }
            else if (!double.TryParse(FinancialTb.Text, out _))
            {
                errorFinancial.SetError(FinancialTb, "Income must be a valid number.");
                return;
            }

            if (string.IsNullOrEmpty(SourceTb.Text))
            {
                errorSource.SetError(SourceTb, "Source of income is required.");
                return;
            }

            if (string.IsNullOrEmpty(EmployerTb.Text))
            {
                errorEmployer.SetError(EmployerTb, "Employer is required.");
                return;
            }


            // Validate Loan Details
            if (string.IsNullOrEmpty(AmountTb.Text))
            {
                errorAmount.SetError(AmountTb, "Loan amount is required.");
                return;
            }
            else if (!double.TryParse(AmountTb.Text, out _))
            {
                errorAmount.SetError(AmountTb, "Loan amount must be a valid number.");
                return;
            }

            if (string.IsNullOrEmpty(PurposeTb.Text))
            {
                errorPurpose.SetError(PurposeTb, "Purpose of loan is required.");
                return;
            }

            if (string.IsNullOrEmpty(TermTb.Text))
            {
                errorTerm.SetError(TermTb, "Repayment term is required.");
                return;
            }
            else if (!int.TryParse(TermTb.Text, out _))
            {
                errorTerm.SetError(TermTb, "Repayment term must be a valid number.");
                return;
            }

           

            // Validate Reference 1
            if (string.IsNullOrEmpty(Rname1.Text))
            {
                errorRname1.SetError(Rname1, "Reference 1 name is required.");
                return;
            }

            if (string.IsNullOrEmpty(RelationshipTb1.Text))
            {
                errorRelat1.SetError(RelationshipTb1, "Relationship for Reference 1 is required.");
                return;
            }

            if (string.IsNullOrEmpty(PhoneTp1.Text))
            {
                errorPhone1.SetError(PhoneTp1, "Phone number for Reference 1 is required.");
                return;
            }
            else if (!long.TryParse(PhoneTp1.Text, out _) || PhoneTp1.Text.Length != 10)
            {
                errorPhone1.SetError(PhoneTp1, "Phone number for Reference 1 must be a 10-digit number.");
                return;
            }

          

            // Validate multiple CheckBoxes
            if (!checkBox.Checked)
            {
                errorCheck.SetError(checkBox, "Please accept the declaration");

                return; 
            }
            else
            {
                checkBox.ForeColor = Color.Green;
                checkBox.Font = new Font("Arial", 12);
            }

         

        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"");

                string store = $"INSERT INTO Loans(Loan_amount,Id_Number) VALUES (@AmountTb,@IDnumberTB)";

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
            Confirmation_Page confirmation_ = new Confirmation_Page();
            confirmation_.Show();

            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
