using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheLostVillage
{
    class ActionHandler
    {
        static Item potion = new Item("potion;1;true;0;0;500");//ide vegyük fel az összes itemet amit használunk
        Enemy lavadog = new Enemy("Lava Dog", 10, 2, 2, potion, @"Art\Characters, monsters\Zombie.txt");//ide vegyük fel az összes enemyt
        Player player;

        Display display;
        public void CallDisplay()
        {
            Console.Write("What's your name? ");
            player = new Player(Console.ReadLine());
            display = new Display()
            {
                Stats = player.stats,
                OwnedItems = player.Inventory
            };
            Console.Clear();
            display.Screen();
        }
        public void Introduction()
        {
            Story story = new Story();
            story.read();
            Console.WriteLine(story.start_date);
            story.witchwrite();
            Fight(lavadog);
        }
        public void Fight(Enemy enemy)
        {
            Battle battle = new Battle(player, enemy);

            display = new Display()
            {
                Stats = player.stats,
                AviableCommands = battle.commands,
                OwnedItems = player.Inventory,
                ArtPath = enemy.ArtPath
            };

            do
            {
                Console.Clear();
                display.Screen();

                battle.Turn();
                Console.ReadKey();

                display = new Display()
                {
                    Stats = player.stats,
                    AviableCommands = battle.commands,
                    OwnedItems = player.Inventory,
                    ArtPath = enemy.ArtPath
                };
            } while (!battle.Over);
        }
    }
}
