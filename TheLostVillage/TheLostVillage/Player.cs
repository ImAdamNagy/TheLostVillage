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
            $"Armor: {Armor}",
            $"Dialogue: {Dialogue}"
            };
        }
        public int Level { get; set; }
        public int Experience { get; set; }
        public Player(string name) : base(name)
        {
            Name = name;
            Level = 1;
            Experience = 0;
            MaxHealth = 5;
            Health = MaxHealth;
            Strength = 2;
            Armor = 0;

            Dialogue = "I'm alive!";
        }

        public void GainExperience(int experience)
        {
            Experience += experience;
            while (Experience >= Level * 10)
            {
                LevelUp();
            }
        }

        public void LevelUp()
        {
            Experience -= Level * 10;
            ++Level;
            MaxHealth += 5;
            Health = MaxHealth;
            Strength += 2;
            ++Armor;
        }
    }
}
