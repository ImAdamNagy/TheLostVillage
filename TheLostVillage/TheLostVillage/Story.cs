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
<<<<<<< HEAD
        ArrayList start = new ArrayList();
=======
        string npc;
        string hero;
        public string start_date = "1526.August 24 Somewhere in Hungary near Mohács";
>>>>>>> ec65c45b9ccca7ca9cdb58a6c339d7c80bea3523
        ArrayList witch = new ArrayList();
        ArrayList paper = new ArrayList();
        ArrayList villager = new ArrayList();
        ArrayList mage = new ArrayList();
        ArrayList dragon = new ArrayList();
        ArrayList end = new ArrayList();
        public void startwrite()
        {
            for (int i = 0; i < start.Count; i++)
            {
                Console.WriteLine(start[i]);
                Console.ReadKey();
            }
        }
        public void witchwrite()
        {
            for (int i = 0; i < witch.Count; i++)
            {
                Console.WriteLine(witch[i]);
                Console.ReadKey();
            }
        }
        public void paperwrite()
        {
            for (int i = 0; i < paper.Count; i++)
            {
                Console.WriteLine(paper[i]);
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

        }
        
        public void magewrite()
        {
            for (int i = 0; i < mage.Count; i++)
            {
                Console.WriteLine(mage[i]);
                Console.ReadKey();
            }

        }
        
        public void dragonwrite()
        {
            for (int i = 0; i < dragon.Count; i++)
            {
                Console.WriteLine(dragon[i]);
                Console.ReadKey();
            }

        }
        public void endwrite()
        {
            for (int i = 0; i < end.Count; i++)
            {
                Console.WriteLine(dragon[i]);
                Console.ReadKey();
            }

        }
        public void read()
        {

            foreach (var item in File.ReadAllLines("start.txt"))
            {
                start.Add(item);
            }
            foreach (var item in File.ReadAllLines("witch.txt"))
            {
                witch.Add(item);
            }
            foreach (var item in File.ReadAllLines("paper.txt"))
            {
                paper.Add(item);
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
            foreach (var item in File.ReadAllLines("end.txt"))
            {

                end.Add(item);
            }
        }
    }
}
