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

        public AdministrationForm()
        {
            InitializeComponent();
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
            this.Hide();
            this.QuestSelectionForm.Closed += (s, args) => Close();
            this.QuestSelectionForm.Show();
        }

        private void AdministrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.QuestSelectionForm.Show();
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            User transferUser = (User)globalUserData.SelectedRows[0].DataBoundItem;
            transferUser.EditUser(this);
        }
    }
}
