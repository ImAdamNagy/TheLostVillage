using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLostVillage
{
    internal class LevelHandler
    {
        public string MapUrl;
        public string[] Commands;
        public string DialogeUrl;
        public Story story;
        public Enemy Enemy;

        public LevelHandler()
        {
            MapUrl = @"Buildings\Hut";
            Commands = new string[] { "Defense", "Attack", "Run", "Inventory"};
        }
    }
}
