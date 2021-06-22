using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardQuestGUIApp
{
    public class ActiveQuest
    {
        private int _questID;
        private string _questName;

        public int QuestID { get => _questID; set => _questID = value; }
        public string QuestName { get => _questName; set => _questName = value; }
        
    }
}
