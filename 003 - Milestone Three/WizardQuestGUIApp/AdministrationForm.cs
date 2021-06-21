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

        public AdministrationForm()
        {
            UpdateDisplay();
            InitializeComponent();
        }

        private void UpdateDisplay()
        {

        }

        private void ActiveQuestList()
        {
            activeQuestData.DataSource = null;
            DataAccess dataAccess = new DataAccess();
            activeQuestDataSource = dataAccess.GetActiveQuest(_userID);
            activeQuestData.DataSource = activeQuestDataSource;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.QuestSelectionForm.Closed += (s, args) => Close();
            this.QuestSelectionForm.Show();
        }
    }
}
