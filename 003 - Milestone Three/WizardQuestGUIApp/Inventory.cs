using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardQuestGUIApp
{
    public class Inventory
    {
        private string _item;
        private int _quantity;

        public string Item { get => _item; set => _item = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
    }
}
