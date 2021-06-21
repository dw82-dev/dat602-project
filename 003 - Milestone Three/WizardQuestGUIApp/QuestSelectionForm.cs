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
        private bool _administrator;
        private List<User> onlineUserDataSource;
        private List<ActiveQuest> activeQuestDataSource;
        private List<UserActiveQuest> userActiveQuestDataSource;
        private List<HighScore> highScoreDataSource;

        public QuestSelectionForm(string username, bool administrator)
        {
            InitializeComponent();
            _username = username;
            _administrator = administrator;
            GetUserID();
            UpdateDisplay();
        }


        private void UpdateDisplay()
        {
            titleLabel.Text = string.Format("Welcome to Wizard Quest {0}", _username);

            HighScoreList();
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

        private void HighScoreList()
        {
            highScoreData.DataSource = null;
            DataAccess dataAccess = new DataAccess();
            highScoreDataSource = dataAccess.GetHighScores();
            highScoreData.DataSource = highScoreDataSource;
        }

        private void OnlineUserList()
        {
            userOnlineData.DataSource = null;
            DataAccess dataAccess = new DataAccess();
            onlineUserDataSource = dataAccess.GetOnlineUsers();
            userOnlineData.DataSource = onlineUserDataSource;
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

        private void QuestSelectionForm_Load(object sender, EventArgs e)
        {
            if (_administrator == true)
            {
                administrationButton.Enabled = true;
            }
            else if (_administrator == false)
            {
                administrationButton.Enabled = false;
            }
        }

        private void administrationButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdministrationForm administrationForm = new AdministrationForm();
            administrationForm.QuestSelectionForm = this;
            this.Visible = false;
            administrationForm.ShowDialog();

        }
    }
}
