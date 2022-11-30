using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheLostVillage
{
    class Item
    {
        private string Name;
        private int Count;
        private bool Consumable;
        private int Value;


        public Item(string adtsor)
        {
            string[] seged = adtsor.Split(';');
            Name = seged[0];
            Count = int.Parse( seged[1]);
            Consumable = bool.Parse( seged[2]);
            Value =int.Parse( seged[3]);
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
