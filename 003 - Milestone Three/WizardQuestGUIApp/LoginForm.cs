using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WizardQuestGUIApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            passwordText.PasswordChar = '*';
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.UserLogin(usernameText.Text, passwordText.Text);

            if (DataAccess.LoginStatus == "Success")
            {
                MessageBox.Show("Login Success", "Welcome Back", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                QuestSelectionForm questSelectionForm = new QuestSelectionForm(usernameText.Text);
                questSelectionForm.Closed += (s, args) => this.Close();
                questSelectionForm.ShowDialog();
                
            }
            else if (DataAccess.LoginStatus == "Password")
            {
                MessageBox.Show("Your Wizard Quest password is incorrect, please try again.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (DataAccess.LoginStatus == "Locked")
            {
                MessageBox.Show("Your Wizard Quest account is locked, please contact administrator.", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (DataAccess.LoginStatus == "Username")
            {
                var result = MessageBox.Show(string.Format($"Wizard Quest username not found. Would you like to register as a new user?"), "New User?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.Hide();
                    RegistrationForm registrationForm = new RegistrationForm(usernameText.Text);
                    registrationForm.Closed += (s, args) => this.Close();
                    registrationForm.ShowDialog();
                }

            }

            ClearLogin();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(string.Format($"Are you sure you want to delete your Wizard Quest account?"), "Delete Account?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.UserDelete(usernameText.Text, passwordText.Text);

                if (DataAccess.LoginStatus == "Success")
                {
                    MessageBox.Show("Your Wizard Quest account has been deleted.", "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (DataAccess.LoginStatus == "Fail")
                {
                    MessageBox.Show("Your Wizard Quest account details are invalid.", "Invalid Username or Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ClearLogin();
        }

        private void ClearLogin()
        {
            this.Controls.Clear();
            this.InitializeComponent();
            passwordText.PasswordChar = '*';
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
