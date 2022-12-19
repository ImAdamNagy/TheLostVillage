using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLostVillage
{
    public class Battle
    {
        public Player player { get; private set; }
        public Enemy enemy { get; private set; }
        public int currentTurn { get; private set; }
        public string[] commands { get; private set; }
        public bool Over
        {
            get
            {
                return !enemy.IsAlive || !player.IsAlive;
            }
        }
        public Battle(Player player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;
            currentTurn = 1;
            Console.WriteLine("You've been attacked by a(n) {0}!", enemy.Name);
            SetCommands();
        }
        public void SetCommands()
        {
            List<string> c = new List<string>();
            c.Add("Attack(A)");
            c.Add("Defend(D)");
            if (player.Potions.Count > 0)
            {
                c.Add($"Potion(P)({player.Potions.Count} left)");
            }
            if (enemy.Name == "Dragon")
                c.Add("Use_Scroll(U)");
            commands = c.ToArray();
        }
        public void Fight(Display display)
        {
            string[] savedcommands = display.AviableCommands;
            player.defending = false;
            enemy.defending = currentTurn % 3 == 0 ? true : false;
            display.LevelHandler.Commands = commands;
            display.Stats = player.stats;
            display.Screen(false);
            PlayerTurn();
            EnemyTurn();

            if (Over) {
                display.LevelHandler.Commands = savedcommands;
                Finish();

            } 
            else {
                ++currentTurn;
                SetCommands();
            }
        }
        private void PlayerTurn()
        { 
                Console.Write("What will you do?: ");
                switch (Console.ReadLine().ToUpper())
                {
                    case "A":
                        player.Attack(enemy);
                        Console.WriteLine("You attack the {0}! {0} has {1} health left.", enemy.Name, enemy.Health);
                        break;
                    case "D":
                        player.defending = true;
                        Console.WriteLine("You defend against {0}'s attacks.", enemy.Name);
                        break;
                    case "P":
                        if (player.Potions.Count <= 0)
                        {
                            Console.WriteLine("You don't have enough potions!");
                        }
                        else
                        {
                            player.UsePotion();
                            Console.WriteLine("You use a potion and heal up. You have {0} health left!", player.Health);
                        }
                        break;
                    case "U":
                        {
                            player.Strength = 9999;
                            Console.WriteLine("You have used the scroll, it gives you super strength!");
                        }
                        break;
                    default:
                        Console.WriteLine("There is no option like that!");
                        break;
                }
        }
        private void EnemyTurn()
        {
            if (!enemy.defending && enemy.IsAlive)
            {
                enemy.Attack(player);
                Console.WriteLine("{0} attacks you! You have {1} health left.", enemy.Name, player.Health);
                Console.WriteLine("Press a key for the next round...");
            }
            else
            {
                Console.WriteLine("{0} defended against your attack.", enemy.Name);
            }
        }
        public void Finish()
        {
            if (player.IsAlive)
            {
                Console.WriteLine("You won!");
                player.LevelUp();
                Console.WriteLine("You gained a level!");
                player.AddLoot(enemy.Loot);
                Console.WriteLine($"{enemy.Name} dropped an item. It's a {enemy.Loot.Name}! You pick it up.");
                Console.Write("Press any key to continue... ");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You lost to {0} and died.", enemy.Name);
                Console.WriteLine("Game Over");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
