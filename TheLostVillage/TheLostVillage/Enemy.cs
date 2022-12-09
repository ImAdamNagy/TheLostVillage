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
            $"Armor: {Armor}",
            $"Dialogue: {Dialogue}"
            };
        }
        public int Exp { get => Difficulty * 5; }
        public string Loot { get; private set; }
        public int Difficulty { get; private set; }
        public Enemy(string name, int difficulty, string loot) : base(name)
        {
            Name = name;
            Difficulty = difficulty;
            Loot = loot;
            MaxHealth = difficulty * 3;
            Health = MaxHealth;
            Strength = difficulty * 1;
            Armor = (int)(difficulty * 0.5);

            Dialogue = "I'm alive and biting!";
        }
    }
}
