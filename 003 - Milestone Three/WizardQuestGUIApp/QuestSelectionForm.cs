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
        private List<UserView> onlineUserDataSource;
        private List<ActiveQuest> activeQuestDataSource;
        private List<ActiveQuest> userActiveQuestDataSource;
        private List<Score> highScoreDataSource;

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
            this.activeQuestData.Columns["QuestID"].Visible = false;
            activeQuestData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void UserActiveQuestList()
        {
            userQuestData.DataSource = null;
            DataAccess dataAccess = new DataAccess();
            userActiveQuestDataSource = dataAccess.GetUserActiveQuest(_userID);
            userQuestData.DataSource = userActiveQuestDataSource;
            this.userQuestData.Columns["QuestID"].Visible = false;
            userQuestData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void NewQuest()
        {
            NewQuestForm newQuestForm = new NewQuestForm();
            if (newQuestForm.ShowDialog() == DialogResult.OK)
            {
                string questName = newQuestForm.NewQuestName;
                this.Hide();
                DataAccess dataAccess = new DataAccess();
                dataAccess.NewQuest(_userID, questName);

                if (DataAccess.QuestStatus == "Success")
                {
                    MessageBox.Show("Quest Creation Success", "New Quest Active", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    QuestForm questForm = new QuestForm(_userID, questName, true);
                    if (questForm.ShowDialog() == DialogResult.OK)
                    {
                        this.Show();
                    }
                }
                else if (DataAccess.QuestStatus == "Invalid")
                {
                    MessageBox.Show("Your Wizard Quest Quest Name is invalid, please try again.", "Invalid Quest Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
                }

                UpdateDisplay();
            }    
        }

        private void JoinQuest(DataGridView selectedDataGrid)
        {
            ActiveQuest joinQuest = (ActiveQuest)selectedDataGrid.SelectedRows[0].DataBoundItem;

            var result = MessageBox.Show(string.Format($"Would you like to join the Quest: {joinQuest.QuestName}?"), "Join Quest?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.JoinQuest(_userID, joinQuest.QuestID);

                if (DataAccess.QuestStatus == "Join")
                {
                    this.Hide();
                    MessageBox.Show("Quest joined", "New Quest Active", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    QuestForm questForm = new QuestForm(_userID, joinQuest.QuestName, true);
                    if (questForm.ShowDialog() == DialogResult.OK)
                    {
                        this.Show();
                    }
                }
                else if (DataAccess.QuestStatus == "Rejoin")
                {
                    this.Hide();
                    MessageBox.Show("Quest joined, continue your existing quest", "Welcome Back", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    QuestForm questForm = new QuestForm(_userID, joinQuest.QuestName, true);
                    if (questForm.ShowDialog() == DialogResult.OK)
                    {
                        this.Show();
                    }
                }
                else if (DataAccess.QuestStatus == "Full")
                {
                    MessageBox.Show("Sorry, this quest is full. Choose another or create your own!", "Quest Full", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (DataAccess.QuestStatus == "InUse")
                {
                    this.Hide();
                    MessageBox.Show("Sorry, you need to choose a new tile", "Tile Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    QuestForm questForm = new QuestForm(_userID, joinQuest.QuestName, false);
                    if (questForm.ShowDialog() == DialogResult.OK)
                    {
                        this.Show();
                    }
                }

                UpdateDisplay();
            }
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
            AdministrationForm administrationForm = new AdministrationForm(_userID);
            if (administrationForm.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                UpdateDisplay();
            }            
        }

        private void newQuestButton_Click(object sender, EventArgs e)
        {
            NewQuest();
        }

        private void userQuestData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            JoinQuest(userQuestData);
        }

        private void activeQuestData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            JoinQuest(activeQuestData);
        }
    }
}
