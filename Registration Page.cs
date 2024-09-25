using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ivy_League_Microfinance
{
    public partial class Registration_Page : Form
    {
        SqlConnection conn;
        SqlCommand command;
        SqlDataReader dataReader;
        SqlDataAdapter adapt;
        DataSet dataS;

        //Arrays to store user passwords and usernames
        private string[] passwords = new string[15];
        private string[] usernames = new string[25];
        private int arrCount = 0;
        public Registration_Page()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome(getUsername(), getPassword());
            welcome.Show();
            this.Close();
            this.Close();
        }

        public string[] getUsername()
        {
            return usernames.Take(arrCount).ToArray();
        }

        public string[] getPassword()
        {
            return passwords.Take(arrCount).ToArray();
        }
        
        //Function for validating email address
        private void validateEmail()
        {
            string email_address = email.Text;

            if(string.IsNullOrEmpty(email.Text))
            {
                errorEmail.SetError(email, "Please insert your email address");
                
                return;
            }

            string email_format = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if(!Regex.IsMatch(email_address, email_format))
            {
                MessageBox.Show("Please enter a valid email address", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void userNameValidation()
        {

            

        }
        
        private bool IsValidPassword(string password)
        {
            if(password.Length <6 || password.Length >8)
            {
                return false;
            }

            int digiCount=password.Count(char.IsDigit);
            if(digiCount<2)
            {
                return false;
            }


            return true ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = FName.Text;
            string surname = LName.Text;
            string id_no = ID.Text;
            int idNumber;
            
            string phone_no=Phone.Text;
            string gender=GenderCB.SelectedText;
            
            

            DateTime  selectedDate = dateTime.Value;

            //FirsT name validation
            if (string.IsNullOrEmpty(FName.Text))
            {

                errorName.SetError(FName, "Name is required");
                return;
            }
            errorName.Clear();
            //Last name Validation
            if (string.IsNullOrEmpty(LName.Text))
            {
                errorSurname.SetError(LName, "Surname Is required.");
                return;
            }

            if (int.TryParse(id_no, out idNumber))
            {
                try
                {
                    SqlConnection conn = new SqlConnection(@"");

                    string store = $"INSERT INTO Clients(F_Name, L_Name, ID_number) VALUES ('{name}', '{surname}', '{ID}')";

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
               

           

            //ID Number validation
            if(string.IsNullOrEmpty(ID.Text))
            {
                errorID.SetError(ID, "Insert ID");
                return;
            }

            //Validate DOB
            if(dateTime.Value> DateTime.Now.AddYears(-18))
            {
                errorDOB.SetError(dateTime, "You must be at least 18 years old to qualify for a loan");
                return;
            }

            //Gender validation
            if(GenderCB.SelectedItem==null)
            {
                errorGender.SetError(GenderCB, "Please Select Your Gender");
                return;
            }

            //Validate Phone Number
            if(!long.TryParse(Phone.Text,out _) || Phone.Text.Length !=10)
            {
                errorPhone.SetError(Phone, "Phone number must be out of 10 digits");
                return;
            }

            MessageBox.Show("Successfully registered");


            Application_Form application = new Application_Form();
            application.Show();

            this.Hide();
        }

        private void Registration_Page_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
