﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardQuestConsoleApp
{
    class Inventory
    {
        public static Inventory CurrentInventory { get; set; }
        public string Item;
        public int Quantity;
    }
}
