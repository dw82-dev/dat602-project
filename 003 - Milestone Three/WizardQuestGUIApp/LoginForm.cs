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

            if (DataAccess.Status == "Success")
            {
                MessageBox.Show("Login Success", "Welcome Back", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QuestSelectionForm questSelectionForm = new QuestSelectionForm();
                questSelectionForm.ShowDialog();
                
            }
            else if (DataAccess.Status == "Password")
            {
                MessageBox.Show("Your Wizard Quest password is incorrect, please try again.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (DataAccess.Status == "Locked")
            {
                MessageBox.Show("Your Wizard Quest account is locked, please contact administrator.", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (DataAccess.Status == "Username")
            {
                var result = MessageBox.Show(string.Format($"Wizard Quest username not found. Would you like to register as a new user?"), "New User?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    
                }

            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(string.Format($"Are you sure you want to delete your Wizard Quest account?"), "Delete Account?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.UserDelete(usernameText.Text, passwordText.Text);

                if (DataAccess.Status == "Success")
                {
                    MessageBox.Show("Your Wizard Quest account has been deleted.", "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (DataAccess.Status == "Fail")
                {
                    MessageBox.Show("Your Wizard Quest account are invalid.", "Invalid Username or Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void ClearLogin()
        {
            this.Controls.Clear();
            this.InitializeComponent();
        }
    }
}
