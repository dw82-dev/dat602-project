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
        private List<ActiveQuest> activeQuestDataSource;

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
            ActiveQuestList();
        }

        private void OnlineUserList()
        {
            usersOnlineData.DataSource = null;
            DataAccess dataAccess = new DataAccess();
            onlineUsersDataSource = dataAccess.GetOnlineUsers();
            usersOnlineData.DataSource = onlineUsersDataSource;
        }

        private void ActiveQuestList()
        {
            activeQuestData.DataSource = null;
            DataAccess dataAccess = new DataAccess();
            activeQuestDataSource = dataAccess.GetActiveQuest();
            activeQuestData.DataSource = activeQuestDataSource;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.UserLogout(_username);

            if (DataAccess.LoginStatus == "Offline")
            {
                MessageBox.Show("Logout Success", "User Offline", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Closed += (s, args) => Close();
                loginForm.ShowDialog();
            }
        }

        private void QuestSelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.UserLogout(_username);
        }

    }
}
