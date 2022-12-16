﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLostVillage
{
     public abstract class Character
     {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Armor { get; set; }
        public bool defending { get; set; }
        public int MaxHealth { get; set; }
        public bool IsAlive { get => Health > 0; }

        private int health;
        public int Health
        {
            get { return health; }
            set 
            { 
                if (value <= MaxHealth && value >= 0 ) {
                    health = value;
                } 
                else if (value > MaxHealth) {
                    health = MaxHealth;
                } 
                else {
                    health = 0;
                }
            }
        }

        public Character (string name)
        {
            Name = name;
            MaxHealth = 5;
            Health = MaxHealth;
            Strength = 2;
            Armor = 1;
        }

        private void TakeDamage(int damage)
        {
            int defense = defending ? Armor * 2 : Armor;
             Health -= damage - defense;
        }

        public void Attack(Character c)
        {
            c.TakeDamage(Strength);
        }
    }
}
