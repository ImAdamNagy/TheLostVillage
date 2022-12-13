using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLostVillage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Display main = new Display();
            Player jatekos = new Player("Keldron");


            main.OwnedItems = jatekos.Inventory;
            main.Stats = jatekos.stats;

            main.Screen();

            Console.ReadKey();
        }
    }
}
