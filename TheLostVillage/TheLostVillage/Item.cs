using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheLostVillage
{
    public class Item
    {
        private string name;
        private int count;
        private bool consumable;
        private int attack_damage;
        private int armor;
        private int value;

        public string Name { get => name; set => name = value; }
        public int Count { get=>count; set => count = value; }
        public bool Consumable { get => consumable; set => consumable = value; }
        public int Attack_Damage { get => attack_damage; set => attack_damage = value; }
        public int Armor { get => armor; set => armor = value; }
        public int Value { get => value ; set => this.value = value; }

        public Item(string adtsor)
        {
            string[] seged = adtsor.Split(';');
            Name = seged[0];
            Count = int.Parse( seged[1]);
            Consumable = bool.Parse( seged[2]);
            attack_damage = int.Parse(seged[3]);
            Armor = int.Parse(seged[4]);
            Value =int.Parse( seged[5]);
        }
        
    }
}
