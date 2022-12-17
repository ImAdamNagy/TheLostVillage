using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TheLostVillage;

namespace TheLostVillageTests
{
    [TestClass()]
    public class PlayerEnemyTests
    {
        Player player;
        Enemy rat;
        Enemy eagle;
        Enemy dragon;
        Item potion;

        public void Initialise()
        {
            potion = new Item("potion;1;true;0;0;500");
            player = new Player("Flora");
            rat = new Enemy("Rattling Rat",10,2,0, potion);
            eagle = new Enemy("Eager Eagle",25,5, 3, potion);
            dragon = new Enemy("Dangerous Dragon", 300,30,10, potion);
        }

        [TestMethod()]
        public void InitialiseTests()
        {
            Initialise();
            Assert.AreEqual(player.Name, "Flora");
            Assert.AreEqual(dragon.Health, 300);
            Assert.AreEqual(dragon.Strength, 30);
            Assert.AreEqual(dragon.Armor, 10);
            Assert.AreEqual(rat.Loot, potion);
            Assert.AreEqual(eagle.Name, "Eager Eagle");
        }

        [TestMethod()]
        public void DamageTests()
        {
            Initialise();
            Assert.AreEqual(player.Name, "Flora");

            rat.Attack(player);
            Assert.AreNotEqual(player.Health, player.MaxHealth);

            bool playersTurn = true;
            while (player.Health > 0 && rat.Health > 0)
            {
                if (playersTurn)
                {
                    player.Attack(rat);
                }
                else
                {
                    rat.Attack(player);
                }
                playersTurn = !playersTurn;
            }
            Assert.AreEqual(rat.Health, 0);
            Assert.AreEqual(player.Health, 12);
            Assert.IsTrue(player.IsAlive);

            if (player.IsAlive)
            {
                player.LevelUp();
                Assert.AreEqual(player.Health, 25);
                Assert.AreEqual(player.Level, 2);
            }
        }
        [TestMethod()]
        public void PotionTests()
        {
            Player anna = new Player("Anna");
            Item poti = new Item("poti;2;true;0;0;500");
            anna.AddLoot(poti);
            Assert.AreEqual(poti, anna.Inventory.Find(x => x == poti));
            poti.Count--;
            Assert.AreEqual(poti.Count, anna.Inventory.Find(x => x.Name == "poti").Count);
            poti.Count--;
            Assert.AreEqual(poti.Count, anna.Inventory.Find(x => x.Name == "poti").Count);
        }
    }
}
