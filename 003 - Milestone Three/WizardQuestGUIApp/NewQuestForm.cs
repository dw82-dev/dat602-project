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
    public partial class NewQuestForm : Form
    {
        private string _newQuestName;

        public string NewQuestName
        {
            get { return _newQuestName; }
            private set { _newQuestName = value; }
        }
        public NewQuestForm()
        {
            InitializeComponent();
            questNameText.MaxLength = 50;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (questNameText.Text != "")
            {
                NewQuestName = questNameText.Text;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please enter a Quest name, please try again.", "Invalid Quest Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
