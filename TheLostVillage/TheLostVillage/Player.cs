using System;
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
        public int Level { get; set; }
        public Player(string name) : base(name)
        {
            Name = name;
            Level = 1;
            MaxHealth = 5;
            Health = MaxHealth;
            Strength = 2;
            Armor = 0;
        }

        public void LevelUp()
        {
            ++Level;
            MaxHealth += 5;
            Health = MaxHealth;
            Strength += 2;
            ++Armor;
        }
    }
}
