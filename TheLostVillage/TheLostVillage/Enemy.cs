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
        public string Loot { get; private set; }
        public Enemy(string name, int health, int strength, int armor, string loot) : base(name)
        {
            Name = name;
            Strength = strength;
            Loot = loot;
            MaxHealth = health;
            Health = MaxHealth;
            Armor = armor;
        }
    }
}
