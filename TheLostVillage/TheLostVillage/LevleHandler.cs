using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLostVillage
{
    public class LevelHandler
    {
        public string MapUrl;
        public string[] Commands;
        public string DialogeUrl;
        public Enemy Enemy;
        public Item Item;

        public LevelHandler(string map)
        {
            string[] array = map.Split(';');
            MapUrl = array[0];
            Commands = array[1].Split(',');
            DialogeUrl = array[2];
            string[] sv;
            if (array[3] != "none")
            {
              sv = array[3].Split(',');
              Enemy = new Enemy(sv[0], int.Parse(sv[1]), int.Parse(sv[2]), int.Parse(sv[3]), sv[4]);
            }
            
        }
    }
}
