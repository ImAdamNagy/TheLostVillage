using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheLostVillage
{
    class ActionHandler
    {
        Display display = new Display();
        public void CallDisplay()
        {
            display.Screen();
        }
        public void Introduction()
        {
            Story story = new Story();
            story.read();
            Console.WriteLine(story.start_date);
            story.witchwrite();
        }
    }
}
