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
        static string SecretWord_1 = "Confidence is the key";

        List<string> words = new List<string>();

        List<int> UsedPositions = new List<int>();

        public void ShuffleTheLettersOfTheWord()
        {
            foreach (var item in SecretWord_1.Split(' '))
            {
                words.Add(item);
            }
            Console.WriteLine("Guess the word to solve the mystery!\n");
            foreach (var item in words)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    int RandomPos = Shuffle.Next(0, item.Length);

                    do { RandomPos = Shuffle.Next(0, item.Length); }
                    while (UsedPositions.Contains(RandomPos));

                    Console.Write(item[RandomPos]);
                    UsedPositions.Add(RandomPos);
                }
                Console.Write("  ");
                UsedPositions.Clear();
            }
        }
        public void GuessAttempts()
        {
            Console.WriteLine();
            string guess = Console.ReadLine();
            if (guess == SecretWord_1)
            {
                Console.Clear();
                Console.WriteLine("Gratulálok megfejtetted a tekercs titkád, mostmár el tudod olvasni a tekercsben rejlő varázslatot!");
                Console.ReadKey();
            }else
            {
                words.Clear();
                Console.WriteLine("Nem ez a helyes válasz próbálkozz újra!");
                Console.ReadKey();
                Console.Clear();
                ShuffleTheLettersOfTheWord();
                GuessAttempts();
            }
        }
        
    }
}
