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
    public partial class QuestSelectionForm : Form
    {
        private string _username;
        private List<OnlineUser> onlineUsersDataSource;

        public QuestSelectionForm(string username)
        {
            InitializeComponent();
            _username = username;
            UpdateDisplay();
        }


        private void UpdateDisplay()
        {
            titleLabel.Text = string.Format("Welcome to Wizard Quest {0}", _username);

            OnlineUserList();
        }

        private void OnlineUserList()
        {
            usersOnlineData.DataSource = null;
            DataAccess dataAccess = new DataAccess();
            onlineUsersDataSource = dataAccess.GetOnlineUsers();
            usersOnlineData.DataSource = onlineUsersDataSource;
        }

        private void UserLogout()
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.UserLogout(_username);

            if (DataAccess.LoginStatus == "Offline")
            {
                this.Close();
                MessageBox.Show("Logout Success", "User Offline", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void logoutButton_Click(object sender, EventArgs e)
        {
            UserLogout();
            //this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        private void QuestSelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Hide();
            UserLogout();
        }
    }
}
