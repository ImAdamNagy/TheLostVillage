using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLostVillage
{
    class Enemy : Character
    {
        public int Exp { get; private set; }
        public string Loot { get; private set; }
        public Enemy(string name, int exp, string loot) : base(name)
        {
            Name = name;
            Exp = exp;
            Loot = loot;
            MaxHealth = 5;
            Health = MaxHealth;
            Strength = 2;
            Armor = 1;

            Dialogue = "I'm alive and biting!";
        }
    }
}
