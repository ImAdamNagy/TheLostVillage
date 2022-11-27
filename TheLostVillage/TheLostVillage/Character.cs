using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLostVillage
{
     public class Character
    {
        public string Name { get; private set; }
        private int maxhealth;
        private int health;
        public int Health
        {
            get { return health; }
            set 
            { 
                if (value <= maxhealth && value >= 0 ) {
                    health = value;
                } 
                else if (value > maxhealth) {
                    health = maxhealth;
                } 
                else {
                    health = 0;
                    IsAlive = false;
                }
            }
        }

        public int Level { get; private set; }
        public int Experience { get; private set; }
        public string Dialogue { get; private set; }
        public int Strength { get; private set; }
        public int Armor { get; private set; }
        public bool IsAlive { get; private set; }

        public Character (string name)
        {
            IsAlive = true;
            Name = name;
            Level = 1;
            AdjustToLevel();
            
            Dialogue = "I'm alive!";
        }

        public void AdjustToLevel()
        {
            maxhealth = Level * 5;
            Health = maxhealth;
            Strength = Level;
            Armor = (int)(Level / 2);
        }

        public int Attack()
        {
            return Strength;
        }

        public int Defend()
        {
            return Armor;
        }

        public void TakeDamage(int damage)
        {
            if (damage > 0)
            {
                Health -= damage;
            }
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
            Level++;
            AdjustToLevel();
        }
    }
}
