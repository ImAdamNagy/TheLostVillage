using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheLostVillage
{
    class Minigame
    {
        Random Shuffle = new Random();

        static string SecretWord_1 = "Rejtély";

        string[] Letters = new string[100];

        List<int> UsedPositions = new List<int>();

        public void ShuffleTheLettersOfTheWord()
        {
            Console.WriteLine("Találja ki a titkos szót, hogy megfejtese a tekercs titkát!\n");

            for (int i = 0; i < SecretWord_1.Length; i++)
            {
                int RandomPos = Shuffle.Next(0, SecretWord_1.Length);

                do{RandomPos = Shuffle.Next(0, SecretWord_1.Length);} 
                while (UsedPositions.Contains(RandomPos));

                Console.Write(SecretWord_1[RandomPos] + " ");
                UsedPositions.Add(RandomPos);
            }
            Console.WriteLine("\n");
            UsedPositions.Clear();
            
        }
        public void GuessAttempts()
        {
            string guess = Console.ReadLine();
            if (guess == SecretWord_1)
            {
                Console.Clear();
                Console.WriteLine("Gratulálok megfejtetted a tekercs titkád, mostmár el tudod olvasni a tekercsben rejlő varázslatot!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Nem ez a helyes válasz próbálkozz újra!");
                Console.ReadKey();
                Console.Clear();
                ShuffleTheLettersOfTheWord();
                GuessAttempts();
            }
        }
        
    }
}
