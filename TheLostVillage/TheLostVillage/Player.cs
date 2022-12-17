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
        public Item Potions { get; private set; }
        public Player(string name) : base(name)
        {
            Name = name;
            Level = 1;
            MaxHealth = 15;
            Health = MaxHealth;
            Strength = 4;
            Armor = 1;
            Inventory = new List<Item>();
            
            Potions = new Item("potion;3;true;0;0;500"); // ideiglenes
            Inventory.Add(Potions);
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
            if (Potions.Count > 0)
            {
                Health += 100;
                Potions.Count--;
            }
        }
        public void AddLoot(Item loot)
        {
            if (Inventory.Exists(x => x.Name == loot.Name))
            {
                Inventory.Find(x => x.Name == loot.Name).Count++;
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
