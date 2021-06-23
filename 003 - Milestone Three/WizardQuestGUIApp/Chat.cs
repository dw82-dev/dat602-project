using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardQuestGUIApp
{
    public class Chat
    {
        private int _chatID;
        private string _username;
        private string _message;

        public int ChatID { get => _chatID; set => _chatID = value; }
        public string Username { get => _username; set => _username = value; }
        public string Message { get => _message; set => _message = value; }

        public override string ToString()
        {
            return string.Format("{0,-20} \t {1,-90}", _username, _message);
        }
    }
}
