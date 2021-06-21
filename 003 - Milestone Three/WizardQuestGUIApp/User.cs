using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardQuestGUIApp
{
    public class User
    {
        private int _userID;
        private string _username;
        private string _userPassword;
        private string _email;
        private int _totalScore;
        private bool _userLocked;
        private bool _administrator;

        public int UserID { get => _userID; set => _userID = value; }
        public string Username { get => _username; set => _username = value; }
        public string UserPassword { get => _userPassword; set => _userPassword = value; }
        public string Email { get => _email; set => _email = value; }
        public int TotalScore { get => _totalScore; set => _totalScore = value; }
        public bool UserLocked { get => _userLocked; set => _userLocked = value; }
        public bool Administrator { get => _administrator; set => _administrator = value; }
    }
}
