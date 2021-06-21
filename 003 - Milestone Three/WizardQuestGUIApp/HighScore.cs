using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardQuestGUIApp
{
    public class HighScore
    {
        private string _username;
        private int _totalScore;

        public string Username { get => _username; set => _username = value; }
        public int TotalScore { get => _totalScore; set => _totalScore = value; }
    }
}
