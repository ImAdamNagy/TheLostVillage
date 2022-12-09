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

        public void Initialise()
        {
            player = new Player("Flora");
            rat = new Enemy("Rattling Rat", 1, "whiskers");
            eagle = new Enemy("Eager Eagle", 10, "feathers");
            dragon = new Enemy("Dangerous Dragon", 100, "peace");
        }

        [TestMethod()]
        public void InitialiseTests()
        {
            Initialise();
            Assert.AreEqual(player.Name, "Flora");
            Assert.AreEqual(dragon.Difficulty, 100);
            Assert.AreEqual(rat.Loot, "whiskers");
            Assert.AreEqual(eagle.Name, "Eager Eagle");
        }

        [TestMethod()]
        public void DamageTests()
        {
            Initialise();
            Assert.AreEqual(player.Name, "Flora");

            player.TakeDamage(rat.Strength - player.Armor);
            Assert.AreNotEqual(player.Health, player.MaxHealth);

            bool playersTurn = true;
            while (player.Health > 0 && rat.Health > 0)
            {
                if (playersTurn)
                {
                    Assert.AreEqual(player.Strength - rat.Armor, 2);
                    rat.TakeDamage(player.Strength - rat.Armor);
                }
                else
                {
                    Assert.AreEqual(rat.Strength - player.Armor, 1);
                    player.TakeDamage(rat.Strength - player.Armor);
                }
                playersTurn = !playersTurn;
            }
            Assert.AreEqual(rat.Health, 0);
            Assert.AreEqual(player.Health, 3);

            player.GainExperience(rat.Exp * 2);
            Assert.AreEqual(player.Health, 10);
            Assert.AreEqual(player.Level, 2);
            Assert.AreEqual(player.Experience, 0);

            player.GainExperience(100000);
            Assert.AreEqual(player.Health, 705);
            Assert.AreEqual(player.Level, 141);
            Assert.AreEqual(player.Experience, 1310);
        }
    }
}
