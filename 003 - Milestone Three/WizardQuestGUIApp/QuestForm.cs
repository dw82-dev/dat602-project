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

        public QuestForm(int userID, string questName)
        {
            InitializeComponent();
            _userID = userID;
            _questName = questName;
            GetQuestID();
        }

        private void GetQuestID()
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.GetQuestID(_questName);
            _questID = Convert.ToInt32(DataAccess.QuestID);
        }

        private void leaveQuestButton_Click(object sender, EventArgs e)
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.LeaveQuest(_userID, _questID);

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
            Button abutton = (Button)sender;
            int x = (Convert.ToInt32(abutton.Text) % 6) + 1;
            int y = (Convert.ToInt32(abutton.Text) / 6) + 1;
            DataAccess dataAccess = new DataAccess();
            dataAccess.UserMove(1, _userID, x, y);

            if (DataAccess.MoveStatus == "Success")
            {
                MessageBox.Show("You have left your quest.", "Quest Left", MessageBoxButtons.OK, MessageBoxIcon.Information);
                abutton.BackColor = Color.Red;
            }
        }
    }
}
