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
    public partial class AdministrationForm : Form
    {
        public Form QuestSelectionForm { get; set; }
        private List<ActiveQuest> activeQuestDataSource;
        private List<User> globalUsersDataSource;
        private int _administratorID;

        public AdministrationForm(int administratorID)
        {
            InitializeComponent();
            _administratorID = administratorID;
            UpdateDisplay();
        }

        public void UpdateDisplay()
        {
            ActiveQuestList();
            GlobalUserList();
        }

        private void ActiveQuestList()
        {
            activeQuestData.DataSource = null;
            DataAccess dataAccess = new DataAccess();
            activeQuestDataSource = dataAccess.GetAdministratorQuest();
            activeQuestData.DataSource = activeQuestDataSource;
            this.activeQuestData.Columns["QuestID"].Visible = false;
            activeQuestData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void GlobalUserList()
        {
            globalUserData.DataSource = null;
            DataAccess dataAccess = new DataAccess();
            globalUsersDataSource = dataAccess.GetAllUsers();
            globalUserData.DataSource = globalUsersDataSource;
            this.globalUserData.Columns["UserID"].Visible = false;
            this.globalUserData.Columns["UserPassword"].Visible = false;
            this.globalUserData.Columns["Email"].Visible = false;
            this.globalUserData.Columns["LoginAttempts"].Visible = false;
            this.globalUserData.Columns["TotalScore"].Visible = false;
            this.globalUserData.Columns["UserLocked"].Visible = false;
            this.globalUserData.Columns["Administrator"].Visible = false;
            globalUserData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //globalUserData.AutoGenerateColumns = false;
            //globalUserData.ColumnCount = 1;
            //globalUserData.Columns[0].HeaderText = "Username";
            //globalUserData.Columns[0].DataPropertyName = "Username";
            //globalUserData.DataSource = globalUsersDataSource;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
            //this.QuestSelectionForm.Closed += (s, args) => Close();
            //this.QuestSelectionForm.Show();
            //this.QuestSelectionForm.UpdateDisplay();
        }

        private void AdministrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            User transferUser = (User)globalUserData.SelectedRows[0].DataBoundItem;
            transferUser.EditUser(this, true);
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            User transferUser = new User();
            transferUser.NewUser(this, false);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            User user = (User)globalUserData.SelectedRows[0].DataBoundItem;

            if (user.UserID != _administratorID)
            {
                var result = MessageBox.Show(string.Format($"Are you sure you want to delete the user {user.Username}?"), "Delete User?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DataAccess dataAccess = new DataAccess();
                    dataAccess.AdministratorDelete(user.UserID);

                    if (DataAccess.AdministrationStatus == "Success")
                    {
                        MessageBox.Show("Delete Success", "User Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (DataAccess.AdministrationStatus == "UserID")
                    {
                        MessageBox.Show("That Wizard Quest UserID is invalid, please try again.", "Invalid UserID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    UpdateDisplay();
                }
            }
            else
            {
                MessageBox.Show("You are unable to deleted you own account.", "Invalid UserID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void killQuestButton_Click(object sender, EventArgs e)
        {
            ActiveQuest activeQuest = (ActiveQuest)activeQuestData.SelectedRows[0].DataBoundItem;
            var result = MessageBox.Show(string.Format($"Are you sure you want to kill the quest: {activeQuest.QuestName}?"), "Kill Quest?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.AdministratorKill(activeQuest.QuestID);

                if (DataAccess.AdministrationStatus == "Success")
                {
                    MessageBox.Show("Quest Killed Successfully", "Quest Killed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (DataAccess.AdministrationStatus == "QuestID")
                {
                    MessageBox.Show("Your Wizard Quest QuestID is invalid, please try again.", "Invalid QuestID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                UpdateDisplay();
            }
        }
    }
}
