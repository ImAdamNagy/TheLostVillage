using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLostVillage
{
    public class Enemy : Character
    {

        public string[] stats
        {
            get => new string[] {
            $"Name: {Name}",
            $"Health: {Health}/{MaxHealth}",
            $"Strength: {Strength}",
            $"Armor: {Armor}"
            };
        }
        public Item Loot { get; private set; }
        public string ArtPath { get; private set; }
        public Enemy(string name, int health, int strength, int armor, string ArtPath) : base(name)
        {
            Name = name;
            Strength = strength;
            MaxHealth = health;
            Health = MaxHealth;
            Armor = armor;
            Loot = new Item("Monster talisman;1;false;0;0;1500");
        }
    }
}
