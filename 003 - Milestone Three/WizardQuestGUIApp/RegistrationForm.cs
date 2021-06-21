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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm(string username)
        {
            InitializeComponent();
            usernameText.Text = username;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (usernameText.Text != "" && passwordText.Text != "" && emailText.Text != "")
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.UserRegistration(usernameText.Text, passwordText.Text, emailText.Text);

                if (DataAccess.RegistrationStatus == "Success")
                {
                    MessageBox.Show("Registration Success", "Welcome To Wizard Quest", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    QuestSelectionForm questSelectionForm = new QuestSelectionForm(usernameText.Text, false);
                    questSelectionForm.Closed += (s, args) => this.Close();
                    questSelectionForm.ShowDialog();
                }
                else if (DataAccess.RegistrationStatus == "Username")
                {
                    MessageBox.Show("The username selected is invalid, please try again.", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Registration incomplete, please try again.", "Incomplete Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.ShowDialog();
        }
    }
}
