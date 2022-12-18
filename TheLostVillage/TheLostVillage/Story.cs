using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace TheLostVillage
{
    static class Story
    {
        public static void WriteStory(string filename)
        {
            foreach (var item in File.ReadAllLines($"{filename}.txt"))
            {
                Console.WriteLine(item);
                Console.ReadKey();
            }
        }
    }
}
