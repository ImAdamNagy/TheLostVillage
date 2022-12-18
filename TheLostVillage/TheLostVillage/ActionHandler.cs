using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheLostVillage
{
    public class ActionHandler
    {
        public List<LevelHandler> levels = new List<LevelHandler>();

        public ActionHandler()
        {
            foreach (var item in File.ReadAllLines("levels.txt"))
            {
               levels.Add(new LevelHandler(item));
            }
        }
    }
}
