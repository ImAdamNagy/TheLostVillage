﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Dictionary<string,Item> Inventory { get; set; } //ideiglenes
        public Player(string name) : base(name)
        {
            Name = name;
            Level = 1;
            MaxHealth = 15;
            Health = MaxHealth;
            Strength = 4;
            Armor = 1;
            Inventory = new Dictionary<string, Item>();
            Item potions = new Item("potion;3;true;0;0;500"); // ideiglenes
            Inventory.Add(potions.Name, potions);
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
            if (Inventory.ContainsKey("potion") && Inventory["potion"].Count > 0)
            {
                Health += 100;
                Inventory["potion"].Count--;
            }
        }
        public void AddLoot(Item loot)
        {
            if (Inventory.ContainsKey(loot.Name))
            {
                Inventory[loot.Name].Count++;
            }
            else
            {
                Inventory.Add(loot.Name, loot);
            }

            if (!loot.Consumable)
            {
                Strength += loot.attack_damadge;
                Armor += loot.Armor;
            }
        }
    }
}
