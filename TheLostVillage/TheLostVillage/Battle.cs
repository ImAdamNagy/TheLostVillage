using System;
using System.Collections.Generic;
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
        }
        public void Turn(string action)
        {
            player.defending = false;
            enemy.defending = currentTurn % 3 == 0 ? true : false;
            PlayerTurn(action);
            EnemyTurn();
            
            if (Over)
            {
                Finish();
            }
            else
            {
                ++currentTurn;
            }
        }
        public void PlayerTurn(string action)
        {
            switch (action)
            {
                case "A":
                    player.Attack(enemy);
                    break;
                case "D":
                    player.defending = true;
                    break;
                case "P":
                    player.UsePotion();
                    break;
            }
        }
        public void EnemyTurn()
        {
            if (!enemy.defending && enemy.IsAlive)
            {
                enemy.Attack(player);
            }
        }
        public void Finish()
        {
            if (player.IsAlive)
            {
                player.LevelUp();
                player.AddLoot(enemy.Loot);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Játék vége");
                Console.ReadKey();
                Environment.Exit(0);
            }

        }
    }
}
