using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardQuestConsoleApp
{
    class User
    {
        public static User CurrentUser { get; set; }
        public string UserName;
        public int TotalScore;
    }
}
