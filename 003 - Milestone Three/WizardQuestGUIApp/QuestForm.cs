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
    public partial class QuestForm : Form
    {
        private int _userID;
        private string _questName;
        private int _questID;
        private List<Inventory> userInventoryDataSource;
        private List<Score> questScoreDataSource;
        private List<Chat> chatDataSource;

        public QuestForm(int userID, string questName)
        {
            InitializeComponent();
            _userID = userID;
            _questName = questName;
            GetQuestID();
            UpdateDisplay();
        }

        public void UpdateDisplay()
        {
            QuestScore();
            UserInventory();
            QuestChat();
        }

        private void GetQuestID()
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.GetQuestID(_questName);
            _questID = Convert.ToInt32(DataAccess.QuestID);
        }

        private void QuestScore()
        {
            userQuestScoreData.DataSource = null;
            DataAccess dataAccess = new DataAccess();
            questScoreDataSource = dataAccess.GetQuestScore(_questID);
            userQuestScoreData.DataSource = questScoreDataSource;
        }

        private void UserInventory()
        {
            inventoryData.DataSource = null;
            DataAccess dataAccess = new DataAccess();
            userInventoryDataSource = dataAccess.GetUserInventory(_userID, _questID);
            inventoryData.DataSource = userInventoryDataSource;
        }

        private void QuestChat()
        {
            chatList.DataSource = null;
            DataAccess dataAccess = new DataAccess();
            chatDataSource = dataAccess.GetQuestChat(_questID);
            chatList.DataSource = chatDataSource;
        }

        private void UserMove(object sender, EventArgs e)
        {
            Button questButton = (Button)sender;
            int x = (Convert.ToInt32(questButton.Text) % 6) + 1;
            int y = (Convert.ToInt32(questButton.Text) / 6) + 1;
            DataAccess dataAccess = new DataAccess();
            dataAccess.UserMove(_questID, _userID, x, y);

            if (DataAccess.MoveStatus == "Success")
            {
                MessageBox.Show("You have moved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                questButton.BackColor = Color.Red;
            }
            else if (DataAccess.MoveStatus == "Invalid")
            {
                MessageBox.Show("Choose a closer tile.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                questButton.BackColor = Color.Red;
            }
        }

        private void leaveQuestButton_Click(object sender, EventArgs e)
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.LeaveQuest(_userID, _questID);

            this.Hide();
            if (DataAccess.QuestStatus == "Success")
            {
                MessageBox.Show("You have left your quest.", "Quest Left", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (DataAccess.QuestStatus == "Invalid")
            {
                MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button questButton = (Button)sender;
            int x = (Convert.ToInt32(questButton.Text) % 6) + 1;
            int y = (Convert.ToInt32(questButton.Text) / 6);
            DataAccess dataAccess = new DataAccess();
            dataAccess.UserMove(_questID, _userID, x, y);

            if (DataAccess.MoveStatus == "Success")
            {
                MessageBox.Show("You have moved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                questButton.BackColor = Color.Red;
            }
            else if (DataAccess.MoveStatus == "Invalid")
            {
                MessageBox.Show("Choose a closer tile.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                questButton.BackColor = Color.Red;
            }
        }

        private void QuestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.LeaveQuest(_userID, _questID);
            DialogResult = DialogResult.OK;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (chatText.Text != "")
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.UserChat(_userID, _questID, chatText.Text);

                if (DataAccess.QuestStatus == "Failed")
                {
                    MessageBox.Show("Your quest has already ended", "Invalid Quest", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (DataAccess.QuestStatus == "Success")
                {
                    chatText.Clear();
                    QuestChat();
                }
            }
        }
    }
}
