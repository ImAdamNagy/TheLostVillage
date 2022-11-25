using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLostVillage
{
    internal class Display
    {
        private const int SCREENWIDTH = 160;
        private const int SCREENHEIGHT = 45;
        private List<string> FinalScreen = new List<string>();
        private List<string> CommandBar = new List<string>();
        private List<string> StatBar = new List<string>();
        private List<string> GameScreen = new List<string>();

        public string[] AviableCommands { get; set; }
        public Display()
        {
            Console.SetWindowSize(SCREENWIDTH+1, SCREENHEIGHT);
        }

        #region FormatHelpers
        private string Separator()
        {
            string separator = "";
            for (int i = 0; i < SCREENWIDTH; i++)
            {
                separator += "-";
            }
            return separator;
        }
        private string Spacers(int amount)
        {
            string spacer = "";
            for (int i = 0; i < amount; i++)
            {
                spacer += " ";
            }
            return spacer;
        }
        private string CreateBorder(string content)
        {
            string line = content;
            line = line.Insert(0, "|");
            line = string.Concat(line,'|');
            return line;
        }
        #endregion
        private void CreateCommandBar()
        {            
            CommandBar.Add(Separator());
            #region Center Align
            string content = string.Join(" ", AviableCommands);
            int length = content.Length;
            int freespace = SCREENWIDTH - 2 - length;
            if (freespace%2==0)
            {
                content = Spacers(freespace / 2) + content + Spacers(freespace / 2);
            }
            else
            {
                freespace++;
                content = Spacers(freespace / 2) + content + Spacers(freespace / 2 - 1);
            }
            #endregion
            CommandBar.Add(CreateBorder(content));
            CommandBar.Add(Separator());     
        }

        private void Assembly()
        {
            CreateCommandBar();

            CommandBar.ForEach(x => FinalScreen.Add(x));
        }

        public void Screen()
        {
            Assembly();
            FinalScreen.ForEach(x => Console.WriteLine(x));
        }
        
    }
}
