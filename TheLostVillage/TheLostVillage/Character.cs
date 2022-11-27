using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLostVillage
{
    class Character
    {
        public string Name { get; private set; }
        private int maxhealth;
        private int health;

        public int Health
        {
            get { return health; }
            set 
            { 
                if (value <= maxhealth || value >= 0 ) {
                    health = value;
                } 
                else if (value > maxhealth) {
                    health = maxhealth;
                } 
                else {
                    health = 0;
                }
            }
        }

        public int Level { get; private set; }
        public string Dialogue { get; private set; }
        public int Strength { get; private set; }
        public int Armor { get; private set; }
        public bool IsAlive { get; private set; }

        public Character (string name)
        {
            Name = name;
            Level = 1;
            maxhealth = Level * 5;
            Health = maxhealth;
            IsAlive = true;
            Strength = Level;
            Armor = (int)(Level / 2);
            Dialogue = "I'm alive!";
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
            Health -= damage;
            if (Health == 0)
            {
                IsAlive = false;
            }
        }
    }
}
