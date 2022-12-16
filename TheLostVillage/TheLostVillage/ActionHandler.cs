using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLostVillage
{
    class ActionHandler
    {
        Display display = new Display();
        public void CallDisplay()
        {
                display.Screen();
        }
        public void InventoryCall()
        {
            ConsoleKey inputkey;
            ConsoleKeyInfo keyinfo = Console.ReadKey(true);
            inputkey = keyinfo.Key;
            if (inputkey == ConsoleKey.V)
            {
                display.ShowInventory();
            }
        }
    }
}
