using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardQuestGUIApp
{
    public class User
    {
        private UserForm _userForm;
        private int _userID;
        private string _username;
        private string _userPassword;
        private string _email;
        private int _loginAttempts;
        private int _totalScore;
        private bool _userLocked;
        private bool _administrator;

        public int UserID { get => _userID; set => _userID = value; }
        public string Username { get => _username; set => _username = value; }
        public string UserPassword { get => _userPassword; set => _userPassword = value; }
        public string Email { get => _email; set => _email = value; }
        public int LoginAttempts { get => _loginAttempts; set => _loginAttempts = value; }
        public int TotalScore { get => _totalScore; set => _totalScore = value; }
        public bool UserLocked { get => _userLocked; set => _userLocked = value; }
        public bool Administrator { get => _administrator; set => _administrator = value; }
        

        public void EditUser(AdministrationForm transferUser)
        {
            if (_userForm == null)
            {
                _userForm = new UserForm(transferUser);
                _userForm.User = this;
            }

            _userForm.userIDNumeric.Value = _userID;
            _userForm.usernameText.Text = _username;
            _userForm.passwordText.Text = _userPassword;
            _userForm.emailText.Text = _email;
            _userForm.loginAttemptsNumeric.Value = _loginAttempts;
            _userForm.totalScoreNumeric.Value = _totalScore;
            _userForm.lockedCheckBox.Checked = _userLocked;
            _userForm.administratorCheckBox.Checked = _administrator;

            _userForm.ShowDialog();
        }
    }


}
