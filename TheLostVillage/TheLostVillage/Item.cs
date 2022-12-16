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
        public string Name;
        public int Count;
        public bool Consumable;
        public int attack_damadge;
        public int Armor;
        private int Value;


        public Item(string adtsor)
        {
            string[] seged = adtsor.Split(';');
            Name = seged[0];
            Count = int.Parse( seged[1]);
            Consumable = bool.Parse( seged[2]);
            attack_damadge = int.Parse(seged[3]);
            Armor = int.Parse(seged[4]);
            Value =int.Parse( seged[5]);
        }
        //majd másik fáljba  kell a listafeltoltes() metódus
        //public void listafeltoltes()
        //{
        //    List<Item> items = new List<Item>();
        //    foreach (var item in File.ReadAllLines("items.txt"))
        //    {
        //        items.Add(new Item(item));
        //    }
        //}
    }
}
