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
        private int _homeTileID;
        private int _currentTileID;
        private string _tileName = "";
        private bool _joinStatus;
        private List<Inventory> userInventoryDataSource;
        private List<Score> questScoreDataSource;
        private List<Chat> chatDataSource;
        private int[,] _questMap =    { { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                                { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 },
                                { 21, 22, 23, 24, 25, 26, 27, 28, 29, 30},
                                { 31, 32, 33, 34, 35, 36, 37, 38, 39, 40},
                                { 41, 42, 43, 44, 45, 46, 47, 48, 49, 50},
                                { 51, 52, 53, 54, 55, 56, 57, 58, 59, 60},
                                { 61, 62, 63, 64, 65, 66, 67, 68, 69, 70},
                                { 71, 72, 73, 74, 75, 76, 77, 78, 79, 80},
                                { 81, 82, 83, 84, 85, 86, 87, 88, 89, 90},
                                { 91, 92, 93, 94, 95, 96, 97, 98, 99, 100}};


        public QuestForm(int userID, string questName, bool joinStatus)
        {
            InitializeComponent();
            _userID = userID;
            _questName = questName;
            _joinStatus = joinStatus;
            GetQuestID();
            GetHomeTileID();
            GetCurrentTileID();
            UpdateDisplay();
        }

        public void UpdateDisplay()
        {
            //DisplayCurrentTile();
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

        private void GetHomeTileID()
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.GetHomeTileID(_userID, _questID);
            _homeTileID = Convert.ToInt32(DataAccess.HomeTileID);
        }

        private void GetCurrentTileID()
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.GetCurrentTileID(_userID, _questID);
            _currentTileID = Convert.ToInt32(DataAccess.CurrentTileID);

            int questMapID = (_currentTileID - _homeTileID) + 1;
            string displayTile = (string.Concat("tile", questMapID));
            DisplayCurrentTile(displayTile);
        }


        private void DisplayCurrentTile(string displayTile)
        {
            if (_tileName != "")
            {
                var previousTile = _tileName;
                var previousTileControl = Controls.Find(previousTile, true).FirstOrDefault() as Button;

                previousTileControl.BackColor = Color.Gray;
            }

            var tileName = displayTile;
            var tileControl = Controls.Find(tileName, true).FirstOrDefault() as Button;

            tileControl.BackColor = Color.Blue;

            _tileName = displayTile;
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

        private void CheckQuest()
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.CheckQuest(_userID, _questID);

            if (DataAccess.QuestStatus == "Death")
            {
                this.Hide();
                MessageBox.Show("Game Over! You did not complete your quest.", "Quest End", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (DataAccess.QuestStatus.EndsWith("!"))
            {
                this.Hide();
                MessageBox.Show(string.Format($"Your quest has ended. {DataAccess.QuestStatus}", "The Quest is WON!", MessageBoxButtons.OK, MessageBoxIcon.Information));
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (DataAccess.QuestStatus.EndsWith("Valid"))
            {
                MessageBox.Show("You have moved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateDisplay();
            }
            else if (DataAccess.QuestStatus.EndsWith("NotFound"))
            {
                this.Hide();
                MessageBox.Show(string.Format($"Your quest has ended. You have been bested!", "Quest Over!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation));
                DialogResult = DialogResult.OK;
                this.Close();
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

        private void UserMove(object sender, EventArgs e)
        {
            Button questButton = (Button)sender;
            string input = questButton.Name;
            int selectedTile = (int.Parse(input.Split('e')[1]));
            var tileSearch = TileSearch(_questMap, 10, selectedTile);

            if (tileSearch.Item1 != 0 && tileSearch.Item2 != 0)
            {
                if (_joinStatus == true)
                {
                    DataAccess dataAccess = new DataAccess();
                    dataAccess.UserMove(_questID, _userID, tileSearch.Item1, tileSearch.Item2);

                    if (DataAccess.MoveStatus == "Success")
                    {
                        DisplayCurrentTile(input);
                        CheckQuest();
                    }
                    else if (DataAccess.MoveStatus == "Invalid")
                    {
                        MessageBox.Show("Choose a closer tile.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (DataAccess.MoveStatus == "InUse")
                    {
                        MessageBox.Show("Someone is on that tile. Try another.", "In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (DataAccess.MoveStatus == "Wait")
                    {
                        MessageBox.Show("It's not your turn!", "Wait Your Turn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (_joinStatus == false)
                {
                    DataAccess dataAccess = new DataAccess();
                    dataAccess.RejoinMove(_questID, _userID, tileSearch.Item1, tileSearch.Item2);

                    if (DataAccess.MoveStatus == "Success")
                    {
                        MessageBox.Show("You have moved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _joinStatus = true;
                        DisplayCurrentTile(input);
                        UpdateDisplay();
                    }
                    else if (DataAccess.MoveStatus == "Invalid")
                    {
                        MessageBox.Show("Choose a closer tile.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (DataAccess.MoveStatus == "InUse")
                    {
                        MessageBox.Show("Someone is on that tile. Try another.", "In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public Tuple<int, int> TileSearch(int[,] mat, int rowMax, int tileID)
        {
            int xMove;
            int yMove;

            // Traverse through the map
            for (int newX = 0; newX < rowMax; newX++)
            {
                for (int newY = 0; newY < rowMax; newY++)

                    // When the tileID is found
                    if (mat[newX, newY] == tileID)
                    {
                        xMove = newX + 1;
                        yMove = newY + 1;

                        return Tuple.Create(xMove, yMove);
                    }
            }

            return Tuple.Create(0, 0);
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
