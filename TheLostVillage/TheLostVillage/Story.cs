using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace TheLostVillage
{
    class Story
    {
        string npc;
        string hero;
        string start_date = "1526.August 24 Somewhere in Hungary near Mohács";
        ArrayList witch = new ArrayList();
        ArrayList villager = new ArrayList();
        ArrayList mage = new ArrayList();
        ArrayList dragon = new ArrayList();
        public Story()
        {

        }

        public void witchwrite()
        {
            for (int i = 0; i < witch.Count; i++)
            {
                Console.WriteLine(witch[i]);
                Console.ReadKey();
            }
        }
        public void villagerwrite()
        {
            for (int i = 0; i < villager.Count; i++)
            {
                Console.WriteLine(villager[i]);
                Console.ReadKey();
            }

        }public void magewrite()
        {
            for (int i = 0; i < mage.Count; i++)
            {
                Console.WriteLine(mage[i]);
                Console.ReadKey();
            }

        }public void dragonwrite()
        {
            for (int i = 0; i < dragon.Count; i++)
            {
                Console.WriteLine(dragon[i]);
                Console.ReadKey();
            }

        }
        public void read()
        {
            
            foreach (var item in File.ReadAllLines("witch.txt"))
            {
                witch.Add(item);
            }
          
            foreach (var item in File.ReadAllLines("villager.txt"))
            {

                villager.Add(item);
            }
            
            foreach (var item in File.ReadAllLines("mage.txt"))
            {

                mage.Add(item);
            }
           
            foreach (var item in File.ReadAllLines("dragon.txt"))
            {

                dragon.Add(item);
            }
        }
    }
}
