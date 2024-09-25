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
    public partial class Welcome : Form
    {

        private string[] storedUsernames;
        private string[] storedPasswords;
        public Welcome(string[] usernames, string[] passwords)
        {
            InitializeComponent();
            storedUsernames = usernames;
            storedPasswords = passwords;
           
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration_Page registration = new Registration_Page();
            registration.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            errorUsername.Clear();
            errorPassword.Clear();

            string username=txtUsername.Text;
            string password=txtPassword.Text;

            bool IsValid = true;

            if(string.IsNullOrEmpty(username))
            {
                errorUsername.SetError(txtUsername, "Username is required");
                IsValid = false;
            }

            if(string.IsNullOrEmpty(password))
            {
                errorPassword.SetError(txtPassword, "Password is required");
                IsValid=false;
            }
            if (!IsValid) return;

            bool loginSuccess = true;

            for(int i = 0; i < storedUsernames.Length; i++)
            {
                if (storedUsernames[i] == username && storedPasswords[i]==password)
                {
                    loginSuccess = true;
                    break;
                }
            }

            if(loginSuccess)
            {
                MessageBox.Show("Login Successful!");

            Maintain_Clients clients = new Maintain_Clients();
               clients.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password. PLease try again or register");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
