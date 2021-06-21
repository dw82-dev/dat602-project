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
        private int _userID;
        private List<OnlineUser> onlineUsersDataSource;
        private List<ActiveQuest> activeQuestDataSource;
        private List<UserActiveQuest> userActiveQuestDataSource;

        public QuestSelectionForm(string username)
        {
            InitializeComponent();
            _username = username;
            GetUserID();
            UpdateDisplay();
        }


        private void UpdateDisplay()
        {
            titleLabel.Text = string.Format("Welcome to Wizard Quest {0}", _username);

            OnlineUserList();
            ActiveQuestList();
            UserActiveQuestList();
        }

        private void GetUserID()
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.GetUserID(_username);
            _userID = Convert.ToInt32(DataAccess.UserID);
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
            activeQuestDataSource = dataAccess.GetActiveQuest(_userID);
            activeQuestData.DataSource = activeQuestDataSource;
        }

        private void UserActiveQuestList()
        {
            userQuestData.DataSource = null;
            DataAccess dataAccess = new DataAccess();
            userActiveQuestDataSource = dataAccess.GetUserActiveQuest(_userID);
            userQuestData.DataSource = userActiveQuestDataSource;
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
