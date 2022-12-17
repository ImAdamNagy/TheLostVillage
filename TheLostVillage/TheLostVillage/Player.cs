using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheLostVillage
{
    public class Player : Character
    {
        public string[] stats
        {
            get => new string[] {
            $"Name: {Name}",
            $"Level: {Level}",
            $"Health: {Health}/{MaxHealth}",
            $"Strength: {Strength}",
            $"Armor: {Armor}"
            };
        }
        public int Level { get; private set; }
        public int Experience { get; set; }
        public List<Item> Inventory { get; set; }
        public Player(string name) : base(name)
        {
            Name = name;
            Level = 1;
            MaxHealth = 15;
            Health = MaxHealth;
            Strength = 4;
            Armor = 1;
            #region Starter Inventory
            Inventory = new List<Item>();
            /*foreach (var item in File.ReadAllLines("Items.txt"))
            {
                Inventory.Add(new Item(item));
            }*/
            #endregion
            Item potions = new Item("potion;3;true;0;0;500"); // ideiglenes
            Inventory.Add(potions);
        }
            
        public void LevelUp()
        {
            ++Level;
            MaxHealth += 10;
            Health = MaxHealth;
            Strength += 2;
            ++Armor;
        }

        public void UsePotion()
        {
            if (Inventory.Exists(x => x.Name == "potion" && x.Count > 0))
            {
                Health += 100;
                Inventory.Where(x => x.Name == "potion").FirstOrDefault().Count++;
            }
        }
        public void AddLoot(Item loot)
        {
            if (Inventory.Exists(x => x.Name == loot.Name))
            {
                Inventory.Where(x => x.Name == loot.Name).FirstOrDefault().Count++;
            }
            else
            {
                Inventory.Add(loot);
            }

            if (!loot.Consumable)
            {
                Strength += loot.Attack_Damage;
                Armor += loot.Armor;
            }
        }
    }
}
