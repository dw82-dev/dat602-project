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
    public partial class UserForm : Form
    {
        public User User;
        private AdministrationForm _administrationForm;
        private bool _existingUser;

        public UserForm(AdministrationForm transferUser, bool existingUser)
        {
            InitializeComponent();
            _administrationForm = transferUser;
            _existingUser = existingUser;
            userIDNumeric.ReadOnly = true;
            userIDNumeric.Increment = 0;
            if (existingUser == false)
            {
                totalScoreNumeric.ReadOnly = true;
                totalScoreNumeric.Increment = 0;
                loginAttemptsNumeric.ReadOnly = true;
                loginAttemptsNumeric.Increment = 0;
                lockedCheckBox.Enabled = false;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _administrationForm.UpdateDisplay();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (_existingUser == true)
            {
                ModifyUser();
            }
            else if (_existingUser == false)
            {
                AddUser();
            }
        }

        private void AddUser()
        {
            if (usernameText.Text != "" && passwordText.Text != "" && emailText.Text != "")
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.AdministratorAdd(usernameText.Text, passwordText.Text, emailText.Text, administratorCheckBox.Checked);

                if (DataAccess.AdministrationStatus == "Success")
                {
                    MessageBox.Show("Update Success", "User Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    _administrationForm.UpdateDisplay();
                }
                else if (DataAccess.AdministrationStatus == "Username")
                {
                    MessageBox.Show("Your Wizard Quest Username is invalid, please try again.", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Details are incomplete, please review and try again.", "User Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModifyUser()
        {
            if (usernameText.Text != "" && passwordText.Text != "" && emailText.Text != "")
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.AdministratorModify(User.UserID, usernameText.Text, passwordText.Text, emailText.Text, Convert.ToInt32(loginAttemptsNumeric.Value), lockedCheckBox.Checked, administratorCheckBox.Checked, Convert.ToInt32(totalScoreNumeric.Value));

                if (DataAccess.AdministrationStatus == "Success")
                {
                    MessageBox.Show("Update Success", "User Modified", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    _administrationForm.UpdateDisplay();
                }
                else if (DataAccess.AdministrationStatus == "UserID")
                {
                    MessageBox.Show("Your Wizard Quest UserID is invalid, please try again.", "Invalid UserID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (DataAccess.AdministrationStatus == "Username")
                {
                    MessageBox.Show("Your Wizard Quest Username is invalid, please try again.", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Details are incomplete, please review and try again.", "User Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
