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
        static string SecretWord_1 = "Have faith in yourself";

        List<string> words = new List<string>();

        List<int> UsedPositions = new List<int>();

        public void ShuffleTheLettersOfTheWord()
        {
            Display display = new Display();
            string task = "Solve the secret of the scroll to be able to kill the dragon";
            Console.WriteLine($"\n{String.Format("{0," + ((Console.WindowWidth / 2) + (task.Length / 2)) + "}", task)}");
            foreach (var item in SecretWord_1.Split(' '))
            {
                words.Add(item);
            }
            string secret = "";
            foreach (var item in words)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    int RandomPos = Shuffle.Next(0, item.Length);

                    do { RandomPos = Shuffle.Next(0, item.Length); }
                    while (UsedPositions.Contains(RandomPos));

                    secret += item[RandomPos];
                    UsedPositions.Add(RandomPos);
                }
                UsedPositions.Clear();
                secret += "   ";
            }
            Console.WriteLine("\n" + display.AlignCenter(secret));
            Console.WriteLine();
        }
        public void GuessAttempts()
        {
            Display display = new Display();
            Console.Write(display.Spacers(80 - (SecretWord_1.Length/2)));
            string guess = Console.ReadLine();
            if (guess == SecretWord_1)
            {
                Console.Clear();
                string win = "Congratulations you solved the secret of the scroll. You may go on and kill the dragon";
                Console.WriteLine($"\n{String.Format("{0," + ((Console.WindowWidth / 2) + (win.Length / 2)) + "}", win)}");
                Console.ReadKey();
            }
            else
            {
                string again = "Wrong answer, try again";
                words.Clear();
                Console.WriteLine($"\n{String.Format("{0," + ((Console.WindowWidth / 2) + (again.Length / 2)) + "}", again)}");
                Console.ReadKey();
                Console.Clear();
                ShuffleTheLettersOfTheWord();
                GuessAttempts();
            }
        }
        
    }
}
