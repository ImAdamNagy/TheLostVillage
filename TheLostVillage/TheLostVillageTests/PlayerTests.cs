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
    public class PlayerTests
    {
        Player linda = new Player("Linda");
        Character bob = new Character("Bob");

        [TestMethod()]
        public void PlayerTest()
        {
            Assert.AreEqual(linda.Name, "Linda");
            Assert.AreEqual(bob.Name, "Bob");
            Assert.IsTrue(linda is Player);
            Assert.IsTrue(bob is Character);
        }
        [TestMethod()]
        public void DamageTest()
        {
            linda.TakeDamage(1);
            Assert.AreEqual(linda.Health, 4);
            Assert.IsTrue(linda.IsAlive);
            linda.TakeDamage(-1);
            Assert.AreNotEqual(linda.Health, 5);
            Assert.IsTrue(linda.IsAlive);
            linda.TakeDamage(5);
            Assert.AreEqual(linda.Health, 0);
            Assert.IsFalse(linda.IsAlive);
            linda.TakeDamage(5);
            Assert.AreEqual(linda.Health, 0);
            Assert.IsFalse(linda.IsAlive);
        }

        [TestMethod()]
        public void LevelUpTest()
        {
            bob.GainExperience(1);
            Assert.AreEqual(bob.Experience, 1);
            Assert.AreEqual(bob.Level, 1);
            bob.GainExperience(11);
            Assert.AreEqual(bob.Experience, 2);
            Assert.AreEqual(bob.Level, 2);
            Assert.AreEqual(bob.Strength, bob.Level);
            Assert.AreEqual(bob.Armor, (int)bob.Level / 2);
            Assert.AreEqual(bob.Health, 10);
        }
    }
}