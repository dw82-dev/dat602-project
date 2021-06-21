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

        private void UpdateDisplay()
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
            gloablUserData.DataSource = null;
            DataAccess dataAccess = new DataAccess();
            globalUsersDataSource = dataAccess.GetAllUsers();
            gloablUserData.DataSource = globalUsersDataSource;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.QuestSelectionForm.Closed += (s, args) => Close();
            this.QuestSelectionForm.Show();
        }
    }
}
