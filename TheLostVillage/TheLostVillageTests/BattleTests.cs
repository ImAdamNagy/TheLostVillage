using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheLostVillage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLostVillage.Tests
{
    [TestClass()]
    public class BattleTests
    {
        static Item potion = new Item("potion;1;true;0;0;500");
        Player flora = new Player("Flora");
        Enemy lavadog = new Enemy("Lava Dog", 10, 2, 2, potion);

        [TestMethod()]
        public void BattleInitialiseTest()
        {
            Battle firstbattle = new Battle(flora, lavadog);
            Assert.AreEqual(firstbattle.player, flora);
            Assert.AreEqual(firstbattle.enemy, lavadog);
        }
        [TestMethod()]
        public void BattlePlayerTurnTest()
        {
            Battle firstbattle = new Battle(flora, lavadog);
            firstbattle.Turn("A");
            Assert.AreNotEqual(lavadog.MaxHealth, lavadog.Health);
            Assert.AreEqual(firstbattle.currentTurn, 2);
            firstbattle.Turn("D");
            firstbattle.Turn("P");
            Assert.AreEqual(flora.Potions.Count, 2);
            Assert.AreEqual(flora.Health, flora.MaxHealth);
            Assert.IsTrue(lavadog.defending);
            for (int i = 0; i < 5; i++)
            {
                firstbattle.Turn("A");
            }
            Assert.AreEqual(lavadog.Health, 0);
            Assert.IsTrue(firstbattle.Over);
            Assert.IsFalse(lavadog.IsAlive);
            Assert.IsTrue(flora.IsAlive);
            Assert.AreEqual(flora.Level, 2);
            Assert.AreEqual(flora.Inventory.Where(x => x.Name == potion.Name).FirstOrDefault().Count, 3);
            Assert.AreEqual(firstbattle.player, flora);
            Assert.AreEqual(flora.Level, 2);
        }
    }
}